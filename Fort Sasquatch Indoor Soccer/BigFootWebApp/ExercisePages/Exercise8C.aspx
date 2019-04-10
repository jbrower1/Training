<%@ Page Title="Team Add" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise8C.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Exercise8C" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Client-Server Entity Insert - Team Series</h1>
    </div>

    <div class="row">
        <div class="alert alert-info">
            <blockquote style="font-size: large">
                Select a team to view its stats
            </blockquote>
        </div>
    </div>
    <br />
    <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <br />

      <asp:RequiredFieldValidator ID="RequiredFieldTeamNameV2" runat="server" ControlToValidate="TeamNameV2"
        ErrorMessage="Team Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    
    <asp:RequiredFieldValidator ID="RequiredFieldCoachV2" runat="server" ControlToValidate="CoachNameV2"
        ErrorMessage="Coach Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"></asp:RequiredFieldValidator>
   
    <asp:RequiredFieldValidator ID="RequiredFieldAssistantV2" runat="server" ControlToValidate="AssistantCoachV2"
        ErrorMessage="Assistant Coach Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"></asp:RequiredFieldValidator>
   
   <asp:CompareValidator ID="CompareWinsV2" runat="server" ErrorMessage="Wins Must be 0 or Greater"
         ControlToValidate="WinsV2" Display="None" SetFocusOnError="true" ForeColor="Firebrick" Type="Integer" Operator="LessThanEqual" ValueToCompare="0"></asp:CompareValidator>
   
     <asp:CompareValidator ID="CompareLossesV2" runat="server" ErrorMessage="Wins Must be 0 or Greater"
         ControlToValidate="LossesV2" Display="None" SetFocusOnError="true" ForeColor="Firebrick" Type="Integer" Operator="LessThanEqual" ValueToCompare="0"></asp:CompareValidator>
    
    <asp:ValidationSummary ID="ValidationContestEntry" runat="server" HeaderText="Correct the following errors and resubmit" CssClass="alert alert-danger" />


    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
        StaticMenuItemStyle-CssClass="tab"
        Font-Size="Large" StaticSelectedStyle-CssClass="selectedTab"
        StaticMenuItemStyle-HorizontalPadding="50px"
        StaticSelectedStyle-BackColor="lightblue"
        CssClass="tabs"
        OnMenuItemClick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="Team Search" Selected="true" Value="0"></asp:MenuItem>
            <asp:MenuItem Text="Team Insert" Value="1"></asp:MenuItem>
            <asp:MenuItem Text="Team Update" Value="2"></asp:MenuItem>
            <asp:MenuItem Text="Team Delete" Value="3"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <div class="tabContents">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Team Series: Team Search</legend>
                    <asp:Label ID="Teaminfo" runat="server"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>
                    
                    <asp:Button ID="SearchButton" runat="server" Text="Search" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" OnClick="SearchButton_Click1" />
                    <asp:Button ID="ClearButton" runat="server" Text="Clear" Font-Size="Large" ForeColor="#438ACA" BackColor="White" 
                        BorderColor="White" BorderStyle="None" OnClick="ClearButton_Click" />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Coach:"></asp:Label>
                    <asp:Label ID="Coach" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Assistant Coach:"></asp:Label>
                    <asp:Label ID="AssistantCoach" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Wins:"></asp:Label>
                    <asp:Label ID="Wins" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Losses:"></asp:Label>
                    <asp:Label ID="Losses" runat="server"></asp:Label>
                </fieldset>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Team Series: Team Insert</legend>
                    <asp:Label ID="Label6" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamListV2" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label ID="label7" runat="server" Text="Team Name:">
                    </asp:Label>
                    <asp:TextBox ID="TeamNameV2" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="InsertTeam" runat="server" Text="Add Team"
                    Font-Size="Large" ForeColor="#438ACA" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="InsertTeam_Click" />
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Coach Name:"></asp:Label>
                    <asp:TextBox ID="CoachNameV2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Assistant Coach:"></asp:Label>
                    <asp:TextBox ID="AssistantCoachV2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Wins:"></asp:Label>
                    <asp:TextBox ID="WinsV2" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Losses:"></asp:Label>
                    <asp:TextBox ID="LossesV2" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    
                </fieldset>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Team Series: Team Update</legend>
                  
                </fieldset>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Team Series: Team Delete</legend>
                    
                </fieldset>
            </asp:View>
        </asp:MultiView>

    </div>
</asp:Content>
