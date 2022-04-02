<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link rel="stylesheet" media="all" href="css/normalize.css" />
    <link rel="stylesheet" media="all" href="css/style.css" />
      <script src="js/sweetalert.min.js"></script> 
    <link rel="stylesheet" type="text/css" href="css/sweetalert.css">

    <script type="text/javascript">
        function successalert() {
            swal({
                title: "Login successful",
                text: "You have successfully logged in",
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
        function failAlert() {
            swal({
                title: "Login Not Found",
                text: "The credentials provided did not match any on records. Please create a new account or return to the previous screen and enter the information again.",
                type: "error",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Create new account",
                cancelButtonText: "Try again",
                closeOnConfirm: false,
                closeOnCancel: false
            },
            function (isConfirm) {
                if (isConfirm) {
                    window.location = 'createNewUser.aspx';
                }
                else { swal("Returning to login page"); }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
  <div class="login">
  <h2>Log In</h2>
  <fieldset>
    <asp:TextBox runat="server" ID="txtUserName" placeholder="User ID" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
  	<asp:TextBox runat="server" ID="txtpassword" type="password" placeholder="Password" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpassword" ErrorMessage='Special characters are not allowed.'  ValidationExpression="^[a-z A-Z0-9_@.-]*$"></asp:RegularExpressionValidator>
  </fieldset>
  <asp:Button id="Button1" Text="Login"  OnClick="login"  runat="server" type="submit" value="Log In" />
    </div>
    </form>
</body>
</html>
