<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guidance.aspx.cs" Inherits="WebApplication2.Guidance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .information {
             font-family: Georgia, "Times New Roman", Times, serif;
            font-size:24px;
	        margin-top: 5px; margin-bottom: 0px;
            font-weight: normal;
            color: #222;
        }
    </style>

    <script type="text/javascript">
function insertControlN (controlN) {
    document.getElementById('controlNumber').innerHTML = controlN;
}
</script>

    <script type="text/javascript">
function insertControlDesc(controlD) {
    document.getElementById('content').innerHTML = controlD;
}
</script>

    <style>
table {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

td, th {
    border: 1px solid #dddddd;
    text-align: left;
    padding: 8px;
}

tr:nth-child(even) {
    background-color: #dddddd;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class = "information" runat="server">
        <table>
    <tr>
    <th>Control</th>
    <th>Additional Guidance</th>
    <th>Need additional guidance?</th>
  </tr>
   <tr>
    <td id="controlNumber" runat ="server"></td>
    <td id="content" runat ="server"> </td>
    <td><a href="mailto:ForeGroundSecurityAssist.com">Need Additional Guidance</a></td>
  </tr>
        </table>
    </div>
    </form>
</body>
</html>
