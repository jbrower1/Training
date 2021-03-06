﻿using System;
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
    public partial class Exercise7C : System.Web.UI.Page
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


                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            TeamList.ClearSelection();
            Teaminfo = null;
            Coach.Text = null;
            AssistantCoach.Text = null;
            Wins.Text = "0";
            Losses.Text = "0";
        }
    }
}
