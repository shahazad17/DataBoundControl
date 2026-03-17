using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBoundsControlDemo
{
    public partial class DetailsViewDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetails();
            }
        }

        private void BindDetails()
        {
            using (OracleConnection con = new OracleConnection(
                ConfigurationManager.ConnectionStrings["OracleDBConnectionString"].ConnectionString))
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM Students", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DetailsView1.DataSource = dt;
                    DetailsView1.DataBind();
                }
                else
                {
                    DetailsView1.DataSource = null;
                    DetailsView1.DataBind();
                    Label1.Text = "No records found in Students table.";
                }
            }
        }
    }
}