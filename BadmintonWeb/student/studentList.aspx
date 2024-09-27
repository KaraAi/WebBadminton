<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="studentList.aspx.cs" Inherits="BadmintonWeb.student.studentList" %>

<%@ Register Src="~/ctrl/ctrlModelStudent.ascx" TagPrefix="uc1" TagName="ctrlModelStudent" %>


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
                        <h2>Danh sách Học viên</h2>
                        <ul class="nav navbar-right">
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content" runat="server">
                        <div class="form-horizontal form-label-left">
                            <div class="form-group" runat="server">
                                <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                    Từ khoá
                                </label>
                                <div class="col-md-4 col-sm-9 col-xs-12">
                                    <input id="txtKeySearch" runat="server" class="form-control" placeholder="Tên, HLV" />
                                </div>
                                <div class="col-md-2 col-sm-9 col-xs-6 btn-search">
                                    <asp:LinkButton ID="lbtSearch" runat="server" CssClass="btn btn-orange" OnClick="lbtSearch_Click" ToolTip="Tìm kiếm">Tìm kiếm</asp:LinkButton>
                                </div>
                                <div class="col-md-2 col-sm-9 col-xs-6 btn-add">
                                    <asp:HyperLink ID="hplInsert" runat="server" CssClass="btn btn-green" data-toggle="modal" ToolTip="Thêm mới" data-target="#ContentPlaceHolder1_ctrlModelStudent_myModelStudent">Thêm mới</asp:HyperLink>
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
                                                <th class="sorting_desc" tabindex="0" aria-controls="datatableComment" rowspan="1" colspan="1" style="width: 50px;"
                                                    aria-sort="descending">Số thứ tự
                                                </th>
                                                <th style="width: 160px;">Tên Học viên</th>
                                                <th style="width: 50px;">Ngày sinh</th>
                                                <th style="width: 50px;">Số điện thoại</th>
                                                <th style="width: 160px;">HLV</th>
                                                <th style="width: 100px;">Ca học</th>
                                                <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1"
                                                    style="width: 100px;" aria-label="Start date: activate to sort column ascending">Action
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptStudent" runat="server" OnItemDataBound="rptStudent_ItemDataBound" OnItemCommand="rptStudent_ItemCommand">
                                                <ItemTemplate>
                                                    <tr role="row" class="odd" runat="server">
                                                        <td>
                                                            <asp:HiddenField ID="hdStudentID" runat="server" Value="0"></asp:HiddenField>
                                                            <asp:Literal ID="ltrStudentID" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrStudentName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrBirthday" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrCoachID" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrTimeID" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lbtEdit" runat="server" ToolTip="Chỉnh học viên" CommandName="updateStudent">
                                                                    <img src="../Images/Edit.gif" alt="Chỉnh sửa học viên" />
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="lbtDelete" runat="server" ToolTip="Xóa học viên" CommandName="deleteStudent" OnClientClick="return confirm('Bạn có thật sự muốn học viên này không?');">
                                                                    <img src="../Images/Delete.gif" alt="Xóa học viên" />
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
    <uc1:ctrlModelStudent runat="server" id="ctrlModelStudent" />
</asp:Content>
