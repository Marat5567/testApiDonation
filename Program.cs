
namespace testApiDonation
{
    internal class Program
    {
        private const string ID_APPLICATION = "";
        private const string API_KEY = "";
        private const string tokensFilePath = @"";
        static async Task Main(string[] args)
        {
            try
            {
                DonationApi donationApi = new DonationApi(ID_APPLICATION, API_KEY, tokensFilePath);

                uint last = 100;
                ShowConsole($"последние {last}", await donationApi.GetDonationsAsync(last));

                DateTime startDate = new DateTime(2026, 2, 18, 12, 10, 0);
                DateTime endDate = new DateTime(2026, 2, 22, 12, 10, 0);
                ShowConsole($"В период с {startDate} до {endDate} {last}", await donationApi.GetDonationsByDateRangeAsync(startDate: startDate, endDate: endDate));

                string messageCompare1 = "Андрей";
                bool checkContains1 = false;
                ShowConsole($"Равняется строке: {messageCompare1}", await donationApi.GetDonationsByMessage(message: messageCompare1, checkContains: checkContains1));

                string messageCompare2 = "а";
                bool checkContains2 = true;
                ShowConsole($"Содержит в себе строку {messageCompare2}", await donationApi.GetDonationsByMessage(message: messageCompare2, checkContains: checkContains2));

                decimal amount = 10;
                ShowConsole($"Равняется сумме: {amount}", await donationApi.GetDonationsByAmount(amount: amount));

                string NameCompare1 = "";
                bool checkNameContains1 = false;
                ShowConsole($"Равняется строке: {NameCompare1}", await donationApi.GetDonationsByMessage(message: NameCompare1, checkContains: checkNameContains1));

                string NameCompare2 = "Андрей";
                bool checkNameContains2 = true;
                ShowConsole($"Содержит в себе строку {NameCompare2}", await donationApi.GetDonationsByUserName(name: NameCompare2, checkContains: checkNameContains2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("\n\nНажмите любую клавишу...");
            Console.ReadLine();
        }

        private static void ShowConsole(string header, List<Donat>? donation)
        {
            Console.WriteLine($"\n\n\n\t\t-------- {header} --------");

            if (donation == null || donation.Count == 0) { Console.WriteLine("Нету донатов"); return; }
            foreach (Donat donat in donation)
            {
                Console.WriteLine($"\n====Донат====");
                Console.WriteLine($"Тип: {donat.Name}");
                Console.WriteLine($"Id: {donat.Id}");
                Console.WriteLine($"Имя пользователя: {donat.Username}");
                Console.WriteLine($"Сообщение: {donat.Message}");
                Console.WriteLine($"Сумма: {donat.Amount}");
                Console.WriteLine($"Валюта: {donat.Currency}");
                Console.WriteLine($"Показывалось ди оповещение (да - 1, нет - 0): {donat.IsShown}");
                Console.WriteLine($"Создан в: {donat.CreatedAt}");
                Console.WriteLine($"Дата и время показа оповещения (null если не показывалось): {(donat.ShownAt != null ? donat.ShownAt : "Не показывалось")}\n");
            }
        }
    }
}
