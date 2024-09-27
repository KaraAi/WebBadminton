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

namespace BadmintonWeb.coach
{
    public partial class CoachDetails : PageBase
    {
        CoachBussiness objCoach = new CoachBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int coachID = 0;
                int.TryParse(Request["CoachID"], out coachID);


                loadDDlFacility();
                LoadDetailUser(coachID);

            }
        }

        public void LoadDetailUser(int coachID)
        {
            CoachBussiness objUser = new CoachBussiness();
            Coachs item = objUser.GetCoachID(coachID);
            if (item != null)
            {
                hdCoachID.Value = item.CoachID.ToString();
                txtCoachName.Text = item.CoachName.ToString();
                imgThumbs.ImageUrl = item.Images;
                ddlFacility.SelectedValue = item.FacilityID.ToString();
                ddlGender.SelectedValue = item.GenderID.ToString();
                txtBirthday.Text = item.Birthday.ToString("dd/MM/yyyy");
                txtPassword.Text = item.Password;
                txtPhone.Text = item.Phone.ToString();
                ddlStatusID.Text = item.StatusID.ToString();
                ddlEducation.Text = item.Education.ToString();
                txtExperience.Text = item.Experience.ToString();
                ddlLevel.Text = item.Level.ToString();
                txtTaxCode.Text = item.TaxCode.ToString();
                txtBankName.Text = item.BankName.ToString();
                txtBankNumber.Text = item.BankNumber.ToString();
                txtWorkingStart.Text = item.WorkingStart.ToString("dd/MM/yyyy");
                txtHealthCondition.Text = item.HealthCondition.ToString();
                txtCCCD.Text = item.CCCD.ToString();
                txtPlaceOfOrigin.Text = item.PlaceOfOrigin.ToString();
                txtPlaceOfResidence.Text = item.PlaceOfResidence.ToString();
                txtSalary.Text = item.Salary.ToString();
                ddlMaritalStatus.SelectedValue = item.MaritalStatus.ToString();
                txtDescription.Text = item.Description.ToString();
                txtNamePerson.Text = item.NamePerson.ToString();
                txtRelationship.Text = item.Relationship.ToString();
                txtPhonePerson.Text = item.PhoneNumber.ToString();
                txtEmail.Text = item.Email.ToString();

                //Load List Permision User
            }

        }
        private void loadDDlFacility()
        {
            FacilityBussiness objFacility = new FacilityBussiness();
            List<Facilitys> lstItem = objFacility.GetAllFacility();
            if (lstItem.Count > 0)
            {
                ddlFacility.Items.Clear();
                ListItem Reward = new ListItem();
                Reward.Text = "------ Chọn Cơ sở ------";
                Reward.Value = "0";
                ddlFacility.Items.Add(Reward);
                foreach (Facilitys type in lstItem)
                {
                    ListItem item = new ListItem();
                    item.Text = type.FacilityName;
                    item.Value = type.FacilityID.ToString();
                    ddlFacility.Items.Add(item);
                }
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
        protected void lbtResetPass_Click(object sender, EventArgs e)
        {
            string Password = CommonClass.StringValidator.GetMD5String("123456");
            int coachID = 0;
            int.TryParse(Request["CoachID"], out coachID);
            CoachBussiness objCoach = new CoachBussiness();
            if (objCoach.ResetPass(coachID, Password) == true)
            {
                // Goi hàm gửi Email
                StringBuilder strcontent = new StringBuilder();
                strcontent.Append("Bạn nhận được thông báo reset mật khẩu<br/><br/>");
                strcontent.AppendFormat("<b>Mật khẩu:</b> {0} <br/><br/>", "123456");
                string cententEmail = strcontent.ToString();
                SendMail("Email reset mật khẩu", cententEmail, "Administrator DavidBadminton", txtEmail.Text.Trim());
                CommonClass.MessageBox.Show("Reset Mật khẩu thành công. Vui lòng check Email!");
            }
        }
        protected void lbtSave_Click(object sender, EventArgs e)
        {
            int coachID = 0;
            int.TryParse(Request["CoachID"], out coachID);
            if (coachID != 0)
            {
                string CoachName = txtCoachName.Text.Trim();
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
                int TypeUser = TypeUserIDContans.HLV;
                int GenderID = int.Parse(ddlGender.SelectedValue.ToString());
                DateTime Birthday = DateTime.Now;
                string Email = txtEmail.Text.Trim();
                if (!string.IsNullOrEmpty(txtBirthday.Text.Trim()))
                {
                    string[] dateBirthday = txtBirthday.Text.Trim().Split('/');
                    Birthday = new DateTime(int.Parse(dateBirthday[2]), int.Parse(dateBirthday[1]), int.Parse(dateBirthday[0]));
                }

                string Password = CommonClass.StringValidator.GetMD5String(txtPassword.Text.Trim());
                Coachs existingCoach = objCoach.GetCoachID(coachID);
                if (existingCoach != null)
                {
                    Password = existingCoach.Password; // Giữ lại mật khẩu cũ
                }

                string Phone = txtPhone.Text.Trim();
                int StatusID = int.Parse(ddlStatusID.SelectedValue.ToString());
                int Education = int.Parse(ddlEducation.SelectedValue.ToString());
                string Experience = txtExperience.Text.Trim();
                int Level = int.Parse(ddlLevel.SelectedValue.ToString());
                string TaxCode = txtTaxCode.Text.Trim();
                string BankName = txtBankName.Text.Trim();
                string BankNumber = txtBankNumber.Text.Trim();
                DateTime WorkingStart = DateTime.Now;
                if (!string.IsNullOrEmpty(txtWorkingStart.Text.Trim()))
                {
                    string[] dateWorking = txtWorkingStart.Text.Trim().Split('/');
                    WorkingStart = new DateTime(int.Parse(dateWorking[2]), int.Parse(dateWorking[1]), int.Parse(dateWorking[0]));
                }

                string HealthConditon = txtHealthCondition.Text.Trim();
                string CCCD = txtCCCD.Text.Trim();
                string PlaceOfOrigin = txtPlaceOfOrigin.Text.Trim();
                string PlaceOfResidence = txtPlaceOfResidence.Text.Trim();
                decimal salary = decimal.Parse(txtSalary.Text.Trim());
                int MaritalStatus = int.Parse(ddlMaritalStatus.SelectedValue.ToString());
                string Description = txtDescription.Text.Trim();
                string NamePerson = txtNamePerson.Text.Trim();
                string RelationShip = txtRelationship.Text.Trim();
                string PhoneNumber =txtPhonePerson.Text.Trim();
                string UserName = this.CoachNameLogin;

                Coachs coach = objCoach.updateCoachs(coachID, CoachName, Imgthumb, Facility, TypeUser, Email, GenderID, Birthday, Password, Phone, StatusID, Education, Experience, Level, TaxCode, BankName, BankNumber, WorkingStart, HealthConditon
                                          , CCCD, PlaceOfOrigin, PlaceOfResidence, salary, MaritalStatus, Description, NamePerson, RelationShip, PhoneNumber, UserName);
                if (coach != null)
                {
                    CommonClass.MessageBox.Show("Chỉnh sửa Người dùng thành công !");

                }

                else
                    CommonClass.MessageBox.Show("Lỗi chỉnh sửa Người dùng.");
            }
        }
    }
}