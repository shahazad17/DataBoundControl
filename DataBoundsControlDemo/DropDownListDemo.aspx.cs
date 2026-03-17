using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBoundsControlDemo
{
    public partial class DropDownListDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OracleConnection con = new OracleConnection(
                    ConfigurationManager.ConnectionStrings["OracleDBConnectionString"].ConnectionString);
                OracleCommand cmd = new OracleCommand("SELECT Name FROM Students", con);
                con.Open();
                OracleDataReader dr = cmd.ExecuteReader();
                DropDownList1.DataSource = dr;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataBind();
                con.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = DropDownList1.SelectedItem.Text;
            Label1.Text = "Selected Student: " + selectedName;
        }
    }
}