<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allSystems.aspx.cs" Inherits="WebApplication2.allSystems" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
     <title>All Systems</title> 
    <meta name="viewport" content="width=device-width">   
    <link rel="stylesheet" media="all" href="css/dynatable-docs.css" />
    <script type='text/javascript' src='js/jquery-1.9.1.min.js'></script>
    <script type='text/javascript' src='js/jquery.scrollTo.js'></script>
    <script type='text/javascript' src='js/jquery.toc.min.js'></script>
    <link rel="stylesheet" media="all" href="css/jquery.dynatable.css" />  
    <script type='text/javascript' src='js/jquery.dynatable.js'></script>   
    <script type='text/javascript' src='js/highcharts.js'></script>
    <script type='text/javascript' src='js/xml2json.js'></script>
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="css/component.css" />
    <style>
  textarea {
    resize: none;
}
    </style> 

     <style>
        #Chart1 {
            display: block;
            margin: auto;
        }

    </style>
        
  </head>

  <body>

<form id="form2" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="3" GridLines="Horizontal"
   Font-Names="Verdana" Font-Size="10" DataKeyNames="System_Name" 
   AutoGenerateColumns="false">
   
   <HeaderStyle BackColor="#336699" ForeColor="White" HorizontalAlign="Left" Height="25" />            
            
   <Columns>                    
        <asp:TemplateField HeaderText="Company">
          <ItemTemplate>
           <asp:Label runat="server" ID="txtCompany" Text='<%# Eval("Company")%>' ReadOnly="true" />
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label runat="server" ID="txtCompany" Text='<%# Eval("Company")%>' ReadOnly="true" />
          </EditItemTemplate>
      </asp:TemplateField>
                
         <asp:TemplateField HeaderText="System Name">
          <ItemTemplate>
           <asp:Label runat="server" ID="txtSystemName" Text='<%# Eval("System_Name")%>' ReadOnly="true" />
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label runat="server" ID="txtSystemName" Text='<%# Eval("System_Name")%>' ReadOnly="true" />
          </EditItemTemplate>
      </asp:TemplateField>

       <asp:TemplateField HeaderText="Open System">
          <ItemTemplate>
            <asp:Button id="Button2"
           Text="Modify System"
           OnClick="Button1_Click" 
           runat="server"/>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Button id="Button3"
           Text="Modify System"
           OnClick="Button1_Click" 
           runat="server"/>
          </EditItemTemplate>
      </asp:TemplateField>
       <asp:TemplateField HeaderText="Visualization of System">
          <ItemTemplate>
            <asp:Button id="Button4"
           Text="Visualize System"
           OnClick="visualSystem" 
           runat="server"/>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Button id="Button5"
           Text="Visualize System"
           OnClick="visualSystem" 
           runat="server"/>
          </EditItemTemplate>
      </asp:TemplateField>
   

    </Columns>
            
</asp:GridView>

    <asp:Chart ID="Chart1" runat="server" >
     <Series>
		<asp:Series Name="Testing" YValueType="Int32">
			<Points>
				<asp:DataPoint AxisLabel="Satisfied controls overall" YValues="0" />
                <asp:DataPoint AxisLabel="Other than satisfied controls overalll" YValues="0" />
				
			</Points>
		</asp:Series>
	</Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" ></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>


    </form>

    </body>
</html>
