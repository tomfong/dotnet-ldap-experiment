using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdapApp
{
    public static class Const
    {
        public static readonly string LDAP_SERVER_ADDRESS = Environment.GetEnvironmentVariable("LDAP_SERVER_ADDRESS");
        public static readonly string LDAP_SERVER_PORT = Environment.GetEnvironmentVariable("LDAP_SERVER_PORT");
        public static readonly string LDAP_SERVER_PORT_SSL = Environment.GetEnvironmentVariable("LDAP_SERVER_PORT_SSL");
        public static readonly string BASE_DN = Environment.GetEnvironmentVariable("BASE_DN");

        public static readonly string LDAP_PATH = string.Format("ldap://{0}:{1}/{2}", LDAP_SERVER_ADDRESS, LDAP_SERVER_PORT, BASE_DN);
        public static readonly string LDAPS_PATH = string.Format("ldaps://{0}:{1}/{2}", LDAP_SERVER_ADDRESS, LDAP_SERVER_PORT_SSL, BASE_DN);
    }
}
