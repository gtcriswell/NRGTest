using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NRGBusiness.Helpers
{
    public class CacheHelper
    {
        public HttpContext _context;
        public CacheHelper(HttpContext context)
        {
            _context = context;
        }

        public void SetKey(CacheName key, object value)
        {
            if (_context != null)
            {
                if (value!=null)
                {
                    _context.Cache[key.ToString()] = value;
                }
            }
        }

        public void ResetCache()
        {
            foreach (System.Collections.DictionaryEntry entry in HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Remove(entry.Key.ToString());
            }
        }
        public object GetObject(CacheName key)
        {
            if (_context == null)
            {
                return null;
            }

            if (_context.Cache[key.ToString()] != null)
            {
                object _key = _context.Cache[key.ToString()];
                if (_key != null)
                {
                    return (_key);
                }
                {
                    return null;
                }

            }

            return null;
        }

    }

    public enum CacheName
    {
        Registrations

    }
}
