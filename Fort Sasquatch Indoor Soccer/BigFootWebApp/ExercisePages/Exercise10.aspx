<%@ Page Title="Multi Record Query Using Code-Behind" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise10.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Exercise10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-header">
        <h1>Multi Record Query using Code-Behind</h1>
    </div>

    <div class="row">
        <div class="alert alert-info">
            <blockquote style="font-size:medium" >
                <b>About:</b> This page will demonstrate a multiple record query display to a GridView using code behind without using ObjectDataSource controls. The page will demonstrate
                customization of the GridView covering templates, columns selection, column headers, caption (with Bootstrap formattion), dataset member referencing (Eval("")) and paging.
                The Page will demonstrate the implimentation of the paging event PageIndexChanging().
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
                    
                    <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="Search" Font-Size="Large" ForeColor="#438ACA" BackColor="White" BorderColor="White" BorderStyle="None" />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Coach:"></asp:Label>
                    <asp:Label ID="Coach" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Assistant Coach:"></asp:Label>
                    <asp:Label ID="AssistantCoach" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Wins:"></asp:Label>
                    <asp:Label ID="Wins" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Losses:"></asp:Label>
                    <asp:Label ID="Losses" runat="server" Text=""></asp:Label>
                    <asp:GridView ID="PlayerGridView" runat="server" BackColor="White"> 

                        <EmptyDataTemplate>
                            No data to show for selected category <!-- USE FOR ASSIGNMENT 10 --> 
                        </EmptyDataTemplate>

                    </asp:GridView>
                </fieldset>
</asp:Content>
