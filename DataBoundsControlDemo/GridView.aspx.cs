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
    }
}