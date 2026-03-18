using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace DataBoundsControlDemo
{
    public partial class GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid(); // rebind data
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rollNo = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // Safely get new values
            string name = e.NewValues["Name"]?.ToString();
            string course = e.NewValues["Course"]?.ToString();

            using (OracleConnection con = new OracleConnection(
                ConfigurationManager.ConnectionStrings["OracleDBConnectionString"].ConnectionString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(
                    "UPDATE Students SET Name=:name, Course=:course WHERE RollNo=:rollNo", con);

                cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = name;
                cmd.Parameters.Add(":course", OracleDbType.Varchar2).Value = course;
                cmd.Parameters.Add(":rollNo", OracleDbType.Int32).Value = rollNo;

                cmd.ExecuteNonQuery();
            }

            // Exit edit mode and refresh
            GridView1.EditIndex = -1;
            BindGrid();
            //    Response.Redirect(Request.RawUrl); 
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            //   BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rollNo = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            using (OracleConnection con = new OracleConnection(
                ConfigurationManager.ConnectionStrings["OracleDBConnectionString"].ConnectionString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM Students WHERE RollNo=:rollNo", con);
                cmd.Parameters.Add(":rollNo", OracleDbType.Varchar2).Value = rollNo;
                cmd.ExecuteNonQuery();
            }

            GridView1.EditIndex = -1;
            BindGrid();
            //     Response.Redirect(Request.RawUrl);
        }

        private void BindGrid()
        {
            using (OracleConnection con = new OracleConnection(
                ConfigurationManager.ConnectionStrings["OracleDBConnectionString"].ConnectionString))
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM Students", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
              //  GridView1.DataKeyNames = new string[] { "RollNo" }; // important for edit/delete
                GridView1.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(
      ConfigurationManager.ConnectionStrings["OracleDBConnectionString"].ConnectionString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(
                    "INSERT INTO Students (RollNo, Name, Course) VALUES (:rollNo, :name, :course)", con);

                cmd.Parameters.Add(":rollNo", OracleDbType.Int32).Value = Convert.ToInt32(txtRollNo.Text);
                cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = txtName.Text;
                cmd.Parameters.Add(":course", OracleDbType.Varchar2).Value = txtCourse.Text;

                cmd.ExecuteNonQuery();
            }

            // Refresh GridView
            BindGrid();

            // Clear textboxes for next insert
            txtRollNo.Text = "";
            txtName.Text = "";
            txtCourse.Text = "";
        }
    }
}