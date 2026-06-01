using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dotNetWebForm
{
    public partial class Registration : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection("data source=RADHIKA\\SQLEXPRESS;initial catalog=DotNetDB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        public void BindData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from RegistrationTbl", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            gvRegistration.DataSource = dt;
            gvRegistration.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                if (txtEmail.Text.Contains("@"))
                {
                    if (btnSubmit.Text.Equals("Submit"))
                    {
                        String imageFileName = Path.GetFileName(fuImage.PostedFile.FileName);
                        fuImage.SaveAs(Server.MapPath("Pics" + "\\" + imageFileName));
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("insert into RegistrationTbl(name,emailId,password,image)values('" + txtName.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + imageFileName + "')", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        BindData();
                        ClearData();
                    }
                    else if (btnSubmit.Text.Equals("Update"))
                    {
                        String imageFileName = Path.GetFileName(fuImage.PostedFile.FileName);
                        if (!String.IsNullOrEmpty(imageFileName))
                        {
                            File.Delete(Server.MapPath("Pics" + "\\" + ViewState["img"]));
                            fuImage.SaveAs(Server.MapPath("Pics" + "\\" + imageFileName));
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("update RegistrationTbl set name='" + txtName.Text + "', emailId='" + txtEmail.Text + "',password='" + txtPassword.Text + "',image='" + imageFileName + "' where rid='" + ViewState["id"] + "'", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                           
                        }
                        else if(String.IsNullOrEmpty(imageFileName))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("update RegistrationTbl set name='" + txtName.Text + "', emailId='" + txtEmail.Text + "',password='" + txtPassword.Text + "' where rid='" + ViewState["id"] + "'", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        BindData();
                        ClearData();
                        btnSubmit.Text = "Submit";
                    }
                }
                else
                {
                    Response.Write("Please provide the correct email id!");
                }

            }
            else
            {
                Response.Write("Please provide all the details!!");
            }

        }

        public void ClearData()
        {
            txtName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        protected void gvRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("deleteCmd"))
            {
                String[] cmdArgument = e.CommandArgument.ToString().Split(',');
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from RegistrationTbl where rid='" + cmdArgument[0] + "' ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                BindData();
                File.Delete(Server.MapPath("Pics" + "\\" + cmdArgument[1]));

            }
            else if (e.CommandName.Equals("editCmd"))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from RegistrationTbl where rid='" + e.CommandArgument + "'", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Close();
                adapter.Fill(dt);
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtEmail.Text = dt.Rows[0]["emailId"].ToString();
                txtPassword.Text = dt.Rows[0]["password"].ToString();
                ViewState["img"] = dt.Rows[0]["image"].ToString();
                btnSubmit.Text = "Update";
                ViewState["id"] = e.CommandArgument;
                

            }

        }
    }
}