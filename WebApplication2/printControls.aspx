<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printControls.aspx.cs" Inherits="WebApplication2.printControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PrimaryID" AllowPaging="false">
   
   <HeaderStyle BackColor="#336699" ForeColor="White" HorizontalAlign="Left" Height="25" />            
            
   <Columns>
                <asp:BoundField DataField="Number" HeaderText= 'Control Number' />
                <asp:BoundField DataField="Control_Description" HeaderText= 'Control Description' />
                <asp:BoundField DataField="Family" HeaderText= 'Family' />
                <asp:BoundField DataField="Response" HeaderText= 'Response' />
                <asp:BoundField DataField="Confidence" HeaderText='Confidence' />
                <asp:BoundField DataField="Status" HeaderText= 'Status' />
                <asp:BoundField DataField="POAM" HeaderText= 'POA&M' />
                <asp:BoundField DataField="800-53_Mapping" HeaderText= '800-53 Mapping' />
   </Columns>
            
</asp:GridView>
    </div>
    </form>
</body>
</html>
