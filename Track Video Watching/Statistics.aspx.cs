using System;
using System.Data;
using System.Web.UI;

namespace Track_Video_Watching
{
    public partial class Statistics : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowMinPlat_Click(object sender, EventArgs e)
        {
            var mysql = new SqlConnector("db_trackvideowatching");

            var platMin = (DataTable) mysql.Select("SELECT Video_Platform, SUM( TIME_TO_SEC( `length` ) ) FROM tbl_records INNER JOIN tbl_users ON FK_UserId = PK_UserId WHERE Username = @1 GROUP BY Video_Platform;", Request.Cookies["Username"].Value);

            DataTable dt = new DataTable();
            dt.Columns.Add("Platform");
            dt.Columns.Add("Total");

            for (int i = 0; i < platMin.Rows.Count; i++)
            {
                dt.Rows.Add(platMin.Rows[i][0], ((TimeSpan) platMin.Rows[i][1]).Seconds);
            }

            graMinPlat.DataSource = dt;
            graMinPlat.Series["Series1"].XValueMember = "Platform";
            graMinPlat.Series["Series1"].YValueMembers = "Total";
            graMinPlat.Series["Series1"].Label = "#VALX #PERCENT{P0}";
            graMinPlat.DataBind();
        }
    }
}