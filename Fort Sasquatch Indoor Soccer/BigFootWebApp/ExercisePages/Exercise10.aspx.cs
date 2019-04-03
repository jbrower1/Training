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
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a supplier to view the supplier products.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                PlayerGridView.DataSource = null;
                PlayerGridView.DataBind();
            }
            else
            {
                try
                {

                    TeamController TeamGetInfo = new TeamController();
                    Team TeamInfo = TeamGetInfo.Team_Find(int.Parse(TeamList.SelectedValue));

                    Coach.Text = TeamInfo.Coach;
                    AssistantCoach.Text = TeamInfo.AssistantCoach;
                    if(TeamInfo.Wins == null)
                    {
                        Wins.Text = "0";
                    }
                    else
                    {
                        Wins.Text = TeamInfo.Wins.ToString();
                    }
                    
                    if (TeamInfo.Losses == null)
                    {
                        Losses.Text = "0";
                    }
                    else
                    {
                        Losses.Text = TeamInfo.Losses.ToString();
                    }
                    
                   
                    
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
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
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a supplier to view the supplier products.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                PlayerGridView.DataSource = null;
                PlayerGridView.DataBind();
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    List<Player> info = sysmgr.Players_GetByTeam(int.Parse(TeamList.SelectedValue));
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the selected team");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.FullName.CompareTo(y.FullName));

                        //GridView
                        PlayerGridView.DataSource = info;
                        PlayerGridView.DataBind();

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