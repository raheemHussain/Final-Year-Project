using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace login1
{
    public partial class ShiftChoice : System.Web.UI.Page
    {
        string ConnectionString = "server=localhost;user id=root;password=Letmein16;database=mydb";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            UserDetails.Text = "Username : " + Session["username"];

            using (MySqlConnection sqlcon = new MySqlConnection(ConnectionString))
            {
                sqlcon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM rota WHERE Hours =" + Session["hours"] + " AND StaffID != '" + Session["username"] + "'", sqlcon);
                DataSet Choices = new DataSet();
                sqlDa.Fill(Choices, "Choices");
                StaffID.DataSource = Choices;
                StaffID.DataBind();
            }

            
        }

        protected void StaffID_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = StaffID.Rows[index];

            var ID = row.Cells[0].Text;
            var Day = row.Cells[1].Text;
            var StartTime = row.Cells[2].Text;
            var FinishTime = row.Cells[3].Text;
            var BreakTime = row.Cells[4].Text;
            var Hours = row.Cells[5].Text;
            var ShiftLeader = row.Cells[6].Text;
            var SwapWith = row.Cells[7].Text;

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script> alert ('Request sent');</script>");


            using (MySqlConnection RequestConnection = new MySqlConnection(ConnectionString))
            {
                RequestConnection.Open();
                //string Request = "INSERT INTO request values ('" + ID + "','" + StartTime + " ','" + FinishTime + " ',' " + BreakTime + " ',' " + Hours + " ',' " + ShiftLeader + " ',' " + Session["username"] + "')";
                string Request = "INSERT INTO request values ('" + ID + "' ,'" + Day + " ','" + StartTime + " ',' " + FinishTime + " ',' " + BreakTime + " ',' " + Hours + " ',' " + ShiftLeader + " ',' " + Session["username"] + "')";


                MySqlCommand cmd = new MySqlCommand(Request, RequestConnection);
                int temp = Convert.ToInt32(cmd.ExecuteNonQuery().ToString());
                
                
            }

        }





    }
}

