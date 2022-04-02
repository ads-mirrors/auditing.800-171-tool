<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" media="all" href="css/normalize.css" />
    <link rel="stylesheet" media="all" href="css/style.css" />
    <link rel="stylesheet" media="all" href="css/button.css" />
    <script type='text/javascript' src='js/jquery-1.12.4.js'></script>
    <script src="js/highcharts.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" BackColor="Coral" 
                        ForeColor="blue" BorderColor="ActiveBorder" 
                        BorderStyle="dashed" BorderWidth="1" Height="60" 
                        Text="You are currently signed in as: " Width="200"
                        ></asp:Label>
  <div id="buttons">
  <asp:Button id="Button1"
           Text="New Assessment"
           OnClick="newSystem"
           Class ="btn blue"
           runat="server"/>
  <asp:Button id="Button2"
           Text="Current Assessment"
           OnClick="allSystems" 
           Class ="btn green"
           runat="server"/>
       <asp:Button id="Button3"
           Text="Login"
           OnClick="LoginUser"
           Class ="btn green"
           runat="server"/>
      <asp:Button id="Button4"
           Text="Create New User"
           OnClick="createNew"
           Class ="btn blue"
           runat="server"/>
</div>

    </div>
    </form>
</body>
</html>
