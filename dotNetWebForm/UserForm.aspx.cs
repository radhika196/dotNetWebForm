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
    public partial class UserForm : System.Web.UI.Page
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
                BindGridData();
                BindCountry();
            }
           
        }

        public void BindCountry()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectCountry", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataTextField = "countryName";
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindState()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectState", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", ddlCountry.SelectedValue);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            ddlState.DataValueField = "stateId";
            ddlState.DataTextField = "stateName";
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCity()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SelectCityById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId",ddlState.SelectedValue);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            ddlCity.DataValueField = "cityId";
            ddlCity.DataTextField = "cityName";
            ddlCity.DataSource = dt;
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindGridData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("JoinGridData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            gVUser.DataSource = dt;
            gVUser.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtuserName.Text))
            {
                if (btnSubmit.Text.Equals("Submit"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("InsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name",txtuserName.Text);
                    cmd.Parameters.AddWithValue("@Country",ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State",ddlState.SelectedValue);
                    cmd.Parameters.AddWithValue("@City",ddlCity.SelectedValue);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    BindGridData();
                    ClearData();
                }else if (btnSubmit.Text.Equals("Update"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ViewState["uid"]);
                    cmd.Parameters.AddWithValue("@Name", txtuserName.Text);
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", ddlState.SelectedValue);
                    cmd.Parameters.AddWithValue("@City", ddlCity.SelectedValue);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    BindGridData();
                    ClearData();
                    btnSubmit.Text = "Submit";
                }
            }
            else
            {
                Response.Write("Please provide all the details");
            }

        }

        public void ClearData()
        {
            txtuserName.Text = String.Empty;
            ddlCountry.SelectedValue = "0";
            ddlState.SelectedValue = "0";
            ddlCity.SelectedValue = "0";
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void gVUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("deleteCmd"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                conn.Close();
                BindGridData();
            }else if (e.CommandName.Equals("editCmd"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",e.CommandArgument);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Close();
                adapter.Fill(dt);
                txtuserName.Text = dt.Rows[0]["userName"].ToString();
                ddlCountry.SelectedValue = dt.Rows[0]["userCountry"].ToString();
                BindState();
                ddlState.SelectedValue = dt.Rows[0]["userState"].ToString();
                BindCity();
                ddlCity.SelectedValue = dt.Rows[0]["userCity"].ToString();
                ViewState["uid"] = e.CommandArgument;
                btnSubmit.Text = "Update";
            }

        }
    }
}