using Common.Enums;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class ExtentionClass
    {
        public static int GetStatusCode(this StatusCode value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(ServiceStatusAttribute), true);
            if (attribs.Length > 0)
            {
                return ((ServiceStatusAttribute)attribs[0]).StatusCode;
            }

            return 9999;
        }

        public static string GetStatusMessage(this StatusCode value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(ServiceStatusAttribute), true);
            if (attribs.Length > 0)
            {
                return ((ServiceStatusAttribute)attribs[0]).Message;
            }

            return value.ToString();
        }

        public static string GetStatusUserMessage(this StatusCode value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(ServiceStatusAttribute), true);
            if (attribs.Length > 0)
            {
                return ((ServiceStatusAttribute)attribs[0]).UserMessage;
            }

            return value.ToString();
        }
    }
}
