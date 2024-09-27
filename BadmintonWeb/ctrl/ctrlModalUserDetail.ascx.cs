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
using Telerik.Web.UI;

namespace BadmintonWeb.ctrl
{
    public partial class ctrlModalUserDetail : UserControlBase
    {
        LibraryCommon _onjFormBase = new LibraryCommon();
        ModuleAccessBussiness objModule = new ModuleAccessBussiness();
        CoachBussiness objCoach = new CoachBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDDlFacility();

            }
            setControl();
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
        private bool checkInsert()
        {

            if (txtCoachName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Tên đầy đủ!");
                DisplayBlock();
                txtCoachName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Mật khẩu!");
                DisplayBlock();
                txtPassword.Focus();
                return false;
            }
            if(txtEmail.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Email");
                DisplayBlock();
                txtEmail.Focus();
                return false;
            }
            if(txtPhone.Text.Trim().Length <= 0)
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

            ModuleAccessBussiness objPermision = new ModuleAccessBussiness();
            UserModules item = objPermision.getViewPermision(MoudleAccessID.Coach, CoachIDLogin);
            if (item == null)
            {
                if (CoachIDLogin != 1)
                {
                    CommonClass.MessageBox.Show("User không có quyền tạo mới người dùng!");
                    DisplayBlock();
                    return false;
                }
            }
            else
            {
                if (CoachIDLogin != 1)
                {
                    if (item.IsInsert == 0)
                    {
                        CommonClass.MessageBox.Show("User không có quyền tạo mới người dùng!");
                        DisplayBlock();
                        return false;
                    }
                }
            }

            return true;
        }
        private void setControl()
        {
            decimal coachID = 0;
            decimal.TryParse(hdCoachID.Value, out coachID);

            if (coachID == 0)
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
        private void ClearText()
        {
            txtCoachName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtCCCD.Text = "";
            txtEmail.Text = "";
            txtBirthday.Text = "";
            imgThumbs.ImageUrl = "";
            ddlGender.SelectedIndex = 0;
            ddlFacility.SelectedIndex = 0;
            txtTaxCode.Text = "";
            txtExperience.Text = "";
            txtBankName.Text = "";
            ddlEducation.SelectedIndex = 0;
            txtBankNumber.Text = "";
            txtWorkingStart.Text = "";
            ddlLevel.SelectedIndex = 0;
            txtPlaceOfOrigin.Text = "";
            txtSalary.Text = "";
            txtPlaceOfResidence.Text = "";
            ddlStatusID.SelectedIndex = 0;
            ddlMaritalStatus.SelectedIndex = 0;
            txtDescription.Text = "";
            txtHealthCondition.Text = "";
            txtNamePerson.Text = "";
            txtRelationship.Text = "";
            txtPhonePerson.Text = "";


            List<getModuleAccessUser_Result> lstItem = new List<getModuleAccessUser_Result>();
            rptModuleAccess.DataSource = lstItem;
            rptModuleAccess.DataBind();
        }
        protected void lbtResetPass_Click(object sender, EventArgs e)
        {
            string Password = CommonClass.StringValidator.GetMD5String("123456");
            int coachID = 0;
            int.TryParse(hdCoachID.Value, out coachID);
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
                LoadListPermission();
            }
            setControl();
            DisplayBlock();

        }
        public void LoadListPermission()
        {
            int coachID = 0;
            int.TryParse(hdCoachID.Value, out coachID);
            ModuleAccessBussiness objModule = new ModuleAccessBussiness();
            List<getModuleAccessUser_Result> lstItem = objModule.getViewModuleAccess().ToList();
            if (lstItem.Count > 0)
            {
                List<UserModules> lstAccess = objModule.getRolesAdministratorByUserID(coachID);
                if (lstAccess.Count > 0)
                {
                    foreach (getModuleAccessUser_Result item in lstItem)
                    {
                        UserModules access = lstAccess.Where(s => s.ModuleID == item.ModuleID).FirstOrDefault();
                        if (access != null)
                        {
                            item.IsView = access.IsView;
                            item.IsInsert = access.IsInsert;
                            item.IsUpdate = access.IsUpdate;
                            item.IsDelete = access.IsDelete;
                        }
                    }
                }
            }
            rptModuleAccess.DataSource = lstItem;
            rptModuleAccess.DataBind();
        }
        private void DisplayBlock()
        {
            myModaUserDetail.Attributes.Add("style", "display:block;");
            myModaUserDetail.Attributes.Add("class", "modal fade in");
        }
        private void DisplayNone()
        {
            myModaUserDetail.Attributes.Add("style", "display:none;");
            myModaUserDetail.Attributes.Add("class", "modal fade in");
        }

        protected void lbtInsertUser_Click(object sender, EventArgs e)
        {
            int coachID = 0;
            int.TryParse(hdCoachID.Value, out coachID);
            if (coachID == 0)
            {
                Insert();
            }
            else
            {
                Update(coachID);
            }
        }
        private void InsertPermision(int coachID)
        {
            int FlagError = 0;
            foreach (RepeaterItem item in rptModuleAccess.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var chkView = (CheckBox)item.FindControl("chkView");
                    var chkInsert = (CheckBox)item.FindControl("chkInsert");
                    var chkUpdate = (CheckBox)item.FindControl("chkUpdate");
                    var chkDelete = (CheckBox)item.FindControl("chkDelete");
                    var hdModuleID = (HiddenField)item.FindControl("hdModuleID");

                    int actionInsert = 0;
                    if (chkInsert.Checked == true)
                        actionInsert = 1;
                    int actionUpdate = 0;
                    if (chkUpdate.Checked == true)
                        actionUpdate = 1;
                    int actionDelete = 0;
                    if (chkDelete.Checked == true)
                        actionDelete = 1;
                    int actionView = 0;
                    if (chkView.Checked == true)
                        actionView = 1;
                    //Update To Database
                    if (objModule.insertUpdateRolesAdministrator(coachID, int.Parse(hdModuleID.Value), actionInsert, actionUpdate, actionDelete, actionView) == false)
                        FlagError = 1;
                }
            }
            if (FlagError != 0)
            {
                CommonClass.MessageBox.Show("Lỗi cập nhật phân quyền.");
            }
        }
     
        private void Insert()
        {
            if (checkInsert() == false)
                return;
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
            string PhoneNumber = txtPhonePerson.Text.Trim();
            string UserName = this.CoachNameLogin;
            Coachs coach = objCoach.insertCoachs(CoachName, Imgthumb, Facility, TypeUser, GenderID, Email, Birthday, Password, Phone, StatusID, Education, Experience, Level, TaxCode, BankName, BankNumber, WorkingStart, HealthConditon
                                      , CCCD, PlaceOfOrigin, PlaceOfResidence, salary, MaritalStatus, Description, NamePerson, RelationShip, PhoneNumber, UserName);
            if (coach != null)
            {
                InsertPermision(coach.CoachID);
                this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                this.Page.GetType().InvokeMember("LoadListCoach", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                ClearText();
                CommonClass.MessageBox.Show("Thêm mới HLV thành công !");
                DisplayNone();
            }
            else
                CommonClass.MessageBox.Show("Lỗi thêm mới HLV");
        }
        private bool checkUpdate(int coachID)
        {
            if (txtCoachName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Tên Huấn Luyện Viên!");
                DisplayBlock();
                txtCoachName.Focus();
                return false;
            }
            if(txtCCCD.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập căn cước công dân");
                DisplayBlock();
                txtCCCD.Focus();
                return false;
            }
            if(txtPhone.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui Lòng nhập Số điện thoại");
                DisplayBlock();
                txtPhone.Focus();
                return false;
            }
            if(txtEmail.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui Lòng nhập Email");
                DisplayBlock();
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        private void Update(int coachID)
        {
            if (checkUpdate(coachID) == true)
                return;
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
            string PhoneNumber = txtPhonePerson.Text.Trim();
            string UserName = this.CoachNameLogin;

            Coachs coach = objCoach.updateCoachs(coachID, CoachName, Imgthumb, Facility, TypeUser, Email, GenderID, Birthday, Password, Phone, StatusID, Education, Experience, Level, TaxCode, BankName, BankNumber, WorkingStart, HealthConditon
                                      , CCCD, PlaceOfOrigin, PlaceOfResidence, salary, MaritalStatus, Description, NamePerson, RelationShip, PhoneNumber, UserName);
            if (coach != null)
            {
                InsertPermision(coach.CoachID);
                this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                this.Page.GetType().InvokeMember("LoadListCoach", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                ClearText();
                CommonClass.MessageBox.Show("Chỉnh sửa Người dùng thành công !");
                DisplayNone();
            }
            else
                CommonClass.MessageBox.Show("Lỗi chỉnh sửa Người dùng.");
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
        protected void rptModuleAccess_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                getModuleAccessUser_Result item = (getModuleAccessUser_Result)e.Item.DataItem;
                HiddenField hdModuleID = e.Item.FindControl("hdModuleID") as HiddenField;
                Literal ltrName = e.Item.FindControl("ltrName") as Literal;
                Literal ltrDescription = e.Item.FindControl("ltrDescription") as Literal;
                CheckBox chkInsert = e.Item.FindControl("chkInsert") as CheckBox;
                CheckBox chkUpdate = e.Item.FindControl("chkUpdate") as CheckBox;
                CheckBox chkDelete = e.Item.FindControl("chkDelete") as CheckBox;
                CheckBox chkView = e.Item.FindControl("chkView") as CheckBox;

                hdModuleID.Value = item.ModuleID.ToString();

                ltrName.Text = item.Name;
                ltrDescription.Text = item.Description;
                if (item.IsView == 1)
                    chkView.Checked = true;
                if (item.IsInsert == 1)
                    chkInsert.Checked = true;
                if (item.IsUpdate == 1)
                    chkUpdate.Checked = true;
                if (item.IsDelete == 1)
                    chkDelete.Checked = true;
            }
        }
    }
}