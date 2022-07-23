using System.Collections.Generic;
using System.Linq;

namespace AppleWatch.Models {
  public class DisplayWatchCard {
    public int WatchId { get; set; }

    public bool IsAuthorisedReseller { get; set; }

    public string Image { get; set; }

    public string SeriesDisplayName { get; set; }

    public string StrapDisplayName { get; set; }

    public string GenuineDisplayName { get; set; }

    public decimal? Price { get; set; }

    public decimal? SaleOffPrice { get; set; }

    public decimal? ActualPrice => Price.HasValue ? Price - SaleOffPrice : null;

    public List<string> CurrentPromotions { get; set; }

    public int PromotionsAmount => CurrentPromotions.Count();
  }
}
