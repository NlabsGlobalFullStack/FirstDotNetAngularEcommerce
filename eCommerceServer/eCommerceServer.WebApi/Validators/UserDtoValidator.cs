using eCommerceServer.WebApi.DTOs;
using FluentValidation;

namespace eCommerceServer.WebApi.Validators
{
    /// <summary>
    /// LoginDto nesnesi için doğrulama kurallarını tanımlayan doğrulama sınıfı.
    /// </summary>
    public sealed class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        /// <summary>
        /// LoginDtoValidator sınıfının yapıcı metodu. Doğrulama kuralları burada tanımlanır.
        /// </summary>
        public LoginDtoValidator()
        {
            RuleFor(u => u.UserNameOrEmail).NotEmpty().NotNull();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(6);
            RuleFor(p => p.Password).Matches("[a-z]");
            RuleFor(p => p.Password).Matches("[A-Z]");
            RuleFor(p => p.Password).Matches("[0-9]");
        }
    }

    /// <summary>
    /// RegisterDto nesnesi için doğrulama kurallarını tanımlayan doğrulama sınıfı.
    /// </summary>
    public sealed class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        /// <summary>
        /// RegisterDtoValidator sınıfının yapıcı metodu. Doğrulama kuralları burada tanımlanır.
        /// </summary>
        public RegisterDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).MinimumLength(6);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.UserName).MinimumLength(4);
            RuleFor(u => u.UserName).NotNull();
            RuleFor(p => p.Password).MinimumLength(6);
            RuleFor(p => p.Password).Matches("[a-z]");
            RuleFor(p => p.Password).Matches("[A-Z]");
            RuleFor(p => p.Password).Matches("[0-9]");
        }
    }
}
