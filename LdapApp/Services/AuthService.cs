using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Novell.Directory.Ldap;

namespace LdapApp.Services
{
    public class AuthService : IAuthService
    {

        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                using var connection = new LdapConnection { SecureSocketLayer = false };
                connection.Connect(Const.LDAP_SERVER_ADDRESS, int.Parse(Const.LDAP_SERVER_PORT));
                var searchResults = connection.Search(
                    "DC=TEST,DC=COM", 
                    LdapConnection.ScopeSub, 
                    string.Format("(mail={0}@somemail.com)", username),
                    null,
                    false
                );
                if (searchResults.HasMore())
                {
                    connection.Bind(username, password);
                    return connection.Bound;
                } else
                {
                    return false;
                }
               
            }
            catch
            {
                return false;
            }
        }

        public bool CreateUserAccount(string username, string password, string[] commonNames, string givenName = "default", string sn = "default", string email = "default")
        {
            try
            {
                using var connection = new LdapConnection { SecureSocketLayer = false };
                connection.Connect(Const.LDAP_SERVER_ADDRESS, int.Parse(Const.LDAP_SERVER_PORT));
                connection.Bind(username, password);
                if (connection.Bound)
                {
                    return false;
                }
                else
                {
                    LdapAttributeSet attributeSet = new();
                    attributeSet.Add(new LdapAttribute("objectclass", "inetOrgPerson"));
                    attributeSet.Add(new LdapAttribute("cn", commonNames));

                    if (givenName != "default")
                    {
                        attributeSet.Add(new LdapAttribute("givenname", givenName));
                    }
                    if (sn != "default")
                    {
                        attributeSet.Add(new LdapAttribute("sn", sn));
                    }
                    if (email != "default")
                    {
                        attributeSet.Add(new LdapAttribute("mail", email));
                    }

                    // DN of the entry to be added
                    string distinguishedName = "cn=KSmith,";
                    LdapEntry newEntry = new(distinguishedName, attributeSet);
                    connection.Add(newEntry);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ResetUserPassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool DisableUserAccount(string username)
        {
            throw new NotImplementedException();
        }

        public bool EnableUserAccount(string username)
        {
            throw new NotImplementedException();
        }

        public bool LockUserAccount(string username)
        {
            throw new NotImplementedException();
        }

        public bool UnlockUserAccount(string username)
        {
            throw new NotImplementedException();
        }

        private bool IsUserExist(string username)
        {
            return false;
        }

    }
}
