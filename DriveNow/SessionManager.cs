using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow
{
    public static class SessionManager
    {
        public static string LoggedInUserId { get; set; }
        public static string LoggedInUserEmail { get; set; }
        public static string LoggedInUserRole { get; set; }
        public static string LoggedInUserName { get; set; }
    }
}
