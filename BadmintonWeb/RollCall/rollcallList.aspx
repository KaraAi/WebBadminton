<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="rollcallList.aspx.cs" Inherits="BadmintonWeb.RollCall.rollcallList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="clearfix">
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Điểm Danh</h2>
                        <ul class="nav navbar-right">
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content" runat="server">
                        <div class="form-horizontal form-label-left">
                            <div class="form-group btn-search" runat="server">
                                <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                </label>
                                <div class="col-md-2 col-sm-9 col-xs-12">
                                </div>
                                <asp:LinkButton ID="lbtSearch" runat="server" CssClass="btn btn-orange" ToolTip="Tìm" OnClick="lbtSearch_Click" >Tìm kiếm</asp:LinkButton>
                            </div>
                        </div>
                        <div class="x_content">
                            <div class="row">
                                <div class="form-horizontal form-label-left">
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                            Cơ sở
                                        </label>
                                        <div class="col-md-6 col-sm-9 col-xs-12">
                                            <asp:DropDownList ID="ddlFacilityID" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                            Huấn Luyện Viên
                                        </label>
                                        <div class="col-md-6 col-sm-9 col-xs-12">
                                            <asp:DropDownList ID="ddlCoachID" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                            Ca học
                                        </label>
                                        <div class="col-md-6 col-sm-9 col-xs-12">
                                            <asp:DropDownList ID="ddlTimeID" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
