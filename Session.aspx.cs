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
    public partial class Session : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["MyDbConnectionStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                GetData();
            }
        }
        private void GetData()
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "select * from SessionTB";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            GridView1.DataSource = sqlDataReader;
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "insert into SessionTB(SessionName) values ('" + txtSessionName.Text + "')";
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
            txtSessionName.Text = string.Empty;

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection sqlConnection = new SqlConnection(constring);
            string query = "Delete from SessionTB where ID=" + id;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            lblMessage.Text = "Data Saves Successfully!";
            ResetValues();

            if (row > 0)
            {
                GetData();
            }
        }
    }
}

    