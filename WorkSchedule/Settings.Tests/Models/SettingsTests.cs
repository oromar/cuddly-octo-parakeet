using Shared;
using Shared.Exceptions;

namespace Settings.Tests.Models;

public class SettingsTests
{
    [Fact]
    public void CreateSettingsObjectSuccess()
    {
        try
        {
            var settings = new Settings.Models.Settings(1, 1);
            Assert.True(settings.IsValid());
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(-1, -1)]
    [InlineData(-1, 1)]
    [InlineData(1, -1)]
    public void CreateSettingsObjectAlternativeFlows(int employeesCount, int daysToCheck)
    {
        List<string> possibleMessages = [
            Strings.SettingsNotConfiguredMessage,
            Strings.InvalidEmployeeCountMessage,
            Strings.InvalidEmployeeIntervalMessage
            ];

        Entities.Settings? settings = null;
        var exception = Assert.Throws<DomainException>(() => settings = new(employeesCount, daysToCheck));
        Assert.Null(settings);
        Assert.Contains(exception.Message, possibleMessages);
    }
}
