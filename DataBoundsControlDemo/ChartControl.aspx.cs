using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBoundsControlDemo
{
    public partial class ChartControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/Books.xml"));

                Chart1.DataSource = ds.Tables[0];
                Chart1.Series["BooksSeries"].XValueMember = "Author";
                Chart1.Series["BooksSeries"].YValueMembers = "BookID"; // must be numeric
                Chart1.DataBind();
            }
        }
    }
}