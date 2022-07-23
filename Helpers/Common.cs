using System.Globalization;

namespace AppleWatch.Helpers {
  public class Common {
    public static readonly CultureInfo Culture = CultureInfo.GetCultureInfo("vi-VN");

    public static string CurrencyFormat(decimal? money) {
      return money.HasValue ? money.Value.ToString("#,###", Culture.NumberFormat) : "";
    }

    public static string TruncateFormat(string text, int maxLength) {
      return text.Length <= maxLength ? text : (text.Substring(0, maxLength) + "...");
    }
  }
}
