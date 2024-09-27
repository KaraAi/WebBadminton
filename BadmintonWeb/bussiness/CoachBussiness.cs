using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BadmintonWeb.bussiness
{
    public class CoachBussiness
    {
        #region Properties....
        David_BadmintonEntities db = new David_BadmintonEntities();
        #endregion
        public List<Coachs> GetAllCoach()
        {
            List<Coachs> lstItem = db.Coachs.ToList();
            return lstItem;
        }
        public Coachs GetCoachID(int CoachID)
        {
            Coachs coachs = db.Coachs.Where(s => s.CoachID == CoachID).FirstOrDefault();
                return coachs;
        }
        public List<TypeUsers> getAllTypeUser()
        {
            List<TypeUsers> lstItem = db.TypeUsers.ToList();
            return lstItem;
        }
        public List<Coachs> getAllUser(string keySearch, int typeUserID)
        {
            List<Coachs> groupUser = db.Coachs.AsEnumerable().Where(s => s.TypeUserID == typeUserID).ToList();
            groupUser = groupUser.AsEnumerable().Where(s =>
                (string.IsNullOrEmpty(keySearch) || s.CoachName.Standardizing().Contains(keySearch.Standardizing())
                || s.CoachName.Standardizing().Contains(keySearch.Standardizing()))).ToList();
            return groupUser;
        }
        public List<Coachs> getCoachIDbyFacilityID(int facilityID)
        {
            List<Coachs> lstAdmin = db.Coachs.Where(s => facilityID == 0 || s.FacilityID == facilityID).OrderBy(s => s.CoachID).ToList();
            return lstAdmin;
        }
        public List<Coachs> GetCoachID()
        {
            List<Coachs> lstItem = db.Coachs.OrderByDescending(s => s.CoachID).ToList();
            return lstItem;
        }
        public Coachs GetCoachByID(int CoachID)
        {
            Coachs coachs = db.Coachs.Where(s => s.CoachID == CoachID).FirstOrDefault();
            if (coachs != null)
                return coachs;
            else
                return null;
        }
        public Coachs checkCoachLogin(string Phone, string Password)
        {
            Coachs coachLogin = db.Coachs.Where(s => s.Phone == Phone && (s.TypeUserID == TypeUserIDContans.Administrator || s.TypeUserID == TypeUserIDContans.HLV || s.TypeUserID == TypeUserIDContans.HocVien) && s.Password == Password).FirstOrDefault();
            if (coachLogin != null)
                return coachLogin;
            else
                return null;
        }
        public Coachs checkLogin(string Phone, string Password)
        {
            Coachs coachLogin = db.Coachs.Where(s => s.Phone == Phone && s.Password == Password).FirstOrDefault();
            if (coachLogin != null)
                return coachLogin;
            else
                return null;
        }
        public Coachs checkUserPass(string Phone, string Password)
        {
            Coachs coachLogin = db.Coachs.Where(s => s.Phone == Phone && s.Password == Password).FirstOrDefault();
            return coachLogin;
        }
        public bool checkCodeCoachs(string phone)
        {
            Coachs coach = db.Coachs.Where(s => s.Phone == phone).FirstOrDefault();
            if (coach != null)
                return false;
            else
                return true;
        }
        public Coachs checkCoachCMNDExists(string CCCD)
        {
            Coachs coach = db.Coachs.Where(s => s.CCCD == CCCD).FirstOrDefault();
            if (coach != null)
                return coach;
            else
                return null;
        }
        public Coachs insertCoachs(string CoachName, string Images,int FacilityID ,int TypeUserID, int GenderID,string Email, DateTime Birthday, string Password, string Phone, int StatusID, int Education, string Experience, int Level, string TaxCode
                                   , string BankName, string BankNumber, DateTime WorkingStart, string HealthCondition, string CCCD, string PlaceOfOrigin, string PlaceOfResidence, decimal Salary, int MaritalStatus
                                   , string Description, string NamePerson, string Relationship, string PhoneNumber, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Coachs coach = new Coachs();
                   
                    coach.CoachName = CoachName;
                    coach.Images = Images;
                        coach.FacilityID = FacilityID;
                    if (TypeUserID != 0)
                    {
                        coach.TypeUserID = TypeUserID;
                    }
                    coach.GenderID = GenderID;
                    coach.Email = Email;
                    coach.Birthday = Birthday;
                    coach.Password = Password;
                    coach.Phone = Phone;
                    coach.StatusID = StatusID;
                    coach.Education = Education;
                    coach.Experience = Experience;
                    coach.Level = Level;
                    coach.TaxCode = TaxCode;
                    coach.BankName = BankName;
                    coach.BankNumber = BankNumber;
                    coach.WorkingStart = WorkingStart;
                    coach.HealthCondition = HealthCondition;
                    coach.CCCD = CCCD;
                    coach.PlaceOfOrigin = PlaceOfOrigin;
                    coach.PlaceOfResidence = PlaceOfResidence;
                    coach.Salary = Salary;
                    coach.MaritalStatus = MaritalStatus;
                    coach.Description = Description;
                    coach.NamePerson = NamePerson;
                    coach.Relationship = Relationship;
                    coach.PhoneNumber = PhoneNumber;

                    coach.UserCreated = UserName;
                    coach.UserUpdated = UserName;
                    coach.DateCreated = DateTime.Now;
                    coach.DateUpdated = DateTime.Now;

                    entityObject.Coachs.Add(coach);

                    entityObject.SaveChanges();

                    return coach;
                }
            }
            catch
            {
                return null;
            }
        }
        public bool checkUpdateCoach(int CoachID)
        {
            Coachs coach = db.Coachs.Where(s => s.CoachID == CoachID).FirstOrDefault();
            if (coach != null)
                return false;
            else
                return true;
        }
        public Coachs updateCoachs(int CoachID,string CoachName, string Images,int FacilityID ,int TypeUserID,string Email, int GenderID, DateTime Birthday, string Password, string Phone, int StatusID, int Education, string Experience, int Level, string TaxCode
                                   , string BankName, string BankNumber, DateTime WorkingStart, string HealthCondition, string CCCD, string PlaceOfOrigin, string PlaceOfResidence, decimal Salary, int MaritalStatus
                                   , string Description, string NamePerson, string Relationship, string PhoneNumber, string UserName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Coachs coach = entityObject.Coachs.Where(s => s.CoachID == CoachID).FirstOrDefault();
                    if (coach != null)
                    {
                   
                        coach.CoachName = CoachName;
                        coach.Images = Images;
                        coach.FacilityID = FacilityID;
                        if (TypeUserID != 0)
                        {
                            coach.TypeUserID = TypeUserID;
                        }
                        coach.Email = Email;
                        coach.GenderID = GenderID;
                        coach.Birthday = Birthday;
                        coach.Password = Password;
                        coach.Phone = Phone;
                        coach.StatusID = StatusID;
                        coach.Education = Education;
                        coach.Experience = Experience;
                        coach.Level = Level;
                        coach.TaxCode = TaxCode;
                        coach.BankName = BankName;
                        coach.BankNumber = BankNumber;
                        coach.WorkingStart = WorkingStart;
                        coach.HealthCondition = HealthCondition;
                        coach.CCCD = CCCD;
                        coach.PlaceOfOrigin = PlaceOfOrigin;
                        coach.PlaceOfResidence = PlaceOfResidence;
                        coach.Salary = Salary;
                        coach.MaritalStatus = MaritalStatus;
                        coach.Description = Description;
                        coach.NamePerson = NamePerson;
                        coach.Relationship = Relationship;
                        coach.PhoneNumber = PhoneNumber;

                        coach.UserUpdated = UserName;
                        coach.DateUpdated = DateTime.Now;


                        entityObject.SaveChanges();
                        return coach;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool ChangePassWord(string Phone, string PassWordOld, string PassWord, string UserUpdated)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Coachs coachs = entityObject.Coachs.Where(s => s.Phone == Phone && s.Password == PassWordOld).FirstOrDefault();
                    if (coachs != null)//update
                    {
                        coachs.Phone = Phone;
                        coachs.Password = PassWord;

                        coachs.UserUpdated = UserUpdated;
                        coachs.DateUpdated = DateTime.Now;

                        //Save to database
                        entityObject.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool checkDeleteCoach(int coachID)
        {
            Coachs item = db.Coachs.Where(s => s.CoachID == coachID && s.TypeUserID == TypeUserIDContans.Administrator).FirstOrDefault();
            if (item != null)
            {
                return false;
            }
            return true;
        }
        //public bool openBlock(int coachID)
        //{
        //    try
        //    {
        //        using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
        //        {
        //            Coachs coach = entityObject.Coachs.Where(s => s.CoachID == coachID).FirstOrDefault();
        //            if (coach != null)
        //            {
        //                coach.StatusID = 1;
        //                //Save to database
        //                entityObject.SaveChanges();

        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public bool deleteCoach(int CoachID)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Coachs coachs = entityObject.Coachs.Where(s => s.CoachID == CoachID).FirstOrDefault();
                    if (coachs != null)
                    {
                        entityObject.Coachs.Remove(coachs);
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
        public bool ResetPass(int coachID, string Password)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    Coachs coach = entityObject.Coachs.Where(s => s.CoachID == coachID).FirstOrDefault();
                    if (coach != null)
                    {
                        coach.Password = Password;
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