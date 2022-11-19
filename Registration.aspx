<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="School_Fees_Management.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span id="studentData" runat="server"></span>

    <div class="text-center">
        <h2><u>Student-form</u> </h2>
    </div>
    <br />
    <br />
    <div class="container form-horizontal">


        <div class="row">
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblName" runat="server" CssClass="form-label" Text="Student Name"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtName" CssClass=" form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblFatherName" runat="server" CssClass="form-label" Text="Father Name "></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtFatherName" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblMotherName" runat="server" CssClass="form-label" Text="Mother Name "></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtMotherName" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblMobile" runat="server" CssClass="form-label" Text="Mobile Number "></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtMobile" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-6 text-right">
                    <asp:Label ID="lblEnrollno" runat="server" CssClass="form-label" Text="Enrollment Number "></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtEnrollno" CssClass="form-control " runat="server"></asp:TextBox>
                </div>
            </div> <br />
            <div class=" col-md-7 text-right">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success" Text="Save" />
                </div>
            <div class=" col-md-5 ">
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" CssClass="btn btn-danger" Text="Reset" />
                </div>
        </div>
    </div>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <div>
        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="ID" >

            <Columns>
                <asp:BoundField HeaderText="StudentID" Datafield="ID" />
                <asp:BoundField HeaderText="Student Name" Datafield="STName" />
                <asp:BoundField HeaderText="Father's Name" Datafield="FatherName" />    
                <asp:BoundField HeaderText="Mother's Name" Datafield="MotherName" />        
                  <asp:BoundField HeaderText="Mobile Number" Datafield="Mobile" />  
              <asp:BoundField HeaderText="Enrollment Number" Datafield="EnrollNo" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button CommandName="Delete" runat="server" Text="Remove" CssClass="btn btn-danger" OnClientClick="return ConfirmDelete();"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>



</asp:Content>
