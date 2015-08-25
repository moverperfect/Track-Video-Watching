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

            var platMin = (DataTable) mysql.Select("SELECT Video_Platform, Length FROM tbl_records GROUP BY Video_Platform;");

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