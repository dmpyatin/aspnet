using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Web.Implementation.Infrastructure
{
    public interface IFormsAuthenticationWrapper
    {
        void SetCookie(string userName, bool remember);
        void SignOut();
    }

    public class FormsAuthenticationWrapper : IFormsAuthenticationWrapper
    {
        public void SetCookie(string userName, bool remember)
        {
            FormsAuthentication.SetAuthCookie(userName, remember);
         
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}