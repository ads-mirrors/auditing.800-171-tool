using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void login(object sender, EventArgs e)
        { 
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            TextBox txtuserName = (TextBox) FindControl("txtUserName");
            TextBox txtpassword = (TextBox) FindControl("txtPassword");
            string userName = txtuserName.Text;
            string password = txtpassword.Text;
            try
            {
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("Data/users.mdb"));
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand("Select Password FROM Users Where userID=@Title", conn);
                cmd.Parameters.AddWithValue("@Title", userName);
                string str = Convert.ToString(cmd.ExecuteScalar());
                    if (str.Equals(password))
                {
                    Default.userID = userName;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "successalert();", true);
                }

                    else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "failAlert();", true);
                }
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }
        }
    }
}