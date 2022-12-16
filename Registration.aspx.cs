using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace School_Fees_Management
{
    public partial class Registration : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["MyDbConnectionStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MyData"] = "Gurudev shri Trilok Ji maharaj";
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    GetDataByID(Request.QueryString["id"]);
                }
                GetData();
            }

        }
        private void GetData()
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "select * from StudentTB";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            GridView1.DataSource = sqlDataReader;
            GridView1.DataBind();

        }
        private void GetDataByID(string id)
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "select * from StudentTB where id=" + id;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {
                txtName.Text = dataSet.Tables[0].Rows[0]["STName"].ToString();
                txtMotherName.Text = dataSet.Tables[0].Rows[0]["MotherName"].ToString();
                txtFatherName.Text = dataSet.Tables[0].Rows[0]["FatherName"].ToString();
                txtMobile.Text = dataSet.Tables[0].Rows[0]["Mobile"].ToString();
                txtEnrollno.Text = dataSet.Tables[0].Rows[0]["EnrollNo"].ToString();
                hdnID.Value = dataSet.Tables[0].Rows[0]["ID"].ToString();
            }
            sqlConnection.Close();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string query = "";
               SqlConnection sqlConnection = new SqlConnection(constring);
            if (string.IsNullOrEmpty(hdnID.Value))
            {
                query = "insert into StudentTB(STName,FatherName,MotherName,Mobile,EnrollNo) values ('" + txtName.Text + "','" + txtFatherName.Text + "','" + txtMotherName.Text + "','" + txtMobile.Text + "','" + txtEnrollno.Text + "')";
            }
            else
            {
                query = "update StudentTB set STName='" + txtName.Text + "',FatherName='" + txtFatherName.Text + "',MotherName='" + txtMotherName.Text + "',Mobile='" + txtMobile.Text + "',EnrollNo='" + txtEnrollno.Text + "' where id=" + hdnID.Value;
            }
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            lblMessage.Text = "Data Saves Successfully!";
            ResetValues();
            Response.Redirect("~/Registration.aspx");
        }
        private void ResetValues()
        {
            txtName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEnrollno.Text = string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = " Delete from StudentTB where ID = " + id;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (row > 0)
            {
                GetData();
            }
        }
    }
}