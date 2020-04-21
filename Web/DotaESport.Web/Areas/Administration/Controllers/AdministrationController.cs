namespace DotaESport.Web.Areas.Administration.Controllers
{
    using DotaESport.Common;
    using DotaESport.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator, Admin")]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
