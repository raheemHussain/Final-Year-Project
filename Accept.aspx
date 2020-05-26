<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accept.aspx.cs" Inherits="login1.Accept" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href ="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <div class ="container-fluid">
                <div class ="jumbotron">
                <h1>Switch Up</h1>
                </div>
                </div>
           <table style="font-family:Arial">

               <tr>
                   <td style="height:500px; background-color:#D8D8F0; width:150px">
                       <asp:Label ID="UserDetails" runat="server" Text=""></asp:Label>
                       <br />
                       
                 <asp:Menu ID ="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Dashboard" Value="Dashboard" NavigateUrl="~/Dashboard.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Rota" Value="ShiftSwap" NavigateUrl="~/Rota.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Shift Swap" Value="ShiftSwap" NavigateUrl="~/ShiftChoice.aspx"></asp:MenuItem>
                    
                    
                </Items>
            </asp:Menu>
                       <asp:Button ID="Availability" runat="server" Text="Availability" CssClass = "btn btn-success" OnClick="Availability_Click" />
                       <br />
                       <asp:Button ID="Logout" runat="server" Text="Logout" CssClass ="btn btn-danger" OnClick="Logout_Click1" />
                   </td>
                   <td style="height:500px; background-color:white; width:650px">

                       
                   </td>

               </tr>

           </table>
        </div>
    </form>
</body>

</html>