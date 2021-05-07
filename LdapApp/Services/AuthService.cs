using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Novell.Directory.Ldap;

namespace LdapApp.Services
{
    public class AuthService : IAuthService
    {

        public bool AuthenticateUser(bool isSsl, string domain, string username, string password)
        {
            try
            {
                using var connection = new LdapConnection { SecureSocketLayer = isSsl };
                connection.Connect(Const.LDAP_SERVER_ADDRESS, int.Parse(isSsl ? Const.LDAP_SERVER_PORT_SSL : Const.LDAP_SERVER_PORT));
                if (string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return false;
                }
                connection.Bind(domain + "\\" + username, password);
                return connection.Bound;
            }
            catch (LdapException e)
            {
                Console.WriteLine("Ldap Error: " + e.ToString());
                return false;
            }
        }

        public bool CreateUserAccount(bool isSsl, string domain, string username, string password, string[] commonNames, string givenName = "default", string sn = "default", string email = "default")
        {
            try
            {
                using var connection = new LdapConnection { SecureSocketLayer = isSsl };
                connection.Connect(Const.LDAP_SERVER_ADDRESS, int.Parse(isSsl ? Const.LDAP_SERVER_PORT_SSL : Const.LDAP_SERVER_PORT));
                if (string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return false;
                }
                connection.Bind(domain + "\\" + username, password);
                if (connection.Bound)
                {
                    return false;   // username already exist
                }
                else
                {
                    LdapAttributeSet attributeSet = new();
                    attributeSet.Add(new LdapAttribute("objectclass", "user"));
                    attributeSet.Add(new LdapAttribute("sAMAccountName", username));
                    byte[] encodedBytes = Encoding.Unicode.GetBytes(password);
                    attributeSet.Add(new LdapAttribute("unicodePwd", encodedBytes));
                    attributeSet.Add(new LdapAttribute("userAccountControl", (512).ToString()));
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
                    LdapEntry newEntry = new(Const.BASE_DN, attributeSet);
                    connection.Add(newEntry);
                    return true;
                }
            }
            catch (LdapException e)
            {
                Console.WriteLine("Ldap Error: " + e.ToString());
                return false;
            }
        }

        public bool ResetUserPassword(bool isSsl, string domain, string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool DisableUserAccount(bool isSsl, string domain, string username)
        {
            throw new NotImplementedException();
        }

        public bool EnableUserAccount(bool isSsl, string domain, string username)
        {
            throw new NotImplementedException();
        }

        public bool LockUserAccount(bool isSsl, string domain, string username)
        {
            throw new NotImplementedException();
        }

        public bool UnlockUserAccount(bool isSsl, string domain, string username)
        {
            throw new NotImplementedException();
        }

    }
}
