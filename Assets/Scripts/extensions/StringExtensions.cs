using System.IO;

namespace extensions
{
  public static class StringExtensions
  {
    public static string Combine(this string home, string path) =>
      Path.Combine(home, path);
  }
}