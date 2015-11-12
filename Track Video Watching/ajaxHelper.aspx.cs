using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Track_Video_Watching
{
    public partial class ajaxHelper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Request.QueryString["action"];
            var format = Request.QueryString["format"];
            var search = Request.QueryString["search"];
            Response.Clear();
            var sql = new SqlConnector("db_trackvideowatching");

            switch (action)
            {
                case "channelsearch":
                    if (format == "json")
                    {
                        var channels =
                            (DataTable) sql.Select("SELECT Channel FROM tbl_records GROUP BY CHANNEL ORDER BY Channel;");

                        Response.Write("[");
                        foreach (DataRow row in channels.Rows)
                        {
                            Response.Write("\"" + row[0] + "\"");
                            if (row != channels.Rows[channels.Rows.Count - 1])
                                Response.Write(",");
                        }
                        Response.Write("]");
                    }
                    break;
            }
        }
    }
}