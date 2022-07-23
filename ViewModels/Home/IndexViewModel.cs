using AppleWatch.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppleWatch.ViewModels.Home {
  public class IndexViewModel {
    public string BigBanner { get; set; }

    public string SmallBanner1 { get; set; }

    public string SmallBanner2 { get; set; }

    public List<DisplayWatchCard> DisplayWatchCards { get; set; }

    public int WatchAmount => DisplayWatchCards == null ? 0 : DisplayWatchCards.Count();
  }
}
