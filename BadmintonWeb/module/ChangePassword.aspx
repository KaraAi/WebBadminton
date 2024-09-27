<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BadmintonWeb.module.ChangePassword" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Đổi mật khẩu</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button"
                            aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Settings 1</a> </li>
                                <li><a href="#">Settings 2</a> </li>
                            </ul>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a></li>
                    </ul>
                    <div class="clearfix">
                    </div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <div class="form-horizontal form-label-left">
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Số điện thoại </label>
                                <div class="col-md-3 col-sm-9 col-xs-12">
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqUsername" runat="server" ErrorMessage="*"
                                        CssClass="error" Display="Dynamic" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Mật khẩu cũ</label>
                                <div class="col-md-7 col-sm-9 col-xs-12">
                                    <asp:TextBox ID="txtPassOld" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqPass" runat="server" ErrorMessage="*"
                                        CssClass="error" Display="Dynamic" ControlToValidate="txtPassOld"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Mật khẩu mới</label>
                                <div class="col-md-7 col-sm-9 col-xs-12">
                                    <asp:TextBox ID="txtPassNew" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqPassNew" runat="server" ErrorMessage="*"
                                        CssClass="error" Display="Dynamic" ControlToValidate="txtPassNew"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                    Nhập lại Mật khẩu mới</label>
                                <div class="col-md-7 col-sm-9 col-xs-12">
                                    <asp:TextBox ID="txtPassNewAgain" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqPassAgain" runat="server" ErrorMessage="*"
                                        CssClass="error" Display="Dynamic" ControlToValidate="txtPassNewAgain"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không giống nhau" Display="Dynamic"
                                        CssClass="validation" ControlToValidate="txtPassNewAgain" ControlToCompare="txtPassNew"></asp:CompareValidator>
                                </div>
                            </div>

                            <div class="ln_solid">
                            </div>
                            <div class="form-group">
                                <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                                    <asp:LinkButton ID="lbtChangePass" runat="server" CssClass="btn btn-primary" OnClick="lbtChangePass_Click"
                                        OnClientClick="return confirm('Bạn có thật sự muốn đổi mật khẩu không?');" ToolTip="Đổi mật khẩu" Text="Đổi mật khẩu" CausesValidation="true"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
