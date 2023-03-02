using System.Globalization;
using System.Text;

namespace WorkSchedule.Domain.Common
{
    public static class StringExtensions
    {

        public static string RemoveDiacritics(this string source)
        {
            if (null == source) return null;
            var chars = source
                .Normalize(NormalizationForm.FormD)
                .ToCharArray()
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}
