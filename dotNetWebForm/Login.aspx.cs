using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dotNetWebForm
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=RADHIKA\\SQLEXPRESS;initial catalog=DotNetDB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtLoginEmail.Text) && !String.IsNullOrEmpty(txtLoginPassword.Text))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from RegistrationTbl where emailId='"+txtLoginEmail.Text+ "' and password='"+txtLoginPassword.Text+"'", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Close();
                adapter.Fill(dt);
                if(dt.Rows.Count==1)
                {
                    Session["loginCredentialId"] = dt.Rows[0]["rid"];
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    labelLogin.Text = "Login Failed!!";
                }


            }
            else
            {
                labelLogin.Text = "Please provide all the details!!";
            }

        }
    }
}