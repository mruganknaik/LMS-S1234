<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Home.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="LMS_S1234.WebForm5" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="height: 100%; background-image: url(imgs/headway-5QgIuuBxKwM-unsplash.jpg); background-size: cover; background-position: center; background-repeat: no-repeat">
        <div class="row" >
            <div class="col-lg-4 col-sm-8 mx-auto" style="padding-top: 30px;">
                <div class="card mx-auto" style="auto; height: fit-content()">
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
                                <form>
                                    <div class="form-group">
                                        <label>First Name</label>
                                        <asp:TextBox class="form-control" id="ipfname" placeholder="Enter First Name" runat="server" TextMode="SingleLine"></asp:TextBox>
                                        <p></p>
                                        <label>Last Name</label>
                                        <asp:TextBox class="form-control" id="iplname" placeholder="Enter Last Name" runat="server" TextMode="SingleLine"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p></p>
                                        <label for="exampleInputEmail1">Email address</label>
                                        <asp:TextBox  class="form-control" id="ipemail"  placeholder="Enter email" runat="server" TextMode="Email"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p></p>
                                        <label for="exampleInputPassword1">Password</label>
                                        <asp:TextBox  class="form-control" id="ippassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p></p>
                                        <label for="exampleInputPassword1">Confirm Password</label>
                                        <asp:TextBox  class="form-control" id="ipconpassword" placeholder="Confirm Your Password" runat="server" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-check">
                                        <asp:Label ID="resultlbl" class="text-danger" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Button id="btnsign" class="btn btn-primary col-12" runat="server" Text="Sign Up" OnClick="btnsign_Click"></asp:Button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
