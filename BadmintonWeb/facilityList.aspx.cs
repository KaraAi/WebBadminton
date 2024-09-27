using BadmintonWeb.bussiness;
using BadmintonWeb.ctrl;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb
{
    public partial class facilityList : PageBase
    {
        private int _IsView = 0;
        private int _IsUpdate = 0;
        private int _IsDeleted = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermision();
                LoadListFacility();
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
                UserModules item = objPermision.getViewPermision(MoudleAccessID.Facility, CoachIDLogin);
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
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            CheckPermision();
            string key = txtKeySearch.Value;
            FacilityBussiness objFacility = new FacilityBussiness();
            List<Facilitys> lstItem = objFacility.getAllFacility(key);
            rptFacility.DataSource = lstItem;
            rptFacility.DataBind();
        }
       
        public void LoadListFacility()
        {
            string key = txtKeySearch.Value;
            FacilityBussiness objFacility = new FacilityBussiness();
            List<Facilitys> lstItem = objFacility.getAllFacility(key);
            rptFacility.DataSource = lstItem;
            rptFacility.DataBind();
        }

        protected void rptFacility_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Facilitys item = (Facilitys)e.Item.DataItem;
                HiddenField hdFacilityID = e.Item.FindControl("hdFacilityID") as HiddenField;
                Literal ltrFacilityID = e.Item.FindControl("ltrFacilityID") as Literal;
                Literal ltrFacilityName = e.Item.FindControl("ltrFacilityName") as Literal;
                Literal ltrAddress = e.Item.FindControl("ltrAddress") as Literal;
                Literal ltrLongtitude = e.Item.FindControl("ltrLongtitude") as Literal;
                Literal ltrLatitude = e.Item.FindControl("ltrLatitude") as Literal;
                LinkButton lbtEdit = e.Item.FindControl("lbtEdit") as LinkButton;
                LinkButton lbtDelete = e.Item.FindControl("lbtDelete") as LinkButton;


                hdFacilityID.Value = item.FacilityID.ToString();
                ltrFacilityID.Text = item.FacilityID.ToString();
                ltrFacilityName.Text = item.FacilityName.ToString();
                ltrAddress.Text = item.Address;
                ltrLongtitude.Text=item.Longtitude.ToString();
                ltrLatitude.Text = item.Latitude.ToString();
                if (_IsUpdate == 1)
                    lbtEdit.Enabled = true;
                else
                    lbtEdit.Enabled = false;

                if (_IsDeleted == 1)
                    lbtDelete.Enabled = true;
                else
                    lbtDelete.Enabled = false;


            }
        }
        protected void rptFacility_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int facilityID = int.Parse(((HiddenField)e.Item.FindControl("hdFacilityID")).Value);
            switch (e.CommandName)
            {
                case "deleteFacility":
                    if (facilityID != 0)
                    {
                        FacilityBussiness objFacility = new FacilityBussiness();
                        //check delete group

                        if (objFacility.DeleteFacility(facilityID) == true)
                        {
                            CheckPermision();
                            LoadListFacility();
                            CommonClass.MessageBox.Show("Cơ sở đã được xóa !");
                        }
                        else
                            CommonClass.MessageBox.Show("Lỗi xóa Cơ sở !");
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy Cơ sở cần xóa!");

                    break;

                case "updateFacility":
                    if (facilityID != 0)
                    {
                        ctrlModelFacility.LoadFacilityDetail(facilityID);
                        CheckPermision();
                        LoadListFacility();
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy Cơ sở cần chỉnh !");

                    break;

            }
        }


    }
}