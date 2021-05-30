<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="LMS_S1234.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="form2maincontainer1" runat="server">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 text-center" style="padding-top: 10px">
                <p class="d-inline-block fs-2">COURSE: </p>
                <asp:DropDownList class="form-select form-select-lg mb-3" ID="DropDownList1" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div id="form2maincontainer" runat="server">
            <div class='row'>
                <div class='col-xs-12 col-sm-12 col-md-12 mx-auto' style='padding-top: 10px'>
                    <div class="text-center">
                        <p class="fs-5">Teachers: </p>
                        <asp:ListBox ID="ListBox2" class="align-content-center mb-3" Width="60%" Height="60px" runat="server"></asp:ListBox>
                        <p class="fs-5">Students: </p>
                        <asp:ListBox ID="ListBox1" class="align-content-center mb-3" Width="60%" Height="180px" runat="server"></asp:ListBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
