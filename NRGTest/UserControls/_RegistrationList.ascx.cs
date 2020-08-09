using NRGClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            Registrations registrations = new Registrations(this.Context);
            gvRegistrations.DataSource = registrations.LoadAll();
            gvRegistrations.DataBind();

        }
    }
}