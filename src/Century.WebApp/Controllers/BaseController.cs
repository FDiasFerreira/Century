using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Century.WebApp.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {

    }
}
