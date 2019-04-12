<%@ Page Title="MultiRecord Query using Object-DataSource" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise11.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Exercise11" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="page-header">
        <h1>MultiRecord Query using Object-DataSource</h1>
    </div>


    <div class="row">
        <div class="alert alert-info">
            <blockquote style="font-size: medium">
                <b>About:</b> Create/Read/Update/Delete for Team Data
            </blockquote>
        </div>
    </div>
    <br />
     <asp:RequiredFieldValidator ID="RequiredFieldPlayerAge" runat="server" ControlToValidate="PlayerAge"
        ErrorMessage="Player Age is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"></asp:RequiredFieldValidator>
    
   <asp:CompareValidator ID="ComparePlayerAge" runat="server" ErrorMessage="Player Age must be a positive number"
         ControlToValidate="PlayerAge" Display="None" SetFocusOnError="true" ForeColor="Firebrick" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0"></asp:CompareValidator>

    <asp:ValidationSummary ID="ValidationPlayer" runat="server" HeaderText="Correct the following errors and resubmit" CssClass="alert alert-danger"/>

    <fieldset class="form-horizontal">
        <asp:Label ID="Label1" runat="server" Text="Enter Age:"></asp:Label>

        <asp:TextBox ID="PlayerAge" runat="server"></asp:TextBox>
        <asp:RadioButtonList ID="PlayerGender" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Male" Value="M" />
             <asp:ListItem Text="Female" Value="F" />
        </asp:RadioButtonList>
        <asp:LinkButton ID="SearchButton" runat="server" Text="Search"  />
        <br />
        <asp:GridView ID="PlayerListByAgeGender" runat="server" DataSourceID="PlayerListODS" AllowPaging="True" AutoGenerateColumns="False" PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="PlayerID" runat="server" 
                            Text='<%# Eval("PlayerID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="FullName" runat="server" 
                            Text='<%# Eval("FullName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Team">
                    <ItemTemplate>
                        <asp:DropDownList ID="TeamListGV" 
                            runat="server" 
                            DataSourceID="TeamListODS" 
                            DataTextField="TeamName" 
                            DataValueField="TeamID"
                            selectedvalue='<%# Eval("TeamID") %>'
                            Enabled="false"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             <EmptyDataTemplate>
                No Players with that Age and Gender
            </EmptyDataTemplate>
        </asp:GridView>

    </fieldset>
    <asp:ObjectDataSource ID="TeamListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Team_List" TypeName="FSISSystem.JBrow.BLL.TeamController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="PlayerListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Player_GetByAgeGender" TypeName="FSISSystem.JBrow.BLL.PlayerController">
        <SelectParameters>
            <asp:ControlParameter ControlID="PlayerAge" DefaultValue="0" Name="age" PropertyName="Text" Type="Int32" />
            <asp:ControlParameter ControlID="PlayerGender" DefaultValue="M" Name="gender" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
