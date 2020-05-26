<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="login1.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href ="Content/bootstrap.css" rel="stylesheet" />
    
        <style>
         body{
         background-color:lightslategray;
        }
    </style>

    <style type="text/css">
        .auto-style1 {
            width: 112%;
            padding-right: 15px;
            padding-left: 15px;
            margin-right: auto;
            margin-left: auto;
        }
    </style>
    

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
                   <td colspan="2" style="height:80px; text-align:center; background-color:#4A3C8C; color:white">
                       <h1>
                           Dashboard
                      </h1>
                   </td>
               </tr>
             
               <tr>
                   <td style="height:500px; background-color:#D8D8F0; width:150px">
                       <asp:Label ID="UserDetails" runat="server" Text=""></asp:Label>
                       <br />
                       <asp:Label ID ="UserHours" runat="server" Text=""></asp:Label>
                       <br />

                       <asp:Menu ID ="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Rota" Value="Rota" NavigateUrl="~/Rota.aspx"></asp:MenuItem>  
                    <asp:MenuItem Text="Shift Swap" Value="ShiftSwap" NavigateUrl="~/ShiftChoice.aspx" ></asp:MenuItem>
                    </Items>
                           </asp:Menu>


                       <asp:Button ID="Availability" runat="server" Text="Availability" CssClass = "btn btn-success" OnClick="Availability_Click" />
                       <br />
                       <asp:Button ID="Logout" runat="server" Text="Logout" CssClass ="btn btn-danger" OnClick="Logout_Click1" />

                       
                   </td>
                   <td style ="background-color:white" class="auto-style1">

                       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Your Requests" />

                       </td>


                   

               </tr>


           </table>
        </div>
    </form>
</body>

</html>
