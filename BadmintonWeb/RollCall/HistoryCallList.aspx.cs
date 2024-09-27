using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BadmintonWeb.RollCall
{
    public partial class HistoryCallList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtToDate.Text = string.Format("01/{0}/{1}", DateTime.Now.Month, DateTime.Now.Year);
                loadDDLCoachID();
                LoadListStudentByDate();
            }
        }
        private void loadDDLCoachID()
        {
            CoachBussiness objCoach = new CoachBussiness();
            List<Coachs> lstItem = objCoach.GetCoachID();
            if (lstItem.Count > 0)
            {
                ddlCoachID.Items.Clear();
                ListItem Coach = new ListItem();
                Coach.Text = "------ Chọn HLV -----";
                Coach.Value = "0";
                ddlCoachID.Items.Add(Coach);
                foreach (Coachs coach in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = coach.CoachName;
                    item.Value = coach.CoachID.ToString();
                    ddlCoachID.Items.Add(item);
                }
            }
        }
        public void LoadListStudentByDate()
        {
            DateTime ToDate = DateTime.MinValue;
            if (txtToDate.Text.Trim().Length != 0)
            {
                string[] arrayTime = txtToDate.Text.Trim().Split('/');
                ToDate = new DateTime(int.Parse(arrayTime[2]), int.Parse(arrayTime[1]), int.Parse(arrayTime[0]));
            }
            int coachID = int.Parse(ddlCoachID.SelectedValue);
            RollCallBussiness objrollCall = new RollCallBussiness();
            List<getCheckedStudentsByDateAndCoach_Result> lstItem = objrollCall.getRollCallByCheckID(ToDate, coachID);
            rptRollCall.DataSource = lstItem;
            rptRollCall.DataBind();
        }

        protected void rptRollCall_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                getCheckedStudentsByDateAndCoach_Result item = (getCheckedStudentsByDateAndCoach_Result)e.Item.DataItem;
                HiddenField hdRollCallID = e.Item.FindControl("hdRollCallID") as HiddenField;
                Literal ltrRollCallID = e.Item.FindControl("ltrRollCallID") as Literal;
                Literal ltrStudentName = e.Item.FindControl("ltrStudentName") as Literal;
                Literal ltrUserCreated = e.Item.FindControl("ltrUserCreated") as Literal;
                Literal ltrDateCreated = e.Item.FindControl("ltrDateCreated") as Literal;

                hdRollCallID.Value = item.RollCallID.ToString();
                ltrRollCallID.Text= item.RollCallID.ToString();
                ltrStudentName.Text = item.StudentName;
                ltrUserCreated.Text = item.UserCreated;
                ltrDateCreated.Text = item.DateCreated.ToString("dd/MM/yyyy");

            }
        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {

            DateTime ToDate = DateTime.MinValue;
            if (txtToDate.Text.Trim().Length != 0)
            {
                string[] arrayTime = txtToDate.Text.Trim().Split('/');
                ToDate = new DateTime(int.Parse(arrayTime[2]), int.Parse(arrayTime[1]), int.Parse(arrayTime[0]));
            }
            int coachID = int.Parse(ddlCoachID.SelectedValue);
            RollCallBussiness objrollCall = new RollCallBussiness();
            List<getCheckedStudentsByDateAndCoach_Result> lstItem = objrollCall.getRollCallByCheckID(ToDate, coachID);
            rptRollCall.DataSource = lstItem;
            rptRollCall.DataBind();
        }
    }
}