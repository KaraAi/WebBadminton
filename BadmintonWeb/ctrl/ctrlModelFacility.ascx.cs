using BadmintonWeb.bussiness;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BadmintonWeb.ctrl
{
    public partial class ctrlModelFacility : UserControlBase
    {
        FacilityBussiness objFacility = new FacilityBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void ClearText()
        {
            txtFacilityName.Text = "";
            txtAddress.Text = "";
            txtLatitude.Text = "";
            txtLongtitude.Text = "";
        }
        public void LoadFacilityDetail(int facilityID)
        {
            Facilitys item = objFacility.GetFacilityByID(facilityID);
            if (item != null)
            {
                hdFacilityID.Value=item.FacilityID.ToString();
                txtFacilityName.Text = item.FacilityName.ToString();
                txtAddress.Text = item.Address.ToString();
                txtLongtitude.Text = item.Longtitude.ToString();
                txtLatitude.Text = item.Latitude.ToString();
            }
            DisplayBlock();
        }


        protected void lbtInsert_Click(object sender, EventArgs e)
        {
            int facilityID = 0;
            int.TryParse(hdFacilityID.Value, out facilityID);
            if (facilityID == 0)
            {
                Insert();
            }
            else
            {
                Update(facilityID);
            }
        }

        private void Insert()
        {
            try
            {
                string facilityName = txtFacilityName.Text;
                string address = txtAddress.Text;
                decimal longtitude = decimal.Parse(txtLongtitude.Text);
                decimal latitude = decimal.Parse(txtLatitude.Text);
                string userName = this.CoachNameLogin;

                Facilitys item = objFacility.InsertFacility(facilityName, address, longtitude, latitude,userName);
                if (item != null)
                {
                    this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    this.Page.GetType().InvokeMember("LoadListFacility", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    ClearText();
                    CommonClass.MessageBox.Show("Thêm mới Cơ sở thành công !");
                    DisplayNone();
                }
                else
                    CommonClass.MessageBox.Show("Lỗi thêm mới cơ sở");
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi thêm mới cơ sở");
            }

        }
        private void Update(int facilityID)
        {
            try
            {
                string facilityName = txtFacilityName.Text;
                string address = txtAddress.Text;
                decimal longtitude = decimal.Parse(txtLongtitude.Text);
                decimal latitude = decimal.Parse(txtLatitude.Text);
                string userName = this.CoachNameLogin;

                Facilitys item = objFacility.UpdateFacility(facilityID,facilityName, address, longtitude, latitude, userName);
                if (item != null)
                {
                    this.Page.GetType().InvokeMember("CheckPermision", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    this.Page.GetType().InvokeMember("LoadListFacility", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    //this.Page.GetType().InvokeMember("keepliSection", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                    ClearText();
                    CommonClass.MessageBox.Show("Cập nhật Cơ sở thành công !");
                    DisplayNone();
                }
                else
                    CommonClass.MessageBox.Show("Lỗi cập nhật cơ sở");
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi cập nhật cơ sở");
            }
        }

        protected void lbtClose_Click(object sender, EventArgs e)
        {
            ClearText();
            DisplayNone();
        }
        protected void lbtCloseTop_Click(object sender, EventArgs e)
        {
            ClearText();
            DisplayNone();
        }
        private void DisplayBlock()
        {
            myModelFacility.Attributes.Add("style", "display:block;");
            myModelFacility.Attributes.Add("class", "modal fade in");
        }
        private void DisplayNone()
        {
            myModelFacility.Attributes.Add("style", "display:none;");
            myModelFacility.Attributes.Add("class", "modal fade in");
        }
    }
}