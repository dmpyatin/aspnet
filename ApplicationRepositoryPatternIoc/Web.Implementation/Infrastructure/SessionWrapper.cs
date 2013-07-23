using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Implementation.Infrastructure
{
    public interface ISessionWrapperRepository
    {
        void SetSession(string key, object value);
        object GetSession(string key);
    }

    public class SessionWrapperRepository : ISessionWrapperRepository
    {
        public void SetSession(string key, object value)
        {
            SessionWrapper.SetSession(key, value);
        }

        public object GetSession(string key)
        {
            return SessionWrapper.GetSession(key);
        }
    }

    public static class SessionWrapper
    {
        public static void SetSession(string key, object value)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        public static object GetSession(string key)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Session[key];
            }

            return null;
        }
    }
}