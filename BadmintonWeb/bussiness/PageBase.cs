using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using Itech.Utils;

namespace BadmintonWeb.bussiness
{
    public class PageBase : System.Web.UI.Page
    {
        private string coachNameLogin = "";
        public string CoachNameLogin
        {
            get { return Session["CoachName"].ToString(); }
            set { coachNameLogin = Session["CoachName"].ToString(); }
        }

        private int coachIDLogin = 0;
        public int CoachIDLogin
        {
            get { return int.Parse((Session["CoachID"] ?? "0").ToString()); }
            set { coachIDLogin = int.Parse((Session["CoachID"] ?? "0").ToString()); }
        }

        private int userTypeID = 0;
        public int TypeUserID
        {
            get { return int.Parse(Session["TypeUserID"].ToString()); }
            set { coachIDLogin = int.Parse(Session["TypeUserID"].ToString()); }
        }

        public string PdfPathName
        {
            get { return Session["PdfPathName"].ToString(); }
        }

        //Kiểm tra file upload đúng định dạng chưa
        protected bool CheckExtention(FileUpload name, int intType)
        {
            string Extentsion = CommonFunctions.getFileFormat(name.FileName);
            bool checkExtension = false;

            if (intType == 0)
            {
                foreach (string strTempExtentsion in ConfigurationManager.AppSettings["FILE_FORMAT_UPLOAD"].ToString().Split(".".ToCharArray()))
                {
                    if (Extentsion.ToLower() == strTempExtentsion.ToLower())
                    {
                        checkExtension = true;
                        return true;
                    }
                }
                if (checkExtension == false)
                {
                    CommonClass.MessageBox.Show("File Upload phải thuộc các định dạng: .gif ; .jpeg ; .jpg; .pdf");
                    return false;
                }
            }
            else
            {
                foreach (string strTempExtentsion in ConfigurationManager.AppSettings["PROFILE_FORMAT_UPLOAD"].ToString().Split(".".ToCharArray()))
                {
                    if (Extentsion.ToLower() == strTempExtentsion.ToLower())
                    {
                        checkExtension = true;
                        return true;
                    }
                }
                if (checkExtension == false)
                {
                    CommonClass.MessageBox.Show("File Upload phải thuộc các định dạng: .docx; .pdf");
                    return false;
                }
            }

            return false;
        }
        public static Bitmap CreateThumbnail(Stream lcFilename, int lnWidth, int lnHeight)
        {

            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }


                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;

                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch
            {
                return null;
            }
            return bmpOut;
        }
        public void SendMail(string strSubjectMail, string strContentMail, string nameTo, string emailTo)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            System.Net.Configuration.MailSettingsSectionGroup settings = (System.Net.Configuration.MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
            string strName = ConfigurationManager.AppSettings["NameAdminEmail"];
            string strEmail = settings.Smtp.Network.UserName;

            //ITServicesUtil.SendMail(strName, strEmail, nameTo, emailTo, strSubjectMail, strContentMail);
            ITServicesUtil.SendMailGmail(strName, strEmail, nameTo, emailTo, "", strSubjectMail, strContentMail, settings.Smtp.Network.Host, settings.Smtp.Network.UserName,
             settings.Smtp.Network.Password);
        }

    }
}