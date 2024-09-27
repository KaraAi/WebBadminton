using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BadmintonWeb.bussiness
{
    public class RollCallBussiness
    {
        #region Properties....
        David_BadmintonEntities db = new David_BadmintonEntities();
        #endregion




        public List<getCheckedStudentsByDateAndCoach_Result> getRollCallByCheckID(DateTime fromDate, int coachID)
        {
            List<getCheckedStudentsByDateAndCoach_Result> lstResult = db.getCheckedStudentsByDateAndCoach(fromDate, coachID).ToList();
            return lstResult;
        }
        public List<getStudentByCoachID_Result> getFilteredRollCall(int facilityID, int coachID, int timeID)
        {
            List<getStudentByCoachID_Result> lstItem = db.getStudentByCoachID(facilityID,coachID,timeID).ToList();
            return lstItem;
        }
        public RollCalls insertRollCall(int StudentID, int CoachID, int isCheck, int StatusID, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    RollCalls rollcall = new RollCalls();
                    rollcall.StudentID = StudentID;
                    rollcall.CoachID = CoachID;
                    rollcall.StatusID = StatusID;
                    rollcall.isCheck = isCheck;

                    rollcall.UserCreated = UserName;
                    rollcall.UserUpdated = UserName;
                    rollcall.DateCreated = DateTime.Now;
                    rollcall.DateUpdated = DateTime.Now;

                    entityObject.RollCalls.Add(rollcall);
                    entityObject.SaveChanges();

                    return rollcall;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool insertisCheckRollCall(int studentID, int coachID, int ActionCheck, int statusID, string UserName)
        {
            try
            {
                using(David_BadmintonEntities entityObject =new David_BadmintonEntities())
                {
                  
                        RollCalls rc = new RollCalls();
                        rc.StudentID = studentID;
                        rc.CoachID = coachID;
                        rc.StatusID = statusID;
                        rc.isCheck = ActionCheck;

                        rc.UserCreated = UserName;
                        rc.UserUpdated = UserName;
                        rc.DateCreated = DateTime.Now;
                        rc.DateUpdated = DateTime.Now;
                        entityObject.RollCalls.Add(rc);
                    entityObject.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public RollCalls UpdateRollCall(int RollCallID, int StudentID, int isCheck, int StatusID, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    RollCalls rollcall = entityObject.RollCalls.Where(s => s.RollCallID == RollCallID).FirstOrDefault();
                    if (rollcall != null)
                    {
                        rollcall.StudentID = StudentID;
                        rollcall.StatusID = StatusID;
                        rollcall.isCheck = isCheck;

                        rollcall.UserCreated = UserName;
                        rollcall.DateUpdated = DateTime.Now;


                        entityObject.SaveChanges();
                        return rollcall;

                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}