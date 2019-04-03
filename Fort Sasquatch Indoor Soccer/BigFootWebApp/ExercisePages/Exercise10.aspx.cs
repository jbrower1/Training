using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using FSISSystem.JBrow.Data;
using FSISSystem.JBrow.BLL;
#endregion

namespace BigFootWebApp.ExercisePages
{
    public partial class Exercise10 : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void TeamGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a supplier to view the supplier products.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                TeamGridView.DataSource = null;
                TeamGridView.DataBind();
            }
            else
            {
                try
                {
                    TeamController sysmgr = new TeamController();
                    List<Team> info = sysmgr.Team_Get(int.Parse(TeamList.SelectedValue));
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the selected team");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));

                        //GridView
                        TeamGridView.DataSource = info;
                        TeamGridView.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
    }
}