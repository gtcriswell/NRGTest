using NRGBusiness;
using NRGBusiness.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace NRGClasses
{
    [Serializable]
    [SaveProcedure("sp_NRGFormSave")]
    [LoadProcedure("sp_NRGFormLoad")]
    public class Registrations
    {
        public HttpContext _context;
        public Registrations(HttpContext context)
        {
            _context = context;
        }

        public Registrations()
        {
        }

        [LoadAttribute("@UID", System.Data.SqlDbType.Int)]
        [SaveAttribute("@UID", System.Data.SqlDbType.Int)]
        [ColMapping("UID")]
        public int UID { get; set; }

        [SaveAttribute("@FirstName", System.Data.SqlDbType.VarChar)]
        [ColMapping("FirstName")]
        public string FirstName { get; set; }

        [SaveAttribute("@LastName", System.Data.SqlDbType.VarChar)]
        [ColMapping("LastName")]
        public string LastName { get; set; }

        [SaveAttribute("@Email", System.Data.SqlDbType.VarChar)]
        [ColMapping("Email")]
        public string Email { get; set; }

        [SaveAttribute("@SSN", System.Data.SqlDbType.VarChar)]
        [ColMapping("SSN")]
        public string SSN { get; set; }

        [SaveAttribute("@DateOfBirth", System.Data.SqlDbType.Date)]
        [ColMapping("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
        public string DateOfBirthFormatted
        {
            get
            {
                if (DateOfBirth.HasValue)
                {
                    return DateOfBirth.Value.ToString("MM/dd/yyyy");
                }
                return string.Empty;
            }
        }

        [SaveAttribute("@Address1", System.Data.SqlDbType.VarChar)]
        [ColMapping("Address1")]
        public string Address1 { get; set; }

        [SaveAttribute("@Address2", System.Data.SqlDbType.VarChar)]
        [ColMapping("Address2")]
        public string Address2 { get; set; }

        [SaveAttribute("@City", System.Data.SqlDbType.VarChar)]
        [ColMapping("City")]
        public string City { get; set; }

        [SaveAttribute("@StateCode", System.Data.SqlDbType.VarChar)]
        [ColMapping("StateCode")]
        public string StateCode { get; set; }

        [SaveAttribute("@Zip", System.Data.SqlDbType.VarChar)]
        [ColMapping("Zip")]
        public string Zip { get; set; }


        public string FullName
        {

            get
            {
                if (!String.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                {
                    return FirstName + ", " + LastName;

                }
                if (!String.IsNullOrEmpty(FirstName))
                {
                    return FirstName;

                }
                if (!String.IsNullOrEmpty(LastName))
                {
                    return LastName;

                }
                return string.Empty;
            }
        }

        [ColMapping("DateAdded")]
        public DateTime DateAdded { get; set; }


        [ColMapping("DateUpdated")]
        public DateTime DateUpdated { get; set; }

        #region factory

        public Registrations Load(int UID)
        {
            Registrations r = new Registrations();
            r.UID = UID;
            Factory d = new Factory(DBAction.load);
            List<Registrations> fs = (List<Registrations>)d.DataUtility<Registrations>(r);
            if (fs.Count > 0)
            {
                foreach (var f in fs)
                {
                    if (f.UID == UID)
                    {
                        return f;
                    }
                }
            }
            return new Registrations();
        }

        private void LoadAllThread()
        {


            Task.Run(() =>
            {
                LoadAll();
            });
        }

        public List<Registrations> LoadAll()
        {
            CacheHelper cacheHelper = new CacheHelper(_context);
            Object _cacheHelper = cacheHelper.GetObject(CacheName.Registrations);
            if (_cacheHelper != null)
            {
                List<Registrations> _result = (List<Registrations>)_cacheHelper;
                if (_result.Count > 0)
                {
                    return _result;
                }
            }
            Factory d = new Factory(DBAction.load);
            List<Registrations> fs = (List<Registrations>)d.DataUtility<Registrations>(new Registrations() { UID = 0 });
            if (fs.Count > 0)
            {
                cacheHelper = new CacheHelper(_context);
                cacheHelper.SetKey(CacheName.Registrations, fs);

                return fs;
            }
            return new List<Registrations>();
        }
        public int Save(HttpContext context)
        {
            _context = context;
            //clear cache
            CacheHelper cacheHelper = new CacheHelper(context);
            cacheHelper.ResetCache();

            Factory d = new Factory(DBAction.save);
            UID = (int)d.DataUtility<Registrations>(this);

            LoadAllThread();

            return UID;

        }

        //not implemented
        public void Delete()
        {

            Factory d = new Factory(DBAction.delete);
            d.DataUtility<Registrations>(this);

        }

        //not implemented
        public void Insert()
        {

            Factory d = new Factory(DBAction.insert);
            d.DataUtility<Registrations>(this);


        }

        public DBAction DataAction { get; set; }

        #endregion

    }
}
