using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLP_RKP_LR2.Models.Utils
{
    public enum ROLES
    {
        PUBLIC,
        EMPLOYEE,
        ADMIN
    }
    public class User
    {
        // TODO: логин с учетом данных в файле
        public static Dictionary<string, ROLES> HumanToTypeDict = new Dictionary<string, ROLES>()
        {
            { "PUB", ROLES.PUBLIC },
            { "EMP", ROLES.EMPLOYEE },
            { "ADM", ROLES.ADMIN }
        };

        public static ROLES Role { get; set; } = ROLES.PUBLIC;
        public static string Username { get; set; } = "Guest";

        public static void Login(string username, ROLES role)
        {
            Role = role;
            Username = username;
        }

        public static bool IsAbleToMakeAction(string action, ROLES minimumRole)
        {
            bool res = true;
            if (minimumRole == ROLES.EMPLOYEE && Role == ROLES.PUBLIC)
            {
                res = false;
            }
            if (minimumRole == ROLES.ADMIN && Role != ROLES.ADMIN)
            {
                res = false;
            }
            if (!res)
            {
                MessageBox.Show("Отказано в доступе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.RestrictedAccess(action);
            }
            return res;
        }
    }
}
