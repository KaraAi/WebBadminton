<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="timeList.aspx.cs" Inherits="BadmintonWeb.time.timeList" %>

<%@ Register Src="~/ctrl/ctrlModelTime.ascx" TagPrefix="uc1" TagName="ctrlModelTime" %>


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
                        <h2>Danh sách ca học</h2>
                        <ul class="nav navbar-right">
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content" runat="server">
                        <div class="form-horizontal form-label-left">
                            <div class="form-group" runat="server">
                                <label class="control-label col-md-1 col-sm-2 col-xs-12">
                                    Từ khóa
                                </label>
                                <div class="col-md-7 col-sm-6 col-xs-12">
                                    <input id="txtKey" runat="server" class="form-control" placeholder="Mã, Tên ca học" />
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-6 btn-search">
                                    <asp:LinkButton ID="lbtSearch" runat="server" CssClass="btn btn-orange" OnClick="lbtSearch_Click" ToolTip="Tìm kiếm">Tìm kiếm</asp:LinkButton>
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-6 btn-add">
                                    <asp:HyperLink ID="hplInsert" runat="server" CssClass="btn btn-green" data-toggle="modal" ToolTip="Thêm mới" data-target="#ContentPlaceHolder1_ctrlModelTime_myModelTime">Thêm mới</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                        <div id="datatable_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                            <div class="row">
                                <div class="col-sm-12">
                                    <table id="datatableUserList" class="table table-striped table-bordered dataTable no-footer"
                                        role="grid" aria-describedby="datatable_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_desc" tabindex="0" aria-controls="datatableComment" rowspan="1" colspan="1" style="width: 100px;"
                                                    aria-sort="descending">Số thứ tự
                                                </th>
                                                <th style="width: 160px;">Ca học</th>
                                                <th style="width: 50px;">Người tạo</th>
                                                <th style="width: 100px;">Người sửa</th>
                                                <th style="width: 50px;">Ngày tạo</th>
                                                <th style="width: 100px;">Ngày sửa</th>
                                                <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1"
                                                    style="width: 100px;" aria-label="Start date: activate to sort column ascending">Action
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptTime" runat="server" OnItemDataBound="rptTime_ItemDataBound" OnItemCommand="rptTime_ItemCommand">
                                                <ItemTemplate>
                                                    <tr role="row" class="odd" runat="server">
                                                        <td>
                                                            <asp:HiddenField ID="hdTimeID" runat="server" Value="0"></asp:HiddenField>
                                                            <asp:Literal ID="ltrTimeID" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrTimeName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrUserCreated" runat="server"></asp:Literal>
                                                        </td>

                                                        <td>
                                                            <asp:Literal ID="ltrUserUpdated" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrDateCreated" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrDateUpdated" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lbtEdit" runat="server" ToolTip="Chỉnh sửa Ca học" CommandName="updateTime">
                                                                <img src="../images/Edit.gif" alt="Chỉnh sửa Ca học" />
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="lbtDelete" runat="server" ToolTip="Xóa Ca học" CommandName="deleteTime" OnClientClick="return confirm('Bạn có thật sự muốn xóa Ca học này không?');">
                                                                 <img src="../images/Delete.gif" alt="Xóa Ca học" />
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
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
    <uc1:ctrlModelTime runat="server" ID="ctrlModelTime" />
</asp:Content>
