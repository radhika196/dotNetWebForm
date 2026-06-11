using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace dotNetWebForm
{
    public partial class EmpForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=RADHIKA\\SQLEXPRESS;initial catalog=DotNetDb;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginCredentialId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowData();
            }
           
        }

        public void ClearData()
        {
            empTxt.Text = string.Empty;
            ageTxt.Text = string.Empty;
            deptTxt.Text = string.Empty;
            salaryTxt.Text = string.Empty;
            txtSearch.Text = string.Empty;
            ddlEmplChoice.SelectedValue = "0";
        }



        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(empTxt.Text))
            {
                if (submitBtn.Text.Equals("Submit"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Employee(empName,empSalary,department,empAge)values('" + empTxt.Text + "', '" + salaryTxt.Text + "','" + deptTxt.Text + "', '" + ageTxt.Text + "'  )", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ClearData();
                    ShowData();

                }
                else if (submitBtn.Text.Equals("Update"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update Employee set empName='"+empTxt.Text+"',empSalary='"+salaryTxt.Text+"',department='"+deptTxt.Text+"',empAge='"+ageTxt.Text+"' ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ClearData();
                    ShowData();
                }
            }
            else
            {
                Response.Write("-----Please provide all the details!------");
            }

        }

        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("deleteCmd"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from Employee where id='" + e.CommandArgument + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                ShowData();

            }
            else if (e.CommandName.Equals("editCmd"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employee where id='"+e.CommandArgument+"'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                empTxt.Text = dt.Rows[0][1].ToString();
                salaryTxt.Text = dt.Rows[0][2].ToString();
                deptTxt.Text = dt.Rows[0][3].ToString();
                ageTxt.Text = dt.Rows[0][4].ToString();
                submitBtn.Text = "Update";
                conn.Close();
            }

        }
        public void ShowData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Employee", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdView.DataSource = dt;
            grdView.DataBind();
            conn.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SearchEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ddl", ddlEmplChoice.SelectedValue);
                cmd.Parameters.AddWithValue("@searchTxt", txtSearch.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Close();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grdView.DataSource = dt;
                grdView.DataBind();
            }
            else
            {
                Response.Write("Please provide the input");
            }
        }
    }
}