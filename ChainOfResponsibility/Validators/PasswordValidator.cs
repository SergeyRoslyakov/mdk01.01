﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class PasswordValidator : IValidator
    {
        private IValidator _nextValidator;

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.WriteLine("Пароль не соответствует требуемой длине");
                return false;
            }

            if (!user.Password.Any(char.IsUpper) || !user.Password.Any(char.IsLower) ||
                !user.Password.Any(char.IsDigit) || !user.Password.Any(c => "#*!@".Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну заглавную букву, одну строчную букву, одну цифру и один специальный символ (#, *, !, @).");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
