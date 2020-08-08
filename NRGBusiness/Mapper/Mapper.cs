using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;


namespace NRGBusiness
{
    public static class ClassMapper
    {

        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {

            List<T> list = new List<T>();

            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();

                foreach (var prop in obj.GetType().GetProperties())
                {

                    //Set the column name to be the name of the property
                    string ColumnName = string.Empty;

                    //Get a list of all of the attributes on the property
                    object[] attrs = prop.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        //Check if there is a custom property name
                        if (attr is ColMapping colName)
                        {
                            //If the custom column name is specified overwrite property name
                            if (!string.IsNullOrWhiteSpace(colName.Name))
                            {
                                if (table.Columns.Contains(colName.Name.ToLower()))
                                {
                                    ColumnName = colName.Name;
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(ColumnName))
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);

                        if (propertyInfo.PropertyType.IsEnum)
                        {
                            if (propertyInfo.CanWrite)
                            {
                                Type enumType = (propertyInfo.PropertyType);
                                string s = row[ColumnName].ToString();
                                object v = Enum.Parse(enumType, s);
                                propertyInfo.SetValue(obj, v, null);
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(bool) || propertyInfo.PropertyType == typeof(Boolean))
                        {
                            if (propertyInfo.CanWrite)
                            {
                                string s = row[ColumnName].ToString();
                                object v = Utility.ConvBool(s);
                                propertyInfo.SetValue(obj, v, null);
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(Int32?) || propertyInfo.PropertyType == typeof(int))
                        {
                            if (propertyInfo.CanWrite)
                            {
                                string s = row[ColumnName].ToString();
                                object v = Utility.ConvInt(s);

                                propertyInfo.SetValue(obj, v, null);
                                propertyInfo.SetValue(obj, v, null);
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime))
                        {
                            if (propertyInfo.CanWrite)
                            {
                                string s = row[ColumnName].ToString();
                                if (!string.IsNullOrEmpty(s))
                                {
                                    if (Utility.IsDate(s))
                                    {
                                        propertyInfo.SetValue(obj, Utility.ConvDateTime(s), null);
                                    }
                                }

                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime?))
                        {
                            if (propertyInfo.CanWrite)
                            {
                                string s = row[ColumnName].ToString();
                                if (!string.IsNullOrEmpty(s))
                                {
                                    if (Utility.IsDate(s))
                                    {
                                        propertyInfo.SetValue(obj, Utility.ConvDateTimeNulll(s), null);
                                    }
                                }
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(Byte) || propertyInfo.PropertyType == typeof(byte))
                        {
                            if (propertyInfo.CanWrite)
                            {
                                object s = row[ColumnName];
                                propertyInfo.SetValue(obj, s, null);
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(Byte[]) || propertyInfo.PropertyType == typeof(byte[]))
                        {
                            if (propertyInfo.CanWrite)
                            {
                                object s = row[ColumnName];
                                propertyInfo.SetValue(obj, s, null);
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(String) || propertyInfo.PropertyType == typeof(string))
                        {
                            if (propertyInfo.CanWrite)
                            {
                                object s = row[ColumnName];
                                propertyInfo.SetValue(obj, Utility.ConvString(s), null);
                            }
                        }
                        else
                        {
                            //GET THE COLUMN NAME OFF THE ATTRIBUTE OR THE NAME OF THE PROPERTY
                            if (propertyInfo.CanWrite)
                            {
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[ColumnName], propertyInfo.PropertyType), null);
                            }
                        }
                    }

                }

                list.Add(obj);
            }

            return list;

        }


    }

    public static class Enum<EnumType> where EnumType : struct, IConvertible
    {

        /// <summary>
        /// Retrieves an array of the values of the constants in a specified enumeration.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static EnumType[] GetValues()
        {
            return (EnumType[])Enum.GetValues(typeof(EnumType));
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static EnumType Parse(string name)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), name);
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static EnumType Parse(string name, bool ignoreCase)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), name, ignoreCase);
        }

        /// <summary>
        /// Converts the specified object with an integer value to an enumeration member.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static EnumType ToObject(object value)
        {
            return (EnumType)Enum.ToObject(typeof(EnumType), value);
        }
    }
}
