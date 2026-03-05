using Shared.Common;
using Shared.Exceptions;
using Shared.Validators;

namespace Shared.Tests.Validators;

public class PeriodValidatorTests
{
    private readonly PeriodValidator validator;

    public PeriodValidatorTests()
    {
        validator = new();
    }

    [Fact]
    public void ValidatePeriodSuccess()
    {
        try
        {
            validator.Validate(DateTime.Now.ToSchedule(), DateTime.Now.AddDays(1).ToSchedule());
            Assert.True(true);
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("unparseable_date")]
    public void ValidateStartDate(string startDate)
    {
        var exception = Assert.Throws<DomainException>(() => validator.Validate(startDate, DateTime.Now.ToSchedule()));
        Assert.Equal(Strings.RequiredStartDate, exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("unparseable_date")]
    public void ValidateEndDate(string endDate)
    {
        var exception = Assert.Throws<DomainException>(() => validator.Validate(DateTime.Now.ToSchedule(), endDate));
        Assert.Equal(Strings.RequiredEndDate, exception.Message);
    }

    [Fact]
    public void ValidateEndDateBeforeStartDate()
    {
        var exception = Assert.Throws<DomainException>(() => validator.Validate(DateTime.Now.ToSchedule(), DateTime.Now.AddDays(-1).ToSchedule()));
        Assert.Equal(Strings.StartDateCannotBeAfterEndDate, exception.Message);
    }
}
