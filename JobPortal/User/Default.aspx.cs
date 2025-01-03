using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.User
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection cdm;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        //protected void btnSend_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch

        //}
    }
}