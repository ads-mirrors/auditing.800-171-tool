<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creationDetails.aspx.cs" Inherits="WebApplication2.creationDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Report Details</title>
    <link rel="stylesheet" media="all" href="css/normalize.css" />
    <link rel="stylesheet" media="all" href="css/style.css" />
</head>
<body>
    <form id="form2" runat="server">
  <div class="login">
  <h2>Create Report</h2>
  <fieldset>
    <asp:TextBox ID="systemName" runat="server" CssClass="txtStyle" AutoPostBack="true" placeHolder ="Name of System"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="systemName" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
      <asp:TextBox ID="companyName" runat="server" CssClass="txtStyle" AutoPostBack="true" placeHolder ="Name of Company"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="companyName" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
      <asp:TextBox ID="yourName" runat="server" CssClass="txtStyle" AutoPostBack="true" placeHolder ="Your name"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="yourName" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
  </fieldset>
  <asp:Button id="Button2" Text="Generate SSR and SRTM"  OnClick="createPrint"  runat="server" type="submit" value="Generate SSR and SRTM"/>
    </div>

         <script type="text/javascript">
               function alertMessage() {
                       alert('Details are missing and must be entered to generate the reports.');
               }
       </script>
    </form>
</body>
</html>
