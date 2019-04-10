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
    public partial class Exercise9C : System.Web.UI.Page
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

                TeamListV3.DataSource = datainfo;
                TeamListV3.DataTextField = nameof(Team.TeamName);
                TeamListV3.DataValueField = nameof(Team.TeamID);
                TeamListV3.DataBind();
                TeamListV3.Items.Insert(0, "select ....");

                TeamListV4.DataSource = datainfo;
                TeamListV4.DataTextField = nameof(Team.TeamName);
                TeamListV4.DataValueField = nameof(Team.TeamID);
                TeamListV4.DataBind();
                TeamListV4.Items.Insert(0, "select ....");
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
            Coach.Text = null;
            AssistantCoach.Text = null;
            Wins.Text = "0";
            Losses.Text = "0";

            TeamListV3.ClearSelection();
            CoachV3.Text = null;
            AssistantCoachV3.Text = null;
            WinsV3.Text = "0";
            LossesV3.Text = "0";

            TeamList.ClearSelection();
            Coach.Text = null;
            AssistantCoach.Text = null;
            Wins.Text = "0";
            Losses.Text = "0";
        }
        protected void SearchButton_ClickV3(object sender, EventArgs e)
        {
            //WORKS!
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a Team to veiw Players.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                TeamIDV3.Text = "0";
                CoachV3.Text = null;
                AssistantCoachV3.Text = null;
                WinsV3.Text = "0";
                LossesV3.Text = "0";
            }
            else
            {
                try
                {

                    TeamController sysmgr = new TeamController();
                    Team TeamInfo = sysmgr.Team_Get(int.Parse(TeamListV3.SelectedValue));

                    if (TeamInfo == null)
                    {
                        errormsgs.Add("TeamInfo Not Bound");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        TeamIDV3.Text = TeamListV3.SelectedValue;
                        CoachV3.Text = TeamInfo.Coach;
                        AssistantCoachV3.Text = TeamInfo.AssistantCoach;
                        if (TeamInfo.Wins == null)
                        {
                            WinsV3.Text = "0";
                        }
                        else
                        {
                            WinsV3.Text = TeamInfo.Wins.ToString();
                        }

                        if (TeamInfo.Losses == null)
                        {
                            LossesV3.Text = "0";
                        }
                        else
                        {
                            LossesV3.Text = TeamInfo.Losses.ToString();
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
        protected void SearchButton_ClickV4(object sender, EventArgs e)
        {
            //WORKS!
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a Team to veiw Players.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                TeamIDV4.Text = "0";
                CoachV4.Text = null;
                AssistantCoachV4.Text = null;
                WinsV4.Text = "0";
                LossesV4.Text = "0";
            }
            else
            {
                try
                {

                    TeamController sysmgr = new TeamController();
                    Team TeamInfo = sysmgr.Team_Get(int.Parse(TeamListV4.SelectedValue));

                    if (TeamInfo == null)
                    {
                        errormsgs.Add("TeamInfo Not Bound");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                    }
                    else
                    {
                        TeamIDV4.Text = TeamListV4.SelectedValue;
                        CoachV4.Text = TeamInfo.Coach;
                        AssistantCoachV4.Text = TeamInfo.AssistantCoach;
                        if (TeamInfo.Wins == null)
                        {
                            WinsV4.Text = "0";
                        }
                        else
                        {
                            WinsV4.Text = TeamInfo.Wins.ToString();
                        }

                        if (TeamInfo.Losses == null)
                        {
                            LossesV4.Text = "0";
                        }
                        else
                        {
                            LossesV4.Text = TeamInfo.Losses.ToString();
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
             
                    Team item = new Team();

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
                  
                    int newTeamID = sysmgr.Team_Add(item);

                    errormsgs.Add(TeamNameV2.Text + " has been added to the database with a key of " + newTeamID.ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-success");

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
        protected void UpdateTeam_Click(object sender, EventArgs e)
        {
            
            if (TeamListV3.SelectedIndex == 0)
            {
                errormsgs.Add("Please select Team");
            }                      
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    
                    Team item = new Team();
                   
                    int teamid = 0;
                    if (!int.TryParse(TeamListV3.SelectedValue, out teamid))
                    {
                        errormsgs.Add("Invalid or missing Team ID");
                    }
                
                    item.TeamID = int.Parse(TeamIDV3.Text.Trim());

                    item.TeamName = TeamNameV3.Text;
                    item.Coach = CoachV3.Text;
                    item.AssistantCoach = AssistantCoachV3.Text;                   

                    if (WinsV3 == null)
                    {
                        item.Wins = 0;
                    }
                    else
                    {
                        item.Wins = int.Parse(WinsV3.Text);
                    }

                    if (LossesV3 == null)
                    {
                        item.Losses = 0;
                    }
                    else
                    {
                        item.Losses = int.Parse(LossesV3.Text);
                    }
                   
                    TeamController sysmgr = new TeamController();
                  
                    int rowsaffected = sysmgr.Team_Update(item);

                    if (rowsaffected == 0)
                    {
                        errormsgs.Add(TeamNameV3.Text + " has not been Updated, Search for Product again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindTeamList();
                    }
                    else
                    {
                        errormsgs.Add(TeamNameV3.Text + " has been Updated ");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindTeamList();
                        TeamListV3.SelectedValue = TeamIDV3.Text;
                    }
                  
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

        protected void DeleteTeam_Click(object sender, EventArgs e) //may be incomplete
        {
            if (TeamListV4.SelectedIndex == 0)
            {
                errormsgs.Add("Please select Team");


            }           
           
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {                   
                    Team item = new Team();
                  
                    int teamid = 0;
                    if (!int.TryParse(TeamListV4.SelectedValue, out teamid))
                    {
                        errormsgs.Add("Invalid or missing Product ID");
                    }

                    item.TeamID = int.Parse(TeamListV4.SelectedValue);

                    item.TeamName = TeamNameV4.Text;
                    item.Coach = CoachV4.Text;
                    item.AssistantCoach = AssistantCoachV4.Text;

                    if (WinsV4 == null)
                    {
                        item.Wins = 0;
                    }
                    else
                    {
                        item.Wins = int.Parse(WinsV4.Text);
                    }

                    if (LossesV4 == null)
                    {
                        item.Losses = 0;
                    }
                    else
                    {
                        item.Losses = int.Parse(LossesV4.Text);
                    }

                    TeamController sysmgr = new TeamController();
                 
                    int rowsaffected = sysmgr.Team_Delete(int.Parse(TeamListV4.SelectedValue));

                    if (rowsaffected == 0)
                    {
                        errormsgs.Add(TeamNameV4.Text + " has not been Deleted, Search for Team again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindTeamList();
                    }
                    else
                    {
                        //success
                        errormsgs.Add(TeamNameV4.Text + " has been Deleted ");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindTeamList();
                    }

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