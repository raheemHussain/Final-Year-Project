﻿using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace login1
{
    public partial class Accept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login1.aspx");
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script> alert ('Request sent');</script>");

            using (MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=Letmein16;database=mydb"))
            {
                sqlcon.Open();
                string query = "SELECT count(*) FROM login WHERE UserName = '" + Session["username"] + "' AND (UserType = 1 OR UserType = 2)";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlcon);
                int UserType = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (UserType > 0) //Depending on how many users
                {
                    Availability.Visible = true;

                }
                else { Availability.Visible = false; }

                string query2 = "SELECT Hours from rota WHERE StaffID='" + Session["username"] + "'";
                MySqlCommand sqlCmd2 = new MySqlCommand(query2, sqlcon);
                int hours = Convert.ToInt32(sqlCmd2.ExecuteScalar());

                UserDetails.Text = "Username : " + Session["username"];
            }

        }

        protected void Dash_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rota.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shiftswap.aspx");
        }

        protected void Logout_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login1.aspx");
        }

        protected void Availability_Click(object sender, EventArgs e)
        {
            Response.Redirect("Availability.aspx");
        }
    }
}