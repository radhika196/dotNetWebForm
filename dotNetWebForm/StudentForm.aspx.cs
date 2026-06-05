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
    public partial class StudentForm : System.Web.UI.Page
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
                BindData();
                BindGender();
                BindCourse();
                BindCity();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtStudName.Text))
            {
                if (btnSubmit.Text.Equals("Submit"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("InsertStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", txtStudName.Text);
                    cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@Course", ddlCourse.SelectedValue);
                    cmd.Parameters.AddWithValue("@City", ddlCity.SelectedValue);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    BindData();
                    ClearData();

                }
                else if (btnSubmit.Text.Equals("Update"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ViewState["studId"]);
                    cmd.Parameters.AddWithValue("@Name", txtStudName.Text);
                    cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@Course", ddlCourse.SelectedValue);
                    cmd.Parameters.AddWithValue("@City", ddlCity.SelectedValue);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    BindData();
                    ClearData();
                    btnSubmit.Text = "Submit";

                }
            }
            else
            {
                Response.Write("Please provide all the data!!");
            }



        }

        protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("deleteBtn"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteStudent ", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                conn.Close();
                BindData();


            }
            else if (e.CommandName.Equals("editBtn"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtStudName.Text = dt.Rows[0]["studentName"].ToString();
                rblGender.SelectedValue = dt.Rows[0]["studentGender"].ToString();
                ddlCourse.SelectedValue = dt.Rows[0]["studentCourse"].ToString();
                ddlCity.SelectedValue = dt.Rows[0]["studentCity"].ToString();
                ViewState["studId"] = e.CommandArgument;
                btnSubmit.Text = "Update";
                conn.Close();

            }
        }

        public void BindData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("JoinStudent", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvStudent.DataSource = dt;
            gvStudent.DataBind();
            conn.Close();
        }

        public void BindGender()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectGender", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rblGender.DataValueField = "genderId";
            rblGender.DataTextField = "genderName";
            rblGender.DataSource = dt;
            rblGender.Items.Insert(0, new ListItem("--Select--", "0"));
            rblGender.DataBind();
            conn.Close();
        }
        public void BindCourse()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectCourse", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlCourse.DataValueField = "courseId";
            ddlCourse.DataTextField = "courseName";
            ddlCourse.DataSource = dt;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("--Select--", "0"));
            conn.Close();
        }
        public void BindCity()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectCity", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlCity.DataValueField = "cityId";
            ddlCity.DataTextField = "cityName";
            ddlCity.DataSource = dt;
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));
            conn.Close();
        }

        public void ClearData()
        {
            txtStudName.Text = String.Empty;
            rblGender.ClearSelection();
            ddlCourse.SelectedValue = "0";
            ddlCity.SelectedValue = "0";
        }
    }
}