<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="School_Fees_Management.Session" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%=Session["MyData"] %>
    <div class="text-center">
        <h2><u>Session</u> </h2>
    </div>
    <br />
    <br />
    <div class="container form-horizontal">
        

        <div class="row">
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblName" runat="server" CssClass="form-label" Text="Session"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtSessionName" CssClass=" form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            </div>
        </div>
    <br />
            <div class=" col-md-7 text-right">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"  CssClass="btn btn-success" Text="Save" />
                </div>
            <div class=" col-md-5 ">
                <asp:Button ID="btnReset" runat="server"  CssClass="btn btn-danger" OnClick="btnReset_Click"  Text="Reset" />
                </div>
    <div class="col-md-6">
<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div><br /><br />
    <br />

    <div>
        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="ID" >
            <Columns>
            <asp:BoundField HeaderText="Session ID" Datafield="ID" />
                <asp:BoundField HeaderText="Session" Datafield="SessionName" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button CommandName="Delete" runat="server" CssClass="btn btn-danger" Text="Remove" />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
        </asp:GridView>

    </div>
</asp:Content>
