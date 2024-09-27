using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.module
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        CoachBussiness objCoach = new CoachBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void lbtChangePass_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string passwordold = CommonClass.StringValidator.GetMD5String(txtPassOld.Text.Trim());
            string passwordnew = CommonClass.StringValidator.GetMD5String(txtPassNewAgain.Text.Trim());
            string userUpdated = Session["Phone"].ToString();

            Coachs item = objCoach.checkLogin(username, passwordold);
            if (item != null)
            {
                if (objCoach.ChangePassWord(username, passwordold, passwordnew, userUpdated) == true)
                    CommonClass.MessageBox.Show("Đổi mật khẩu thành công.");
                else
                    CommonClass.MessageBox.Show("Lỗi đổi mật khẩu.");
            }
            else
                CommonClass.MessageBox.Show("Không tìm thấy user cần đổi mật khẩu.");
        }

    }
}