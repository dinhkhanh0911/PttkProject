using PttkProject.Common;
using PttkProject.DatabaseDAO;
using PttkProject.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class BaseAdminController : Controller
    {
        private NguoiDungDAO nguoiDung = new NguoiDungDAO();
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (User)Session[CommonConstant.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { controller = "DangNhap", action = "dangnhap" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}