<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createNewUser.aspx.cs" Inherits="WebApplication2.createNewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
    <link rel="stylesheet" media="all" href="css/normalize.css" />
    <link rel="stylesheet" media="all" href="css/style.css" />
      <script src="js/sweetalert.min.js"></script> 
    <link rel="stylesheet" type="text/css" href="css/sweetalert.css">

    <script type="text/javascript">
        function successalert() {
            swal({
                title: "User ID Created",
                text: "The User ID was created successfully",
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
                title: "User ID Taken",
                text: "That user ID has already been chosen by another user. Please enter a different ID and try again.",
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
</head>
<body>
    <form id="form1" runat="server">
  <div class="login">
  <h2>Create Account</h2>
  <fieldset>
    <asp:TextBox runat="server" ID="txtUserName" placeholder="User ID" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
  	<asp:TextBox runat="server" ID="txtpassword" type="password" placeholder="Password" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpassword" ErrorMessage='Special characters are not allowed.' ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
  </fieldset>
  <asp:Button id="Button1" Text="Create Account"  OnClick="login"  runat="server" type="submit" value="Create Account" />
    </div>
         <script type="text/javascript">
               function alertMessage() {
                       alert('User ID is already Taken. Please enter a different ID and try again.');
               }
       </script>
    </form>

       
</body>
</html>