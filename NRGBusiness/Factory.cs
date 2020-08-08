using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace NRGBusiness
{
    public class Factory
    {
        private DBAction _dbaction = DBAction.save;
        public Factory(DBAction dbaction)
        {
            _dbaction = dbaction;
        }
        public object DataUtility<T>(Object dataobject) where T : class, new()
        {
            T obj = new T();

            string ProcedureName = string.Empty;
            string LoadName = "";
            string DeleteName = "";

            object[] attrs = dataobject.GetType().GetCustomAttributes(true);
            foreach (object c in attrs)
            {
                if (_dbaction == DBAction.insert)
                {
                    if (c is InsertProcedure ps)
                    {
                        ProcedureName = ps.Name;
                        break;
                    }
                }
                if (_dbaction == DBAction.save)
                {
                    if (c is SaveProcedure ps)
                    {
                        ProcedureName = ps.Name;
                        break;
                    }
                }
                if (_dbaction == DBAction.load)
                {
                    if (c is LoadProcedure pl)
                    {
                        ProcedureName = pl.Name;
                        LoadName = pl.LoadName;
                        break;
                    }
                }
                if (_dbaction == DBAction.delete)
                {
                    if (c is DeleteProcedure pl)
                    {
                        ProcedureName = pl.Name;
                        DeleteName = pl.DeleteName;
                        break;
                    }
                }
            }


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ProcedureName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter();

            foreach (var prop in obj.GetType().GetProperties())
            {
                object[] pattrs = prop.GetCustomAttributes(true);
                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);

                foreach (object attr in pattrs)
                {
                    if (_dbaction == DBAction.save)
                    {
                        if (attr is SaveAttribute c)
                        {
                            string name = c.PropertyName;
                            if (dataobject.GetType().GetProperty(name) != null)
                            {

                                object save_value = dataobject.GetType().GetProperty(name).GetValue(dataobject, null);
                                object type = dataobject.GetType().GetProperty(name).PropertyType.Name;
                                save_value = FormatValue(save_value, c.DBType, type);

                                p = new SqlParameter();
                                p.SqlDbType = c.DBType;
                                p.Value = save_value;
                                p.ParameterName = c.Parameter;
                                cmd.Parameters.Add(p);
                            }
                        }
                    }
                    if (_dbaction == DBAction.insert)
                    {
                        if (attr is InsertAttribute c)
                        {
                            string name = c.PropertyName;
                            if (dataobject.GetType().GetProperty(name) != null)
                            {

                                object save_value = dataobject.GetType().GetProperty(name).GetValue(dataobject, null);
                                save_value = FormatValue(save_value, c.DBType);

                                p = new SqlParameter();
                                p.SqlDbType = c.DBType;
                                p.Value = save_value;
                                p.ParameterName = c.Parameter;
                                cmd.Parameters.Add(p);
                            }
                        }
                    }
                    if (_dbaction == DBAction.load)
                    {
                        if (attr is LoadAttribute c)
                        {
                            if (c.LoadName == LoadName)
                            {
                                string name = c.PropertyName;
                                object load_value = dataobject.GetType().GetProperty(name).GetValue(dataobject, null);
                                load_value = FormatValue(load_value, c.DBType);

                                p = new SqlParameter();
                                p.SqlDbType = c.DBType;
                                p.Value = load_value;
                                p.ParameterName = c.Parameter;
                                if (!string.IsNullOrEmpty(c.typeName))
                                {
                                    p.TypeName = c.typeName;
                                }
                                cmd.Parameters.Add(p);
                            }

                        }
                    }

                    if (_dbaction == DBAction.delete)
                    {
                        if (attr is DeleteAttribute c)
                        {
                            if (c.DeleteName == DeleteName)
                            {

                                string name = c.PropertyName;
                                object delete_value = dataobject.GetType().GetProperty(name).GetValue(dataobject, null);
                                delete_value = FormatValue(delete_value, c.DBType);

                                p = new SqlParameter();
                                p.SqlDbType = c.DBType;
                                p.Value = delete_value;
                                p.ParameterName = c.Parameter;
                                cmd.Parameters.Add(p);
                            }
                        }
                    }
                }
            }

            using (SqlConnection con = ConnectionInfo.Connection)
            {
                con.Open();
                cmd.Connection = con;

                if (_dbaction == DBAction.save || _dbaction == DBAction.insert || _dbaction == DBAction.delete)
                {
                    object r = cmd.ExecuteScalar();
                    con.Close();
                    if (r != null)
                    {
                        return r;
                    }
                    else
                    {
                        return 0;
                    }
                }
                if (_dbaction == DBAction.load)
                {
                    DataTable oDataTable = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(oDataTable);
                    }
                    con.Close();
                    return oDataTable.ToList<T>();
                }
            }

            return 0;

        }

        private object FormatValue(object value, SqlDbType s, object type = null)
        {
            if (type != null)
            {
                if (Utility.ConvString(type).ToLower() == "boolean")
                {
                    if (s == SqlDbType.VarChar)
                    {
                        return Utility.ConvYN(value);
                    }
                }
            }
            if (s == SqlDbType.VarChar)
            {
                if (value == null)
                {
                    return string.Empty;
                }
                return value.ToString();
            }
            if (s == SqlDbType.Binary)
            {
                if (value == null)
                {
                    return null;
                }

                return Utility.ConvByte(value);
            }

            if (s == SqlDbType.Int)
            {
                if (value == null)
                {
                    return 0;
                }

                int i = 0;
                if (int.TryParse(value.ToString(), out i))
                {
                    return int.Parse(value.ToString());
                }
                return 0;
            }
            if (s == SqlDbType.Decimal)
            {
                if (value == null)
                {
                    return 0;
                }

                decimal i = 0;
                if (decimal.TryParse(value.ToString(), out i))
                {
                    return decimal.Parse(value.ToString());
                }
                return 0;
            }

            return value;
        }
    }
}
