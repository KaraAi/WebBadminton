<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="coachList.aspx.cs" Inherits="BadmintonWeb.coach.coachList" %>

<%@ Register Src="~/ctrl/ctrlModalUserDetail.ascx" TagPrefix="uc1" TagName="ctrlModalUserDetail" %>

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
                        <h2>Danh sách Huấn Luyện Viên</h2>
                        <ul class="nav navbar-right">
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content" runat="server">
                        <div class="form-horizontal form-label-left">
                            <div class="form-group" runat="server">
                                <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                    Từ khóa</label>
                                <div class="col-md-3 col-sm-9 col-xs-12">
                                    <input id="txtKey" runat="server" class="form-control" placeholder="Mã, họ tên" />
                                </div>
                                <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                    Loại TK</label>
                                <div class="col-md-3 col-sm-9 col-xs-12">
                                    <asp:DropDownList ID="ddTypeUserID" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-sm-6 col-xs-6 btn-search">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-orange" OnClick="lbtSearch_Click" ToolTip="Tìm kiếm">Tìm kiếm</asp:LinkButton>
                                </div>
                                <div class="col-md-2 col-sm-6 col-xs-6 btn-add">
                                    <asp:HyperLink ID="hplInsert" runat="server" CssClass="btn btn-green" data-toggle="modal" ToolTip="Thêm mới" data-target="#ContentPlaceHolder1_ctrlModalUserDetail_myModaUserDetail">Thêm mới</asp:HyperLink>
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
                                                <th class="sorting_desc" tabindex="0" aria-controls="datatableComment" rowspan="1" colspan="1" style="width: 30px;"
                                                    aria-sort="descending">Số thứ tự
                                                </th>
                                                <th style="width: 100px;">Tên HLV</th>
                                                <th style="width: 50px;">Giới tính</th>
                                                <th style="width: 50px;">Ngày sinh</th>
                                                <th style="width: 50px;">Cơ sở</th>
                                                <th style="width: 100px;">Level</th>
                                                <th style="width: 100px;">Mã số thuế</th>
                                                <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1"
                                                    style="width: 143.2px;" aria-label="Start date: activate to sort column ascending">Action
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptCoach" runat="server" OnItemDataBound="rptCoach_ItemDataBound" OnItemCommand="rptCoach_ItemCommand">
                                                <ItemTemplate>
                                                    <tr role="row" class="odd" runat="server">
                                                        <td>
                                                            <asp:HiddenField ID="hdCoachID" runat="server" Value="0"></asp:HiddenField>
                                                            <asp:Literal ID="ltrCoachID" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrCoachName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrGenderID" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrBirhtday" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrFacility" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrLevel" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrTaxCode" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lbtEdit" runat="server" ToolTip="Chỉnh người dùng" CommandName="updateUser">
                                                                 <img src="../Images/Edit.gif" alt="Chỉnh sửa Người dùng" />
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="lbtDelete" runat="server" ToolTip="Xóa Người dùng" CommandName="deleteUser" OnClientClick="return confirm('Bạn có thật sự muốn xóa Người dùng này không?');">
                                                                 <img src="../Images/Delete.gif" alt="Xóa Người dùng" />
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
    <uc1:ctrlModalUserDetail runat="server" ID="ctrlModalUserDetail" />
</asp:Content>
