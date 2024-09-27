<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlModuleAccess.ascx.cs" Inherits="BadmintonWeb.ctrl.ctrlModuleAccess" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div class="modal fade" id="myModuleAccess" role="dialog" runat="server">
    <div class="modal-dialog modalSection">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <asp:LinkButton ID="lbtCloseTop" runat="server" OnClick="lbtCloseTop_Click" CssClass="close" data-dismiss="modal">&times;</asp:LinkButton>
                <h4 class="modal-title">Chi tiết Bộ quyền</h4>
            </div>
            <div class="modal-body" style="overflow: hidden;">
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
                                                        <label class="col-md-12 col-sm-3 col-xs-12">
                                                            Tên bộ quyền</label>
                                                        <div class="col-md-12 col-sm-9 col-xs-12">
                                                            <asp:HiddenField ID="hdModuleID" runat="server" Value="0" />
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="rqUserName" runat="server" ErrorMessage="Vui lòng nhập mã người dùng" ControlToValidate="txtUserName" CssClass="parsley-error"
                                                                    ValidationGroup="sfsdfd" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-md-12 col-sm-3 col-xs-12">
                                                            Nội dung</label>
                                                        <div class="col-md-12 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                <asp:LinkButton ID="lbtClose" runat="server" CssClass="btn btn-default" data-dismiss="modal" OnClick="lbtClose_Click">Close</asp:LinkButton>
            </div>
        </div>

    </div>
</div>
