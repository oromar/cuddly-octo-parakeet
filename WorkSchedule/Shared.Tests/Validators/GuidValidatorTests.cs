using Shared.Exceptions;
using Shared.Validators;

namespace Shared.Tests.Validators;

public class GuidValidatorTests
{
    private readonly GuidValidator validator;
    public GuidValidatorTests()
    {
        validator = new();
    }

    [Fact]
    public void ValidateGuidSuccess()
    {
        try
        {
            validator.Validate(Guid.NewGuid().ToString());
            Assert.True(true);
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void ValidateNullGuid()
    {
       var exception = Assert.Throws<DomainException>(() =>  validator.Validate(null));
        Assert.Equal(Strings.RequiredGuid,exception.Message );
    }

    [Fact]
    public void ValidateEmptyGuid()
    {
        var exception = Assert.Throws<DomainException>(() => validator.Validate(Guid.Empty.ToString()));
        Assert.Equal(Strings.InvalidGuid, exception.Message);
    }
}
