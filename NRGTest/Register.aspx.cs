using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NRGBusiness;
using NRGClasses;

namespace NRGTest
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData("3");
        }



        protected void btnSaveRegistration_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                Registrations registrations = new Registrations();
                registrations.Load(Utility.ConvInt(hfUID.Value));
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
                registrations.UID = registrations.Save();

            }
            else
            {

                txtSSN.Attributes.Add("value", txtSSN.Text);
            }
        }

        #region private methods

        private void LoadData(string UID)
        {
            Registrations registrations = new Registrations().Load(Utility.ConvInt(UID));
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