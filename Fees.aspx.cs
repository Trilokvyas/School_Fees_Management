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
        string constring = ConfigurationManager.ConnectionStrings["MyDbConnectionStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            { 
                GetData();
                GetSessionDropDownData();
                GetClassDropDownData();
            }
        }
        public void GetSessionDropDownData()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(constring);
                string query = "select * from SessionTB";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                ddlSession.DataSource = sqlDataReader;
                ddlSession.DataTextField = "SessionName";
                ddlSession.DataValueField = "ID";
                ddlSession.DataBind();
            }catch(Exception ex) { }
        }
        public void GetClassDropDownData()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(constring);
                string query = "select * from ClassCategory";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                ddlClass.DataSource = sqlDataReader;
                ddlClass.DataTextField = "ClName";
                ddlClass.DataValueField = "ID";
                ddlClass.DataBind();
            }catch(Exception ex) { }
        }
        private void GetData()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(constring);
                string query = "select f.ID,s.SessionName,c.ClName,f.Amount from Fees f join [dbo].[SessionTB] s  on f.sessionID=s.ID join ClassCategory c on f.ClassCategoryID=c.ID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                GridView1.DataSource = sqlDataReader;
                GridView1.DataBind();
            }catch(Exception ex) { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(constring);
                string query = "insert into Fees(ClassCategoryID,SessionID,Amount) values (" + ddlClass.Text + "," + ddlSession.Text + "," + txtAmount.Text + ")";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                int row = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                lblMessage.Text = "Data Saves Successfully!";
                ResetValues();
                GetData();
            }catch(Exception ex)
            {
                 
            }
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