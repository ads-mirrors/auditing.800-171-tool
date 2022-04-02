using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class visualizationSystem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Width = new System.Web.UI.WebControls.Unit(1800, System.Web.UI.WebControls.UnitType.Pixel);
            Chart1.Height = new System.Web.UI.WebControls.Unit(1200, System.Web.UI.WebControls.UnitType.Pixel);
            Chart2.Width = new System.Web.UI.WebControls.Unit(1800, System.Web.UI.WebControls.UnitType.Pixel);
            Chart2.Height = new System.Web.UI.WebControls.Unit(1200, System.Web.UI.WebControls.UnitType.Pixel);
            Chart3.Width = new System.Web.UI.WebControls.Unit(1800, System.Web.UI.WebControls.UnitType.Pixel);
            Chart3.Height = new System.Web.UI.WebControls.Unit(1200, System.Web.UI.WebControls.UnitType.Pixel);
            ReadRecords();
        }

        private void ReadRecords()
        {
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            int notSatisfied = 0;
            int satisfied = 0;
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


            try {
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

            System.Diagnostics.Debug.WriteLine(satisfied);
            string[] xValues = { "Access Controls Satisfied", "Access Controls other than satisfied", "Awareness Training Controls Satisfied", "Awareness Training Controls other than satisfied", "Audit and Accountability Controls satisfied", "Audit and Accountability controls other than satisfied", "Configuration Management controls satisfied", "Configuration Management controls other than satisifed", "Identification and Authentication controls satisfied", "Identification and Authentication controls other than sastisifed" };
            int[] yValues = { accessControlSat, accessControlUSat, awareTrainingSat, awareTrainingUSat, auditSat, auditUSat, configurationManSat, configurationManUSat, identifationSat, identifationUSat };
            Chart1.Series["Testing"].Points.DataBindXY(xValues, yValues);

            string[] x2Value = { "Incident Response controls satisfied", "Incident Response controls other than satisfied", "Maintenance controls satisfied", "Maintenance controls other than satisfied", "Media protection controls satisfied", "Media protection controls other than satisfied", "Personnel security controls satisfied", "Personnel security controls other than satisfied", " Physical protection controls satisfied", "Physical protection controls other than satisfied" };
            int[] y2Value = { incidentSat, incidentUSat, maintenSat, maintenUSat, mediaProtection, mediaProtectionU, personnelSat, personnelUSat, physicalSat, physicalUSat };
            Chart2.Series["Testing2"].Points.DataBindXY(x2Value, y2Value);

            string[] x3Value = { "Risk assessment controls satisfied", "Risk assessment controls other than satisfied", "Security assessment controls satisfied", "Security assessmeent controls other than satisfied", "System and communication controls satisfied", "System and communication controls other that satisfied", "System and information controls satisfied", "System and information controls other than satisfied" };
            int[] y3Value = { riskAssesSat, riskAssesUSat, securityAssessSat, securityAssessUSat, systemComm, systemCommU, systemInform, systemInformU };
            Chart3.Series["Testing3"].Points.DataBindXY(x3Value, y3Value);
        }

    
    static object[] ToObjectArray(IEnumerable enumerableObject)
    {
        List<object> oList = new List<object>();
        foreach (object item in enumerableObject) { oList.Add(item); }
        return oList.ToArray();
    }
}
}