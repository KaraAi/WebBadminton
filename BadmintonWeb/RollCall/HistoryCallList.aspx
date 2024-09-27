<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/userMasterPage.Master" AutoEventWireup="true" CodeBehind="HistoryCallList.aspx.cs" Inherits="BadmintonWeb.RollCall.HistoryCallList" %>
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
                      <h2>Lịch Sử Điểm Danh</h2>
                      <ul class="nav navbar-right">
                      </ul>
                      <div class="clearfix">
                      </div>
                  </div>
                  <div class="x_content" runat="server">
                      <div class="form-horizontal form-label-left">
                          <div class="form-group " runat="server">
                              <label class="control-label col-md-2 col-sm-2 col-xs-12">
                                  Chọn ngày</label>
                              <div class="col-md-3 col-sm-3 col-xs-12">
                                  <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control has-feedback-left datetime"></asp:TextBox>
                                    <span class="fa fa-calendar form-control-feedback left" aria-hidden="true"></span>
                              </div>
                              <label class="control-label col-md-2 col-sm-2 col-xs-12">
                                  Huấn Luyện Viên</label>
                              <div class="col-md-3 col-sm-3 col-xs-12">
                                  <asp:DropDownList ID="ddlCoachID" CssClass="form-control" runat="server">
                                  </asp:DropDownList>
                              </div>
                              <div class="col-md-2 col-sm-2 col-xs-12 btn-search ">
                                  <asp:LinkButton ID="lbtSearch" runat="server" CssClass="btn btn-orange" OnClick="lbtSearch_Click" ToolTip="Tìm kiếm">Tìm kiếm</asp:LinkButton>
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
                                              <th style="width: 100px;">Học viên</th>
                                              <th style="width: 50px;">Người điểm danh</th>
                                              <th style="width: 50px;">Ngày điểm danh</th>
                                          </tr>
                                      </thead>
                                      <tbody>
                                          <asp:Repeater ID="rptRollCall" runat="server" OnItemDataBound="rptRollCall_ItemDataBound">
                                              <ItemTemplate>
                                                  <tr role="row" class="odd" runat="server">
                                                      <td>
                                                          <asp:HiddenField ID="hdRollCallID" runat="server" Value="0"></asp:HiddenField>
                                                          <asp:Literal ID="ltrRollCallID" runat="server"></asp:Literal>
                                                      </td>
                                                      <td>
                                                          <asp:Literal ID="ltrStudentName" runat="server"></asp:Literal>
                                                      </td>
                                                      <td>
                                                          <asp:Literal ID="ltrUserCreated" runat="server"></asp:Literal>
                                                      </td>
                                                      <td>
                                                          <asp:Literal ID="ltrDateCreated" runat="server"></asp:Literal>
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
</asp:Content>
