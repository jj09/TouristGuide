using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Security;
using System.Collections.Generic;
using TouristGuide.Providers.Database;

namespace TouristGuide.Providers
{

  public sealed class TGMembershipProvider : MembershipProvider
  {
      IDataProvider Data = new SqlProvider();

    #region Class Variables

    private int newPasswordLength = 8;
    private string connectionString;
    private string applicationName;
    private bool enablePasswordReset;
    private bool enablePasswordRetrieval;
    private bool requiresQuestionAndAnswer;
    private bool requiresUniqueEmail;
    private int maxInvalidPasswordAttempts;
    private int passwordAttemptWindow;
    private MembershipPasswordFormat passwordFormat;
    private int minRequiredNonAlphanumericCharacters;
    private int minRequiredPasswordLength;
    private string passwordStrengthRegularExpression;
    private MachineKeySection machineKey; //Used when determining encryption key values.

    #endregion

    #region Enums

    private enum FailureType
    {
      Password = 1,
      PasswordAnswer = 2
    }

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

    public override bool EnablePasswordReset
    {
      get
      {
        return enablePasswordReset;
      }
    }

    public override bool EnablePasswordRetrieval
    {
      get
      {
        return enablePasswordRetrieval;
      }
    }

    public override bool RequiresQuestionAndAnswer
    {
      get
      {
        return requiresQuestionAndAnswer;
      }
    }

    public override bool RequiresUniqueEmail
    {
      get
      {
        return requiresUniqueEmail;
      }
    }

    public override int MaxInvalidPasswordAttempts
    {
      get
      {
        return maxInvalidPasswordAttempts;
      }
    }

    public override int PasswordAttemptWindow
    {
      get
      {
        return passwordAttemptWindow;
      }
    }

    public override MembershipPasswordFormat PasswordFormat
    {
      get
      {
        return passwordFormat;
      }
    }

    public override int MinRequiredNonAlphanumericCharacters
    {
      get
      {
        return minRequiredNonAlphanumericCharacters;
      }
    }

    public override int MinRequiredPasswordLength
    {
      get
      {
        return minRequiredPasswordLength;
      }
    }

    public override string PasswordStrengthRegularExpression
    {
      get
      {
        return passwordStrengthRegularExpression;
      }
    }

    #endregion

    #region Initialization

    public override void Initialize(string name, NameValueCollection config)
    {
      if (config == null)
      {
        throw new ArgumentNullException("config");
      }

      if (name == null || name.Length == 0)
      {
        name = "DomodiMembershipProvider";
      }

      if (String.IsNullOrEmpty(config["description"]))
      {
        config.Remove("description");
        config.Add("description", "Membership provider");
      }

      //Initialize the abstract base class.
      base.Initialize(name, config);

      applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
      maxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
      passwordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
      minRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredAlphaNumericCharacters"], "1"));
      minRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
      passwordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], String.Empty));
      enablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
      enablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
      requiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
      requiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "false"));

      string temp_format = config["passwordFormat"];
      if (temp_format == null)
      {
        temp_format = "Hashed";
      }

      switch (temp_format)
      {
        case "Hashed":
          passwordFormat = MembershipPasswordFormat.Hashed;
          break;
        case "Encrypted":
          passwordFormat = MembershipPasswordFormat.Encrypted;
          break;
        case "Clear":
          passwordFormat = MembershipPasswordFormat.Clear;
          break;
        default:
          throw new ProviderException("Password format not supported.");
      }

      ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

      if ((ConnectionStringSettings == null) || (ConnectionStringSettings.ConnectionString.Trim() == String.Empty))
      {
        throw new ProviderException("Connection string cannot be blank.");
      }

      connectionString = ConnectionStringSettings.ConnectionString;

      //Get encryption and decryption key information from the configuration.
      System.Configuration.Configuration cfg = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
      machineKey = cfg.GetSection("system.web/machineKey") as MachineKeySection;

      if (machineKey.ValidationKey.Contains("AutoGenerate"))
      {
        if (PasswordFormat != MembershipPasswordFormat.Clear)
        {
          throw new ProviderException("Hashed or Encrypted passwords are not supported with auto-generated keys.");
        }
      }
    }

    private string GetConfigValue(string configValue, string defaultValue)
    {
      if (String.IsNullOrEmpty(configValue))
      {
        return defaultValue;
      }

      return configValue;
    }

    #endregion

    #region Implemented Abstract Methods from MembershipProvider

    /// <summary>
    /// Change the user password.
    /// </summary>
    /// <param name="username">UserName</param>
    /// <param name="oldPwd">Old password.</param>
    /// <param name="newPwd">New password.</param>
    /// <returns>T/F if password was changed.</returns>
    public override bool ChangePassword(string username, string oldPwd, string newPwd)
    {
      if (!ValidateUser(username, oldPwd))
      {
        return false;
      }

      ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, newPwd, true);

      OnValidatingPassword(args);

      if (args.Cancel)
      {
        if (args.FailureInformation != null)
        {
          throw args.FailureInformation;
        }
        else
        {
          throw new Exception("Change password canceled due to new password validation failure.");
        }
      }

      Data.ChangePassword(username, EncodePassword(newPwd));
      return true;

    }

    /// <summary>
    /// Change the question and answer for a password validation.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <param name="password">Password.</param>
    /// <param name="newPwdQuestion">New question text.</param>
    /// <param name="newPwdAnswer">New answer text.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public override bool ChangePasswordQuestionAndAnswer(string username, string password, 
                                                string newPwdQuestion, string newPwdAnswer)
    {
      if (!ValidateUser(username, password))
      {
        return false;
      }

      Data.ChangePasswordQuestionAnswer(username, newPwdQuestion, EncodePassword(newPwdAnswer));
      return true;
    }
    /// <summary>
    /// Create a new user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <param name="password">Password.</param>
    /// <param name="email">Email address.</param>
    /// <param name="passwordQuestion">Security quesiton for password.</param>
    /// <param name="passwordAnswer">Security quesiton answer for password.</param>
    /// <param name="isApproved"></param>
    /// <param name="userID">User ID</param>
    /// <param name="status"></param>
    /// <returns>MembershipUser</returns>
    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, 
        string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
      ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);

      OnValidatingPassword(args);

      if (args.Cancel)
      {
        status = MembershipCreateStatus.InvalidPassword;
        return null;
      }

      if ((RequiresUniqueEmail && (Data.GetUserByEmail(email) != null)))
      {
        status = MembershipCreateStatus.DuplicateEmail;
        return null;
      }

      MembershipUser membershipUser = GetUser(username, false);

      if (membershipUser == null)
      {
        System.DateTime createDate = DateTime.Now;
        Users u = new Users();
        u.Login = username;
        u.Password = EncodePassword(password);
        u.Email = email;
        u.PasswordQuestion = passwordQuestion == null ? String.Empty : passwordQuestion;
        u.PasswordAnswer = passwordQuestion == null ? String.Empty : EncodePassword(passwordAnswer);
        u.IsApproved = isApproved;

        Data.CreateUser(u);
        status = MembershipCreateStatus.Success;

        return this.GetMembershipUser(Data.GetUserByLogin(username));
      }
      else
      {
        status = MembershipCreateStatus.DuplicateUserName;
      }

      return null;
    }

    /// <summary>
    /// Delete a user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <param name="deleteAllRelatedData">Whether to delete all related data.</param>
    /// <returns>T/F if the user was deleted.</returns>
    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        Data.DeleteUser(username, deleteAllRelatedData);
        return true;
    }
    
    /// <summary>
    /// Get a collection of users.
    /// </summary>
    /// <param name="pageIndex">Page index.</param>
    /// <param name="pageSize">Page size.</param>
    /// <param name="totalRecords">Total # of records to retrieve.</param>
    /// <returns>Collection of MembershipUser objects.</returns>
    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        //add paging to take pageSize number of users skiping pageIndex
        List<Users> us = Data.GetUsers();
        totalRecords = us.Count;
        MembershipUserCollection users = new MembershipUserCollection();

        foreach (var u in us)
            users.Add(this.GetMembershipUser(u));

        return users;
    }
    
    /// <summary>
    /// Gets the number of users currently on-line.
    /// </summary>
    /// <returns>  /// # of users on-line.</returns>
    public override int GetNumberOfUsersOnline()
    {
        return Data.GetNumberOnlineUsers();
    }

    /// <summary>
    /// Get the password for a user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <param name="answer">Answer to security question.</param>
    /// <returns>Password for the user.</returns>
    public override string GetPassword(string username, string answer)
    {
      if (!EnablePasswordRetrieval)
      {
        throw new ProviderException("Password Retrieval Not Enabled.");
      }

      if (PasswordFormat == MembershipPasswordFormat.Hashed)
      {
        throw new ProviderException("Cannot retrieve Hashed passwords.");
      }

      Users u = Data.GetUserByLogin(username);

      if(u==null)
      {
          throw new MembershipPasswordException("The supplied user name is not found.");
      }
      else if (u.IsLockedOut.HasValue && u.IsLockedOut.Value)
      {
          throw new MembershipPasswordException("The supplied user is locked out.");
      }

      if (RequiresQuestionAndAnswer && !CheckPassword(answer, u.PasswordAnswer))
      {
          Data.UpdateFailedPassword(username, (int)FailureType.PasswordAnswer, passwordAttemptWindow, maxInvalidPasswordAttempts);
          throw new MembershipPasswordException("Incorrect password answer.");
      }

      string password = u.Password;
      if (PasswordFormat == MembershipPasswordFormat.Encrypted)
      {
          password = UnEncodePassword(password);
      } 

      return password;
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
        Users u = Data.GetUserByLogin(username);

        if (u == null)
            return null;

        if (userIsOnline)
        {
            u.LastActivityDate = DateTime.Now;
            Data.SubmitChanges();
        }

        return GetMembershipUser(u);
    }

    /// <summary>
    /// Get a user based upon provider key and if they are on-line.
    /// </summary>
    /// <param name="userID">Provider key.</param>
    /// <param name="userIsOnline">T/F whether the user is on-line.</param>
    /// <returns></returns>
    public override MembershipUser GetUser(object userID, bool userIsOnline)
    {
        Users u = Data.GetUserByUserId((int)userID);

        if (userIsOnline)
        {
            u.LastActivityDate = DateTime.Now;
            Data.SubmitChanges();
        }

        return GetMembershipUser(u);
    }

    public override String GetUserNameByEmail(string emial)
    {
        Users u = Data.GetUserByEmail(emial);
        return u.Login;
    }

    /// <summary>
    /// Unlock a user.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <returns>T/F if unlocked.</returns>
    public override bool UnlockUser(string username)
    {
        Data.UnlockUser(username);
        return true;
    }

    /// <summary>
    /// Reset the user password.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <param name="answer">Answer to security question.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public override string ResetPassword(string username, string answer)
    {
      if (!EnablePasswordReset)
      {
        throw new NotSupportedException("Password Reset is not enabled.");
      }

      if ((answer == null) && (RequiresQuestionAndAnswer))
      {
          Data.UpdateFailedPassword(username, (int)FailureType.PasswordAnswer, passwordAttemptWindow, maxInvalidPasswordAttempts);

        throw new ProviderException("Password answer required for password Reset.");
      }

      string newPassword =
        System.Web.Security.Membership.GeneratePassword(
        newPasswordLength,
        MinRequiredNonAlphanumericCharacters
        );

      ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, newPassword, true);

      OnValidatingPassword(args);

      if (args.Cancel)
      {
        if (args.FailureInformation != null)
        {
          throw args.FailureInformation;
        }
        else
        {
          throw new MembershipPasswordException("Reset password canceled due to password validation failure.");
        }
      }

      Users u = Data.GetUserByLogin(username);
        
      if(u==null)
      {
          throw new MembershipPasswordException("The supplied user name is not found.");
      }
      else if(RequiresQuestionAndAnswer && (!CheckPassword(answer, u.PasswordAnswer)))
      {
          Data.UpdateFailedPassword(username, (int)FailureType.PasswordAnswer, passwordAttemptWindow, maxInvalidPasswordAttempts);
          throw new MembershipPasswordException("Incorrect password answer.");
      }

      u.Password = EncodePassword(newPassword);
      Data.SubmitChanges();
      return u.Password;      
    }

    /// <summary>
    /// Update the user information.
    /// </summary>
    /// <param name="_membershipUser">MembershipUser object containing data.</param>
    public override void UpdateUser(MembershipUser membershipUser)
    {
        Data.SubmitChanges();
    }

    /// <summary>
    /// Validate the user based upon username and password.
    /// </summary>
    /// <param name="username">User name.</param>
    /// <param name="password">Password.</param>
    /// <returns>T/F if the user is valid.</returns>
    public override bool ValidateUser(string username, string password)
    {
        bool isValid = false;
        Users u = Data.GetUserByLogin(username);

        if (u == null)
        {
            u = Data.GetUserByEmail(username);
        }

        if (u!=null && CheckPassword(password, u.Password))
        {
            if (u.IsApproved.HasValue && u.IsApproved.Value)
            {
                isValid = true;
                u.LastLoginDate = DateTime.Now;
                Data.SubmitChanges();
            }
        }
        else
        {
          Data.UpdateFailedPassword(username, (int)FailureType.Password, passwordAttemptWindow, maxInvalidPasswordAttempts);
        }

        return isValid;
    }
    /// <summary>
    /// Find all users matching a search string.
    /// </summary>
    /// <param name="usernameToMatch">Search string of user name to match.</param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="totalRecords">Total records found.</param>
    /// <returns>Collection of MembershipUser objects.</returns>

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        //add paging to take pageSize number of users skiping pageIndex
        List<Users> us = Data.FindUsersbyEmail(usernameToMatch);
        totalRecords = us.Count;
        MembershipUserCollection users = new MembershipUserCollection();

        foreach (var u in us)
            users.Add(this.GetMembershipUser(u));

        return users;
    }

    /// <summary>
    /// Find all users matching a search string of their email.
    /// </summary>
    /// <param name="emailToMatch">Search string of email to match.</param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="totalRecords">Total records found.</param>
    /// <returns>Collection of MembershipUser objects.</returns>

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        //add paging to take pageSize number of users skiping pageIndex
        List<Users> us = Data.FindUsersbyEmail(emailToMatch);
        totalRecords = us.Count;
        MembershipUserCollection users = new MembershipUserCollection();

        foreach (var u in us)
            users.Add(this.GetMembershipUser(u));

        return users;
    }

    #endregion

    #region "Utility Functions"

    private MembershipUser GetMembershipUser(Users u)
    {
        if (u == null)
            return null;

        MembershipUser membershipUser = new MembershipUser(
               this.Name,
               u.Login,
               u.UserId,
               u.Email,
               u.PasswordQuestion,
               u.Comment,
               u.IsApproved.HasValue ? u.IsApproved.Value : true,
               u.IsLockedOut.HasValue ? u.IsLockedOut.Value : false,
               u.CreationDate.HasValue ? u.CreationDate.Value : DateTime.Now,
               u.LastLoginDate.HasValue ? u.LastLoginDate.Value : DateTime.Now,
               u.LastActivityDate.HasValue ? u.LastActivityDate.Value : DateTime.Now,
               u.LastPasswordChangedDate.HasValue ? u.LastPasswordChangedDate.Value : DateTime.Now,
               u.LastLockedOutDate.HasValue ? u.LastLockedOutDate.Value : DateTime.Now
            );

        return membershipUser;
    }

    /// <summary>
    /// Converts a hexadecimal string to a byte array. Used to convert encryption key values from the configuration
    /// </summary>
    /// <param name="hexString"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    private byte[] HexToByte(string hexString)
    {
      byte[] returnBytes = new byte[hexString.Length / 2];
      for (int i = 0; i < returnBytes.Length; i++)
        returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
      return returnBytes;
    }

    /// <summary>
    /// Check the password format based upon the MembershipPasswordFormat.
    /// </summary>
    /// <param name="password">Password</param>
    /// <param name="dbpassword"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    private bool CheckPassword(string password, string dbpassword)
    {
      string pass1 = password;
      string pass2 = dbpassword;

      switch (PasswordFormat)
      {
        case MembershipPasswordFormat.Encrypted:
          pass2 = UnEncodePassword(dbpassword);
          break;
        case MembershipPasswordFormat.Hashed:
          pass1 = EncodePassword(password);
          break;
        default:
          break;
      }

      if (pass1 == pass2)
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Encode password.
    /// </summary>
    /// <param name="password">Password.</param>
    /// <returns>Encoded password.</returns>
    private string EncodePassword(string password)
    {
      string encodedPassword = password;

      switch (PasswordFormat)
      {
        case MembershipPasswordFormat.Clear:
          break;
        case MembershipPasswordFormat.Encrypted:
          encodedPassword =
            Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
          break;
        case MembershipPasswordFormat.Hashed:
          HMACSHA1 hash = new HMACSHA1();
          hash.Key = HexToByte(machineKey.ValidationKey);
          encodedPassword =
            Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
          break;
        default:
          throw new ProviderException("Unsupported password format.");
      }

      return encodedPassword;
    }

    /// <summary>
    /// UnEncode password.
    /// </summary>
    /// <param name="encodedPassword">Password.</param>
    /// <returns>Unencoded password.</returns>
    private string UnEncodePassword(string encodedPassword)
    {
      string password = encodedPassword;

      switch (PasswordFormat)
      {
        case MembershipPasswordFormat.Clear:
          break;
        case MembershipPasswordFormat.Encrypted:
          password =
            Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
          break;
        case MembershipPasswordFormat.Hashed:
          throw new ProviderException("Cannot unencode a hashed password.");
        default:
          throw new ProviderException("Unsupported password format.");
      }

      return password;
    }

    #endregion

  }
}