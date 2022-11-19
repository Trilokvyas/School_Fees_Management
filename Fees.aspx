<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fees.aspx.cs" Inherits="School_Fees_Management.Fees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h2><u>Fees</u> </h2>
    </div>
    <br />
    <br />
    <div class="container form-horizontal">


        <div class="row">
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblSession" runat="server" CssClass="form-label" Text="Session"></asp:Label>
                </div>
                <div class="col-md-6 text-right">
                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Please Select Session</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblClName" runat="server" CssClass="form-label" Text="Class Name"></asp:Label>
                </div>
                <div class="col-md-6 text-right">
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Please Select Class</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblAmount" runat="server" CssClass="form-label" Text="Amount"></asp:Label>
                </div>
                <div class="col-md-6 text-right">
                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="form-label" Text=""></asp:Label>
            </div>
        </div>
        <div class="col-md-7 text-right">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success" />
        </div>
        <div class="col-md-5 ">
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" CssClass="btn btn-primary" />
        </div>
    </div>
    <br />
    <div>

        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="ClName" HeaderText="Class" /> 
                <asp:BoundField DataField="SessionName" HeaderText="Session" />
                <asp:BoundField DataField="Amount" HeaderText="Fees" />

            </Columns>
        </asp:GridView>

    </div>


</asp:Content>
