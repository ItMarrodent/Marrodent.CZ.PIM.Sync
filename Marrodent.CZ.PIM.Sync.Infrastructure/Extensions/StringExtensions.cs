using System.Text;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string arg)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(arg));
        }
    }
}
