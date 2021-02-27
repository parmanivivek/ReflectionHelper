using System.Reflection;

namespace ReflectionUtility
{
    public class ReflectionHelper
    {
        public static object GetPropertyValue(object src, string propName)
        {
            if (src == null) return null;
            if (propName == null) return null;

            if (propName.Contains("."))//complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperty(propName);
                return prop != null ? prop.GetValue(src, null) : null;
            }
        }

        public static PropertyInfo GetPropertyInfo(object src, string propName)
        {
            if (src == null) return null;
            if (propName == null) return null;

            if (propName.Contains("."))//complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyInfo(GetPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperty(propName);
                return prop;
            }
        }
    }
}
