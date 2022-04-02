using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication2
{
    public partial class newSystem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //Must press button twice to ensue the person wants the system created

        private void addSystem(String name, String company)
        {
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            try
            {
                if (Default.userID.Equals("Not Logged In"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "failAlert();", true);
                }
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("Data/systems.mdb"));
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("INSERT INTO ListOfSystems ([Company],[System_Name],[userID]) VALUES (@companyName,@systemName,@userID)", conn);
                cmd.Parameters.AddWithValue("@companyName", company);
                cmd.Parameters.AddWithValue("@systemName", name);
                cmd.Parameters.AddWithValue("@userID", Default.userID);

                if (Default.userID.Equals("Not Logged In"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "failAlert();", true);
                }
                else {
                    reader = cmd.ExecuteReader();
                }
                
            }
            catch (Exception e)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "idTaken();", true);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }
            try {

                if (Default.userID.Equals("Not Logged In"))
                {

                }
                else {
                    File.Copy(Server.MapPath("~") + @"Data\171.mdb", Server.MapPath("~") + @"Data\" + name + ".mdb");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "successalert();", true);
                }
            }
            catch (Exception cop)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "idTaken();", true);
            }
        }
    
        protected void runAlert()
        {
            ClientScript.RegisterStartupScript(this.GetType(), "hwa", "successalert();window.location ='Default.aspx';", true);
        }

        protected void addSystem(object sender, EventArgs e)
        {
            String nameofSystem = systemName.Text.ToString();
            String companyNameSt = companyName.Text.ToString();
            addSystem(nameofSystem, companyNameSt);
           
        }




    }
}