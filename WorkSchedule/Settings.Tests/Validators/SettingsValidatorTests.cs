using Settings.Validators;
using Shared;
using Shared.Exceptions;

namespace Settings.Tests.Validators;

public class SettingsValidatorTests
{
    private readonly SettingsValidator validator;

    public SettingsValidatorTests()
    {
        validator = new ();
    }

    [Fact]
    public void ValidateSettingsSuccess()
    {
        try
        {
            validator.Validate(new Settings.Models.Settings(1, 1));
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void ValidateNullSettings()
    {
        var exception = Assert.Throws<DomainException>(() => validator.Validate(null));
        Assert.Equal(Strings.SettingsNotConfiguredMessage, exception.Message);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(-1, -1)]
    [InlineData(-1, 1)]
    [InlineData(1, -1)]
    public void ValidateSettingsAlternativeFlows(int employeesCount, int daysToCheck)
    {
        List<string> possibleMessages = [Strings.InvalidEmployeeCountMessage, Strings.InvalidEmployeeIntervalMessage];
        var exception = Assert.Throws<DomainException>(() => validator.Validate(new Settings.Models.Settings(employeesCount, daysToCheck)));
        Assert.Contains(exception.Message, possibleMessages);
    }
}
