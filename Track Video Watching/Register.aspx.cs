using System;
using System.Data;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Track_Video_Watching
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Registers a user given the textbox inputs
        /// </summary>
        protected void cmdRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtCPassword.Text)
            {
                Response.Write("Passwords do not match");
                return;
            }

            var mysql = new SqlConnector("db_trackvideowatching");

            var users =
                (DataTable)
                    mysql.Select("Select Username, EmailAddress From tbl_users WHERE Username = @1 OR EmailAddress = @2;", txtUsername.Text, txtEmail.Text);
            if (users.Rows.Count != 0)
            {
                Response.Write("A user already exists with this username/email");
                return;
            }

            var salt = Utilities.GenerateSaltValue();

            var password = Utilities.HashPassword(txtPassword.Text, salt, MD5.Create());

            mysql.NonQuery("INSERT INTO tbl_users ( Username, Password_hash, Salt, EmailAddress) VALUES ( @1, @2, @3, @4 );", txtUsername.Text, password, salt, txtEmail.Text);

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "5;url=Login.aspx";
            Page.Controls.Add(meta);
            Response.Write("Account Creation Successfull, you will now be redirected");
        }
    }
}