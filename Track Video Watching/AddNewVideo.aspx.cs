using System;
using System.Data;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Web.UI;

namespace Track_Video_Watching
{
    public partial class AddNewVideo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.TodaysDate = DateTime.Today;
            Calendar1.SelectedDate = DateTime.Today;
        }

        protected void cboPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlatform.Visible = cboPlatform.Text == "Other";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
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
                var platform = cboPlatform.Text;
                if (cboPlatform.Text == "Other")
                {
                    platform = txtPlatform.Text;
                }
                mysql.NonQuery("INSERT INTO tbl_records ( FK_UserID, Video_Platform, Date_Watched, Channel, Length) VALUES ('" + user.Rows[0][0] + "','" + platform + "','" + Calendar1.SelectedDate.ToString("yyyy-MM-dd") + "','" + txtChannel.Text + "','" + txtHour.Text + ":" + txtMin.Text + ":" + txtSec.Text + "');");
                Response.Write("Video has been added to database");
            }
            Response.Write("Authentication failed");
        }
    }
}