using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Common
{
    public class CheckAuthorityAttribute : AuthorizeAttribute
    {
        public int RoleID { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[CommonConstant.USER_SESSTION];
            //List<int> privilegeLevels = this.GetCredentiaByLoggedInUser();      privilegeLevels.Contains(session.RoleID)
            if (session.RoleID == RoleID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<int> GetCredentiaByLoggedInUser()
        {
            var credentials = (List<int>) HttpContext.Current.Session[CommonConstant.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}