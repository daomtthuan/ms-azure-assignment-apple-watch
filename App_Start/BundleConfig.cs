using System.Web.Optimization;

namespace AppleWatch {
  public class BundleConfig {
    public static void RegisterBundles(BundleCollection bundles) {
      // Styles
      bundles.Add(new StyleBundle("~/bundles/styles").Include(
        "~/Assets/Libraries/Bootstrap/css/bootstrap.css",
        "~/Assets/Styles/main.css"
      ));

      // Scripts
      bundles.Add(new Bundle("~/bundles/scripts").Include(
        "~/Assets/Libraries/Bootstrap/js/bootstrap.bundle.min.js",
        "~/Assets/Libraries/FontAwesome/js/all.min.js",
        "~/Assets/Scripts/main.js"
      ));
    }
  }
}
