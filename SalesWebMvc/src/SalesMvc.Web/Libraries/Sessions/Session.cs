using System;
using Microsoft.AspNetCore.Http;

namespace SalesMvc.Web.Libraries.Sessions
{
    public class Session
    {
        private readonly IHttpContextAccessor _context;

        public Session(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Create(string key, string value)
        {
            _context.HttpContext.Session.SetString(key, value);
        }

        public void Update(string key, string value)
        {
            if (Exist(key))
            {
                _context.HttpContext.Session.Remove(key);
            }
            _context.HttpContext.Session.SetString(key, value);
        }

        private bool Exist(string key)
        {
            if (string.IsNullOrEmpty(_context.HttpContext.Session.GetString(key)))
            {
                return false;
            }

            return true;
        }

        public void Remove(string key)
        {
            if (Exist(key))
            {
                _context.HttpContext.Session.Remove(key);
            }
        }

        public string Search(string key)
        {
            return _context.HttpContext.Session.GetString(key);
        }

        public void RemoveAll()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}
