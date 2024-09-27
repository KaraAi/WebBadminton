using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.ctrl
{
    public partial class ctrlModelTime : UserControlBase
    {
        TimeBussiness objTime = new TimeBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        private void ClearText()
        {
            txtTimeName.Text = "";
        }
        public void LoadDetailTime(int TimeID)
        {
            Time item = objTime.GetTimeByID(TimeID);
            if (item != null)
            {
                txtTimeName.Text = item.TimeName.ToString();
            }
            DisplayBlock();
        }
        protected void lbtInsert_Click(object sender, EventArgs e)
        {
            int timeID = 0;
            int.TryParse(hdTimeID.Value, out timeID);
            if (timeID == 0)
            {
                Insert();
            }
            else
            {
                Update(timeID);
            }
        }
        private void Insert()
        {
            try
            {
                string TimeName = txtTimeName.Text.ToString();

                string UserName = this.CoachNameLogin;
                Time item = objTime.insertTime(TimeName,UserName);
                if (item != null)
                {

                    this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    this.Page.GetType().InvokeMember("LoadListTime", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    ClearText();
                    CommonClass.MessageBox.Show("Thêm mới Ca học thành công !");
                    DisplayNone();
                }
                else
                    CommonClass.MessageBox.Show("Lỗi thêm mới Ca học.");

            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi thêm mới Ca học.");
            }
        }
        private void Update(int timeID)
        {
            try
            {
                string TimeName = txtTimeName.Text.ToString();

                string UserName = this.CoachNameLogin;
                Time item = objTime.updateTime(timeID,TimeName, UserName);
                if (item != null)
                {

                    this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    this.Page.GetType().InvokeMember("LoadListTime", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    ClearText();
                    CommonClass.MessageBox.Show("Cập nhật Ca học thành công !");
                    DisplayNone();
                }
                else
                    CommonClass.MessageBox.Show("Lỗi cập nhật Ca học.");

            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi cập nhật Ca học.");
            }
        }
        protected void lbtClose_Click(object sender, EventArgs e)
        {
            ClearText();
            DisplayNone();
        }
        protected void lbtCloseTop_Click(object sender, EventArgs e)
        {
            ClearText();
            DisplayNone();
        }
        private void DisplayBlock()
        {
            myModelTime.Attributes.Add("style", "display:block;");
            myModelTime.Attributes.Add("class", "modal fade in");
        }
        private void DisplayNone()
        {
            myModelTime.Attributes.Add("style", "display:none;");
            myModelTime.Attributes.Add("class", "modal fade in");
        }
    }
}