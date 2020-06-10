using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotaESport.Web.Controllers
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                return null; //throw new ArgumentNullException(nameof(principal));

            string ret = "";

            try
            {
                ret = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            catch (System.Exception)
            {
            }
            return ret;
        }
    }
}
