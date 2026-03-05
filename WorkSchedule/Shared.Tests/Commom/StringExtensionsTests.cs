using Shared.Common;

namespace Shared.Tests.Commom;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("√„", "Aa")]
    [InlineData("¬‚", "Aa")]
    [InlineData("¿‡", "Aa")]
    [InlineData("«Á", "Cc")]
    [InlineData("¡·", "Aa")]
    public void RemoveDiacriticsSuccess(string originalValue, string expectedResult)
    {
        string? normalizedValue = originalValue.RemoveDiacritics();
        Assert.NotNull(normalizedValue);
        Assert.NotEmpty(normalizedValue);
        Assert.Equal(expectedResult, normalizedValue);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    public void RemoveDiacriticsAlternativeFlows(string originalValue, string expectedResult)
    {
        string? normalizedValue = originalValue.RemoveDiacritics();
        Assert.Equal(expectedResult, normalizedValue);
    }
}