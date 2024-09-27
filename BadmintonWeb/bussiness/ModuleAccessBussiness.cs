using BadmintonWeb.models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace BadmintonWeb.bussiness
{
    public class ModuleAccessBussiness
    {
        #region Properties....
        David_BadmintonEntities db = new David_BadmintonEntities();
        #endregion
        public List<ModuleAccess> getViewListModuleAccess(string keySearch)
        {
            List<ModuleAccess> lstItem = db.ModuleAccess.AsEnumerable().Where(s =>
               string.IsNullOrEmpty(keySearch) || s.Name.Standardizing().Contains(keySearch.Standardizing())
               ).ToList();
            return lstItem;
        }
        public List<ModuleAccess> getAllMoudleAccess()
        {
            List<ModuleAccess> lstItem = db.ModuleAccess.OrderByDescending(s => s.ModuleID).ToList();
            return lstItem;
        }
        public ModuleAccess getMoudleAccessByID(decimal moduleAccessID)
        {
            ModuleAccess item = db.ModuleAccess.Where(s => s.ModuleID == moduleAccessID).FirstOrDefault();
            return item;
        }
        public List<getModuleAccessUser_Result> getViewModuleAccess()
        {
            List<getModuleAccessUser_Result> lstItem = db.getModuleAccessUser().ToList();
            return lstItem;
        }
        public List<UserModules> getRolesAdministratorByUserID(int CoachID)
        {
            var lstProject = db.UserModules.Where(s => s.CoachID == CoachID).ToList();
            return lstProject;
        }
        public bool insertUpdateRolesAdministrator(int _coachID, decimal moduleID, int ActionInsert, int ActionUpdate, int ActionDelete, int ActionView)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    UserModules item = entityObject.UserModules.Where(s => s.CoachID == _coachID && s.ModuleID == moduleID).FirstOrDefault();
                    if (item == null)
                    {
                        UserModules user = new UserModules();
                        user.CoachID = _coachID;
                        user.ModuleID = moduleID;
                        user.IsView = ActionView;
                        user.IsInsert = ActionInsert;
                        user.IsUpdate = ActionUpdate;
                        user.IsDelete = ActionDelete;

                        entityObject.UserModules.Add(user);
                    }
                    else
                    {
                        item.IsView = ActionView;
                        item.IsInsert = ActionInsert;
                        item.IsUpdate = ActionUpdate;
                        item.IsDelete = ActionDelete;
                    }
                    //Save to database
                    entityObject.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserModules getViewPermision(decimal moduleID, int coachID)
        {
            UserModules lstItem = db.UserModules.Where(s => s.ModuleID == moduleID && s.CoachID == coachID).FirstOrDefault();
            return lstItem;
        }

        public bool checkInserMoudleAccess(string Name)
        {
            ModuleAccess item = db.ModuleAccess.Where(s => s.Name == Name).FirstOrDefault();
            if (item != null)
                return false;
            else
                return true;
        }
        public ModuleAccess checkMoudleAccessExists(string name)
        {
            ModuleAccess item = db.ModuleAccess.Where(s => s.Name == name).FirstOrDefault();
            if (item != null)
                return item;
            else
                return null;
        }
        public ModuleAccess insertMoudleAccess(string name, string description, string userName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    ModuleAccess item = new ModuleAccess();

                    item.Name = name;
                    item.Description = description;
                    item.UserCreated = userName;
                    item.UserUpdated = userName;
                    item.DateCreated = DateTime.Now;
                    item.DateUpdated = DateTime.Now;

                    entityObject.ModuleAccess.Add(item);

                    //Save to database
                    entityObject.SaveChanges();
                    return item;
                }
            }
            catch
            {
                return null;
            }
        }
        public bool checkUpdateMoudleAccess(decimal moduleID, string name)
        {
            ModuleAccess item = db.ModuleAccess.Where(s => s.Name == name && s.ModuleID != moduleID).FirstOrDefault();
            if (item != null)
                return false;
            else
                return true;
        }
        public ModuleAccess updateMoudleAccess(decimal moduleID, string name, string description, string userName)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    ModuleAccess item = entityObject.ModuleAccess.Where(s => s.ModuleID == moduleID).FirstOrDefault();
                    if (item != null)
                    {
                        item.Name = name;
                        item.Description = description;
                        item.UserUpdated = userName;
                        item.DateUpdated = DateTime.Now;

                        //Save to database
                        entityObject.SaveChanges();

                        return item;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool checkDeleteMoudleAccessID(decimal moduleID)
        {
            ModuleAccess item = db.ModuleAccess.Where(s => s.ModuleID == moduleID).FirstOrDefault();
            if (item != null)
                return false;
            return true;
        }
        public bool deleteMoudleAccess(decimal moduleID)
        {
            try
            {
                using (David_BadmintonEntities entityObject = new David_BadmintonEntities())
                {
                    ModuleAccess item = entityObject.ModuleAccess.Where(s => s.ModuleID == moduleID).FirstOrDefault();
                    if (item != null)
                    {
                        entityObject.ModuleAccess.Remove(item);
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