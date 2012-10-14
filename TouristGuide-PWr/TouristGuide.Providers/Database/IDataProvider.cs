using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouristGuide.Providers.Database
{
    public interface IDataProvider
    {
        void SubmitChanges();

        #region Users

        Users GetUserByLogin(string login);
        Users GetUserByEmail(string emial);
        Users GetUserByUserId(int userId);
        List<Users> GetUsers();
        List<Users> FindUsersbyLogin(string login);
        List<Users> FindUsersbyEmail(string emial);
        void ChangePassword(string login, string password);
        void ChangePasswordQuestionAnswer(string login, string question, string answer);
        void CreateUser(Users u);
        void UnlockUser(string login);
        void UpdatePassword(string login, string password);
        int GetNumberOnlineUsers();
        void UpdateFailedPassword(string login, int failureType, int passwordAttemptWindow,
                                        int maxInvalidPasswordAttempts);
        void DeleteUser(String login, bool deleteAllRelatedData);
        bool ValidateUser(String username, String password);

        #endregion

        #region Roles

        string[] GetRolesForUser(string username);
        void AddRole(string username, string role, string auth = "");
        void RemoveRole(string username, string role);
        void AddUsersToRoles(string[] usernames, string[] roles);
        void RemoveUsersFromRoles(string[] usernames, string[] roles);
        bool RoleExists(string roleName);
        string[] GetAllRoles();
        void CreateRole(string roleName, string username = "");
        void DeleteRole(string roleName);
        string[] FindUsersInRole(string roleName, string userNameToMatch);
        string[] GetUsersInRole(string roleName);
        List<Roles> GetRoles();
        Roles GetRole(int roleId);
        void EditUserRoles(string username, List<int> rolesId, string auth);

        #endregion        
    }
}
