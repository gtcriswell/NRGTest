using NRGBusiness;
using NRGClasses;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NRGTest
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";

                if (Request.QueryString["action"] != null)
                {
                    if (Request.QueryString["action"] == "edit")
                    {
                        if (Request.QueryString["uid"] != null)
                        {
                            string UID = Request.QueryString["uid"].ToString();
                            {
                                LoadData(UID);
                            }
                        }
                    }
                }

            }
        }



        protected void btnSaveRegistration_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                Registrations registrations = new Registrations(Context);
                registrations = registrations.Load(Utility.ConvInt(hfUID.Value));
                registrations.UID = Utility.ConvInt(hfUID.Value);

                registrations.Address1 = txtAdd1.Text;
                registrations.Address2 = txtAdd2.Text;
                registrations.City = txtCity.Text;
                registrations.DateOfBirth = Utility.ConvDateTimeNulll(txtBirthDate.Text);
                registrations.Email = txtEmail.Text.ToLower();
                registrations.FirstName = txtFirstName.Text;
                registrations.LastName = txtLastName.Text;
                registrations.SSN = txtSSN.Text;
                registrations.StateCode = ddlState.SelectedValue;
                registrations.Zip = txtZip.Text;
                registrations.UID = registrations.Save(Context);

                //clear form
                LoadData("0");

                lblMessage.Text= registrations.FullName + " Updated";
            }
            else
            {

                txtSSN.Attributes.Add("value", txtSSN.Text);
            }
        }


        #region private methods

        private void LoadData(string UID)
        {
            Registrations registrations = new Registrations(Context).Load(Utility.ConvInt(UID));
            txtAdd1.Text = registrations.Address1;
            txtAdd2.Text = registrations.Address2;
            txtCity.Text = registrations.City;
            txtBirthDate.Text = registrations.DateOfBirthFormatted;
            txtEmail.Text = registrations.Email;
            txtFirstName.Text = registrations.FirstName;
            txtLastName.Text = registrations.LastName;
            txtSSN.Attributes.Add("value", registrations.SSN);
            ddlState.SelectedValue = registrations.StateCode;
            txtZip.Text = registrations.Zip;
            hfUID.Value = registrations.UID.ToString();
        }

        #endregion


        #region web method

        private static List<Registrations> BindFilter(string filter)
        {
            List<Registrations> registrations = new Registrations(HttpContext.Current).LoadAll();
            List<Registrations> _filter = new List<Registrations>();

            filter = Utility.CleanAlphaNumeric(filter);

            if (!string.IsNullOrEmpty(filter))
            {
                foreach (var x in registrations)
                {
                    if (Utility.CleanAlphaNumeric(x.FirstName).ToLower().Contains(filter.ToLower())
                        || Utility.CleanAlphaNumeric(x.LastName).ToLower().Contains(filter.ToLower())
                            || Utility.CleanAlphaNumeric(x.Email).ToLower().Contains(filter.ToLower()))
                    {
                        _filter.Add(x);
                    }

                }
            }
            else
            {
                _filter = registrations;
            }

            return _filter;

        }


        [WebMethod]
        public static string LoadUserControl(string filter)
        {
            var filtered = BindFilter(filter);

            string table = string.Empty;
            string header = "<tr><td>Name</td><td>Email</td><td>City</td><td>State</td></tr>";
            foreach (var c in filtered)
            {
                table = table + "<tr>" +
                    "<td>" + c.FullName + "</td><td>" + c.Email + "</td>" +
                     //"<td><a href=register.aspx?action=edit&uid=" + c.UID + ">edit</a></td>" +
                     "<td>" + c.City + "</td><td>" + c.StateCode + "</td>" +
                    "</tr>";
            }

            table = "<table class='table'>" + header+ table + "</table>";

            return table;

        }

        #endregion

        #region custom validators
        protected void cv_zip_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (!Utility.IsValidZip(txtZip.Text))
            {
                args.IsValid = false;
            }

        }

        protected void cv_email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (!Utility.IsValidEmail(txtEmail.Text))
            {
                args.IsValid = false;
            }
        }


        protected void cv_ssn_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (!Utility.IsValidSSN(txtSSN.Text))
            {
                args.IsValid = false;
            }
        }


        protected void cv_state_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (string.IsNullOrEmpty(ddlState.SelectedValue))
            {
                args.IsValid = false;
            }
        }

        protected void cv_birthdate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (!Utility.IsDate(txtBirthDate.Text))
            {
                args.IsValid = false;
            }
        }
        #endregion

    }
}