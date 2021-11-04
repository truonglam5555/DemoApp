using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace DemoApp.Common.Utils
{
    public static class CommonMethods
    {
        public static string GetDescription<T>(this T enumerationValue)
           where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }

        public static bool IsPhoneNumber(string number)
        {

            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return false;
                }

                if (number[0] == '0' && number.Length > 10)
                {
                    return false;
                }

                if (number[0] == '8' && number.Length > 11)
                {
                    return false;
                }

                var r = new Regex(@"^((0[3|8|9|7|5])+([0-9]{8}))|((84[3|8|9|7|5])+([0-9]{8}))");

                return r.IsMatch(number);

            }
            catch
            {
                return false;
            }
        }
    }
}
