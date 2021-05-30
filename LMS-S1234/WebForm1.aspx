<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Home.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LMS_S1234.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="height: 100%; background-image: url(imgs/headway-5QgIuuBxKwM-unsplash.jpg); background-size: cover; background-position: center; background-repeat: no-repeat">
        <div class="row" >
        <div class="col-lg-4 col-sm-8 mx-auto" style="padding-top: 30px;">
            <div class="card mx-auto" style="auto; height:fit-content()">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <h5 class="card-title fs-3 text-center">USER LOGIN</h5>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                            <form >
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Email address</label>
                                    <asp:TextBox class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" runat="server"></asp:TextBox>
                                    <p></p>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Password</label>
                                    <asp:TextBox type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-check">
                                    <asp:Label ID="Label1" runat="server" class="text-danger text-center mx-auto" Text=""></asp:Label>
                                </div>
                                <asp:button type="submit" class="btn btn-success col-12" runat="server" Text="Log In" OnClick="Unnamed_Click"></asp:button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
