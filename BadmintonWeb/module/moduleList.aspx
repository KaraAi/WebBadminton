<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="moduleList.aspx.cs" Inherits="BadmintonWeb.module.moduleList" %>

<%@ Register Src="~/ctrl/ctrlModuleAccess.ascx" TagPrefix="uc1" TagName="ctrlModuleAccess" %>


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
                        <h2>Danh sách Bộ quyền module
                        </h2>
                        <ul class="nav navbar-right">
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <div class="form-horizontal form-label-left">
                            <div class="form-group">
                                <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                    Từ khóa</label>
                                <div class="col-md-7 col-sm-5 col-xs-12">
                                    <input id="txtKey" runat="server" class="form-control" placeholder="Tên bộ quyền" />
                                </div> 
                                <div class="col-md-2 col-sm-2 col-xs-6 btn-search">
                                    <asp:LinkButton ID="lbtSearch" runat="server" CssClass="btn btn-orange" OnClick="lbtSearch_Click" ToolTip="Tìm kiếm">Tìm kiếm</asp:LinkButton>
                                </div>
                                <div class="col-md-2 col-sm-2 col-xs-6 btn-add">
                                    <asp:HyperLink ID="hplInsert" runat="server" CssClass="btn btn-green" data-toggle="modal" ToolTip="Thêm mới" data-target="#ContentPlaceHolder1_ctrlModuleAccess_myModuleAccess">Thêm mới</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                        <div id="datatable_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                            <div class="row">
                                <div class="col-sm-12">
                                    <table id="datatableComment" class="table table-striped table-bordered dataTable no-footer"
                                        role="grid" aria-describedby="datatable_info">
                                        <thead>
                                            <tr role="row">
                                                <th class="sorting_desc" tabindex="0" aria-controls="datatableComment" rowspan="1" colspan="1" style="width: 80px;"
                                                    id="1" aria-sort="descending">Tên Module
                                                </th>
                                                <th>Nội dung</th>
                                                <th style="width: 80px;">Người tạo</th>
                                                <th style="width: 80px;">Ngày tạo</th>
                                                <th style="width: 80px;">Người sửa</th>
                                                <th style="width: 80px;">Ngày sửa</th>
                                                <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1"
                                                    style="width: 100px;" aria-label="Start date: activate to sort column ascending">Action
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptModuleAccess" runat="server" OnItemDataBound="rptModuleAccess_ItemDataBound" OnItemCommand="rptModuleAccess_ItemCommand">
                                                <ItemTemplate>
                                                    <tr role="row" class="odd">
                                                        <td>
                                                            <asp:HiddenField ID="hdModuleID" runat="server" Value="0" />
                                                            <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrUserCreated" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrDateCreated" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrUserUpdated" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrDateUpdated" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lbtEdit" runat="server" ToolTip="Chỉnh sửa bộ quyền" CommandName="updateModuleAccess">
                                                                                        <img src="../images/Edit.gif" alt="Chỉnh sửa bộ quyền" />
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="lbtDelete" runat="server" ToolTip="Xóa bộ quyền" CommandName="deleteModuleAccess" OnClientClick="return confirm('Bạn có thật sự muốn xóa bộ quyền Module này không?');">
                                                                                        <img src="../images/Delete.gif" alt="Xóa bộ quyền" />
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
    <uc1:ctrlModuleAccess runat="server" ID="ctrlModuleAccess" />
</asp:Content>
