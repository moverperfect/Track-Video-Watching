using System;
using System.Data;
using System.Web.UI;

namespace Track_Video_Watching
{
    public partial class Statistics : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var mysql = new SqlConnector("db_trackvideowatching");

                var list =
                    (DataTable)
                        mysql.Select(
                            "SELECT Video_Platform FROM tbl_records INNER JOIN tbl_users ON FK_UserId = PK_UserId WHERE Username = @1 GROUP by Video_Platform;",
                            Request.Cookies["Username"].Value);
            
                cboChannel.DataSource = list;
                cboChannel.DataTextField = "Video_Platform";
                cboChannel.DataBind();
            }
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
               dt.Rows.Add(platMin.Rows[i][0], Convert.ToInt32(platMin.Rows[i][1])/60);
            }

            graMinPlat.DataSource = dt;
            graMinPlat.Series["Series1"].XValueMember = "Platform";
            graMinPlat.Series["Series1"].YValueMembers = "Total";
            graMinPlat.Series["Series1"].Label = "#VALX #VALY Minutes #PERCENT{P0}";
            graMinPlat.DataBind();
        }

        protected void btnShowMinChan_Click(object sender, EventArgs e)
        {
            var mysql = new SqlConnector("db_trackvideowatching");

            var list =
                (DataTable)
                    mysql.Select(
                        "SELECT Channel, SUM( TIME_TO_SEC( `length` ) ) as Total FROM tbl_records INNER JOIN tbl_users ON FK_UserId = PK_UserId WHERE Username = @1 AND Video_Platform = @2 GROUP BY Channel ORDER BY Total DESC",
                        Request.Cookies["Username"].Value, cboChannel.SelectedValue);

            DataTable dt = new DataTable();
            dt.Columns.Add("Channel");
            dt.Columns.Add("Total");

            for (int i = 0; i < list.Rows.Count; i++)
            {
                dt.Rows.Add(list.Rows[i][0], Convert.ToInt32(list.Rows[i][1]) / 60);
            }

            graMinCha.DataSource = dt;
            graMinCha.Series["Series1"].XValueMember = "Channel";
            graMinCha.Series["Series1"].YValueMembers = "Total";
            graMinCha.Series["Series1"].Label = "#VALX #PERCENT{P0}";
            graMinCha.Series["Series1"].LegendText = "#VALX #VALY Minutes #PERCENT{p0}";
            graMinCha.Series["Series1"].IsValueShownAsLabel = true;
            graMinCha.Series["Series1"].IsVisibleInLegend = true;
            graMinCha.Legends.Add("Legend1");
            graMinCha.DataBind();
        }
    }
}