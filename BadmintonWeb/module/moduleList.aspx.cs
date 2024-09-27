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
    public partial class moduleList : PageBase
    {
        LibraryCommon _objLibrary = new LibraryCommon();
        private int _IsView = 0;
        private int _IsUpdate = 0;
        private int _IsDeleted = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermision();
                LoadListModuleAccess();
            }
        }
        public void CheckPermision()
        {
            if (CoachIDLogin == 1)
            {
                _IsView = 1;
                _IsUpdate = 1;
                _IsDeleted = 1;
                hplInsert.Visible = true;
            }
            else
            {
                hplInsert.Visible = false;

                ModuleAccessBussiness objPermision = new ModuleAccessBussiness();
                UserModules item = objPermision.getViewPermision(MoudleAccessID.Module, CoachIDLogin);
                if (item != null)
                {
                    if (item.IsInsert == 1)
                        hplInsert.Visible = true;
                    else
                        hplInsert.Visible = false;

                    if (item.IsUpdate == 1)
                    {
                        _IsUpdate = 1;
                        _IsView = 1;
                    }
                    if (item.IsView == 1)
                        _IsView = 1;

                    if (item.IsDelete == 1)
                    {
                        _IsDeleted = 1;
                    }
                }
            }
        }
        public void LoadListModuleAccess()
        {
            string key = txtKey.Value;
            ModuleAccessBussiness objModule = new ModuleAccessBussiness();
            List<ModuleAccess> lstItem = objModule.getViewListModuleAccess(key);
            rptModuleAccess.DataSource = lstItem;
            rptModuleAccess.DataBind();
        }
        protected void rptModuleAccess_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ModuleAccess item = (ModuleAccess)e.Item.DataItem;
                HiddenField hdModuleID = e.Item.FindControl("hdModuleID") as HiddenField;
                Literal ltrName = e.Item.FindControl("ltrName") as Literal;
                Literal ltrDescription = e.Item.FindControl("ltrDescription") as Literal;
                Literal ltrUserUpdated = e.Item.FindControl("ltrUserUpdated") as Literal;
                Literal ltrDateUpdated = e.Item.FindControl("ltrDateUpdated") as Literal;
                Literal ltrUserCreated = e.Item.FindControl("ltrUserCreated") as Literal;
                Literal ltrDateCreated = e.Item.FindControl("ltrDateCreated") as Literal;
                LinkButton lbtEdit = e.Item.FindControl("lbtEdit") as LinkButton;
                LinkButton lbtDelete = e.Item.FindControl("lbtDelete") as LinkButton;

                hdModuleID.Value = item.ModuleID.ToString();
                ltrName.Text = item.Name.ToString();
                ltrDescription.Text = item.Description.ToString();
                if (_IsUpdate == 1)
                    lbtEdit.Enabled = true;
                else
                    lbtEdit.Enabled = false;

                if (_IsDeleted == 1)
                    lbtDelete.Enabled = true;
                else
                    lbtDelete.Enabled = false;

                ltrUserCreated.Text = item.UserCreated;
                ltrUserUpdated.Text = item.UserUpdated;
                ltrDateCreated.Text = item.DateCreated.ToString("dd/MM/yyyy");
                ltrDateUpdated.Text = item.DateUpdated.ToString("dd/MM/yyyy");
            }
        }

        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            CheckPermision();

            string key = txtKey.Value;
            ModuleAccessBussiness objModule = new ModuleAccessBussiness();
            List<ModuleAccess> lstItem = objModule.getViewListModuleAccess(key);
            rptModuleAccess.DataSource = lstItem;
            rptModuleAccess.DataBind();
        }

        protected void rptModuleAccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            decimal moduleID = decimal.Parse(((HiddenField)e.Item.FindControl("hdModuleID")).Value);
            switch (e.CommandName)
            {
                case "deleteModuleAccess":
                    if (moduleID != 0)
                    {
                        ModuleAccessBussiness objModule = new ModuleAccessBussiness();
                        //check delete group
                        if (objModule.checkDeleteMoudleAccessID(moduleID) == false)
                        {
                            CommonClass.MessageBox.Show("Bộ quyền đang được sử dụng. Không thể xoá !");
                            return;
                        }
                        if (objModule.deleteMoudleAccess(moduleID) == true)
                        {
                            CheckPermision();
                            LoadListModuleAccess();
                            CommonClass.MessageBox.Show("Bộ quyền đã được xóa !");
                        }
                        else
                            CommonClass.MessageBox.Show("Lỗi xóa bộ quyền !");
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy bộ quyền cần xóa!");

                    break;

                case "updateModuleAccess":
                    if (moduleID != 0)
                    {
                        ctrlModuleAccess.LoadDetailSection(moduleID);
                        CheckPermision();
                        LoadListModuleAccess();
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy bộ quyền cần chỉnh !");

                    break;

            }
        }
    }
}