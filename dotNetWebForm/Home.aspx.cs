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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=RADHIKA\\SQLEXPRESS;initial catalog=DotNetDB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginCredentialId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindLoginData();
            }

        }

        public void BindLoginData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from RegistrationTbl where rid='"+ Session["loginCredentialId"] + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            gvHomePage.DataSource = dt;
            gvHomePage.DataBind();

        }

        protected void gvHomePage_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}