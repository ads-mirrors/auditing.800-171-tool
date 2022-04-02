<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newSystem.aspx.cs" Inherits="WebApplication2.newSystem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Add System</title>
    <link rel="stylesheet" media="all" href="css/normalize.css" />
    <link rel="stylesheet" media="all" href="css/style.css" />
    <script src="js/sweetalert.min.js"></script> 
    <link rel="stylesheet" type="text/css" href="css/sweetalert.css">

      <script type="text/javascript">
        function successalert() {
            swal({
                title: "System Created",
                text: "The system was created successfully",
                type: "success",
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Return to main page",
                closeOnConfirm: false
            },
            function () {
                window.location = 'Default.aspx';
            });
        }
    </script>

     <script type="text/javascript">
        function idTaken() {
            swal({
                title: "System name Taken",
                text: "That system name has already been chosen by another user. Please enter a different system name and try again.",
                type: "error",
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Return to page",
                closeOnConfirm: true
            },
            function () {
                
            });
        }
    </script>

    <script type="text/javascript">
        function failAlert() {
            swal({
                title: "System Creation Failed",
                text: "The system was not created",
                type: "error",
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "You must login before you can create a system",
                closeOnConfirm: false
            },
            function () {
                window.location = 'Default.aspx';
            });
        }
    </script>
</head>
<body>
    <form id="form2" runat="server">
  <div class="login">
  <h2>Create System</h2>
  <fieldset>
    <asp:TextBox ID="systemName" runat="server" CssClass="txtStyle" AutoPostBack="true" placeHolder ="Name of System"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="systemName" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
      <asp:TextBox ID="companyName" runat="server" CssClass="txtStyle" AutoPostBack="true" placeHolder ="Name of Company"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="companyName" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
  </fieldset>
  <asp:Button id="Button2" Text="Add System"  OnClick="addSystem"  runat="server" type="submit" value="Add System"/>
    </div>

         <script type="text/javascript">
               function alertMessage() {
                       alert('System name already exists. Please enter a different name and try again.');
               }
       </script>
    </form>
</body>
</html>
