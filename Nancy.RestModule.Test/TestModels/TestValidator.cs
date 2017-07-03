using FluentValidation;

namespace Nancy.RestModule.Test.TestModels
{
    public class TestValidator : AbstractValidator<TestRequestModel>
    {
        public TestValidator()
        {
            RuleFor(request => request.Value).NotEmpty();
        }
    }
}