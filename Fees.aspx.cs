using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace School_Fees_Management
{
    public partial class Fees : System.Web.UI.Page
    {
        string constring = "server=DESKTOP-C0J1D8E;database=SchoolFeesManagement; integrated security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                GetSessionDropDownData();
                GetClassDropDownData();
            }
        }
        public void GetSessionDropDownData()
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "select * from SessionTB";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DropDownList1.DataSource = sqlDataReader;
            DropDownList1.DataTextField = "SessionName";
            DropDownList1.DataValueField = "ID";
           
            DropDownList1.DataBind();
        }
        public void GetClassDropDownData()
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "select * from ClassCategory";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DropDownList2.DataSource = sqlDataReader;
            DropDownList2.DataTextField = "ClName" +
                "";
            DropDownList2.DataValueField = "ID";
          
            DropDownList2.DataBind();

        }
        private void GetData()
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "select * from Fees";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            GridView1.DataSource = sqlDataReader;
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "insert into Fees(Amount) values ('" + txtAmount.Text + "')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            lblMessage.Text = "Data Saves Successfully!";
            ResetValues();
            GetData();
        }
        public void ResetValues()
        {
            txtAmount.Text = string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetValues();
        }
    }
}