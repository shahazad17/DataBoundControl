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
    public partial class FormVIew : System.Web.UI.Page
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
                FormView1.DataSource = dt;
                FormView1.DataBind();

            }

        }
        /*
        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            FormView1.PageIndex = e.NewPageIndex;
            BindDetails(); // rebind your data source
        }
        */

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            FormView1.PageIndex = e.NewPageIndex;
           BindDetails();
        }
    }
}