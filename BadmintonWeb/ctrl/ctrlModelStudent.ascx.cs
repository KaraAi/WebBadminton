using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.AsyncUpload;

namespace BadmintonWeb.ctrl
{
    public partial class ctrlModelStudent : UserControlBase
    {
        StudentBussiness objStudent = new StudentBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDDlFacility();
                loadDDLCoachID();
                loadDDLTime();
            }
            setControl();
        }
        public void ClearText()
        {
            txtStudentName.Text = "";
            imgThumbs.ImageUrl = "";
            ddlFacility.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            txtBirthday.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            ddlLevel.SelectedIndex = 0;
            txtHealthCondition.Text = "";
            txtRelationship.Text = "";
            txtHeight.Text = "";
            txtWeight.Text = "";
            ddlStatusID.SelectedIndex = 0;
            txtStartDay.Text = "";
            txtTuiTions.Text = "";
            txtDescription.Text = "";
            txtGuardianName.Text = "";
            txtGuardianPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            ddlTimeID.SelectedIndex = 0;
        }
        public void LoadStudentDetail(int studentID)
        {
            Students item = objStudent.GetStudentByID(studentID);
            if (item != null)
            {
                hdStudentID.Value = item.StudentID.ToString();
                txtStudentName.Text = item.StudentName.ToString();
                imgThumbs.ImageUrl = item.Images;
                ddlFacility.SelectedValue = item.FacilityID.ToString();
                ddlGender.SelectedValue = item.GenderID.ToString();
                txtBirthday.Text = item.Birthday.ToString("dd/MM/yyyy");
                txtPassword.Text = item.Password;
                txtPhone.Text = item.Phone.ToString();
                ddlLevel.Text = item.Level.ToString();
                ddlCoachID.SelectedValue = item.CoachID.ToString();
                txtHealthCondition.Text = item.HealthCondition.ToString();
                txtRelationship.Text = item.Relationship.ToString();
                txtHeight.Text = item.Height.ToString();
                txtWeight.Text = item.Weight.ToString();
                ddlStatusID.SelectedValue = item.StatusID.ToString();
                txtStartDay.Text = item.StudyStart.ToString("dd/MM/yyyy");
                txtTuiTions.Text = item.Tuitions.ToString();
                txtDescription.Text = item.Description.ToString();
                txtGuardianName.Text = item.GuardianName.ToString();
                txtGuardianPhone.Text = item.GuardianPhone.ToString();
                txtAddress.Text = item.Address.ToString();
                txtEmail.Text = item.Email.ToString();
                ddlTimeID.SelectedValue = item.TimeID.ToString();

            }
            setControl();
            DisplayBlock();
        }
        private bool checkInsert()
        {

            if (txtStudentName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Tên đầy đủ!");
                DisplayBlock();
                txtStudentName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Mật khẩu!");
                DisplayBlock();
                txtPassword.Focus();
                return false;
            }
            if (txtEmail.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Email");
                DisplayBlock();
                txtEmail.Focus();
                return false;
            }
            if (txtPhone.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui Lòng nhập số điện thoại");
                DisplayBlock();
                txtPhone.Focus();
                return false;
            }
            if (ddlFacility.SelectedValue == "0")
            {
                CommonClass.MessageBox.Show("Vui lòng chọn Đơn vị!");
                DisplayBlock();
                ddlFacility.Focus();
                return false;
            }
            return true;
        }
        private bool checkUpdate(int StudentID)
        {

            if (txtStudentName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Tên đầy đủ!");
                DisplayBlock();
                txtStudentName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Mật khẩu!");
                DisplayBlock();
                txtPassword.Focus();
                return false;
            }
            if (txtEmail.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Email");
                DisplayBlock();
                txtEmail.Focus();
                return false;
            }
            if (txtPhone.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui Lòng nhập số điện thoại");
                DisplayBlock();
                txtPhone.Focus();
                return false;
            }
            if (ddlFacility.SelectedValue == "0")
            {
                CommonClass.MessageBox.Show("Vui lòng chọn Đơn vị!");
                DisplayBlock();
                ddlFacility.Focus();
                return false;
            }
            return true;
        }
        protected void lbtResetPass_Click(object sender, EventArgs e)
        {
            string Password = CommonClass.StringValidator.GetMD5String("123456");
            int studentID = 0;
            int.TryParse(hdStudentID.Value, out studentID);
            StudentBussiness objStudent = new StudentBussiness();
            if (objStudent.ResetPass(studentID, Password) == true)
            {
                // Goi hàm gửi Email
                StringBuilder strcontent = new StringBuilder();
                strcontent.Append("Bạn nhận được thông báo reset mật khẩu<br/><br/>");
                strcontent.AppendFormat("<b>Mật khẩu:</b> {0} <br/><br/>", "123456");
                string cententEmail = strcontent.ToString();
                SendMail("Email reset mật khẩu", cententEmail, "Administrator Ban thi đua khen thưởng", txtEmail.Text.Trim());
                CommonClass.MessageBox.Show("Reset Mật khẩu thành công. Vui lòng check Email!");
            }
        }
        protected void lbtChangeImages_Click(object sender, EventArgs e)
        {
            if (FileUpload1.Visible == false)
            {
                FileUpload1.Visible = true;
                imgThumbs.Visible = false;
                lbtChangeImages.Text = "Bỏ Qua";
            }
            else
            {
                FileUpload1.Visible = false;
                imgThumbs.Visible = true;
                lbtChangeImages.Text = "Đổi Ảnh";
            }
        }
        private void setControl()
        {
            decimal studentID = 0;
            decimal.TryParse(hdStudentID.Value, out studentID);

            if (studentID == 0)
            {
                lbtResetPass.Visible = false;
                txtPassword.Visible = true;
            }
            else
            {
                lbtResetPass.Visible = true;
                txtPassword.Visible = false;
            }
        }
        protected void lbtClose_Click(object sender, EventArgs e)
        {
            ClearText();
            setControl();
            DisplayNone();
        }
        protected void lbtCloseTop_Click(object sender, EventArgs e)
        {
            ClearText();
            setControl();
            DisplayNone();
        }
        private void DisplayBlock()
        {
            myModelStudent.Attributes.Add("style", "display:block;");
            myModelStudent.Attributes.Add("class", "modal fade in");
        }
        private void DisplayNone()
        {
            myModelStudent.Attributes.Add("style", "display:none;");
            myModelStudent.Attributes.Add("class", "modal fade in");
        }
        protected void lbtInsert_Click(object sender, EventArgs e)
        {
            int studentID = 0;
            int.TryParse(hdStudentID.Value, out studentID);
            if (studentID == 0)
            {
                Insert();
            }
            else
            {
                Update(studentID);
            }
        }
        private void loadDDlFacility()
        {
            FacilityBussiness objFacility = new FacilityBussiness();
            List<Facilitys> lstItem = objFacility.GetAllFacility();
            if (lstItem.Count > 0)
            {
                ddlFacility.Items.Clear();
                ListItem Facility = new ListItem();
                Facility.Text = "------ Chọn Cơ sở ------";
                Facility.Value = "0";
                ddlFacility.Items.Add(Facility);
                foreach (Facilitys type in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = type.FacilityName;
                    item.Value = type.FacilityID.ToString();
                    ddlFacility.Items.Add(item);
                }
            }
        }
        private void loadDDLTime()
        {
            TimeBussiness objTime = new TimeBussiness();
            List<Time> lstItem = objTime.GetAllTime();
            if (lstItem.Count > 0)
            {
                ddlTimeID.Items.Clear();
                ListItem Time = new ListItem();
                Time.Text = "----- Chọn ca học -----";
                Time.Value = "0";
                ddlTimeID.Items.Add(Time);
                foreach (Time t in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = t.TimeName;
                    item.Value = t.TimeID.ToString();
                    ddlTimeID.Items.Add(item);
                }
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
        private void Insert()
        {
            if (checkInsert() == true)
                return;
            string StudentName = txtStudentName.Text.Trim();
            string Imgthumb = imgThumbs.ImageUrl;
            if (!string.IsNullOrEmpty(FileUpload1.FileName) && CheckExtention(FileUpload1, 0) == true)
            {
                string sFolderPath = Server.MapPath("~/Images/upload/");
                string generalString = "_" + DateTime.Now.Second.ToString() + ".";
                string fileName = FileUpload1.FileName.Replace(".", generalString);
                Bitmap filehinh = CreateThumbnail(FileUpload1.PostedFile.InputStream, 2000, 2000);
                filehinh.Save(Path.Combine(sFolderPath, fileName));
                Imgthumb = "~/Images/upload/" + fileName;
            }
            int Facility = int.Parse(ddlFacility.SelectedValue.ToString());
            int TypeUser = TypeUserIDContans.HocVien;
            int GenderID = int.Parse(ddlGender.SelectedValue.ToString());
            DateTime Birthday = DateTime.Now;
            if (!string.IsNullOrEmpty(txtBirthday.Text.Trim()))
            {
                string[] dateBirthday = txtBirthday.Text.Trim().Split('/');
                Birthday = new DateTime(int.Parse(dateBirthday[2]), int.Parse(dateBirthday[1]), int.Parse(dateBirthday[0]));
            }
            string Password = CommonClass.StringValidator.GetMD5String(txtPassword.Text.Trim());
            string Phone = txtPhone.Text.Trim();
            int Level = int.Parse(ddlLevel.SelectedValue.ToString());
            string HealthCondition = txtHealthCondition.Text.Trim();
            string Relationship = txtRelationship.Text.Trim();
            string Height = txtHeight.Text.Trim();
            string Weight = txtWeight.Text.Trim();
            string Email = txtEmail.Text.Trim();
            DateTime StudyStart = DateTime.Now;
            if (!string.IsNullOrEmpty(txtStartDay.Text.Trim()))
            {
                string[] dateStart = txtStartDay.Text.Trim().Split('/');
                StudyStart = new DateTime(int.Parse(dateStart[2]), int.Parse(dateStart[1]), int.Parse(dateStart[0]));
            }
            decimal Tuition = decimal.Parse(txtTuiTions.Text.ToString());
            string Description = txtDescription.Text.Trim();
            string GuardianName = txtGuardianName.Text.Trim();
            string GuardianPhone = txtGuardianPhone.Text.Trim();
            string Address = txtAddress.Text.Trim();
            int CoachID = int.Parse(ddlCoachID.SelectedValue.ToString());
            int TimeID = int.Parse(ddlTimeID.SelectedValue.ToString());
            int StatusID = int.Parse(ddlStatusID.SelectedValue.ToString());
            string UserName = this.CoachNameLogin;
            Students item = objStudent.InsertStudent(Facility, CoachID, TimeID, Email, StudentName, Imgthumb, GenderID, Birthday, TypeUser, Phone, StatusID, Address, Password, Level, Tuition, StudyStart, HealthCondition, Height
                                         , Weight, GuardianName, Relationship, GuardianPhone, Description, UserName);
            if (item != null)
            {
                this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                this.Page.GetType().InvokeMember("LoadListStudent", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                ClearText();
                CommonClass.MessageBox.Show("Thêm mới Học viên thành công !");
                DisplayNone();
            }
            else
                CommonClass.MessageBox.Show("Lỗi thêm mới Học viên");
        }
        private void Update(int studentID)
        {
            if (checkUpdate(studentID) == true)
                return;
            string StudentName = txtStudentName.Text.Trim();
            string Imgthumb = imgThumbs.ImageUrl;
            if (!string.IsNullOrEmpty(FileUpload1.FileName) && CheckExtention(FileUpload1, 0) == true)
            {
                string sFolderPath = Server.MapPath("~/Images/upload/");
                string generalString = "_" + DateTime.Now.Second.ToString() + ".";
                string fileName = FileUpload1.FileName.Replace(".", generalString);
                Bitmap filehinh = CreateThumbnail(FileUpload1.PostedFile.InputStream, 2000, 2000);
                filehinh.Save(Path.Combine(sFolderPath, fileName));
                Imgthumb = "~/Images/upload/" + fileName;
            }
            int Facility = int.Parse(ddlFacility.SelectedValue.ToString());
            int TypeUser = TypeUserIDContans.HocVien;
            int GenderID = int.Parse(ddlGender.SelectedValue.ToString());
            DateTime Birthday = DateTime.Now;
            if (!string.IsNullOrEmpty(txtBirthday.Text.Trim()))
            {
                string[] dateBirthday = txtBirthday.Text.Trim().Split('/');
                Birthday = new DateTime(int.Parse(dateBirthday[2]), int.Parse(dateBirthday[1]), int.Parse(dateBirthday[0]));
            }
            string Password = CommonClass.StringValidator.GetMD5String(txtPassword.Text.Trim());
            Students st = objStudent.getStudentName(studentID);
            if (st != null)
            {
                Password = st.Password;
            }
            string Phone = txtPhone.Text.Trim();
            int Level = int.Parse(ddlLevel.SelectedValue.ToString());
            string HealthCondition = txtHealthCondition.Text.Trim();
            string Relationship = txtRelationship.Text.Trim();
            string Height = txtHeight.Text.Trim();
            string Weight = txtWeight.Text.Trim();
            string Email = txtEmail.Text.Trim();
            DateTime StudyStart = DateTime.Now;
            if (!string.IsNullOrEmpty(txtStartDay.Text.Trim()))
            {
                string[] dateStart = txtStartDay.Text.Trim().Split('/');
                StudyStart = new DateTime(int.Parse(dateStart[2]), int.Parse(dateStart[1]), int.Parse(dateStart[0]));
            }
            decimal Tuition = decimal.Parse(txtTuiTions.Text.ToString());
            string Description = txtDescription.Text.Trim();
            string GuardianName = txtGuardianName.Text.Trim();
            string GuardianPhone = txtGuardianPhone.Text.Trim();
            string Address = txtAddress.Text.Trim();
            int CoachID = int.Parse(ddlCoachID.SelectedValue.ToString());
            int TimeID = int.Parse(ddlTimeID.SelectedValue.ToString());
            int StatusID = int.Parse(ddlStatusID.SelectedValue.ToString());
            string UserName = this.CoachNameLogin;
            Students item = objStudent.UpdateStudent(studentID, Facility, CoachID, TimeID, Email, StudentName, Imgthumb, GenderID, Birthday, TypeUser, Phone, StatusID, Address, Password, Level, Tuition, StudyStart, HealthCondition, Height
                                         , Weight, GuardianName, Relationship, GuardianPhone, Description, UserName);
            if (item != null)
            {
                this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                this.Page.GetType().InvokeMember("LoadListStudent", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                ClearText();
                CommonClass.MessageBox.Show("Cập nhật Học viên thành công !");
                DisplayNone();
            }
            else
                CommonClass.MessageBox.Show("Lỗi cập nhật Học viên");
        }

    }

}