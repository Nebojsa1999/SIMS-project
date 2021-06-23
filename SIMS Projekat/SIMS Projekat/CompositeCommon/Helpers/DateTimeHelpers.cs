using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat.CompositeCommon.Helpers
{
    public class DateTimeHelpercs
    {
        public static bool DateToString(DateTime date, out string result)
        {
            result = string.Empty;

            try
            {
                result = date.ToString("dd.MM.yyyy");
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool StringToDate(string date, out DateTime result)
        {
            result = new DateTime();

            try
            {
                result = DateTime.ParseExact(date, "dd.MM.yyyy", null);
                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
