using System;
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
    }
}