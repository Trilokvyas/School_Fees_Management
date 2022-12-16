<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="School_Fees_Management.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h2>Login</h2>
    <div class="container form-horizontal"> 
        <div class="row">
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblName" runat="server" CssClass="form-label" Text="User Name"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtUserName" CssClass=" form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Password"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class=" col-md-7 text-right">
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="Login" />
    </div>
    <div class=" col-md-5 ">
        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-danger"  Text="Reset" />
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
