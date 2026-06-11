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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=RADHIKA\\SQLEXPRESS;initial catalog=DotNetDB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginCredentialId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        public void clearData()
        {
            txtOldPassword.Text = string.Empty;
            txtCnfNewPassword.Text = string.Empty;
        }

        protected void btnChangepass_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Equals(txtCnfNewPassword.Text))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update RegistrationTbl set password='" + txtNewPassword.Text + "' where rid='" + Session["loginCredentialId"] + "' and password='" + txtOldPassword.Text + "'", conn);
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                clearData();
                if (i == 0)
                {
                    lblChangePass.Text = "Old Password do not match!!";
                }
                else if (i == 1)
                {
                    lblChangePass.Text = "Password changed successfully";
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                lblChangePass.Text = "Password do not match!!";
            }

        }
    }
}