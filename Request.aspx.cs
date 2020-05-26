using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;
namespace login1
{
    public partial class Request : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = "server=localhost;user id=root;password=Letmein16;database=mydb";
            
                if (Session["username"] == null)
                {
                    Response.Redirect("Login1.aspx");
                }

                using (MySqlConnection sqlcon = new MySqlConnection(ConnectionString))
                {
                    sqlcon.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM request WHERE StaffID = '" + Session["username"]+"'", sqlcon);

                    DataSet Rota = new DataSet();
                    sqlDa.Fill(Rota, "Rota");
                    Grid.DataSource = Rota;
                    Grid.DataBind();
            }

                
        }

        protected void StaffID_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = Grid.Rows[index];

            // this is a bit risky 
            var ID = row.Cells[0].Text;
            var Day = row.Cells[1].Text;
            var StartTime = row.Cells[2].Text;
            var FinishTime = row.Cells[3].Text;
            var BreakTime = row.Cells[4].Text;
            var Hours = row.Cells[5].Text;
            var ShiftLeader = row.Cells[6].Text;
            var SwapWith = row.Cells[7].Text;
            SwapWith = SwapWith.Trim(' ');

            if (e.CommandName == "Accept")
            {
                string ConnectionString = "server=localhost;user id=root;password=Letmein16;database=mydb";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script> alert ('Accepted');</script>");


                using (MySqlConnection AcceptConnection = new MySqlConnection(ConnectionString))
                {
                    AcceptConnection.Open();
                    //string Accept = "INSERT INTO rota values ('" + ID + "','" + StartTime + " ','" + FinishTime + " ',' " + BreakTime + " ',' " + Hours + " ',' " + ShiftLeader + "', ' ', ' ', ' ') ON DUPLICATE KEY UPDATE StartTime = '" + StartTime + " ', FinishTime = '" + FinishTime + " ', BreakTime = ' " + BreakTime + " ', Hours = ' " + Hours + " ', ShiftLeader = ' " + ShiftLeader + "', ShiftSwap = ' ', Responce = ' ', ID = ' '";
                    //string Accept = "UPDATE rota SET StaffID = " + ID + "WHERE StaffID= '" + Session["username"]+"';";
                    string Accept2 = "UPDATE rota SET StaffID = case StaffID when '"+SwapWith+"' then '"+Session["username"]+"' when '"+Session["username"]+"' then '"+SwapWith+"' else StaffID end";
                    MySqlCommand command2 = new MySqlCommand(Accept2, AcceptConnection);
                    int temp2 = Convert.ToInt32(command2.ExecuteNonQuery().ToString());
                }

                using (MySqlConnection RejectConnection = new MySqlConnection(ConnectionString))
                {
                    RejectConnection.Open();
                    string Reject = "DELETE FROM request WHERE StaffID = '"+ID+"'";
                    //('" + ID + "','" + StartTime + " ','" + FinishTime + " ',' " + BreakTime + " ',' " + Hours + " ',' " + ShiftLeader + "', ' ', ' ', ' ')";
                    MySqlCommand command = new MySqlCommand(Reject, RejectConnection);
                    int temp = Convert.ToInt32(command.ExecuteNonQuery().ToString());
                }

                Response.Redirect("Dashboard.aspx");
            }

            if(e.CommandName == "Reject")
            {
                string ConnectionString = "server=localhost;user id=root;password=Letmein16;database=mydb";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script> alert ('Rejected');</script>");



                using (MySqlConnection DeleteConnection = new MySqlConnection(ConnectionString))
                {
                    DeleteConnection.Open();
                    string Delete = "DELETE FROM request WHERE StaffID = '"+ID+"'";
                   //('" + ID + "','" + StartTime + " ','" + FinishTime + " ',' " + BreakTime + " ',' " + Hours + " ',' " + ShiftLeader + "', ' ', ' ', ' ')";
                    MySqlCommand command = new MySqlCommand(Delete, DeleteConnection);
                    int temp = Convert.ToInt32(command.ExecuteNonQuery().ToString());
                }

                Response.Redirect("Dashboard.aspx");



            }

        }

        protected void StaffID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}