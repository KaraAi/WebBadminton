<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="rollcallDetail.aspx.cs" Inherits="BadmintonWeb.RollCall.rollcallDetail" %>

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
                            <div class="form-group btn-save" runat="server">
                                <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                </label>
                                <div class="col-md-2 col-sm-9 col-xs-12">
                                </div>
                                <asp:LinkButton ID="lbtSave" runat="server" CssClass="btn btn-green" ToolTip="Lưu lại" OnClick="lbtSave_Click">Lưu</asp:LinkButton>
                            </div>
                        </div>
                        <div id="datatable_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                            <div class="row">
                                <div class="col-sm-12">
                                    <table id="datatableUserList" class="table table-striped table-bordered dataTable no-footer"
                                        role="grid" aria-describedby="datatable_info">
                                        <thead>
                                            <tr role="row">
                                                <th style="width: 160px;">Tên học viên</th>
                                                <th style="width: 50px;">Ca học</th>
                                                <th style="width: 100px;">Tên Huấn luyện viên</th>
                                                <th style="width: 100px;">Có mặt</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptRollCall" runat="server" OnItemDataBound="rptRollCall_ItemDataBound">
                                                <itemtemplate>
                                                    <tr role="row" class="odd" runat="server">
                                                        <td>
                                                            <asp:HiddenField ID="hdStudent" runat="server" />
                                                            <asp:Literal ID="ltrStudent" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrTime" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:HiddenField ID="hdCoach" runat="server" />
                                                            <asp:Literal ID="ltrCoach" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkCheck" runat="server"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </itemtemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
