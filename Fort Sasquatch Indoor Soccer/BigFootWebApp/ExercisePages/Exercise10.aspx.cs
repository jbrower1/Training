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
            if (!Page.IsPostBack)
            {
                BindTeamList();
            }
        }
        protected void BindTeamList()
        {
            try
            {
                TeamController sysmgr = new TeamController();

                List<Team> datainfo = sysmgr.Team_List();

                datainfo.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = datainfo;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "select ....");
            }
            catch (Exception ex)
            {

                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (TeamList.SelectedIndex == 0)
        //    {
        //        errormsgs.Add("Select a supplier to view the supplier products.");
        //        LoadMessageDisplay(errormsgs, "alert alert-info");
        //        TeamGridView.DataSource = null;
        //        TeamGridView.DataBind();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            TeamController sysmgr = new TeamController();
        //            List<Team> info = sysmgr.Team_Find(int.Parse(TeamList.SelectedValue));
        //            if (info.Count == 0)
        //            {
        //                errormsgs.Add("No data found for the selected team");
        //                LoadMessageDisplay(errormsgs, "alert alert-info");
        //            }
        //            else
        //            {
        //                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));

                //                //GridView
                //                TeamGridView.DataSource = info;
                //                TeamGridView.DataBind();

                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            errormsgs.Add(GetInnerException(ex).ToString());
                //            LoadMessageDisplay(errormsgs, "alert alert-danger");
                //        }
                //    }
        }
        protected Exception GetInnerException(Exception ex)
        {
            
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
        //    
        }
    }
}