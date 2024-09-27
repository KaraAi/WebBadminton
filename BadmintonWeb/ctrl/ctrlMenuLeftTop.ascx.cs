using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.ctrl
{
    public partial class ctrlMenuLeftTop : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CoachName"] != null)
                {
                    ltrUserCode1.Text = Session["CoachName"].ToString();
                }
                hplProfile.NavigateUrl = "~/coach/CoachDetails.aspx?CoachID=" + this.CoachIDLogin;
                loadImagesAvarta(imgUser1);

                //Set phân quyền menu
                SetPermissionMenu();
            }
        }
        CoachBussiness objCoach = new CoachBussiness();

        public void loadImagesAvarta(Image imgLoginAvarta)
        {
            int coachID = 0;
            if (Session["CoachID"] != null)
                coachID = int.Parse(Session["CoachID"].ToString());
            if (coachID != 0)
            {
                imgLoginAvarta.ImageUrl = "~/images/img.jpg";

                Coachs item = objCoach.GetCoachID(coachID);
                if (item != null)
                {
                    string imagePath = "";//item.ImagesPaths;
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        byte[] bytes = Convert.FromBase64String(imagePath);
                        ImageFormat isImage = GetImageFormat(bytes);
                        if (isImage != ImageFormat.Icon)
                        {
                            imgLoginAvarta.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                            imgLoginAvarta.AlternateText = item.CoachName;
                        }
                    }
                }
            }
        }
        private void SetPermissionMenu()
        {
            int typeUserLogin = 0;
            if (Session["TypeUserID"] != null)
                typeUserLogin = int.Parse(Session["TypeUserID"].ToString());

            if (typeUserLogin == TypeUserIDContans.HLV)
            {
                htmlCoachList.Visible = false;
                htmlInformation.Visible = false;
                htmlTimeList.Visible = false;
                htmlStudentList.Visible = false;
                htmlFacilityList.Visible = false;
                htmlRollCall.Visible = true;
                liHistoryRollCall.Visible = true;
            }
            else if (typeUserLogin == TypeUserIDContans.Administrator)
            {
                htmlCoachList.Visible = true;
                htmlInformation.Visible = true;
                htmlTimeList.Visible = true;
                htmlStudentList.Visible = true;
                htmlFacilityList.Visible = true;
                htmlRollCall.Visible = true;
                liHistoryRollCall.Visible = true;
            }

        }

    }
}