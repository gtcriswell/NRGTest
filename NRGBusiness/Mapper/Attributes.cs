using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace NRGBusiness
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class SaveAttribute : Attribute
    {
        private string _propertyName = "";
        private string _parameter = "";
        private SqlDbType _dbtype = SqlDbType.VarChar;
        public string Parameter { get => _parameter; set => _parameter = value; }
        public SqlDbType DBType { get => _dbtype; set => _dbtype = value; }
        public string PropertyName { get => _propertyName; set => _propertyName = value; }

        public SaveAttribute(string parameter, SqlDbType dbtype, [CallerMemberName] string propertyName = null)
        {
            _parameter = parameter;
            _dbtype = dbtype;
            _propertyName = propertyName;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class InsertAttribute : Attribute
    {
        private string _propertyName = "";
        private string _parameter = "";
        private SqlDbType _dbtype = SqlDbType.VarChar;
        public string Parameter { get => _parameter; set => _parameter = value; }
        public SqlDbType DBType { get => _dbtype; set => _dbtype = value; }
        public string PropertyName { get => _propertyName; set => _propertyName = value; }

        public InsertAttribute(string parameter, SqlDbType dbtype, [CallerMemberName] string propertyName = null)
        {
            _parameter = parameter;
            _dbtype = dbtype;
            _propertyName = propertyName;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class LoadAttribute : Attribute
    {
        private string _propertyName = "";
        private string _parameter = "";
        private SqlDbType _dbtype = SqlDbType.VarChar;
        private string _typeName = string.Empty;
        private string _loadname = "";

        public string Parameter { get => _parameter; set => _parameter = value; }
        public SqlDbType DBType { get => _dbtype; set => _dbtype = value; }
        public string typeName { get => _typeName; set => _typeName = value; }
        public string LoadName { get => _loadname; set => _loadname = value; }
        public string PropertyName { get => _propertyName; set => _propertyName = value; }

        public LoadAttribute(string parameter, SqlDbType dbtype, [CallerMemberName] string propertyName = null)
        {
            _parameter = parameter;
            _dbtype = dbtype;
            _propertyName = propertyName;
        }
        public LoadAttribute(string parameter, SqlDbType dbtype, string typename, [CallerMemberName] string propertyName = null)
        {
            _parameter = parameter;
            _dbtype = dbtype;
            _typeName = typename;
            _propertyName = propertyName;
        }
        public LoadAttribute(string parameter, SqlDbType dbtype, string typename, string loadname, [CallerMemberName] string propertyName = null)
        {
            _parameter = parameter;
            _dbtype = dbtype;
            _typeName = typename;
            _loadname = loadname;
            _propertyName = propertyName;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class DeleteAttribute : Attribute
    {
        private string _propertyName = "";
        private string _parameter = "";
        private SqlDbType _dbtype = SqlDbType.VarChar;
        private string _deletename = "";

        public string Parameter { get => _parameter; set => _parameter = value; }
        public SqlDbType DBType { get => _dbtype; set => _dbtype = value; }
        public string DeleteName { get => _deletename; set => _deletename = value; }
        public string PropertyName { get => _propertyName; set => _propertyName = value; }
        public DeleteAttribute(string parameter, SqlDbType dbtype, [CallerMemberName] string propertyName = null)
        {
            _parameter = parameter;
            _dbtype = dbtype;
            _propertyName = propertyName;
        }
        public DeleteAttribute(string parameter, SqlDbType dbtype, string deletename, [CallerMemberName] string propertyName = null)
        {
            _parameter = parameter;
            _dbtype = dbtype;
            _deletename = deletename;
            _propertyName = propertyName;
        }
    }
    public class ColMapping : Attribute
    {

        private string _name = "";
        public string Name { get => _name; set => _name = value; }

        public ColMapping(string name)
        {
            _name = name;
        }
    }
    public class InsertProcedure : Attribute
    {

        private string _name = "";

        public string Name { get => _name; set => _name = value; }

        public InsertProcedure(string name)
        {
            _name = name;
        }
    }
    public class SaveProcedure : Attribute
    {

        private string _name = "";

        public string Name { get => _name; set => _name = value; }

        public SaveProcedure(string name)
        {
            _name = name;
        }
    }
    public class LoadProcedure : Attribute
    {

        private string _name = "";
        private string _loadname = "";
        public string Name { get => _name; set => _name = value; }
        public string LoadName { get => _loadname; set => _loadname = value; }
        public LoadProcedure(string name, string loadname)
        {
            _name = name;
            _loadname = loadname;
        }
        public LoadProcedure(string name)
        {
            _name = name;
            _loadname = string.Empty;
        }
    }
    public class DeleteProcedure : Attribute
    {

        private string _name = "";
        private string _deletename = "";
        public string Name { get => _name; set => _name = value; }
        public string DeleteName { get => _deletename; set => _deletename = value; }

        public DeleteProcedure(string name)
        {
            _name = name;
        }
        public DeleteProcedure(string name, string deletename)
        {
            _name = name;
            _deletename = deletename;
        }
    }
    public enum DBAction
    {
        save,
        load,
        delete,
        insert
    }
}
