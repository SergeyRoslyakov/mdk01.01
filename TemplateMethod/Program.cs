namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Moderator moderator = new Moderator();
            Guest guest = new Guest();
            VIPUser vipUser = new VIPUser(); // Создаем VIP пользователя

            guest.Login = "testUser";
            moderator.Login = "Moderator121";
            admin.Login = "admin545";
            vipUser.Login = "VIPUser001"; // Задаем логин для VIP пользователя

            admin.Work("лого", moderator);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower", guest);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin);
            Console.WriteLine("-----------------------------------");
            vipUser.Work("пейзаж", guest); // VIP пользователь подает жалобу на гостя
            Console.WriteLine("-----------------------------------");
        }
    }
}
