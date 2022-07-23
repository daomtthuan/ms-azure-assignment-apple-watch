using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AppleWatch {
  public class MvcApplication : HttpApplication {
    protected void Application_Start(object sender, EventArgs e) {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    protected void Application_BeginRequest(object sender, EventArgs e) {
      var context = HttpContext.Current;

      var isGet = context.Request.RequestType.ToLowerInvariant().Contains("get");
      var url = context.Request.Url;

      if (isGet && !url.AbsolutePath.Contains(".")) {
        var urlLowercase = url.Scheme + "://" + HttpUtility.UrlDecode(url.Authority + url.AbsolutePath);

        if (Regex.IsMatch(urlLowercase, @"[A-Z]") || Regex.IsMatch(urlLowercase, @"[ÀÈÌÒÙÁÉÍÓÚÂÊÎÔÛÃÕÄËÏÖÜÝÑ]")) {
          urlLowercase = urlLowercase.ToLower() + url.Query;

          Response.Clear();
          Response.Status = "301 Moved Permanently";
          Response.AddHeader("Location", urlLowercase);
          Response.End();
        }
      }
    }
  }
}
