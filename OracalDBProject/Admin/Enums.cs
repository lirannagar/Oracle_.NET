using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public static class Enums
    {
        public enum ERole
        {
            [DescriptionAttribute("A100")]
            ADMIN_ROLE,
            [DescriptionAttribute("C100")]
            CLUB_MEMBER_ROLE


        }

        public static string GetDescription(Enum value)
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return value.ToString();
        }
    }
}
