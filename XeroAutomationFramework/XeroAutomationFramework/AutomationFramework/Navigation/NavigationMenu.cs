using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    public class NavigationMenu
    {
        public class Payroll
        {
            public class Employees
            {
                public static void Select()
                {
                    MenuSelector.Select("Payroll", "Employees");
                }
            }
        }

        public class Accounts
        {
            public class Sales
            {
                public static void Select()
                {
                    MenuSelector.Select("Accounts", "Sales");
                }
            }
        }
    }
}
