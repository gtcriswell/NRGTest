using NRGClasses;
using System;

namespace NRGTest.UserControls
{
    public partial class _RegistrationList : System.Web.UI.UserControl
    {
        public static string UID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        public void BindData()
        {
            Registrations registrations = new Registrations(Context);
            gvRegistrations.DataSource = registrations.LoadAll();
            gvRegistrations.DataBind();

        }
    }
}