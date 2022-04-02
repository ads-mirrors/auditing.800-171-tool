<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Selection.aspx.cs" Inherits="WebApplication2.WebForm1" EnableEventValidation = "false"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
     <title>System Details</title> 
    <meta name="viewport" content="width=device-width"> 
     <script type='text/javascript' src='js/jquery-1.12.4.js'></script>
	 <script type='text/javascript' src='js/jquery-ui.js'></script>  
    <link rel="stylesheet" media="all" href="css/dynatable-docs.css" />
    <script type='text/javascript' src='js/jquery.scrollTo.js'></script>
    <script type='text/javascript' src='js/jquery.toc.min.js'></script>
    <link rel="stylesheet" media="all" href="css/jquery.dynatable.css" />  
    <script type='text/javascript' src='js/jquery.dynatable.js'></script>   
    <script type='text/javascript' src='js/highcharts.js'></script>
    <script type='text/javascript' src='js/xml2json.js'></script>
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="css/component.css" />
    <script src="js/sweetalert.min.js"></script> 
    <link rel="stylesheet" type="text/css" href="css/sweetalert.css">
    <link rel="stylesheet" href="css/jquery-ui.css">

    <style>
  textarea {
    resize: none;
}
    </style> 
        <link rel="stylesheet" media="all" href="css/button.css" />
  <script type="text/javascript">
    function playSound(pathToMp3) {
        var audioElement;
        if (!audioElement) {
            audioElement = document.createElement('audio');
            audioElement.innerHTML = '<source src="' +pathToMp3+ '" type="audio/mpeg" />'
        }
        audioElement.play();
        alert("Called");
    }
  </script>


   <script type="text/javascript">
        function successalert(controlDes) {
            swal({   
                title: "HTML <small>Title</small>!",   
                text: controlDes,
                html: true });
        }
    </script>

  </head>

  <body>

<form id="form1" runat="server">

    <div id="buttons">
  <asp:Button id="Button4"
           Text="Home Page"
           OnClick="goHome" 
           Class ="btn green"
           runat="server"/>
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
           Text="Generate SSP and SRTM"
           OnClick="generateSSP" 
           Class ="btn blue"
           runat="server"/>
        </div>
    
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PrimaryID"
            OnRowCommand="GridViewData_RowCommand" PageSize="5" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
   
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
                <asp:TemplateField HeaderText="Attachments">
          <ItemTemplate>
          <asp:Button id="Button1"
           Text="Submit Attachments"
           OnClick="Button1_Click" 
           runat="server"/>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Button id="Button1"
           Text="Submit Attachments"
           OnClick="Button1_Click" 
           runat="server"/>
          </EditItemTemplate>
      </asp:TemplateField>

        <asp:TemplateField HeaderText="Help">
          <ItemTemplate>
          <asp:Button id="Button2"
           Text="Play Audio Description"
           OnClick="Button2_Click" 
           runat="server"/>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Button id="Button2"
           Text="Play Audio Description"
           OnClick="Button2_Click" 
           runat="server"/>
          </EditItemTemplate>
      </asp:TemplateField>

       <asp:TemplateField HeaderText="Guidance">
          <ItemTemplate>
          <asp:Button id="Button6"
           Text="Additional Guidance"
           OnClick="getGuidance" 
           runat="server"/>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Button id="Button8"
           Text="Additional Guidance"
           OnClick="getGuidance" 
           runat="server"/>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="ShowPopup"
CommandArgument='<%#Eval("PrimaryID") %>'>Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
    </Columns>
            
</asp:GridView>

    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
    
<style type="text/css">
        
        #mask
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        $(".btnClose").live('click',function () {
            HidePopup();
        });
    </script>
    <div id="mask">
    </div>
      <asp:Panel ID="pnlpopup" runat="server"  BackColor="White" Height="800px"
            Width="800px" Style="z-index:111;background-color: White; position: absolute; left: 35%; top: 5%; 
 
border: outset 2px gray;padding:5px;display:none">
            <table width="100%" style="width: 100%; height: 100%;" cellpadding="0" cellspacing="5">
                <tr style="background-color: #0924BC">
                    <td colspan="2" style="color:White; font-weight: bold; font-size: 1.2em; padding:3px"
                        align="center">
                        Control Details
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 45%; text-align: center;">
                        <asp:Label ID="LabelValidate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%">
                        Control ID:
                    </td>
                    <td>
                        <asp:Label ID="lblID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Control Number:
                    </td>
                    <td>
                        <asp:Label ID="txtControlNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Response:
                    </td>
                    <td>
                        <asp:TextBox ID="txtResponse" runat="server" TextMode ="MultiLine" style="width: 500px; Height: 200px"/>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Confidence:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfidence" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        Status:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbtLstRating" runat="server" 
                RepeatDirection="Horizontal" RepeatLayout="Table">
                <asp:ListItem Text="Satisfied" Value="Satisfied"></asp:ListItem>
                <asp:ListItem Text="Other than Satisfied" Value="Other than Satisfied"></asp:ListItem>
            </asp:RadioButtonList>            
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        POA&Ms:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPOAMs" runat="server" TextMode ="MultiLine" style="width: 500px; Height: 200px"/>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnClose" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

    <script>
    </script>
    
    </form>



    


    </body>
</html>
