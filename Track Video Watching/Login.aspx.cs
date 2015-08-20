using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Track_Video_Watching
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Register.aspx");
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {

        }
    }
}