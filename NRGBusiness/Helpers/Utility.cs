using System;
using System.IO;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace NRGBusiness
{
    public class Utility
    {
        #region conversion



        public static string ConvString(object o)
        {

            if (o == null)
            {
                return string.Empty;
            }

            return o.ToString();
        }

        public static int ConvInt(object o)
        {

            if (o == null)
            {
                return 0;
            }

            o = CleanNonNumeric(o);
            decimal g = 0;

            if (decimal.TryParse(o.ToString(), out g))
            {
                return decimal.ToInt32(decimal.Parse(o.ToString()));
            }
            return 0;
        }
        public static double ConvDouble(object o)
        {
            if (o == null)
            {
                return 0;
            }

            o = CleanNonNumeric(o);
            double g = 0;

            if (double.TryParse(o.ToString(), out g))
            {
                return double.Parse(o.ToString());
            }
            return 0;
        }
        public static decimal ConvDecimal(object o)
        {
            if (o == null)
            {
                return 0;
            }

            o = CleanNonNumeric(o);
            decimal g = 0;

            if (decimal.TryParse(o.ToString(), out g))
            {
                return decimal.Parse(o.ToString());
            }
            return 0;
        }

        public static DateTime? ConvDateTime(object o)
        {
            DateTime? d = new DateTime();
            if (o == null)
            {
                return DateTime.Now;
            }
            if (Utility.IsDate(o))
            {
                d = DateTime.Parse(o.ToString());
            }
            return d;
        }

        public static Byte[] ConvByte(object o)
        {
            if (o == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, o);
                return ms.ToArray();
            }
        }
        public static DateTime? ConvDateTimeNulll(object o)
        {
            DateTime? d = new DateTime();
            if (o == null)
            {
                return d;
            }
            if (Utility.IsDate(o))
            {
                d = DateTime.Parse(o.ToString());
            }
            return d;
        }

        public static bool ConvBool(object o)
        {

            if (o == null)
            {
                return false;
            }

            string s = o.ToString();
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            switch (s.ToLower())
            {
                case "y":
                    return true;
                case "1":
                    return true;
                case "yes":
                    return true;
                case "true":
                    return true;
                case "on":
                    return true;
            }
            return false;
        }

        public static string ConvYN(object o)
        {

            if (o == null)
            {
                return "N";
            }

            string s = o.ToString();
            if (string.IsNullOrEmpty(s))
            {
                return "N";
            }
            switch (s.ToLower())
            {
                case "y":
                    return "Y";
                case "t":
                    return "Y";
                case "1":
                    return "Y";
                case "yes":
                    return "Y";
                case "true":
                    return "Y";
                case "on":
                    return "Y";
            }

            return "N";

        }

        public static object CleanNonNumeric(object o)
        {
            if (o == null)
            {
                return o;
            }
            return Regex.Replace(o.ToString(), "[^0-9.]", "");
        }

        public static string CleanAlphaNumeric(object o)
        {
            if (o == null)
            {
                return string.Empty;
            }
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(o.ToString(), "");
        }



        #endregion

        public static bool IsValidZip(object zipcode)
        {
            string _zipcode = ConvString(CleanNonNumeric(zipcode));
            if (_zipcode.Length == 9)
            {
                return true;
            }
            if (_zipcode.Length == 5)
            {
                return true;
            }

            return false;

        }

        public static bool IsValidEmail(string EmailAddress)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(EmailAddress);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool IsValidSSN(object SSN)
        {
            string _SSN = ConvString(SSN);
            if (_SSN.Length == 9)
            {
                return true;
            }

            return false;

        }
        public static bool IsDate(object o)
        {
            if (o == null)
            {
                return false;
            }
            DateTime dt = new DateTime();
            if (DateTime.TryParse(o.ToString(), out dt))
            {
                return true;
            }
            return false;
        }

    }
}
