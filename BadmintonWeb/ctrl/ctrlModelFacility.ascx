<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlModelFacility.ascx.cs" Inherits="BadmintonWeb.ctrl.ctrlModelFacility" %>



<div class="modal fade" id="myModelFacility" role="dialog" runat="server">
    <div class="modal-dialog modalSection">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <asp:LinkButton ID="lbtCloseTop" runat="server" OnClick="lbtCloseTop_Click" CssClass="close" data-dismiss="modal">&times;</asp:LinkButton>
                <h4 class="modal-title">Chi tiết Cơ sở</h4>
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
                                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                                            Tên cơ sở</label>
                                                        <div class="col-md-5 col-sm-9 col-xs-12">
                                                            <asp:HiddenField  ID="hdFacilityID" runat="server" Value="0"/>
                                                            <asp:TextBox ID="txtFacilityName" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                                            Địa chỉ</label>
                                                        <div class="col-md-5 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                                            Kinh độ</label>
                                                        <div class="col-md-5 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtLongtitude" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                                            Vĩ độ</label>
                                                        <div class="col-md-5 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:LinkButton ID="lbtInsert" runat="server" CssClass="btn btn-primary" OnClick="lbtInsert_Click">Lưu lại</asp:LinkButton>
                <asp:LinkButton ID="lbtClose" runat="server" CssClass="btn btn-default" data-dismiss="modal" OnClick="lbtClose_Click">Close</asp:LinkButton>
            </div>
        </div>

    </div>
</div>
