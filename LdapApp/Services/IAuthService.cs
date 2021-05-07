using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace LdapApp.Services
{
    public interface IAuthService
    {

        public bool AuthenticateUser(bool isSsl, string domain, string username, string password);

        public bool CreateUserAccount(bool isSsl, string domain, string username, string password, string[] commonNames, string givenName, string sn, string email);

        public bool ResetUserPassword(bool isSsl, string domain, string username, string newPassword);

        public bool EnableUserAccount(bool isSsl, string domain, string username);

        public bool DisableUserAccount(bool isSsl, string domain, string username);

        public bool LockUserAccount(bool isSsl, string domain, string username);

        public bool UnlockUserAccount(bool isSsl, string domain, string username);
    }
}
