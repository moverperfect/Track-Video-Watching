using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Track_Video_Watching
{
    public partial class Register : System.Web.UI.Page
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

            var users =  (DataTable)mysql.Select("Select Username, EmailAddress From tbl_users WHERE Username = '" + txtUsername.Text + "' OR EmailAddress = '" +
                         txtEmail.Text + "';");
            if (users.Rows.Count != 0)
            {
                Response.Write("A user already exists with this username/email");
                return;
            }

            var salt = Utilities.GenerateSaltValue();

            var password = Utilities.HashPassword(txtPassword.Text, salt, MD5.Create());

            mysql.NonQuery("INSERT INTO tbl_users ( Username, Password_hash, Salt, EmailAddress) VALUES ('" + txtUsername.Text + "','" + password + "','" + salt + "','" + txtEmail.Text + "');");

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "5;url=Login.aspx";
            Page.Controls.Add(meta);
            Response.Write("Account Creation Successfull, you will now be redirected");
        }
    }
}