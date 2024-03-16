using Domen.DTOs;
using Domen.Entities;
using System.Text;
using System.Text.Json;

namespace UserSide
{
    internal class Program
    {

        static  void Main(string[] args)
        {
            using HttpClient client = new HttpClient();
            List<string>UserPins = new List<string>();
            Console.WriteLine("                      GAME STARTED");

            Console.WriteLine("=======================================================");

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"USER {i} : Include name");

                var userName = Console.ReadLine();

                Console.WriteLine($"USER {i} : Include pin");

                var userpin = Console.ReadLine();

                UserPins.Add(userpin);

                CreateUserDTO createUserDTO = new CreateUserDTO() { Name = userName, PIN = userpin };

                string response = string.Empty;

                string payload=JsonSerializer.Serialize(createUserDTO);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                Uri url = new Uri("https://localhost:7251/api/Game/registration");
                HttpResponseMessage result = client.PostAsync(url, content).Result;
                if (result.IsSuccessStatusCode)
                {
                   response = result.StatusCode.ToString();
                   Console.WriteLine(response);
                   Console.WriteLine("Greate");
                }
                else
                {
                    Console.WriteLine("Error");
                }

                
            }


            Console.WriteLine("VIEW BALANCE: Press 1");

            Console.WriteLine("LIST OF GAMES: Press 2");

            Console.WriteLine("CONNECT TO GAME BY ID: Press 3");

            Console.WriteLine("START NEW GAME: Press 4");

            string menu;

            while (true)
            {
                menu = Console.ReadLine();

                if (menu == "1")
                {
                    Console.WriteLine("BALANCE");
                }
                else if (menu == "2")
                {
                    Console.WriteLine("IST OF GAMES");
                }
                else if (menu == "3")
                {
                    Console.WriteLine("GAME STARTED");
                }
                else if (menu == "4")
                {
                    string response = string.Empty;
                    CreateMatchHistoryDTO createMatchHistoryDTO = new CreateMatchHistoryDTO() { oneUserPIN = UserPins[0], anotherUserPIN = UserPins[1] };
                    string payload = JsonSerializer.Serialize(createMatchHistoryDTO);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    Uri url = new Uri("https://localhost:7251/api/Game/NewMatch");
                    HttpResponseMessage result = client.PostAsync(url, content).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        response = result.StatusCode.ToString();
                        Console.WriteLine(response);
                        Console.WriteLine("Greate");
                        UserPins.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                else
                {
                    Console.WriteLine("Press correct key");
                }


            }
        }
    }
}
