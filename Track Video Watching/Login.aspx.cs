using System;
using System.Data;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;

namespace Track_Video_Watching
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Redirect to register page
        /// </summary>
        protected void cmdRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Register.aspx");
        }

        /// <summary>
        /// Check details and login to page
        /// </summary>
        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            var mysql = new SqlConnector("db_trackvideowatching");

            var users =
                (DataTable)
                    mysql.Select("SELECT Username, Password_Hash, Salt FROM tbl_Users WHERE Username = '" +
                                 txtUsername.Text + "';");
            if (users.Rows.Count != 0)
            {
                var matchHash = Utilities.HashPassword(txtPassword.Text, users.Rows[0][2].ToString(), MD5.Create());
                if (matchHash == users.Rows[0][1].ToString())
                {
                    var coookieValue = Utilities.HashPassword(txtUsername.Text + users.Rows[0][1].ToString(), users.Rows[0][2].ToString(), 
                        MD5.Create());
                    Response.Cookies.Add(new HttpCookie("Username", txtUsername.Text));
                    Response.Cookies.Add(new HttpCookie("Token", coookieValue));
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Response.Write("Incorrect password");
                }
            }
            else
            {
                Response.Write("No such user exists");
            }
        }
    }
}