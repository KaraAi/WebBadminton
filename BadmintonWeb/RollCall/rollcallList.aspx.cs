using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.RollCall
{
    public partial class rollcallList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadddlFacility();
                LoaddlTimeID();
                LoadddlCoach();
            }
        }
        public void LoadddlFacility()
        {
            FacilityBussiness objFacility = new FacilityBussiness();
            List<Facilitys> lstItem = objFacility.GetAllFacility();
            if (lstItem.Count > 0)
            {
                ddlFacilityID.Items.Clear();
                ListItem Reward = new ListItem();
                Reward.Text = "------ Chọn Cơ sở ------";
                Reward.Value = "0";
                ddlFacilityID.Items.Add(Reward);
                foreach (Facilitys type in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = type.FacilityName;
                    item.Value = type.FacilityID.ToString();
                    ddlFacilityID.Items.Add(item);
                }
            }
        }
        //protected void ddlFacilityID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int facilityID = int.Parse(ddlFacilityID.SelectedValue.ToString());
        //    if (facilityID > 0)
        //    {
        //        LoadddlCoach(facilityID); 
        //    }
        //    else
        //    {
        //        ddlCoachID.SelectedIndex = 0; 
        //    }
        //}
        public void LoadddlCoach()
        {
            CoachBussiness objCoach = new CoachBussiness();
            List<Coachs> lstItem = objCoach.GetCoachID();
                if(lstItem.Count > 0)
            {
                ddlCoachID.Items.Clear();
                ListItem coach = new ListItem();
                coach.Text = "----- Chọn Huấn Luyện Viên -----";
                coach.Value = "0";
                ddlCoachID.Items.Add (coach);
                foreach(Coachs type in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = type.CoachName;
                    item.Value = type.CoachID.ToString();
                    ddlCoachID.Items.Add(item);
                }
            }
        }

        public void LoaddlTimeID()
        {
            TimeBussiness objTime = new TimeBussiness();
            List<Time> lstItem = objTime.GetAllTime();
            if (lstItem.Count > 0)
            {
                ddlTimeID.Items.Clear();
                ListItem Reward = new ListItem();
                Reward.Text = "------ Chọn Ca học ------";
                Reward.Value = "0";
                ddlTimeID.Items.Add(Reward);
                foreach (Time type in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = type.TimeName;
                    item.Value = type.TimeID.ToString();
                    ddlTimeID.Items.Add(item);
                }
            }
        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            int facilityID = int.Parse(ddlFacilityID.SelectedValue);
            int coachID = int.Parse(ddlCoachID.SelectedValue);
            int timeID = int.Parse(ddlTimeID.SelectedValue);

            if (facilityID > 0 && coachID > 0 && timeID > 0)
            {
                Response.Redirect($"~/RollCall/rollcallDetail.aspx?facilityID={facilityID}&coachID={coachID}&timeID={timeID}");
            }

        }

    }
}