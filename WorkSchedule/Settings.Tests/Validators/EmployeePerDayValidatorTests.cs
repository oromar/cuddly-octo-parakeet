using Settings.Validators;
using Shared;
using Shared.Exceptions;

namespace Settings.Tests.Validators;

public class EmployeePerDayValidatorTests
{
    private readonly EmployeePerDayValidator validator;
    public EmployeePerDayValidatorTests()
    {
        validator = new();
    }

    [Fact]
    public void ValidateEmployeePerDaySuccess()
    {
        try
        {
            validator.Validate(1);
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ValidateEmployeePerDayAlternativeFlows(int value)
    {
        var exception = Assert.Throws<DomainException>(() => validator.Validate(value));
        Assert.Equal(Strings.InvalidEmployeeCountMessage, exception.Message);
    }
}
