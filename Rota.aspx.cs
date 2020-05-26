using System;
using MySql.Data.MySqlClient;
using System.Data;


namespace login1
{
    public partial class Rota : System.Web.UI.Page
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
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM rota", sqlcon);
                DataSet Rota = new DataSet();
                sqlDa.Fill(Rota, "Rota");
                StaffID.DataSource = Rota;
                StaffID.DataBind();
            }
        }

        protected void StaffID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}