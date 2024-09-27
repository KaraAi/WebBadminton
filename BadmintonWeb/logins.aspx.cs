using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb
{
    public partial class logins : PageBase
    {
        CoachBussiness objCoach = new CoachBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtCode.Attributes.Add("onkeypress", "button_click(this,'" + this.lbtLogin.ClientID + "')");
                this.txtPassWord.Attributes.Add("onkeypress", "button_click(this,'" + this.lbtLogin.ClientID + "')");
            }

        }
        protected void lbtLogin_Click(object sender, EventArgs e)
        {
            string strUserName = CommonClass.StringValidator.GetSafeString(txtCode.Text.Trim().ToString());
            string strPassWord = CommonClass.StringValidator.GetMD5String(txtPassWord.Text.Trim());

            Coachs item = objCoach.checkCoachLogin(strUserName,strPassWord);
            if (item != null)
            {
              
                    Session["CoachID"] = item.CoachID;
                    Session["Phone"] = strUserName;
                    Session["CoachName"] = item.CoachName;
                    Session["PassWord"] = true;
                    Session["TypeUserID"] = item.TypeUserID;

                    this.CoachNameLogin = item.CoachName;
                    Response.Redirect("~/RollCall/rollcallList.aspx");
               
            }
            else
            {
                CommonClass.MessageBox.Show("Tên truy cập hoặc mật khẩu truy cập không đúng");
                txtPassWord.Text = string.Empty;
                txtPassWord.Focus();
            }

        }
    }
}