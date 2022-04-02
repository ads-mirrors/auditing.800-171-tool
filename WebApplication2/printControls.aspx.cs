using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class printControls : System.Web.UI.Page
    {
        String systemName;
        String controlStatus = "Less than satisfied";
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

            int accessControlSat = 0;
            int awareTrainingSat = 0;
            int auditSat = 0;
            int configurationManSat = 0;
            int identifationSat = 0;
            int incidentSat = 0;
            int maintenSat = 0;
            int mediaProtection = 0;
            int personnelSat = 0;
            int physicalSat = 0;
            int riskAssesSat = 0;
            int securityAssessSat = 0;
            int systemComm = 0;
            int systemInform = 0;

            int accessControlUSat = 0;
            int awareTrainingUSat = 0;
            int auditUSat = 0;
            int configurationManUSat = 0;
            int identifationUSat = 0;
            int incidentUSat = 0;
            int maintenUSat = 0;
            int mediaProtectionU = 0;
            int personnelUSat = 0;
            int physicalUSat = 0;
            int riskAssesUSat = 0;
            int securityAssessUSat = 0;
            int systemCommU = 0;
            int systemInformU = 0;

            try
            {
                conn = new OleDbConnection(
                        "Provider=Microsoft.Jet.OLEDB.4.0; " +
                        "Data Source=" + Server.MapPath("Data/" + (String)Session["SystemName"] + ".mdb"));
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'ACCESS CONTROL'", conn);
                accessControlSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                    new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'AWARENESS AND TRAINING'", conn);
                awareTrainingSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                    new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'AUDIT AND ACCOUNTABILITY'", conn);
                auditSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                    new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'CONFIGURATION MANAGEMENT'", conn);
                configurationManSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                    new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'IDENTIFICATION AND AUTHENTICATION'", conn);
                identifationSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                    new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'INCIDENT RESPONSE'", conn);
                incidentSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                   new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'MAINTENANCE'", conn);
                maintenSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                   new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'MEDIA PROTECTION'", conn);
                mediaProtection = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                  new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'PERSONNEL SECURITY'", conn);
                personnelSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                 new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'PERSONNEL SECURITY'", conn);
                personnelSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                 new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'PHYSICAL PROTECTION'", conn);
                physicalSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'RISK ASSESSMENT'", conn);
                riskAssesSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
                new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'SECURITY ASSESSMENT'", conn);
                securityAssessSat = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
               new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'SYSTEM AND COMMUNICATIONS PROTECTION'", conn);
                systemComm = System.Convert.ToInt32(cmd.ExecuteScalar());
                cmd =
              new OleDbCommand("Select COUNT(*) FROM 171 WHERE Status = 'Satisfied' AND Family = 'SYSTEM AND INFORMATION INTEGRITY'", conn);
                systemInform = System.Convert.ToInt32(cmd.ExecuteScalar());

                accessControlUSat = 22 - accessControlSat;
                awareTrainingUSat = 3 - awareTrainingSat;
                auditUSat = 9 - auditSat;
                configurationManUSat = 9 - configurationManSat;
                identifationUSat = 11 - identifationSat;
                incidentUSat = 3 - incidentSat;
                maintenUSat = 6 - maintenSat;
                mediaProtectionU = 9 - mediaProtection;
                personnelUSat = 2 - personnelSat;
                physicalUSat = 6 - physicalSat;
                riskAssesUSat = 3 - riskAssesSat;
                securityAssessUSat = 3 - securityAssessSat;
                systemCommU = 16 - systemComm;
                systemInformU = 7 - systemInform;
            }

            catch (Exception ex)
            {

            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }


            //Create a SRTM
            //Create a table
            GridView1.AllowPaging = false;
            GridView1.DataBind();
            iTextSharp.text.Table table = new iTextSharp.text.Table(GridView1.Columns.Count);
            table.Cellpadding = 5;
            //Transfer rows from GridView to table

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < GridView1.Columns.Count; j++)
                    {
                        string cellText = Page.Server.HtmlDecode(GridView1.Rows[i].Cells[j].Text);
                        switch (j)
                        {
                            case 0:
                                {
                                    cellText = cellText;
                                    break;
                                }
                            case 1:
                                {
                                    cellText = "Control Description: " + cellText;
                                    break;
                                }
                            case 2:
                                {
                                    cellText = "Family: " + cellText;
                                    break;
                                }

                            case 3:
                                {
                                    cellText = "Response: " + cellText;
                                    break;
                                }
                            case 4:
                                {
                                    cellText = "Confidence: " + cellText;
                                    break;
                                }
                            case 5:
                                {
                                    if (cellText.Equals("Satisfied"))
                                    {
                                        cellText = "Satisfied";
                                    }
                                    else
                                    {
                                        cellText = "Other than Satisifed";
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    cellText = "POA&M: " + cellText;
                                    break;
                                }
                            case 7:
                                {
                                    cellText = "800-53 mapping: " + cellText;
                                    break;
                                }
                            default:
                                {
                                    System.Console.WriteLine("Other number");
                                    break;
                                }
                        }

                        iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
                        switch (j)
                        {
                            case 0:
                                {
                                    cell.Colspan = 4;
                                    break;
                                }
                            case 1:
                                {
                                    cell.Colspan = 4;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Colspan = 8;
                                    break;
                                }

                            case 3:
                                {
                                    cell.Colspan = 8;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Colspan = 4;
                                    break;
                                }
                            case 5:
                                {
                                    cell.Colspan = 4;
                                    break;
                                }
                            case 6:
                                {
                                    cell.Colspan = 8;
                                    break;
                                }
                            case 7:
                                {
                                    cell.Colspan = 8;
                                    break;
                                }
                            default:
                                {
                                    System.Console.WriteLine("Other number");
                                    break;
                                }
                        }


                        //Set Color of Alternating row
                        if (i % 2 != 0)
                        {
                            cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#C2D69B"));
                        }
                        if (j == 0 || j == 5)
                        {
                            table.AddCell(cell);

                        }
                    }
                }
            }

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
            Paragraph space = new Paragraph(" ");
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            Paragraph p = new Paragraph("SSP and SRTM Report");
                p.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(p);
            Paragraph userDetails = new Paragraph("This report was created for the system: " + (String)Session["SystemNameReport"]);
            userDetails.Alignment = Element.ALIGN_CENTER;
        
            Paragraph userDetails2 = new Paragraph("Information contained herein belongs to: " + (String)Session["CompanyNameReport"]);
            userDetails2.Alignment = Element.ALIGN_CENTER;
 
            Paragraph userDetails3 = new Paragraph("Report created by: " + (String)Session["userNameReport"]);
            userDetails3.Alignment = Element.ALIGN_CENTER;
       
            Paragraph todaysDate = new Paragraph("Report created on: " + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
            todaysDate.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(userDetails);
            pdfDoc.Add(userDetails2);
            pdfDoc.Add(userDetails3);
            pdfDoc.Add(todaysDate);
            pdfDoc.NewPage();
            Paragraph accessControls = new Paragraph("Access controls satisfied: " + accessControlSat + Environment.NewLine + "Access controls other than satisfied: " + accessControlUSat);
            Paragraph awareTraining = new Paragraph("Awareness Training controls satisfied: " + awareTrainingSat + Environment.NewLine + "Awareness and Training controls other than satisfied: " + awareTrainingUSat);
            Paragraph auditAccount = new Paragraph("Audit and Accounting controls satisfied: " + auditSat + Environment.NewLine + "Audit and Accounting controls other than satisfied: " + auditUSat);
            Paragraph configMan = new Paragraph("Configuration Management controls satisfied: " + configurationManSat + Environment.NewLine + "Configuration management controls other than satisfied: " + configurationManUSat);
            Paragraph identification = new Paragraph("Identification and Authentication controls satisfied: " + identifationSat + Environment.NewLine + "Identification and Authenticaion controls other than satisfied: " + identifationUSat);
            Paragraph incident = new Paragraph("Incident response controls satisfied: " + incidentSat + Environment.NewLine + "Incident response controls other than satisfied: " + incidentUSat);
            Paragraph maintenence = new Paragraph("Maintenance controls satisfied: " + maintenSat + Environment.NewLine + "Maintenance controls other than satisfied: " + maintenUSat);
            Paragraph media = new Paragraph("Media protection controls satisfied: " + mediaProtection + Environment.NewLine + "Media protection controls other than satisfied: " + mediaProtectionU);
            Paragraph personnel = new Paragraph("Personnel Security controls satisfied: " + personnelSat + Environment.NewLine + "Personnel security controls other than satisfied: " + personnelUSat);
            Paragraph physical = new Paragraph("Physical protection controls satisfied: " + physicalSat + Environment.NewLine + "Physical protection controls other than satisfied: " + physicalUSat);
            Paragraph risk = new Paragraph("Risk assessment security controls satisfied: " + riskAssesSat + Environment.NewLine + "Risk assessment security controls other than satisfied: " + riskAssesUSat);
            Paragraph security = new Paragraph("Security assessment security controls satisfied: " + securityAssessSat + Environment.NewLine + "Security assessment security controls other than satisfied: " + securityAssessUSat);
            Paragraph systemCommpara = new Paragraph("Systems and communications controls satisfied: " +  systemComm + Environment.NewLine + "Systems and communications controls other than satisfied: " + systemCommU);
            Paragraph information = new Paragraph("System and information integrity controls satisfied: " + systemInform + Environment.NewLine + "System and information integrity controls other than satisfied: " + systemInformU);
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            pdfDoc.Add(space);
            pdfDoc.Add(accessControls);
            pdfDoc.Add(awareTraining);
            pdfDoc.Add(auditAccount);
            pdfDoc.Add(configMan);
            pdfDoc.Add(identification);
            pdfDoc.Add(incident);
            pdfDoc.Add(maintenence);
            pdfDoc.Add(media);
            pdfDoc.Add(personnel);
            pdfDoc.Add(physical);
            pdfDoc.Add(risk);
            pdfDoc.Add(security);
            pdfDoc.Add(systemCommpara);
            pdfDoc.Add(information);
            pdfDoc.NewPage();
            pdfDoc.Add(table);




                //Create the SSP table
                GridView1.AllowPaging = false;
                GridView1.DataBind();
                iTextSharp.text.Table table2 = new iTextSharp.text.Table(GridView1.Columns.Count);
                table2.Cellpadding = 5;
                //Transfer rows from GridView to table

                for (int k = 0; k < GridView1.Rows.Count; k++)
                {
                    if (GridView1.Rows[k].RowType == DataControlRowType.DataRow)
                    {
                        for (int l = 0; l < GridView1.Columns.Count; l++)
                        {
                            string cellText = Page.Server.HtmlDecode(GridView1.Rows[k].Cells[l].Text);
                            switch (l)
                            {
                                case 0:
                                    {
                                        cellText = "Control Number: " + cellText;
                                        break;
                                    }
                                case 1:
                                    {
                                        cellText = "Control Description: " + cellText;
                                        break;
                                    }
                                case 2:
                                    {
                                        cellText = "Family: " + cellText;
                                        break;
                                    }

                                case 3:
                                    {
                                        cellText = "Response: " + cellText;
                                        break;
                                    }
                                case 4:
                                    {
                                        cellText = "Confidence: " + cellText;
                                        break;
                                    }
                                case 5:
                                    {
                                        cellText = "Status: " + cellText;
                                        break;
                                    }
                                case 6:
                                    {
                                        cellText = "POA&M: " + cellText;
                                        break;
                                    }
                                case 7:
                                    {
                                        cellText = "800-53 mapping: " + cellText;
                                        break;
                                    }
                                default:
                                    {
                                        System.Console.WriteLine("Other number");
                                        break;
                                    }
                            }

                            iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
                            switch (l)
                            {
                                case 0:
                                    {
                                        cell.Colspan = 4;
                                        break;
                                    }
                                case 1:
                                    {
                                        cell.Colspan = 4;
                                        break;
                                    }
                                case 2:
                                    {
                                        cell.Colspan = 8;
                                        break;
                                    }

                                case 3:
                                    {
                                        cell.Colspan = 8;
                                        break;
                                    }
                                case 4:
                                    {
                                        cell.Colspan = 4;
                                        break;
                                    }
                                case 5:
                                    {
                                        cell.Colspan = 4;
                                        break;
                                    }
                                case 6:
                                    {
                                        cell.Colspan = 8;
                                        break;
                                    }
                                case 7:
                                    {
                                        cell.Colspan = 8;
                                        break;
                                    }
                                default:
                                    {
                                        System.Console.WriteLine("Other number");
                                        break;
                                    }
                            }


                            //Set Color of Alternating row
                            if (k % 2 != 0)
                            {
                                cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#C2D69B"));
                            }

                            table2.AddCell(cell);
                        }
                    }
                }

    
                pdfDoc.NewPage();
                pdfDoc.Add(table2);
                pdfDoc.NewPage();
                Paragraph spaces = new Paragraph(" ");
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
                pdfDoc.Add(spaces);
            Paragraph e = new Paragraph("I ______________ attest that the information enclosed in this packet is accurate and no information or disclosuers were witheld to the best of my knowledge. My signature is a legally binding agreement to this fact. Signature: ________________   on the date of __________________");
                e.Alignment = Element.ALIGN_CENTER;
  
            pdfDoc.Add(e);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;" +
                                               "filename=GridViewExport2.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }


