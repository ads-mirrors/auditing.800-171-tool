using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        public static string userID = "Not Logged In";
        protected void Page_Load(object sender, EventArgs e)
        {
            ChangeLabelText();

        }

        protected void allSystems(object sender, EventArgs e)
        {
            Response.Redirect("allSystems.aspx");
        }

        protected void newSystem(object sender, EventArgs e)
        {
            Response.Redirect("newSystem.aspx");
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void createNew(object sender, EventArgs e)
        {
            Response.Redirect("createNewUser.aspx");
        }


        protected void ChangeLabelText()
        {
            Label2.Text = "You are currently logged in as: " + userID;
        }
    }
}