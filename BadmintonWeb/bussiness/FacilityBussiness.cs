using Antlr.Runtime;
using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace BadmintonWeb.bussiness
{
    public class FacilityBussiness
    {
        #region Properties....
        David_BadmintonEntities db = new David_BadmintonEntities();
        #endregion

        public List<Facilitys> GetAllFacility()
        {
            List<Facilitys> lstItem = db.Facilitys.OrderByDescending(s=>s.FacilityID).ToList();
            return lstItem;
        }
        public Facilitys GetFacilityByID(int FacilityID)
        {
            Facilitys facilitys = db.Facilitys.Where(s => s.FacilityID == FacilityID).FirstOrDefault();
            if (facilitys != null)
                return facilitys;
            else
                return null;
        }
        public Facilitys getFacilityID(int FacilityID)
        {
            Facilitys facilitys = db.Facilitys.Where(s => s.FacilityID == FacilityID).FirstOrDefault();
                return facilitys;
        }
        public List<Facilitys> getAllFacility(string keySearch)
        {
            List<Facilitys> facilitys = db.Facilitys.ToList();
            facilitys = facilitys.AsEnumerable().Where(s =>
                (string.IsNullOrEmpty(keySearch) || s.FacilityName.Standardizing().Contains(keySearch.Standardizing())
                || s.FacilityName.Standardizing().Contains(keySearch.Standardizing()))).ToList();
            return facilitys;
        }
        public List<Facilitys> GetFacilityBySearch(string keySearch)
        {
            List<Facilitys> lstfacilitys = db.Facilitys.Where(s => s.FacilityName.Standardizing() == keySearch).OrderByDescending(s => s.FacilityName).ToList();
            return lstfacilitys;
        }

        public bool CheckInsertFacility(string FacilityName)
        {
            Facilitys item = db.Facilitys.Where(s=>s.FacilityName == FacilityName).FirstOrDefault();
            if (item != null)
                return false;
            else 
                return true;
        }
        public bool CheckUpdateFacility(int FacilityID,string FacilityName)
        {
            Facilitys item = db.Facilitys.Where(s => s.FacilityID != FacilityID && s.FacilityName == FacilityName).FirstOrDefault();
            if (item != null)
                return false;
            else
                return true;
        }
        public Facilitys InsertFacility(string FacilityName, string Address, decimal Longtitude, decimal Latitude, string UserName)
        {
            try
            {
                using(David_BadmintonEntities entityobject = new David_BadmintonEntities())
                {
                    Facilitys facilitys = new Facilitys();
                    facilitys.FacilityName = FacilityName;
                    facilitys.Address = Address;
                    facilitys.Longtitude = Longtitude;
                    facilitys.Latitude = Latitude;

                    facilitys.UserCreated = UserName;
                    facilitys.UserUpdated = UserName;
                    facilitys.DateCreated = DateTime.Now;
                    facilitys.DateUpdated = DateTime.Now;

                    entityobject.Facilitys.Add(facilitys);
                    entityobject.SaveChanges();
                    return facilitys;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Facilitys UpdateFacility(int FacilityID, string FacilityName, string Address, decimal Longtitude, decimal Latitude, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Facilitys facilitys = entityObject.Facilitys.Where(s => s.FacilityID == FacilityID).FirstOrDefault();
                    if (facilitys != null)
                    {
                        facilitys.FacilityName = FacilityName;
                        facilitys.Address = Address;
                        facilitys.Longtitude = Longtitude;
                        facilitys.Latitude = Latitude;

                        facilitys.UserUpdated = UserName;
                        facilitys.DateUpdated = DateTime.Now;

                        entityObject.SaveChanges();
                        return facilitys;
                    }
                   
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool CheckDeleteFacility(int FacilityID)
        {
            //Kiểm tra cơ sở đã dùng chưa
            return true;
        }

        public bool DeleteFacility(int FacilityID)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Facilitys facilitys = entityObject.Facilitys.Where(s => s.FacilityID == FacilityID).FirstOrDefault();
                    if (facilitys != null)
                    {
                        entityObject.Facilitys.Remove(facilitys);
                        //Save to database
                        entityObject.SaveChanges();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}