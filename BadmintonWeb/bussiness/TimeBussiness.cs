using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BadmintonWeb.bussiness
{
    public class TimeBussiness
    {
        #region Properties....
        David_BadmintonEntities db = new David_BadmintonEntities();
        #endregion

        public List<Time> GetAllTime()
        {
            List<Time> lstItem = db.Time.OrderByDescending(s=>s.TimeID).ToList();
            return lstItem;
        }
        public List<Time> getViewListTime(string keySearch)
        {
            List<Time> lstItem = db.Time.AsEnumerable().Where(s =>
               string.IsNullOrEmpty(keySearch) || s.TimeName.Standardizing().Contains(keySearch.Standardizing())
               ).ToList();
            return lstItem;
        }
        public Time GetTimeByID(int timeID)
        {
            Time time = db.Time.Where(s => s.TimeID == timeID).FirstOrDefault();
            if (time != null)
                return time;
            else
                return null;
        }
        public Time GetNameTimeByID(int timeID)
        {
            Time time = db.Time.Where(s => s.TimeID == timeID).FirstOrDefault();
           return time;
        }

        public Time insertTime(string TimeName, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Time time = new Time();
                    time.TimeName = TimeName;
                    time.UserCreated = UserName;
                    time.UserUpdated = UserName;
                    time.DateCreated = DateTime.Now;
                    time.DateUpdated = DateTime.Now;

                    entityObject.Time.Add(time);

                    entityObject.SaveChanges();
                    return time;
                }
            }
            catch
            {
                return null;
            }
        }

        public Time updateTime(int TimeID,string TimeName, string UserName)
        {
            try
            {
                using(David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Time time = entityObject.Time.Where(s => s.TimeID == TimeID).FirstOrDefault();
                    if (time != null)
                    {
                        time.TimeName = TimeName;

                        time.DateUpdated = DateTime.Now;
                        time.UserUpdated = UserName;

                        entityObject.SaveChanges();
                        return time;
                    }
                }
              return null;
            }
            catch 
            {
                return null;
            }
        }
        public bool DeleteTime(int TimeID)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Time time = entityObject.Time.Where(s => s.TimeID == TimeID).FirstOrDefault();
                    if (time != null)
                    {
                        entityObject.Time.Remove(time);
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