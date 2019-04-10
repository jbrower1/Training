using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using FSISSystem.JBrow.Data;
using FSISSystem.JBrow.BLL;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

#endregion

namespace BigFootWebApp.ExercisePages
{
    public partial class Exercise8C : System.Web.UI.Page
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
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
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

        protected void InsertTeam_Click(object sender, EventArgs e)
        {
         

                if (errormsgs.Count() > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        //create an instance of product 
                        Team item = new Team();

                        //collect the data from the web form and place in the product instance
                        item.TeamName = TeamNameV2.Text;
                        item.Coach = CoachNameV2.Text;
                        item.AssistantCoach = AssistantCoachV2.Text;
                                             
                        if (string.IsNullOrEmpty(WinsV2.Text))
                        {
                            item.Wins = 0;
                        }
                        else
                        {
                            item.Wins = int.Parse(WinsV2.Text);

                        }
                        if (string.IsNullOrEmpty(LossesV2.Text))
                        {
                            item.Losses = 0;
                        }
                        else
                        {
                            item.Losses = int.Parse(LossesV2.Text);
                        }
                        TeamController sysmgr = new TeamController();

                        //Issue a call to the apropriate BLL controller method
                        int newTeamID = sysmgr.Team_Add(item);

                        //handle results
                        errormsgs.Add(TeamNameV2.Text + " has been added to the database with a key of " + newTeamID.ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-success");

                        // also if any controll uses this new instance for a query or other action, you must update (refresh) that control
                        BindTeamList();
                        TeamList.SelectedValue = newTeamID.ToString();

                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
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