using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class EmailValidator : IValidator
    {
        private IValidator _nextValidator;

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Email)) return false;
            if (!user.Email.Contains("@")) return false;
            var parts = user.Email.Split('@');
            if (parts.Length != 2 || parts[0].Length < 8) return false;

            string domain = parts[1];
            if (domain != "mail.ru" && domain != "yandex.ru" && domain != "gmail.com") return false;

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}

