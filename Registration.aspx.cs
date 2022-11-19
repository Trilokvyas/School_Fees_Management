using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace School_Fees_Management
{
    public partial class Registration : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["MyDbConnectionStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "insert into StudentTB(STName,FatherName,MotherName,Mobile,EnrollNo) values ('" + txtName.Text + "','" + txtFatherName.Text + "','" + txtMotherName.Text + "','"+txtMobile.Text+"','"+txtEnrollno.Text+"')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            lblMessage.Text = "Data Saves Successfully!";
            ResetValues();
            GetData();
        }
        private void ResetValues()
        {
            txtName.Text = string.Empty;
            txtFatherName.Text= string.Empty;
            txtMotherName.Text= string.Empty;
            txtMobile.Text= string.Empty;
            txtEnrollno.Text= string.Empty;
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