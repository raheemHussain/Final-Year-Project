<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="login1.Request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href ="Content/bootstrap.css" rel="stylesheet" />
        <link href ="Documents/startbootstrap-sb-admin-gh-pages" rel ="stylesheet" />
        
  <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>

  <!-- Page level plugin CSS-->
  <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet"/>

  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet"/>

        <style>
         body{
         background-color:lightslategray;
        }
    </style>
        

    <style type="text/css">
        .auto-style1 {
            height: 500px;
            width: 1545px;
            background-color: lightslategray;
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
                            Request
                       </h1>
                   </td>
               </tr>
               <tr>
                   <td style="height:500px; background-color:#D8D8F0; width:150px">
                       <asp:Label ID="UserDetails" runat="server" Text=""></asp:Label>
                 <asp:Menu ID ="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Dashboard" Value="Rota" NavigateUrl="~/Dashboard.aspx"></asp:MenuItem>  
                    <asp:MenuItem Text="Rota" Value="ShiftSwap" NavigateUrl="~/Rota.aspx"></asp:MenuItem>

                    
                </Items>
            </asp:Menu>
                       
                   </td>
                   <td style="background-color:white; " class="auto-style1">
                <asp:GridView ID ="Grid" class="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowCommand="StaffID_RowCommand1" OnSelectedIndexChanged="StaffID_SelectedIndexChanged">

                <Columns>
                    <asp:BoundField DataField="StaffID" HeaderText="Staff"/>
                    <asp:BoundField DataField ="Day" HeaderText="Day" />
                    <asp:BoundField DataField="StartTime" HeaderText="Start Time"/>
                    <asp:BoundField DataField="FinishTime" HeaderText="Finsih Time"/>
                    <asp:BoundField DataField="BreakTime" HeaderText="Break Time"/>
                    <asp:BoundField DataField="Hours" HeaderText="Hours"/>
                    <asp:BoundField DataField="ShiftLeader" HeaderText="Shift Leader"/>
                    <asp:BoundField DataField="SwapWith" HeaderText="Swap With" />

                    <asp:ButtonField CommandName="Accept" Text="Accept" />
                    <asp:ButtonField CommandName="Reject" Text="Reject" />
                    
                </Columns>

            </asp:GridView>
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />

                       
                   </td>

               </tr>
           </table>
        </div>
    </form>
</body>

</html>
