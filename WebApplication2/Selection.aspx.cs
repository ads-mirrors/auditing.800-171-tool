using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace WebApplication2
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        String systemName;
        String controlStatus = "Other than satisfied";
        MyCustomString a = new MyCustomString("Cheese");
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReadRecords();
            }

        }


        private void ReadRecords()
        {
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            OleDbDataAdapter a = null;
            DataSet ds = null;
            try
            {
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("Data/" + (String)Session["SystemName"] + ".mdb"));
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand("Select * FROM 171", conn);
                a = new OleDbDataAdapter(cmd);

                ds = new DataSet();
                a.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.AllowPaging = true;
                    GridView1.DataBind();
                }

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
        }
        [WebMethod]
        public static String getXMLFile(String testString)
        {
            var requestUrl = "~/Data/testXML.xml";
            var absoluteURL = GetAbsoluteUrl(requestUrl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(absoluteURL);


            string xml = null;
            using (WebResponse response = request.GetResponse())
            {
                using (var xmlStream = new StreamReader(response.GetResponseStream()))
                {
                    xml = xmlStream.ReadToEnd();
                }
            }
            System.Diagnostics.Debug.WriteLine("Example:" + xml.ToString());
            return xml.ToString();
        }
        [System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
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

        protected void GridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPopup")
            {
                LinkButton btndetails = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                lblID.Text = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();

                // DataRow dr = dt.Select("CustomerID=" + GridViewData.DataKeys[gvrow.RowIndex].Value.ToString())[0];
                txtControlNumber.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
                txtResponse.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
                txtConfidence.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                rbtLstRating.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
                txtPOAMs.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
                Popup(true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rbtLstRating.SelectedItem != null)
            {
                controlStatus = rbtLstRating.SelectedItem.Text;
            }

            string sql = "UPDATE 171 SET Response=\"" + txtResponse.Text + "\", Confidence=\"" + txtConfidence.Text + "\", POAM=\"" + txtPOAMs.Text + "\", Status=\"" + controlStatus + "\"" + " WHERE PrimaryID=" + lblID.Text;
            System.Diagnostics.Debug.WriteLine(sql);
            OleDbConnection conn = null;
            conn = new OleDbConnection(
               "Provider=Microsoft.Jet.OLEDB.4.0; " +
               "Data Source=" + Server.MapPath("Data/" + (String)Session["SystemName"] + ".mdb"));
            conn.Open();
            OleDbCommand cmd =
               new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ReadRecords();
            Popup(false);
        }
        //To show message after performing operations
        void Popup(bool isDisplay)
        {
            StringBuilder builder = new StringBuilder();
            if (isDisplay)
            {
                builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button click 1 detected");
            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            String controlNumber = HttpUtility.HtmlDecode(gvr.Cells[0].Text);

            if (controlNumber != null)
            {
                // In future, need to link to correct system and create a folder for each one
                System.Diagnostics.Debug.WriteLine("Found it:" + controlNumber);
                Session["ControlNumber"] = controlNumber;
                Response.Redirect("WebForm2.aspx");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button click 2 detected");
            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            String controlNumber = HttpUtility.HtmlDecode(gvr.Cells[0].Text);
            if (controlNumber != null)
            {
                System.Diagnostics.Debug.WriteLine("Found it:" + controlNumber);
                String pathToMp3 = GetAbsoluteUrl("~/Recordings/test.mp3");
                ClientScript.RegisterStartupScript(this.GetType(), "hwa", "playSound('" + pathToMp3 + "');", true);
            }

        }

        protected void goHome(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }

        protected void getGuidance(object sender, EventArgs e)
        {

            try {
                OleDbConnection conn = null;
                OleDbDataReader reader = null;
                OleDbDataAdapter a = null;
                Button btn = (Button)sender;
                //Get the row that contains this button
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                String controlNumber = HttpUtility.HtmlDecode(gvr.Cells[0].Text);
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("Data/" + (String)Session["SystemName"] + ".mdb"));
                conn.Open();
                OleDbCommand cmd =
                    new OleDbCommand("Select Guidance FROM 171 Where Number = @Title", conn);
                cmd.Parameters.AddWithValue("@Title", controlNumber);
                String controlDescr = System.Convert.ToString(cmd.ExecuteScalar());
                System.Diagnostics.Debug.WriteLine(controlDescr);
                Session["guidance"] = controlDescr;
                Session["controlNumber"] = controlNumber;
                if (controlNumber != null)
                {
                    Response.Redirect("Guidance.aspx");
                }
            }

            catch(Exception ex)
              {
                
              }

            }



        protected String SelectCheckBox_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                GridViewRow row = (GridViewRow)chk.NamingContainer;
                System.Diagnostics.Debug.WriteLine("This works");
                return "Satisfied";
            }

            return "Other than Satisfied";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Popup(false);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ReadRecords();
        }

        protected void allSystems(object sender, EventArgs e)
        {
            Response.Redirect("allSystems.aspx");
        }

        protected void newSystem(object sender, EventArgs e)
        {
            Response.Redirect("newSystem.aspx");
        }

        protected void generateSSP(object sender, EventArgs e)
        {
            Response.Redirect("creationDetails.aspx");

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }



        public class MyCustomString
        {
            public bool IsMutable { get; set; }

            private string _myString;
            public string MyString
            {
                get
                {
                    return _myString;
                }
                set
                {
                    if (IsMutable)
                    {
                        _myString = value;
                    }
                }
            }

            public MyCustomString(string val)
            {
                MyString = val;
                IsMutable = true;
            }
        }


    }
}
