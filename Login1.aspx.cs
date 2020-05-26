using System;
using MySql.Data.MySqlClient;

namespace login1
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            using (MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=Letmein16;database=mydb"))
            {
                sqlcon.Open();
                string query = "SELECT * FROM login WHERE username=@username AND password=@password ";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlcon);
                sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int Users = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (Users > 0) //Depending on how many users
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Dashboard.aspx");
                }
                else { lblErrorMessage.Visible = true; }


            }
        }
    }
}