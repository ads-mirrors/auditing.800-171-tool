<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visualizationSystem.aspx.cs" Inherits="WebApplication2.visualizationSystem" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type='text/javascript' src='js/jquery-1.12.4.js'></script>
    <script src="js/highcharts.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<asp:Chart ID="Chart1" runat="server" >
            <Series>
		<asp:Series Name="Testing" YValueType="Int32">
			<Points>
			
				
			</Points>
		</asp:Series>
	</Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"> <AxisX Interval="1"> </AxisX> </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <asp:Chart ID="Chart2" runat="server" >
            <Series>
		<asp:Series Name="Testing2" YValueType="Int32">
			<Points>
		
				
			</Points>
		</asp:Series>
	</Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea2"> <AxisX Interval="1"> </AxisX> </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

    <asp:Chart ID="Chart3" runat="server" >
            <Series>
		<asp:Series Name="Testing3" YValueType="Int32">
			<Points>
				
			</Points>
		</asp:Series>
	</Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea3"> <AxisX Interval="1"> </AxisX> </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
