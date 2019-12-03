using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AreaDemo
{
    /// <summary>
    /// https://ideafromtheweb.com/how-to/create-new-areas-separate-project-asp-net-mvc/
    /// </summary>
    public class NewAreaRegistration : AreaRegistration
    {
        public override string AreaName => "NewArea";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("NewArea_Default",
                "NewArea/{controller}/{action}/{id}",
                new { controller = "NewAreaHome", action = "Index", id = UrlParameter.Optional },
                new string[] { "NewArea.Controllers" });
        }
    }
}
