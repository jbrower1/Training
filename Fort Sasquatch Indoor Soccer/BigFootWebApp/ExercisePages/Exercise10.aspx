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
                    <asp:Label ID="Teaminfo" runat="server"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>
                    <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>
                    <asp:Button ID="SearchButton" runat="server" Text="Search" Font-Size="Large" ForeColor="#438ACA" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="SearchButton_Click1" />
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
                    <asp:GridView ID="PlayerGridView" runat="server" BackColor="White" AllowPaging="True" PageSize="5" PagerSettings-Mode="NumericFirstLast" 
                        PagerSettings-FirstPageText="Start" PagerSettings-LastPageText="End" PagerSettings-PageButtonCount="3"
                        GridLines="Horizontal" AlternatingRowStyle-BackColor="#E8E6E3"
                        OnPageIndexChanging="PlayerGridView_PageIndexChanging" AutoGenerateColumns="False" OnSelectedIndexChanged="PlayerGridView_SelectedIndexChanged1"> 
                        
                        <AlternatingRowStyle BackColor="#E8E6E3"></AlternatingRowStyle>

                        <Columns>
                            
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    &nbsp;<asp:Label ID="PlayerName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle BackColor="#666666" Font-Bold="True" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                   &nbsp; <asp:Label ID="PlayerAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle BackColor="#666666" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                   &nbsp; <asp:Label ID="PlayerGender" runat="server" Text='<%# HandlePlayerGender(Eval("Gender").ToString()) %>'></asp:Label>&nbsp;&nbsp;
                                </ItemTemplate>
                                <HeaderStyle BackColor="#666666" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Med Alert">
                                <ItemTemplate>
                                    <asp:Label ID="PlayerMedicalDetails" runat="server" Text='<%# Eval("MedicalAlertDetails") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#666666" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>                           
                        </Columns>
                         
                        <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3"></PagerSettings>        
                         <EmptyDataTemplate>
                            No data to show for selected category 
                        </EmptyDataTemplate>
                    </asp:GridView>
                </fieldset>
</asp:Content>
