using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class allSystems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReadRecords();
                Chart1.Width = new System.Web.UI.WebControls.Unit(800, System.Web.UI.WebControls.UnitType.Pixel);
                Chart1.Height = new System.Web.UI.WebControls.Unit(800, System.Web.UI.WebControls.UnitType.Pixel);
                if (Default.userID.Equals("Not Logged In"))
                {
                    Chart1.Visible = false;
                }
            }

            Chart1.Width = new System.Web.UI.WebControls.Unit(800, System.Web.UI.WebControls.UnitType.Pixel);
            Chart1.Height = new System.Web.UI.WebControls.Unit(800, System.Web.UI.WebControls.UnitType.Pixel);
            if (Default.userID.Equals("Not Logged In"))
            {
                Chart1.Visible = false;
            }
        }

        private void ReadRecords()
        {
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            try
            {
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("Data/systems.mdb"));
                conn.Open();
                System.Diagnostics.Debug.WriteLine("Value of user id is:" + Default.userID);
                OleDbCommand cmd =
                    new OleDbCommand("Select * FROM ListOfSystems Where userID=@Title", conn);
                cmd.Parameters.AddWithValue("@Title", Default.userID);
                reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
            //        catch (Exception e)
            //        {
            //            Response.Write(e.Message);
            //            Response.End();
            //        }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }


            String[] nameOfSystems = new String[GridView1.Rows.Count];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label Lb = (Label)GridView1.Rows[i].Cells[2].FindControl("txtSystemName");
                nameOfSystems[i] = Lb.Text;
                System.Diagnostics.Debug.WriteLine("System added and its name is: " + Lb.Text);
            }

            for (int k = 0; k < nameOfSystems.Length; k++)
            {
                System.Diagnostics.Debug.WriteLine(nameOfSystems[k]);
            }

            int notSatisfied = 0;
            int satisfied = 0;

            for (int j = 0; j < nameOfSystems.Length; j++)
            {
                conn = new OleDbConnection(
                        "Provider=Microsoft.Jet.OLEDB.4.0; " +
                        "Data Source=" + Server.MapPath("Data/" + nameOfSystems[j] + ".mdb"));
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied'", conn);
                int countAdd = System.Convert.ToInt32(cmd.ExecuteScalar());
                satisfied = satisfied + countAdd;
            }

            System.Diagnostics.Debug.WriteLine(satisfied);
            string[] xValues = { "Satisfied", "Other than satisfied" };
            int countSystems = nameOfSystems.Length;
            notSatisfied = 109 * countSystems;
            notSatisfied = notSatisfied - satisfied;
            int[] yValues = { satisfied, notSatisfied };
            Chart1.Series["Testing"].Points.DataBindXY(xValues, yValues);

        }


        public static string GetAbsoluteUrl(string relativeUrl)
        {

            if (String.IsNullOrEmpty(relativeUrl))
                return String.Empty;
            if (relativeUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || relativeUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                return relativeUrl;
            if (HttpContext.Current == null)
                return relativeUrl;
            HttpContext context = HttpContext.Current;
            if (relativeUrl.StartsWith("/"))
            {
                relativeUrl = relativeUrl.Insert(0, "~");
            }
            //GET RELATIVE PATH
            Page page = context.Handler as Page;
            if (page != null)
            {
                //USE PAGE IN CASE RELATIVE TO USER’S CURRENT LOCATION IS NEEDED
                relativeUrl = page.ResolveUrl(relativeUrl);
            }
            else //OTHERWISE ASSUME WE WANT ROOT PATH
            {
                //PREPARE TO USE IN VIRTUAL PATH UTILITY
                if (!relativeUrl.StartsWith("~/"))
                {
                    relativeUrl = relativeUrl.Insert(0, "~/");
                }
                relativeUrl = VirtualPathUtility.ToAbsolute(relativeUrl);
            }
            var url = context.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;
            //BUILD AND RETURN ABSOLUTE URL
            String result = (url.Scheme + "://" + url.Host + port + relativeUrl);
            return result;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowNumber = gvr.RowIndex;
            Label lb = (Label)gvr.FindControl("txtSystemName");
            // check to make sure it was found
            if (lb != null)
            {
                // In future, need to link to correct recording using the pullled number. 
                String systemName = lb.Text;
                System.Diagnostics.Debug.WriteLine("Found it:" + systemName);
                Session["SystemName"] = systemName;
                Response.Redirect("Selection.aspx");

            }
        }

        protected void visualSystem(Object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowNumber = gvr.RowIndex;
            Label lb = (Label)gvr.FindControl("txtSystemName");
            // check to make sure it was found
            if (lb != null)
            {
                // In future, need to link to correct recording using the pullled number. 
                String systemName = lb.Text;
                System.Diagnostics.Debug.WriteLine("Found it:" + systemName);
                Session["SystemName"] = systemName;
                Response.Redirect("visualizationSystem.aspx");
            }
        }
    }
}
