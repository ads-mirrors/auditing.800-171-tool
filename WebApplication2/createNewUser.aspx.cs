using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class createNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            TextBox txtuserName = (TextBox)FindControl("txtUserName");
            TextBox txtpassword = (TextBox)FindControl("txtPassword");
            string userName = txtuserName.Text;
            string password = txtpassword.Text;
            try
            {
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("Data/users.mdb"));
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO Users ([userID],[Password]) VALUES (@userName,@password)", conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@password", password);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "idTaken();", true);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();

            }
            conn = null;
            reader = null;
            txtuserName = (TextBox)FindControl("txtUserName");
            txtpassword = (TextBox)FindControl("txtPassword");
            userName = txtuserName.Text;
            password = txtpassword.Text;
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
            }

            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }

        }
    }
}