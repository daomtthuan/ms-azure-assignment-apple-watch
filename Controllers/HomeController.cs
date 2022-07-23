using AppleWatch.Models;
using AppleWatch.ViewModels.Home;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AppleWatch.Controllers {
  public class HomeController : Controller {
    // GET: Index
    public ActionResult Index() {
      ViewBag.Url = "Home/Index";
      ViewBag.Title = "Home";

      using (var entities = new AppleWatchEntities()) {

        // Get Watches
        var watches = from w in entities.Watches
                      select new DisplayWatchCard {
                        IsAuthorisedReseller = w.IsAuthorisedReseller,
                        Image = w.Id + ".png",
                        SeriesDisplayName = w.Series.DisplayName,
                        StrapDisplayName = w.Strap.DisplayName,
                        GenuineDisplayName = w.Genuine.DisplayName,
                        Price = w.Price,
                        // Get current Promotions
                        CurrentPromotions = (from p in entities.Promotions
                                             join pa in entities.PromotionApplications on p.Id equals pa.PromotionId
                                             where pa.WatchId == w.Id &&
                                                   DateTime.Compare(pa.FromDate, DateTime.Now) <= 0 &&
                                                   DateTime.Compare(pa.ToDate ?? DateTime.Now, DateTime.Now) >= 0
                                             select p.DisplayName).ToList(),

                        // Get current SaleOffs
                        SaleOffPrice = (from so in entities.SaleOffs
                                        where so.WatchId == w.Id &&
                                              DateTime.Compare(so.FromDate, DateTime.Now) <= 0 &&
                                              DateTime.Compare(so.ToDate ?? DateTime.Now, DateTime.Now) >= 0
                                        select so.SaleOffPrice).FirstOrDefault()
                      };

        var viewModel = new IndexViewModel() {
          BigBanner = "1.png",
          SmallBanner1 = "2.png",
          SmallBanner2 = "3.png",
          DisplayWatchCards = watches.ToList()
        };

        return View("Index", viewModel);
      }
    }
  }
}
