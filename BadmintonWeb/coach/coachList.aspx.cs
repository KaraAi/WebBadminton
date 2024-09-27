using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.coach
{
    public partial class coachList : PageBase
    {
        private int _IsView = 0;
        private int _IsUpdate = 0;
        private int _IsDeleted = 0;
        CoachBussiness objCoach = new CoachBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
                CheckPermision();
                loadDDLTypeUser();
                LoadListCoach();
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
                UserModules item = objPermision.getViewPermision(MoudleAccessID.Coach, CoachIDLogin);
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

        private void loadDDLTypeUser()
        {
            CoachBussiness objUser = new CoachBussiness();
            List<TypeUsers> lstItem = objUser.getAllTypeUser().Where(s => s.TypeUserID == TypeUserIDContans.HLV
                                                             || s.TypeUserID == TypeUserIDContans.Administrator).ToList();
            if (lstItem.Count > 0)
            {
                ddTypeUserID.Items.Clear();
                foreach (TypeUsers type in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = type.UserName;
                    item.Value = type.TypeUserID.ToString();
                    ddTypeUserID.Items.Add(item);
                }
            }
        }
        private string getNameFacility(int facilityID)
        {
            FacilityBussiness objPosition = new FacilityBussiness();
            Facilitys item = objPosition.getFacilityID(facilityID);
            if (item != null)
                return item.FacilityName;
            return "";
        }
        public void LoadListCoach()
        {
            string key = txtKey.Value;
            int typeUserID = int.Parse(ddTypeUserID.SelectedValue.ToString());
            CoachBussiness objUser = new CoachBussiness();
            List<Coachs> lstItem = objUser.getAllUser(key, typeUserID);
            rptCoach.DataSource = lstItem;
            rptCoach.DataBind();
        }
       
        protected void rptCoach_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Coachs item = (Coachs)e.Item.DataItem;
                HiddenField hdCoachID = e.Item.FindControl("hdCoachID") as HiddenField;
                Literal ltrCoachID = e.Item.FindControl("ltrCoachID") as Literal;
                Literal ltrCoachName = e.Item.FindControl("ltrCoachName") as Literal;
                Literal ltrGenderID = e.Item.FindControl("ltrGenderID") as Literal;
                Literal ltrBirhtday = e.Item.FindControl("ltrBirhtday") as Literal;
                Literal ltrFacility = e.Item.FindControl("ltrFacility") as Literal;
                Literal ltrLevel = e.Item.FindControl("ltrLevel") as Literal;
                Literal ltrTaxCode = e.Item.FindControl("ltrTaxCode") as Literal;
                LinkButton lbtEdit = e.Item.FindControl("lbtEdit") as LinkButton;
                LinkButton lbtDelete = e.Item.FindControl("lbtDelete") as LinkButton;

                //string links = "~/coach/coachDetail.aspx?coachID=" + item.CoachID;
                //hdCoachID.Value = string.Format("<a href='{0}' title='{1}'>{1}</a>", ResolveUrl(links), item.CoachID);
                //ltrCoachID.Text = string.Format("<a href='{0}' title='{1}'>{1}</a>", ResolveUrl(links), item.CoachID);
                //ltrCoachName.Text = string.Format("<a href='{0}' title='{1}'>{1}</a>", ResolveUrl(links), item.CoachName);
                hdCoachID.Value = item.CoachID.ToString();
                ltrFacility.Text = getNameFacility(item.FacilityID);
                ltrCoachName.Text = item.CoachName;
                ltrGenderID.Text = LoadGenderName(item.GenderID);
                ltrBirhtday.Text = item.Birthday.ToString("dd/MM/yyyy");
                ltrCoachID.Text = item.CoachID.ToString();

                if (_IsUpdate == 1)
                    lbtEdit.Enabled = true;
                else
                    lbtEdit.Enabled = false;

                if (_IsDeleted == 1)
                    lbtDelete.Enabled = true;
                else
                    lbtDelete.Enabled = false;

                ltrLevel.Text = LoadLevelName(item.Level);
                ltrTaxCode.Text = item.TaxCode.ToString();
            }
        }
        private string LoadGenderName(int GenderID)
        {
            if (GenderID == 0)
                return "Nữ";
            else if (GenderID == 1)
                return "Nam";
            return "";
        }
        private string LoadLevelName(int Level)
        {
            if (Level == 1)
                return "CoachCEO";
            else if (Level == 2)
                return "CoachManager";
            else if (Level == 3)
                return "Coach";
            else if (Level == 4)
                return "Support";
            return "";
        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            CheckPermision();

            string key = txtKey.Value;
            int typeUserID = int.Parse(ddTypeUserID.SelectedValue.ToString());
            CoachBussiness objUser = new CoachBussiness();
            List<Coachs> lstItem = objUser.getAllUser(key, typeUserID);
            rptCoach.DataSource = lstItem;
            rptCoach.DataBind();
        }
        protected void rptCoach_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int coachID = int.Parse(((HiddenField)e.Item.FindControl("hdCoachID")).Value);
            switch (e.CommandName)
            {
                case "deleteUser":
                    if (coachID != 0)
                    {
                        CoachBussiness objUser = new CoachBussiness();
                        //check delete group
                        if (objUser.checkDeleteCoach(coachID) == false)
                        {
                            CommonClass.MessageBox.Show("Người dùng này đã được sử dụng. Không thể xoá !");
                            return;
                        }
                        if (coachID == 1)
                        {
                            CommonClass.MessageBox.Show("Đây là user hệ thống. Không thể xoá !");
                            return;
                        }
                        if (objUser.deleteCoach(coachID) == true)
                        {
                            CheckPermision();
                            LoadListCoach();
                            CommonClass.MessageBox.Show("Người dùng đã được xóa!");
                        }
                        else
                            CommonClass.MessageBox.Show("Lỗi xóa người dùng !");
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy người dùng cần xóa !");

                    break;

                case "updateUser":
                    if (coachID != 0)
                    {
                        ctrlModalUserDetail.LoadDetailUser(coachID);
                        CheckPermision();
                        LoadListCoach();
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy người dùng cần chỉnh !");

                    break;

            }
        }
    }
}