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
            //Works
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
                //Works
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
        protected Exception GetInnerException(Exception ex)
        {
            //works
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            //works
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void SearchButton_Click1(object sender, EventArgs e)
        {
            PlayerGridView.DataSource = null;
            PlayerGridView.DataBind();
            //WORKS!
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a Team to veiw Players.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                Teaminfo = null;
                Coach.Text = null;
                AssistantCoach.Text = null;
                Wins.Text = "0";
                Losses.Text = "0";
                PlayerGridView.DataSource = null;
                PlayerGridView.DataBind();
            }
            else
            {
                try
                {

                    TeamController sysmgr = new TeamController();
                    Team TeamInfo = sysmgr.Team_Get(int.Parse(TeamList.SelectedValue));

                    if (TeamInfo == null)
                    {
                        errormsgs.Add("TeamInfo Not Bound");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {

                        Coach.Text = TeamInfo.Coach;
                        AssistantCoach.Text = TeamInfo.AssistantCoach;
                        if (TeamInfo.Wins == null)
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
                    PlayerController plyrmgr = new PlayerController();
                    List<Player> info = plyrmgr.Players_GetByTeam(int.Parse(TeamList.SelectedValue));
                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the selected team");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        info.Sort((x, y) => x.FullName.CompareTo(y.FullName));


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
        protected string HandlePlayerGender(string Gender)
        {
            if (Gender == "F")
            {
                return "Female";
            }
            else if (Gender == "M")
            {
                return "Male";
            }
            else
            {
                return "Other";
            }
        }

        protected void PlayerGridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
            

        }
        protected void PlayerGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PlayerGridView.PageIndex = e.NewPageIndex;

            // you must refresh your grid view with a call to the database
            try
            {

                PlayerController sysmgr = new PlayerController();
                List<Player> datainfo = sysmgr.Players_GetByTeam(int.Parse(TeamList.SelectedValue));



                datainfo.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                PlayerGridView.DataSource = datainfo;
                PlayerGridView.DataBind();

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
    }
}