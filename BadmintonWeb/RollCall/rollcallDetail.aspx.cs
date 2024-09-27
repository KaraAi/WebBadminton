using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.RollCall
{
    public partial class rollcallDetail : PageBase
    {
        RollCallBussiness objRollCall = new RollCallBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int coachID = 0;
                int.TryParse(Request["coachID"], out coachID);
                int timeID = 0;
                int.TryParse(Request["timeID"], out timeID);
                int facilityID = 0;
                int.TryParse(Request["facilityID"], out facilityID);
                if (facilityID > 0 && coachID > 0 && timeID > 0)
                {
                    LoadData(facilityID,coachID,timeID);
                }
            }
        }


        public void LoadData(int facilityID, int coachID, int timeID)
        {

            RollCallBussiness objModule = new RollCallBussiness();
            List<getStudentByCoachID_Result> lstItem = objModule.getFilteredRollCall(facilityID, coachID, timeID).ToList();
            rptRollCall.DataSource = lstItem;
            rptRollCall.DataBind();
        }

        protected void rptRollCall_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                getStudentByCoachID_Result item = (getStudentByCoachID_Result)e.Item.DataItem;
                Literal ltrStudent = e.Item.FindControl("ltrStudent") as Literal;
                HiddenField hdStudent = e.Item.FindControl("hdStudent") as HiddenField;
                Literal ltrTime = e.Item.FindControl("ltrTime") as Literal;
                HiddenField hdCoach = e.Item.FindControl("hdCoach") as HiddenField;
                Literal ltrCoach = e.Item.FindControl("ltrCoach") as Literal;
                CheckBox chkCheck = e.Item.FindControl("chkCheck") as CheckBox;

                hdStudent.Value = item.StudentID.ToString();
                hdCoach.Value = item.CoachID.ToString();
                ltrStudent.Text = item.StudentName.ToString();
                ltrCoach.Text = item.CoachName.ToString();
                ltrTime.Text = item.TimeName.ToString();
                if(item.isCheck == 1)
                {
                    chkCheck.Checked= true;
                }

            }
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = this.CoachNameLogin;

                foreach (RepeaterItem item in rptRollCall.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {

                        HiddenField hdStudent = item.FindControl("hdStudent") as HiddenField;
                        HiddenField hdCoach = item.FindControl("hdCoach") as HiddenField;
                        CheckBox chkCheck = item.FindControl("chkCheck") as CheckBox;


                        int studentID = 0;
                        int.TryParse(hdStudent.Value, out studentID);
                        int coachID = 0;
                        int.TryParse(hdCoach.Value, out coachID);
                        int statusID = 1;

                        int isCheck = chkCheck.Checked ? 1 : 0;

                        bool isSaved = objRollCall.insertisCheckRollCall(studentID, coachID, isCheck, statusID, userName);

                        if (!isSaved)
                        {
                            CommonClass.MessageBox.Show("Điểm danh Học viên Thất bại!");
                            return;
                        }
                    }
                }

                CommonClass.MessageBox.Show("Điểm danh Học viên thành công !");
            }
            catch (Exception ex)
            {
                CommonClass.MessageBox.Show("Lỗi điểm danh Học viên!");
            }
        }


        
    }
}