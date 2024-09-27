<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlModalUserDetail.ascx.cs" Inherits="BadmintonWeb.ctrl.ctrlModalUserDetail" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="modal fade" id="myModaUserDetail" role="dialog" runat="server">
    <div class="modal-dialog modalSection">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <asp:LinkButton ID="lbtCloseTop" runat="server" OnClick="lbtCloseTop_Click" CssClass="close" data-dismiss="modal">&times;</asp:LinkButton>
                <h4 class="modal-title">Chi tiết Tài khoản người dùng</h4>
            </div>
            <div class="modal-body bodyUserEdit" style="overflow: scroll;">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_content">
                            <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                    <li role="presentation" class="active" id="liInfor" runat="server"><a href="#ContentPlaceHolder1_ctrlModalUserDetail_tab_contentInfor" id="home-tab"
                                        role="tab" data-toggle="tab" aria-expanded="true">Thông tin người dùng</a>
                                    </li>
                                    <li role="presentation" class="" id="liPermissionModule" runat="server"><a href="#ContentPlaceHolder1_ctrlModalUserDetail_tab_contentPermissionModule" role="tab" id="profile-tabCost"
                                        data-toggle="tab" aria-expanded="false">Phân quyền</a></li>
                                </ul>
                                <div id="myTabContent" class="tab-content">
                                    <div role="tabpanel" class="tab-pane fade active in" id="tab_contentInfor" aria-labelledby="home-tab" runat="server">
                                        <div class="x_content">
                                            <div class="row">
                                                <div class="form-horizontal form-label-left">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Họ và tên:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                           
                                                            <asp:TextBox ID="txtCoachName" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Ảnh đại diện
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                            <asp:Image ID="imgThumbs" runat="server" Width="100" Style="float: left;" />
                                                            <asp:LinkButton ID="lbtChangeImages" runat="server" ToolTip="Đổi Ảnh" OnClick="lbtChangeImages_Click" CssClass="btn btn-primary">Đổi Ảnh</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            CCCD:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtCCCD" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Ngày sinh:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control has-feedback-left datetime"></asp:TextBox>
                                                            <span class="fa fa-calendar form-control-feedback left" aria-hidden="true"></span>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Giới tính:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="" Text="----- Chọn Giới tính -----"></asp:ListItem>
                                                                <asp:ListItem Value="0" Text="Nữ"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Nam"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Cơ sở:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlFacility" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Số điện thoại:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                             <asp:HiddenField ID="hdCoachID" runat="server" Value="0"/>
                                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Mã số thuế:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtTaxCode" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Kinh nghiệm:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Ngân Hàng:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Trình độ học vấn:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlEducation" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="" Text="----- Chọn Trình độ -----"></asp:ListItem>
                                                                <asp:ListItem Value="0" Text="Trung học phổ thông"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Đại học"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Sau Đại học"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            STK:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtBankNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Ngày làm việc:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtWorkingStart" runat="server" CssClass="form-control has-feedback-left datetime"></asp:TextBox>
                                                            <span class="fa fa-calendar form-control-feedback left" aria-hidden="true"></span>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Level
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="" Text="----- Chọn Level -----"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="CoachCEO"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="CoachManager"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Coach"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="Support"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Quê quán:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtPlaceOfOrigin" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Mức lương:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtSalary" runat="server" CssClass="moneyformat" Text="0" Style="width: 100%;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Địa chỉ:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtPlaceOfResidence" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Trạng thái
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlStatusID" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="" Text="----- Chọn Trạng Thái -----"></asp:ListItem>
                                                                <asp:ListItem Value="0" Text="Đang dạy"></asp:ListItem>
                                                                <asp:ListItem Vaule="1" Text="Nghỉ tạm thời"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Nghỉ"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Mật khẩu:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:LinkButton ID="lbtResetPass" runat="server" OnClick="lbtResetPass_Click" CssClass="resetpass">Reset mật khẩu</asp:LinkButton>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Tình trạng hôn nhân
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="0" Text="Không"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Có"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Ghi chú</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Tình trạng Sức khoẻ
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtHealthCondition" runat="server" CssClass="form-control">
                                                            </asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Email:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="x_title">
                                                        <h2>Thông tin thêm</h2>
                                                        <ul class="nav navbar-right panel_toolbox">
                                                        </ul>
                                                        <div class="clearfix">
                                                        </div>
                                                    </div>
                                                    <div class="x_content">
                                                        <div class="row">
                                                            <div class="form-horizontal form-label-left">
                                                                <div class="form-group">
                                                                    <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                                        Tên người liên hệ:</label>
                                                                    <div class="col-md-4 col-sm-9 col-xs-12">
                                                                        <asp:TextBox ID="txtNamePerson" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                                        Mối quan hệ:
                                                                    </label>
                                                                    <div class="col-md-4 col-sm-9 col-xs-12">
                                                                        <asp:TextBox ID="txtRelationship" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                                        Số điện thoại:</label>
                                                                    <div class="col-md-4 col-sm-9 col-xs-12">
                                                                        <asp:TextBox ID="txtPhonePerson" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="tab_contentPermissionModule" aria-labelledby="profile-tab" runat="server">
                                        <div class="x_panel">
                                            <div class="x_content">
                                                <div id="datatable_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <table id="datatablePermission" class="table table-striped table-bordered dataTable no-footer datatablevu"
                                                                style="width: 100% !important;">
                                                                <thead>
                                                                    <tr role="row">
                                                                        <th class="sorting_desc" aria-controls="datatableComment" style="width: 150px;"
                                                                            id="1" aria-sort="descending">Tên module
                                                                        </th>
                                                                        <th>Mô tả
                                                                        </th>
                                                                        <th style="width: 70px;">Xem
                                                                        </th>
                                                                        <th style="width: 70px;">Thêm mới
                                                                        </th>
                                                                        <th style="width: 70px;">Chỉnh sửa
                                                                        </th>
                                                                        <th style="width: 70px;">Xóa
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <asp:Repeater ID="rptModuleAccess" runat="server" OnItemDataBound="rptModuleAccess_ItemDataBound">
                                                                        <ItemTemplate>
                                                                            <tr role="row" class="odd">
                                                                                <td class="sorting_1">
                                                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdModuleID" runat="server" />
                                                                                    <%--<input type="checkbox" id="chkView" name="vehicle1" value="Bike">--%>
                                                                                    <asp:CheckBox ID="chkView" runat="server" />
                                                                                </td>
                                                                                <td>
                                                                                    <%--<input type="checkbox" id="chkInsert" name="vehicle1" value="Bike">--%>
                                                                                    <asp:CheckBox ID="chkInsert" runat="server" />

                                                                                </td>
                                                                                <td>
                                                                                    <%--<input type="checkbox" id="chkUpdate" name="vehicle1" value="Bike">--%>
                                                                                    <asp:CheckBox ID="chkUpdate" runat="server" />
                                                                                </td>
                                                                                <td>
                                                                                    <%--<input type="checkbox" id="chkDelete" name="vehicle1" value="Bike">--%>
                                                                                    <asp:CheckBox ID="chkDelete" runat="server" />
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
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="lbtInsertUser" runat="server" CssClass="btn btn-primary" OnClick="lbtInsertUser_Click">Lưu lại</asp:LinkButton>
                <asp:LinkButton ID="lbtClose" runat="server" CssClass="btn btn-default" data-dismiss="modal" OnClick="lbtClose_Click">Đóng</asp:LinkButton>
            </div>
        </div>

    </div>
</div>
