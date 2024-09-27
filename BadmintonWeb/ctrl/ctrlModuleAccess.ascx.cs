using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.ctrl
{
    public partial class ctrlModuleAccess : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        private void ClearText()
        {
            hdModuleID.Value = "0";
            txtName.Text = "";
            txtDescription.Text = "";
        }
        public void LoadDetailSection(decimal moduleID)
        {
            ModuleAccessBussiness objModule = new ModuleAccessBussiness();
            ModuleAccess item = objModule.getMoudleAccessByID(moduleID);
            if (item != null)
            {
                hdModuleID.Value = item.ModuleID.ToString();
                txtName.Text = item.Name;
                txtDescription.Text = item.Description;
            }
            DisplayBlock();

        }

        protected void lbtInsert_Click(object sender, EventArgs e)
        {
            decimal moduleID = 0;
            decimal.TryParse(hdModuleID.Value, out moduleID);
            if (moduleID == 0)
            {
                Insert();
            }
            else
            {
                Update(moduleID);
            }
        }
        private bool checkInsert()
        {
            if (txtName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Tên bộ quyền module!");
                DisplayBlock();
                txtName.Focus();
                return false;
            }
            ModuleAccessBussiness objModule = new ModuleAccessBussiness();
            if (objModule.checkInserMoudleAccess(txtName.Text.Trim()) == false)
            {
                CommonClass.MessageBox.Show("Tên bộ quyền này đã tồn tại. Vui lòng nhập tên khác!");
                DisplayBlock();
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void Insert()
        {
            try
            {
                if (checkInsert() == false)
                    return;
                string statusName = txtName.Text.Trim();
                string userName = CoachNameLogin;
                string description = txtDescription.Text.Trim();
                ModuleAccessBussiness objModule = new ModuleAccessBussiness();
                ModuleAccess item = objModule.insertMoudleAccess(statusName, description, userName);
                if (item != null)
                {
                    this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    this.Page.GetType().InvokeMember("LoadListModuleAccess", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    ClearText();
                    CommonClass.MessageBox.Show("Thêm mới Bộ quyền module thành công !");
                    DisplayNone();
                }
                else
                    CommonClass.MessageBox.Show("Lỗi thêm mới Bộ quyền module.");
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi thêm mới Bộ quyền module.");
            }
        }
        private bool checkUpdate(decimal moduleID)
        {

            if (txtName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Tên Bộ quyền module!");
                DisplayBlock();
                txtName.Focus();
                return false;
            }
            ModuleAccessBussiness objModule = new ModuleAccessBussiness();
            if (objModule.checkUpdateMoudleAccess(moduleID, txtName.Text.Trim()) == false)
            {
                CommonClass.MessageBox.Show("Tên Bộ quyền module này đã tồn tại. Vui lòng nhập tên khác!");
                DisplayBlock();
                txtName.Focus();
                return false;
            }

            return true;
        }
        private void Update(decimal moduleID)
        {
            if (checkUpdate(moduleID) == false)
                return;
            string statusName = txtName.Text.Trim();
            string userName = CoachNameLogin;
            string description = txtDescription.Text.Trim();
            ModuleAccessBussiness objModule = new ModuleAccessBussiness();
            ModuleAccess item = objModule.updateMoudleAccess(moduleID, statusName, description, userName);
            if (item != null)
            {
                this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                this.Page.GetType().InvokeMember("LoadListModuleAccess", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                ClearText();
                CommonClass.MessageBox.Show("Chỉnh sửa Bộ quyền module thành công !");
                DisplayNone();
            }
            else
                CommonClass.MessageBox.Show("Lỗi chỉnh sửa Bộ quyền module.");
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
            myModuleAccess.Attributes.Add("style", "display:block;");
            myModuleAccess.Attributes.Add("class", "modal fade in");
        }
        private void DisplayNone()
        {
            myModuleAccess.Attributes.Add("style", "display:none;");
            myModuleAccess.Attributes.Add("class", "modal fade in");
        }
    }
}