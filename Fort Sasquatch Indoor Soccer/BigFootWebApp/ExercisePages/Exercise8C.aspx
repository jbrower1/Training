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
    <fieldset class="form-horizontal">
        <asp:Label ID="Teaminfo" runat="server"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>
        <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>
        <asp:Button ID="SearchButton" runat="server" Text="Search" Font-Size="Large" ForeColor="#438ACA" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="SearchButton_Click1" />
        <asp:Button ID="ClearButton" runat="server" Text="Clear" Font-Size="Large" ForeColor="#438ACA" BackColor="White" BorderColor="White" BorderStyle="None"  OnClick="ClearButton_Click" />
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
</asp:Content>
