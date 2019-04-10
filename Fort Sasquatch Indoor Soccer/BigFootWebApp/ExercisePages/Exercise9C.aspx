<%@ Page Title="Team Update/Delete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise9C.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Exercise9C" %>

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
        ErrorMessage="Team Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick" validationgroup="V2"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldTeamNameV3" runat="server" ControlToValidate="TeamNameV3"
        ErrorMessage="Team Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick" validationgroup="V3"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldCoachV2" runat="server" ControlToValidate="CoachNameV2"
        ErrorMessage="Coach Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick" validationgroup="V2"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldCoachV3" runat="server" ControlToValidate="CoachV3"
        ErrorMessage="Coach Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick" validationgroup="V3"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldAssistantV2" runat="server" ControlToValidate="AssistantCoachV2"
        ErrorMessage="Assistant Coach Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick" validationgroup="V2"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldAssistantV3" runat="server" ControlToValidate="AssistantCoachV3"
        ErrorMessage="Assistant Coach Name is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick" validationgroup="V3"></asp:RequiredFieldValidator>
  
   <asp:CompareValidator ID="CompareWinsV2" runat="server" ErrorMessage="Wins Must be 0 or Greater"
         ControlToValidate="WinsV2" Display="None" SetFocusOnError="true" ForeColor="Firebrick" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0" validationgroup="V2"></asp:CompareValidator>
   <asp:CompareValidator ID="CompareWinsV3" runat="server" ErrorMessage="Wins Must be 0 or Greater"
         ControlToValidate="WinsV3" Display="None" SetFocusOnError="true" ForeColor="Firebrick" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0" validationgroup="V3"></asp:CompareValidator>

     <asp:CompareValidator ID="CompareLossesV2" runat="server" ErrorMessage="Wins Must be 0 or Greater"
         ControlToValidate="LossesV2" Display="None" SetFocusOnError="true" ForeColor="Firebrick" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0" validationgroup="V2"></asp:CompareValidator>
   <asp:CompareValidator ID="CompareLossesV3" runat="server" ErrorMessage="Wins Must be 0 or Greater"
         ControlToValidate="LossesV3" Display="None" SetFocusOnError="true" ForeColor="Firebrick" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0" validationgroup="V3"></asp:CompareValidator>

    <asp:ValidationSummary ID="ValidationTeamV2" runat="server" HeaderText="Correct the following errors and resubmit" CssClass="alert alert-danger" validationgroup="V2" />
    <asp:ValidationSummary ID="ValidationTeamV3" runat="server" HeaderText="Correct the following errors and resubmit" CssClass="alert alert-danger" validationgroup="V3"/>

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
                    <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>
                    <asp:Button ID="SearchButton" runat="server" CausesValidation="false" Text="Search" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" OnClick="SearchButton_Click1" />
                    <asp:Button ID="ClearButton" runat="server" CausesValidation="false" Text="Clear" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
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
                    <asp:Label ID="Label19" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamListV2" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Label ID="label7" runat="server" Text="Team Name:">
                    </asp:Label>
                    <asp:TextBox ID="TeamNameV2" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="InsertTeam" runat="server" Text="Add Team"
                        Font-Size="Large" ForeColor="#438ACA" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="InsertTeam_Click" validationgroup="V2"/>
                    <asp:Button ID="ClearButtonV2" runat="server" CausesValidation="false" Text="Clear" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" OnClick="ClearButton_Click" />
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
                    <asp:Label ID="Label6" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamListV3" runat="server"></asp:DropDownList>
                    <asp:Button ID="SearchButtonV3" runat="server" Text="Search" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" CausesValidation="false" OnClick="SearchButton_ClickV3" />
                    <asp:Button ID="ClearButtonV3" runat="server" Text="Clear" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" CausesValidation="false" OnClick="ClearButton_Click" />
                    <asp:Button ID="UpdateTeam" runat="server" Text="Update" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" OnClick="UpdateTeam_Click" validationgroup="V3"/>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Team ID:"></asp:Label>
                    <asp:Label ID="TeamIDV3" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="Team Name:"></asp:Label>
                    <asp:TextBox ID="TeamNameV3" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Coach:"></asp:Label>
                    <asp:TextBox ID="CoachV3" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Assistant Coach:"></asp:Label>
                    <asp:TextBox ID="AssistantCoachV3" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Wins:"></asp:Label>
                    <asp:TextBox ID="WinsV3" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="Losses:"></asp:Label>
                    <asp:TextBox ID="LossesV3" runat="server" TextMode="Number"></asp:TextBox>
                </fieldset>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <fieldset class="form-horizontal">
                    <legend>Team Series: Team Delete</legend>
                    <asp:Label ID="Label20" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamListV4" runat="server"></asp:DropDownList>
                    <asp:Button ID="SearchButtonV4" runat="server" Text="Search" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" CausesValidation="false" OnClick="SearchButton_ClickV4" />
                    <asp:Button ID="ClearButtonV4" runat="server" Text="Clear" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" CausesValidation="false" OnClick="ClearButton_Click" />
                    <asp:Button ID="DeleteButton" runat="server" Text="Delete" Font-Size="Large" ForeColor="#438ACA" BackColor="White"
                        BorderColor="White" BorderStyle="None" OnClientClick=" return confirm('Are you sure you want to delete this team? ')" CausesValidation="false" OnClick="DeleteTeam_Click" />
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Team ID:"></asp:Label>
                    <asp:Label ID="TeamIDV4" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label21" runat="server" Text="Team Name:"></asp:Label>
                    <asp:Label ID="TeamNameV4" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="Coach:"></asp:Label>
                    <asp:Label ID="CoachV4" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label25" runat="server" Text="Assistant Coach:"></asp:Label>
                    <asp:Label ID="AssistantCoachV4" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label27" runat="server" Text="Wins:"></asp:Label>
                    <asp:Label ID="WinsV4" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label29" runat="server" Text="Losses:"></asp:Label>
                    <asp:Label ID="LossesV4" runat="server"></asp:Label>
                </fieldset>
            </asp:View>
        </asp:MultiView>

    </div>
</asp:Content>
