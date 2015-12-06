using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAutomationFramework
{
    /*
    * This class consists of functions to check if the given date lies in between a given range of dates.
    */

    public class DateRangeChecker
    {
        public static bool IsDateInRange(string startDate, string endDate, string dateToCheck)
        {
            DateTime firstDate = Convert.ToDateTime(startDate);
            DateTime lastDate = Convert.ToDateTime(endDate);
            DateTime testDate;
            if (dateToCheck!=" ")
            {
                testDate = Convert.ToDateTime(dateToCheck);
                return (testDate.Ticks >= firstDate.Ticks && testDate.Ticks < lastDate.Ticks);
            }
            else
                return true;
        }
    }
}
