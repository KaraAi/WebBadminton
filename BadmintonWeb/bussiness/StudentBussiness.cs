using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace BadmintonWeb.bussiness
{
    public class StudentBussiness
    {
        #region Properties....
        David_BadmintonEntities db = new David_BadmintonEntities();
        #endregion

        public List<Students> GetAllStudent()
        {
            List<Students> lstItem = db.Students.ToList();
            return lstItem;
        }
        public List<Students> getViewListStudent(string keySearch)
        {
            List<Students> lstItem = db.Students.AsEnumerable().Where(s =>
               string.IsNullOrEmpty(keySearch) || s.StudentName.Standardizing().Contains(keySearch.Standardizing())
               ).ToList();
            return lstItem;
        }
        public Students getStudentName(int StudentID)
        {
            Students item = db.Students.Where(s => s.StudentID == StudentID).FirstOrDefault();
                return item;
        }
        public Students GetStudentByID(int StudentID)
        {
            Students item = db.Students.Where(s=>s.StudentID  == StudentID).FirstOrDefault();
            if(item != null)
            {
                return item;
            }
            return null;
        }
        public Students InsertStudent(int FacilityID, int CoachID,int TimeID,string Email ,string StudentName, string Images, int GenderID, DateTime Birhday,int TypeUserID, string Phone, int StatusID, string Address, string Password, int Level
                                        , decimal Tuitions, DateTime StudyStart, string HealthCondition, string Height, string Weight, string GuardianName, string Relationship
                                        , string GuardianPhone, string Description, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Students stDetail = new Students();
                    stDetail.FacilityID = FacilityID;
                    stDetail.CoachID = CoachID;
                    stDetail.TimeID = TimeID;
                    stDetail.Email =  Email; 
                    stDetail.StudentName = StudentName;
                    stDetail.Images = Images;
                    stDetail.GenderID = GenderID;
                    stDetail.Birthday = Birhday;
                    if (TypeUserID != 0)
                    {
                        stDetail.TypeUserID = TypeUserID;
                    }
                    stDetail.Phone = Phone;
                    stDetail.StatusID = StatusID;
                    stDetail.Address = Address;
                    stDetail.Password = Password;
                    stDetail.Level = Level;
                    stDetail.Tuitions = Tuitions;
                    stDetail.StudyStart = StudyStart;
                    stDetail.HealthCondition = HealthCondition;
                    stDetail.Height = Height;
                    stDetail.Weight = Weight;
                    stDetail.GuardianName = GuardianName;
                    stDetail.Relationship = Relationship;
                    stDetail.Description = Description;
                    stDetail.GuardianPhone = GuardianPhone;
                    stDetail.Description = Description;

                    stDetail.UserCreated = UserName;
                    stDetail.UserUpdated = UserName;
                    stDetail.DateCreated = DateTime.Now;
                    stDetail.DateUpdated = DateTime.Now;

                    entityObject.Students.Add(stDetail);
                    entityObject.SaveChanges();
                    return stDetail;
                }
            }
            catch
            {
                return null; 
            }
        }

        public Students UpdateStudent(int StudentID,int FacilityID, int CoachID,int TimeID,string Email ,string StudentName, string Images, int GenderID, DateTime Birhday,int TypeUserID ,string Phone, int StatusID, string Address, string Password, int Level
                                        , decimal Tuitions, DateTime StudyStart, string HealthCondition, string Height, string Weight, string GuardianName, string Relationship
                                        , string GuardianPhone, string Description, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Students students = entityObject.Students.Where(s => s.StudentID == StudentID).FirstOrDefault();
                    if (students != null)
                    {
                        students.FacilityID = FacilityID;
                        students.CoachID = CoachID;
                        students.TimeID = TimeID;
                        students.Email = Email;
                        students.StudentName = StudentName;
                        students.Images = Images;
                        students.GenderID = GenderID;
                        students.Birthday = Birhday;
                        if (TypeUserID != 0)
                        {
                            students.TypeUserID = TypeUserID;
                        }
                        students.Phone = Phone;
                        students.StatusID = StatusID;
                        students.Address = Address;
                        students.Password = Password;
                        students.Level = Level;
                        students.Tuitions = Tuitions;
                        students.StudyStart = StudyStart;
                        students.Relationship = Relationship;
                        students.HealthCondition = HealthCondition;
                        students.Height = Height;
                        students.Weight = Weight;
                        students.GuardianName = GuardianName;
                        students.Description = Description;
                        students.GuardianPhone = GuardianPhone;
                        students.Description = Description;
                        
                        students.UserUpdated = UserName;
                        students.DateUpdated = DateTime.Now;
                        entityObject.SaveChanges();
                        return students;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool deleteStudent(int StudentID)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Students students = entityObject.Students.Where(s => s.StudentID == StudentID).FirstOrDefault();
                    if (students != null)
                    {
                        entityObject.Students.Remove(students);
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
        public bool ResetPass(int studentID, string Password)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Students student = entityObject.Students.Where(s => s.StudentID == studentID).FirstOrDefault();
                    if (student != null)
                    {
                        student.Password = Password;
                        //Save to database
                        entityObject.SaveChanges();

                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}