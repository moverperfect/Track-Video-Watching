using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Track_Video_Watching
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var mysql = new SqlConnector("db_trackvideowatching");

            var user =
                (DataTable)
                    mysql.Select("SELECT PK_UserID, Username, Password_Hash, Salt FROM tbl_users WHERE Username = '" + Request.Cookies["Username"].Value + "';");

            if (user.Rows.Count == 0)
            {
                Response.Write("You are not logged in, please log in");
                return;
            }

            if (Utilities.HashPassword(user.Rows[0][1].ToString() + user.Rows[0][2], user.Rows[0][3].ToString(), MD5.Create()) ==
                Request.Cookies["Token"].Value)
            {
                var videos = mysql.Count("SELECT COUNT(*) FROM tbl_records WHERE FK_UserID = '" + user.Rows[0][0] + "';");
                Response.Write("Welcome back " + Request.Cookies["Username"].Value + ", you have " + videos + " video in our database");
                return;
            }
            Response.Write("Authentication failed");
        }

        protected void btnAddVideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewVideo.aspx");
        }
    }
}