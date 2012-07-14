using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Diagnostics;
using TouristGuide.Providers.Database;

namespace TouristGuide.Providers
{
    public sealed class TGRoleProvider : RoleProvider
    {

        IDataProvider Data = new SqlProvider();

        #region Class Variables

        private string eventSource;
        private string eventLog;
        private string exceptionMessage;
        private string connectionString;
        private string applicationName;
        private bool writeExceptionsToEventLog;

        #endregion

        #region Properties

        public override string ApplicationName
        {
            get
            {
                return applicationName;
            }
            set
            {
                applicationName = value;
            }
        }

        public bool WriteExceptionsToEventLog
        {
            get 
            { 
                return writeExceptionsToEventLog; 
            }
            set 
            { 
                writeExceptionsToEventLog = value; 
            }
        }

        #endregion

        #region Initialization

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "DomodiRoleProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Role provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);
            
            if (config["applicationName"] == null || config["applicationName"].Trim() == "")
            {
                applicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            }
            else
            {
                applicationName = config["applicationName"];
            }
            
            if (config["writeExceptionsToEventLog"] != null)
            {
                if (config["writeExceptionsToEventLog"].ToUpper() == "TRUE")
                {
                    writeExceptionsToEventLog = true;
                }
            }

            eventSource = "DomodiRoleProvider";
            eventLog = applicationName;
            exceptionMessage = "An exception occurred. Please check the Event Log.";
            
            ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if ((ConnectionStringSettings == null) || (ConnectionStringSettings.ConnectionString.Trim() == String.Empty))
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            connectionString = ConnectionStringSettings.ConnectionString;
        }

        #endregion

        #region Implemented Abstract Methods from RoleProvider

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            Data.AddUsersToRoles(usernames, roleNames);
        }

        public void AddUserToRole(string username, string roleName)
        {
            Data.AddRole(username, roleName);
        }

        public override void CreateRole(string roleName)
        {
            Data.CreateRole(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            Data.DeleteRole(roleName);
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return Data.FindUsersInRole(roleName, usernameToMatch);
        }

        public override string[] GetAllRoles()
        {
            return Data.GetAllRoles();
        }

        public override string[] GetRolesForUser(string username)
        {
            return Data.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return Data.GetUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = Data.GetRolesForUser(username);
            
            foreach(var r in roles)
                if(r.Equals(roleName))
                    return true;

            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            Data.RemoveUsersFromRoles(usernames, roleNames);
        }

        public override bool RoleExists(string roleName)
        {
            return Data.RoleExists(roleName);
        }

        #endregion

        #region "Utility Functions"

        private void WriteToEventLog(SqlException e, string action)
        {
            EventLog log = new EventLog();
            log.Source = eventSource;
            log.Log = eventLog;

            string message = exceptionMessage + "\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            log.WriteEntry(message);
        }        

        #endregion

    }
}
