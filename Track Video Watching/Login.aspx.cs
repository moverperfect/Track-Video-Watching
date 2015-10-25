using System;
using System.Data;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;

namespace Track_Video_Watching
{
    public partial class Login : Page
    {
        /// <summary>
        /// On page load, remove any cookies that the user has
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            // If they dont have any cookies then return
            var httpCookie = Request.Cookies["UserId"];
            if (httpCookie == null) return;

            // Remove the cookies if they have them
            Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Token"].Expires = DateTime.Now.AddDays(-1);
        }

        /// <summary>
        /// Check details and login to page
        /// </summary>
        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            incorrectPassword.Visible = false;
            incorrectUser.Visible = false;

            var mysql = new SqlConnector("db_trackvideowatching");

            var users =
                (DataTable)
                    mysql.Select("SELECT Username, Password_Hash, Salt FROM tbl_Users WHERE Username = @1;", txtUsername.Value);
            if (users.Rows.Count != 0)
            {
                if (txtPassword.Value != "" && Utilities.HashPassword(txtPassword.Value, users.Rows[0][2].ToString(), MD5.Create()) == users.Rows[0][1].ToString())
                {
                    var coookieValue = Utilities.HashPassword(txtUsername.Value + users.Rows[0][1],
                        users.Rows[0][2].ToString(),
                        MD5.Create());
                    Response.Cookies.Add(new HttpCookie("Username", txtUsername.Value));
                    Response.Cookies.Add(new HttpCookie("Token", coookieValue));
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    incorrectPassword.Visible = true;
                }
            }
            else
            {
                incorrectUser.Visible = true;
            }
        }
    }
}