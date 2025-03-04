using ChainOfResponsibility.Validators;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmailValidator emailValidator = new EmailValidator();
            PasswordValidator passwordValidator = new PasswordValidator();
            LoginValidator loginValidator = new LoginValidator();

            User user = new User
            {
                Login = "5463T3",
                Password = "password46545!R",
                Email = "testemail@mail.ru"
            };

            loginValidator.SetNextValidator(emailValidator);
            emailValidator.SetNextValidator(passwordValidator);

            if (loginValidator.Validate(user))
            {
                Console.WriteLine("Все данные валидны.");
            }
        }
    }
}
