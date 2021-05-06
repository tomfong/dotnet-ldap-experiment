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

        public bool AuthenticateUser(string username, string password);

        public bool CreateUserAccount(string username, string password, string[] commonNames, string givenName,string sn, string email);

        public bool ResetUserPassword(string username, string newPassword);

        public bool EnableUserAccount(string username);

        public bool DisableUserAccount(string username);

        public bool LockUserAccount(string username);

        public bool UnlockUserAccount(string username);
    }
}
