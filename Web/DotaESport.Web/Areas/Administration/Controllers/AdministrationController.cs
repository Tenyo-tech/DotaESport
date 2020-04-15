namespace DotaESport.Web.Areas.Administration.Controllers
{
    using DotaESport.Common;
    using DotaESport.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
