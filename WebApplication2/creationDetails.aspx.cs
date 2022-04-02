using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class creationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createPrint(object sender, EventArgs e)
        {
            String nameofSystem = systemName.Text.ToString();
            String companyNameSt = companyName.Text.ToString();
            String userName = yourName.Text.ToString();
            Session["SystemNameReport"] = nameofSystem;
            Session["CompanyNameReport"] = companyNameSt;
            Session["userNameReport"] = userName;
            if (nameofSystem.Equals(null) || companyNameSt.Equals(null) || userName.Equals(null))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);
            }
            else {
                Response.Redirect("printControls.aspx");
            }

        }
    }
}