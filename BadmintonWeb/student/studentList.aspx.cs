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

namespace BadmintonWeb.student
{
   
    public partial class studentList : PageBase
    {
        private int _IsView = 0;
        private int _IsUpdate = 0;
        private int _IsDeleted = 0;
        StudentBussiness objStudent = new StudentBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CheckPermision();
                LoadListStudent();
            }
        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            CheckPermision();

            string key = txtKeySearch.Value;
            StudentBussiness objUser = new StudentBussiness();
            List<Students> lstItem = objUser.getViewListStudent(key);
            rptStudent.DataSource = lstItem;
            rptStudent.DataBind();
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
                UserModules item = objPermision.getViewPermision(MoudleAccessID.Student, CoachIDLogin);
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
        public void LoadListStudent()
        {
            //List<Students> lstItem = objStudent.GetAllStudent();
            //rptStudent.DataSource = lstItem;
            //rptStudent.DataBind();
            string key = txtKeySearch.Value;
            StudentBussiness objUser = new StudentBussiness();
            List<Students> lstItem = objUser.getViewListStudent(key);
            rptStudent.DataSource = lstItem;
            rptStudent.DataBind();

        }

        protected void rptStudent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Students item = (Students)e.Item.DataItem;
                HiddenField hdStudentID = e.Item.FindControl("hdStudentID") as HiddenField;
                Literal ltrStudentID = e.Item.FindControl("ltrStudentID") as Literal;
                Literal ltrStudentName = e.Item.FindControl("ltrStudentName") as Literal;
                Literal ltrBirthday = e.Item.FindControl("ltrBirthday") as Literal;
                Literal ltrPhone = e.Item.FindControl("ltrPhone") as Literal;
                Literal ltrCoachID = e.Item.FindControl("ltrCoachID") as Literal;
                Literal ltrTimeID = e.Item.FindControl("ltrTimeID") as Literal;
                LinkButton lbtEdit = e.Item.FindControl("lbtEdit") as LinkButton;
                LinkButton lbtDelete = e.Item.FindControl("lbtDelete") as LinkButton;


                hdStudentID.Value =item.StudentID.ToString();
                ltrStudentID.Text = item.StudentID.ToString();
                ltrStudentName.Text = item.StudentName.ToString();
                ltrBirthday.Text = item.Birthday.ToString("dd/MM/yyyy");
                ltrPhone.Text = item.Phone.ToString();
                ltrCoachID.Text = LoadCoachIDName(item.CoachID);
                if (_IsUpdate == 1)
                    lbtEdit.Enabled = true;
                else
                    lbtEdit.Enabled = false;

                if (_IsDeleted == 1)
                    lbtDelete.Enabled = true;
                else
                    lbtDelete.Enabled = false;


                ltrTimeID.Text = LoadNameTimeID(item.TimeID);
            }
        }
        private string LoadCoachIDName(int CoachID)
        {
            CoachBussiness objCoach = new CoachBussiness();
            Coachs item = objCoach.GetCoachID(CoachID);
            if(item != null)
                return item.CoachName;
            return "";
        }
      
        private string LoadNameTimeID(int TimeID)
        {
            TimeBussiness objTime = new TimeBussiness();
            Time item = objTime.GetNameTimeByID(TimeID);
            if (item != null)
                return item.TimeName;
            return "";
        }
        protected void rptStudent_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int studentID = int.Parse(((HiddenField)e.Item.FindControl("hdStudentID")).Value);
            switch (e.CommandName)
            {
                case "deleteStudent":
                    if (studentID != 0)
                    {
                        StudentBussiness objUser = new StudentBussiness();
                        //check delete group
                        //if (objUser.checkDeleteCoach(studentID) == false)
                        //{
                        //    CommonClass.MessageBox.Show("Người dùng này đã được sử dụng. Không thể xoá !");
                        //    return;
                        //}
                        //if (studentID == 1)
                        //{
                        //    CommonClass.MessageBox.Show("Đây là user hệ thống. Không thể xoá !");
                        //    return;
                        //}
                        if (objUser.deleteStudent(studentID) == true)
                        {
                            CheckPermision();
                            LoadListStudent();
                            CommonClass.MessageBox.Show("Học viên đã được xóa!");
                        }
                        else
                            CommonClass.MessageBox.Show("Lỗi xóa học viên !");
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy học viên cần xóa !");

                    break;

                case "updateStudent":
                    if (studentID != 0)
                    {
                        ctrlModelStudent.LoadStudentDetail(studentID);
                        CheckPermision();
                        LoadListStudent();
                    }
                    else
                        CommonClass.MessageBox.Show("Không tìm thấy học viên cần chỉnh !");

                    break;

            }
        }
    }
}