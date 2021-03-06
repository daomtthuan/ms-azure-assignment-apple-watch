using System.Web.Mvc;
using System.Web.Routing;

namespace AppleWatch {
  public class RouteConfig {
    public static void RegisterRoutes(RouteCollection routes) {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.LowercaseUrls = true;

      _ = routes.MapRoute(
          name: "Home",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
