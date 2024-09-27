using BadmintonWeb.bussiness;
using BadmintonWeb.ctrl;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.time
{
    public partial class timeList : PageBase
    {
        private int _IsView = 0;
        private int _IsUpdate = 0;
        private int _IsDeleted = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermision();
                LoadListTime();
                
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
                UserModules item = objPermision.getViewPermision(MoudleAccessID.Time, CoachIDLogin);
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
      
        public void LoadListTime()
        {
            //TimeBussiness objTime = new TimeBussiness();
            //List<Time> lstItem = objTime.GetAllTime();
            string key = txtKey.Value;
            TimeBussiness objTime = new TimeBussiness();
            List<Time> lstItem = objTime.getViewListTime(key);
            rptTime.DataSource = lstItem;
            rptTime.DataBind();
        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            CheckPermision();

            string key = txtKey.Value;
            TimeBussiness objTime = new TimeBussiness();
            List<Time> lstItem = objTime.getViewListTime(key);
            rptTime.DataSource = lstItem;
            rptTime.DataBind();
        }
        protected void rptTime_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Time item = (Time)e.Item.DataItem;
                HiddenField hdTimeID = e.Item.FindControl("hdTimeID") as HiddenField;
                Literal ltrTimeID = e.Item.FindControl("ltrTimeID") as Literal;
                Literal ltrTimeName = e.Item.FindControl("ltrTimeName") as Literal;
                Literal ltrUserCreated = e.Item.FindControl("ltrUserCreated") as Literal;
                Literal ltrDateCreated = e.Item.FindControl("ltrDateCreated") as Literal;
                Literal ltrUserUpdated = e.Item.FindControl("ltrUserUpdated") as Literal;
                Literal ltrDateUpdated = e.Item.FindControl("ltrDateUpdated") as Literal;
                LinkButton lbtEdit = e.Item.FindControl("lbtEdit") as LinkButton;
                LinkButton lbtDelete = e.Item.FindControl("lbtDelete") as LinkButton;

             

                hdTimeID.Value =  item.TimeID.ToString();
                ltrTimeID.Text = item.TimeID.ToString();
                ltrTimeName.Text = item.TimeName.ToString();
                ltrUserCreated.Text = item.UserCreated.ToString();
                ltrDateCreated.Text = item.DateCreated.ToString("dd/MM/yyyy");
                ltrUserUpdated.Text = item.UserUpdated.ToString();
                if (_IsUpdate == 1)
                    lbtEdit.Enabled = true;
                else
                    lbtEdit.Enabled = false;

                if (_IsDeleted == 1)
                    lbtDelete.Enabled = true;
                else
                    lbtDelete.Enabled = false;


                ltrDateUpdated.Text = item.DateUpdated.ToString("dd/MM/yyyy");
            }
        }
        protected void rptTime_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int timeID = int.Parse(((HiddenField)e.Item.FindControl("hdTimeID")).Value);
            switch (e.CommandName)
            {
                case "deleteTime":
                    if (timeID != 0)
                    {
                        TimeBussiness objTime = new TimeBussiness();
                        //check delete group
                      
                        if (objTime.DeleteTime(timeID) == true)
                        {
                            CheckPermision();
                            LoadListTime();
                            CommonClass.MessageBox.Show("Ca học đã được xóa !");
                        }
                        else
                            CommonClass.MessageBox.Show("Lỗi xóa Ca học !");
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy Ca học cần xóa!");

                    break;

                case "updateTime":
                    if (timeID != 0)
                    {
                        ctrlModelTime.LoadDetailTime(timeID);
                        CheckPermision();
                        LoadListTime();
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy Ca học cần chỉnh !");

                    break;

            }
        }

    }
}