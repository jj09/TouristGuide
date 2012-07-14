using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Objects;

namespace TouristGuide.Providers.Database
{
    public partial class SqlProvider : IDataProvider
    {
        readonly object _lock = new object();
        private TouristGuideDBEntities _TGEntities;
        private TouristGuideDBEntities TGEntities
        {
            get
            {
                if (_TGEntities == null)
                {
                    lock (_lock)
                    {
                        if (_TGEntities == null)
                        {
                            _TGEntities = new TouristGuideDBEntities();
                            _TGEntities.CommandTimeout = 600;
                        }
                    }
                }

                return _TGEntities;
            }
        }

        public void SubmitChanges()
        {
            TGEntities.SaveChanges();
        }

        #region Users

        public Users GetUserByLogin(string login)
        {
            return TGEntities.Users.SingleOrDefault(x => x.Login.Equals(login));
        }

        public Users GetUserByEmail(string emial)
        {
            return TGEntities.Users.SingleOrDefault(x => x.Email.Equals(emial));
        }

        public Users GetUserByUserId(int userId)
        {
            return TGEntities.Users.SingleOrDefault(x => x.UserId == userId);
        }

        public List<Users> GetUsers()
        {
            return TGEntities.Users.ToList();
        }

        public List<Users> FindUsersbyEmail(string emial)
        {
            return TGEntities.Users.Where(x => x.Email.Contains(emial)).ToList();
        }

        public List<Users> FindUsersbyLogin(string login)
        {
            return TGEntities.Users.Where(x => x.Login.Contains(login)).ToList();
        }

        public void ChangePassword(string login, string password)
        {
            Users u = TGEntities.Users.SingleOrDefault(x => x.Login.Equals(login));

            if (u != null)
            {
                u.Password = password;
                u.LastPasswordChangedDate = DateTime.Now;
                SubmitChanges();
            }
        }

        public void ChangePasswordQuestionAnswer(string login, string question, string answer)
        {
            Users u = TGEntities.Users.SingleOrDefault(x => x.Login.Equals(login));

            if (u != null)
            {
                u.PasswordQuestion = question;
                u.PasswordAnswer = answer;
                SubmitChanges();
            }
        }

        public void CreateUser(Users u)
        {
            u.CreationDate = DateTime.Now;
            u.LastActivityDate = DateTime.Now;
            u.LastPasswordChangedDate = DateTime.Now;
            u.IsLockedOut = false;
            u.FailedPasswordAnswerAttemptCount = 0;
            u.FailedPasswordAttemptCount = 0;
            TGEntities.Users.AddObject(u);
            SubmitChanges();
        }

        public void UnlockUser(string login)
        {
            Users u = TGEntities.Users.SingleOrDefault(x => x.Login.Equals(login));

            if (u != null)
            {
                u.IsLockedOut = false;
                u.LastLockedOutDate = DateTime.Now;
                SubmitChanges();
            }
        }

        public void UpdatePassword(string login, string password)
        {
            Users u = TGEntities.Users.SingleOrDefault(x => x.Login.Equals(login));

            if (u != null)
            {
                u.Password = password;
                u.LastPasswordChangedDate = DateTime.Now;
                SubmitChanges();
            }
        }

        public bool ValidateUser(string username, string password)
        {
            return TGEntities.Users.Count(x => x.Login == username &&
                    (x.IsLockedOut.HasValue && x.IsLockedOut.Value == false) && x.Password.Equals(password)) > 0;
        }

        public int GetNumberOnlineUsers()
        {
            return TGEntities.Users.Count(x => x.IsOnLine.HasValue && x.IsOnLine.Value == true);
        }

        public void UpdateFailedPassword(string login, int failureType, int passwordAttemptWindow,
                                        int maxInvalidPasswordAttempts)
        {
            Users u = TGEntities.Users.SingleOrDefault(x => x.Login.Equals(login));

            if (u == null)
                return;

            int failureCount = 0;
            DateTime windowStart = DateTime.Now;
            DateTime windowEnd = DateTime.Now;

            if (failureType == 1)
            {
                failureCount = u.FailedPasswordAttemptCount.HasValue ? u.FailedPasswordAttemptCount.Value : 0;
                windowStart = u.FailedPasswordAttemptWindowStart.HasValue ? u.FailedPasswordAttemptWindowStart.Value : DateTime.Now;
            }
            else if (failureType == 2)
            {
                failureCount = u.FailedPasswordAnswerAttemptCount.HasValue ? u.FailedPasswordAnswerAttemptCount.Value : 0;
                windowStart = u.FailedPasswordAnswerAttemptWindowStart.HasValue ? u.FailedPasswordAnswerAttemptWindowStart.Value : DateTime.Now;
            }

            windowEnd = windowStart.AddMinutes(passwordAttemptWindow);

            if (failureCount == 0 || DateTime.Now > windowEnd)
            {
                if (failureType == 1)
                {
                    u.FailedPasswordAttemptCount = 1;
                    u.FailedPasswordAttemptWindowStart = DateTime.Now;
                }
                else if (failureType == 2)
                {
                    u.FailedPasswordAnswerAttemptCount = 1;
                    u.FailedPasswordAnswerAttemptWindowStart = DateTime.Now;
                }
            }

            ++failureCount;

            if (failureCount >= maxInvalidPasswordAttempts)
            {
                u.IsLockedOut = true;
                u.LastLockedOutDate = DateTime.Now;
            }
            else
            {
                if (failureType == 1)
                    u.FailedPasswordAttemptCount = failureCount;
                else if (failureType == 2)
                    u.FailedPasswordAnswerAttemptCount = failureCount;
            }

            SubmitChanges();
        }

        public void DeleteUser(String login, bool deleteAllRelatedData)
        {
            //TODO: implement method's body
            Users u = TGEntities.Users.SingleOrDefault(x => x.Login.Equals(login));

            if (u != null)
            {
                //TODO: implement user's data deletion (rather stored procedure)
                TGEntities.Users.DeleteObject(u);
                SubmitChanges();
            }
        }

        #endregion

        #region Roles

        public string[] GetRolesForUser(string username)
        {
            return TGEntities.UserRoles.Where(x => x.Users.Login.Equals(username)).Select(x => x.Roles.Role).ToArray();
        }

        public void AddRole(string username, string role, string auth)
        {
            UserRoles ur = new UserRoles();
            Users u = GetUserByLogin(username);
            Roles r = TGEntities.Roles.SingleOrDefault(x => x.Role.Equals(role));

            if (u != null && r != null)
            {
                ur.UserId = u.UserId;
                r.UserRoles.Add(ur);
                SubmitChanges();
            }
        }

        public void RemoveRole(string username, string role)
        {
            UserRoles ur = TGEntities.UserRoles.Where(x => x.Users.Login.Equals(username)).SingleOrDefault(x => x.Roles.Role == role);

            if (ur != null)
            {
                TGEntities.UserRoles.DeleteObject(ur);
                SubmitChanges();
            }
        }

        public void EditUserRoles(string username, List<int> rolesId, string auth)
        {
            List<Roles> roles = TGEntities.Roles.Where(x => rolesId.Contains(x.RoleId)).ToList();
            List<Roles> uRoles = TGEntities.UserRoles.Where(x => x.Users.Login.Equals(username)).Select(x => x.Roles).ToList();
            List<Roles> remove = uRoles.Where(x => !roles.Contains(x)).ToList();
            List<Roles> add = roles.Where(x => !uRoles.Contains(x)).ToList();

            foreach (var r in remove)
                RemoveRole(username, r.Role);

            foreach (var r in add)
                AddRole(username, r.Role, auth);
        }

        public void AddUsersToRoles(string[] usernames, string[] roles)
        {
            foreach (var u in usernames)
                foreach (var r in roles)
                    AddRole(u, r, "");
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roles)
        {
            foreach (var u in usernames)
                foreach (var r in roles)
                    RemoveRole(u, r);
        }

        public bool RoleExists(string roleName)
        {
            return TGEntities.Roles.Count(x => x.Role == roleName) > 0;
        }

        public string[] GetAllRoles()
        {
            return TGEntities.Roles.Select(x => x.Role).ToArray();
        }

        public void CreateRole(string roleName, string username)
        {
            Roles r = new Roles();
            r.Role = roleName;
            TGEntities.Roles.AddObject(r);
            SubmitChanges();
        }

        public void DeleteRole(string roleName)
        {
            Roles r = TGEntities.Roles.SingleOrDefault(x => x.Role.Equals(roleName));

            if (r != null)
            {
                TGEntities.Roles.DeleteObject(r);
                SubmitChanges();
            }
        }

        public string[] FindUsersInRole(string roleName, string userNameToMatch)
        {
            Roles r = TGEntities.Roles.SingleOrDefault(x => x.Equals(roleName));

            if (r != null)
            {
                return TGEntities.UserRoles.Where(x => x.RoleId == r.RoleId && x.Users.Login.Contains(userNameToMatch))
                    .Select(x => x.Users.Login).ToArray();
            }

            return null;
        }

        public string[] GetUsersInRole(string roleName)
        {
            Roles r = TGEntities.Roles.SingleOrDefault(x => x.Equals(roleName));

            if (r != null)
            {
                return TGEntities.UserRoles.Where(x => x.RoleId == r.RoleId).Select(x => x.Users.Login).ToArray();
            }

            return null;
        }

        public List<Roles> GetRoles()
        {
            return TGEntities.Roles.ToList();
        }

        public Roles GetRole(int roleId)
        {
            return TGEntities.Roles.SingleOrDefault(x => x.RoleId == roleId);
        }

        #endregion
    }
}