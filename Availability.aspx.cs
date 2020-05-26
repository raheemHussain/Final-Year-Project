using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace login1
{
    public partial class Availability : System.Web.UI.Page
    {
        string ConnectionString = "server=localhost;user id=root;password=Letmein16;database=mydb";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login1.aspx");
            }

            using (MySqlConnection sqlcon = new MySqlConnection(ConnectionString))
            {
                sqlcon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM staff", sqlcon);
                DataTable dtb1 = new DataTable();
                sqlDa.Fill(dtb1);
                StaffID.DataSource = dtb1;
                StaffID.DataBind();
            }
        }
    }
}