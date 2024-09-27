<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlMenuLeftTop.ascx.cs" Inherits="BadmintonWeb.ctrl.ctrlMenuLeftTop" %>
<div class="col-md-3 left_col">
    <div class="left_col scroll-view">
        <div class="navbar nav_title" style="border: 0;">
            <a href="../default.aspx" class="site_title" title="DavidBadminton">
                <img src="../Images/logo.png" alt="DavidBadminton" width="35px" />
                <span>&nbsp;</span>
            </a>
        </div>
        <div class="clearfix">
        </div>

        <br />
        <!-- sidebar menu -->
        <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
            <div class="menu_section">
                <%--<h3>General</h3>--%>
                <ul class="nav side-menu">
                    <li>
                        <a title=""><i class="fa fa-calendar"></i>Điểm danh <span class="fa fa-chevron-down"></span></a>
                        <ul class="nav child_menu">
                            <li  runat="server" id="htmlRollCall"><a href="../RollCall/rollcallList.aspx">Điểm Danh</a></li>
                            <li runat="server" id="liHistoryRollCall"><a href="../RollCall/HistoryCallList.aspx">Lịch sử điểm danh</a></li>
                        </ul>
                    </li>
                    <li runat="server" id="htmlStudentList"><a href="../student/studentList.aspx"><i class="fa fa-users"></i>Danh sách học viên</a>
                    </li>
                    <li runat="server" id="htmlCoachList"><a href="../coach/coachList.aspx"><i class=" fa fa-solid fa-user-tie"></i>Huấn Luyện viên </a>
                    </li>
                    <li runat="server" id="htmlFacilityList"><a href="../facilityList.aspx"><i class="fa fa-regular fa-building"></i>Cơ sở</a>
                    </li>
                    <li runat="server" id="htmlTimeList"><a href="../time/timeList.aspx"><i class="fa fa-solid fa-hourglass-start"></i>Ca học</a>
                    </li>
                    <li runat="server" id="htmlInformation"><a href="../module/moduleList.aspx"><i class="fa fa-solid fa-users-gear"></i>Người dùng </a>
                       
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<!-- top navigation -->
<div class="top_nav">
    <div class="nav_menu">
        <nav>
            <div class="nav toggle">
                <a id="menu_toggle"><i class="fa fa-bars"></i></a>
            </div>
            <ul class="nav navbar-nav navbar-right">
                <li class="">
                    <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                        <%--<img src="images/img.jpg" alt="">--%>
                        <asp:Image ID="imgUser1" runat="server" />
                        <%--Administators--%>
                        <asp:Literal ID="ltrUserCode1" runat="server"></asp:Literal>

                        <span class="fa fa-angle-down"></span>
                    </a>
                    <ul class="dropdown-menu dropdown-usermenu pull-right customertop100">
                        <li>
                            <asp:HyperLink ID="hplProfile" runat="server">Thông tin Tài khoản</asp:HyperLink>
                        </li>
                         <li><a href="../module/ChangePassword.aspx">Đổi mật khẩu</a></li>
                        <li><a href="../logins.aspx"><i class="fa fa-sign-out pull-right"></i>Log Out</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
    </div>
</div>

