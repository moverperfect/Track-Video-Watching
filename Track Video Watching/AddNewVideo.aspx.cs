using System;
using System.Data;
using System.Security.Cryptography;
using System.Web.UI;

namespace Track_Video_Watching
{
    public partial class AddNewVideo : Page
    {
        /// <summary>
        /// Sets calendar to the current day
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.TodaysDate = DateTime.Today;
            Calendar1.SelectedDate = DateTime.Today;
        }

        /// <summary>
        /// Makes the other textbox visibile when it is selected
        /// </summary>
        protected void cboPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlatform.Visible = cboPlatform.Text == "Other";
        }

        /// <summary>
        /// Adds all of the information for the new video to the database
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var mysql = new SqlConnector("db_trackvideowatching");

            var user =
                (DataTable)
                    mysql.Select("SELECT PK_UserID, Username, Password_Hash, Salt FROM tbl_users WHERE Username = @1;", Request.Cookies["Username"].Value);

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
                mysql.NonQuery("INSERT INTO tbl_records ( FK_UserID, Video_Platform, Date_Watched, Channel, Length) VALUES ( @1, @2, @3, @4, @5:@6:@7 );", user.Rows[0][0].ToString(), platform, Calendar1.SelectedDate.ToString("yyyy-MM-dd"), txtChannel.Text, txtHour.Text, txtMin.Text, txtSec.Text);
                cboPlatform.Text = "YouTube";
                txtPlatform.Text = "";
                txtChannel.Text = "";
                txtHour.Text = "";
                txtMin.Text = "";
                txtSec.Text = "";
                Response.Write("Video has been added to database");
                return;
            }
            Response.Write("Authentication failed");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}