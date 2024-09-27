<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlModelStudent.ascx.cs" Inherits="BadmintonWeb.ctrl.ctrlModelStudent" %>


<div class="modal fade" id="myModelStudent" role="dialog" runat="server">
    <div class="modal-dialog modalSection">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <asp:LinkButton ID="lbtCloseTop" runat="server" OnClick="lbtCloseTop_Click" CssClass="close" data-dismiss="modal">&times;</asp:LinkButton>
                <h4 class="modal-title">Chi tiết Học viên</h4>
            </div>
            <div class="modal-body bodyUserEdit"  style="overflow: scroll;">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_content">
                            <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                <div id="myTabContent" class="tab-content">
                                    <div role="tabpanel" class="tab-pane fade active in" id="tab_contentInfor" aria-labelledby="home-tab" runat="server">
                                        <%-- <div class="x_panel minheightchiltab">--%>
                                        <div class="x_content">
                                            <div class="row">
                                                <div class="form-horizontal form-label-left">
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Họ và tên:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                           
                                                            <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control"></asp:TextBox>
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
                                                            Ca học:*</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlTimeID" runat="server" CssClass="form-control"></asp:DropDownList>
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
                                                             <asp:HiddenField ID="hdStudentID" runat="server" Value="0" />
                                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Email:*
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Huấn Luyện viên:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlCoachID" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Học Phí:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtTuiTions" runat="server" CssClass="moneyformat" Text="0" Style="width: 100%;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Địa chỉ:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control">
                                                            </asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Level:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="" Text="----- Chọn Level -----"></asp:ListItem>
                                                                <asp:ListItem Value="0" Text="Chuyên biệt"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="5"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="6"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="7"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="8"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="9"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="10"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Ngày Bắt đầu:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtStartDay" runat="server" CssClass="form-control has-feedback-left datetime"></asp:TextBox>
                                                            <span class="fa fa-calendar form-control-feedback left" aria-hidden="true"></span>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Trạng thái:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:DropDownList ID="ddlStatusID" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="" Text="----- Chọn Trạng Thái -----"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Đang học"></asp:ListItem>
                                                                <asp:ListItem Vaule="1" Text="Nghỉ tạm thời"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="Chưa học"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Người giám hộ:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtGuardianName" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Số điện thoại:
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtGuardianPhone" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Quan hệ:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtRelationship" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                            Mật khẩu:*
                                                        </label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:LinkButton ID="lbtResetPass" runat="server" OnClick="lbtResetPass_Click" CssClass="resetpass">Reset mật khẩu</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                            Ghi chú:</label>
                                                        <div class="col-md-4 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
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
                                                                        Tình trạng sức khoẻ:</label>
                                                                    <div class="col-md-4 col-sm-9 col-xs-12">
                                                                        <asp:TextBox ID="txtHealthCondition" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-md-2 col-sm-3 col-xs-12">
                                                                        Cân nặng:
                                                                    </label>
                                                                    <div class="col-md-4 col-sm-9 col-xs-12">
                                                                        <asp:TextBox ID="txtWeight" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="control-label col-md-1 col-sm-3 col-xs-12">
                                                                        Chiều cao:</label>
                                                                    <div class="col-md-4 col-sm-9 col-xs-12">
                                                                        <asp:TextBox ID="txtHeight" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="lbtInsert" runat="server" CssClass="btn btn-primary" OnClick="lbtInsert_Click">Lưu lại</asp:LinkButton>
                <asp:LinkButton ID="lbtClose" runat="server" CssClass="btn btn-default" data-dismiss="modal" OnClick="lbtClose_Click">Đóng</asp:LinkButton>
            </div>
        </div>

    </div>
</div>
