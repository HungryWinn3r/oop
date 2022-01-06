using System;

namespace Banks
{
    public class Terminal : ClientManager
    {
        public void Cmd(Client client)
        {
            Console.WriteLine("Client-Address/Passport");
            Console.WriteLine("ShowClientLevel");

            if (Console.ReadLine() == "Client")
            {
                if (Console.ReadLine() == "Address")
                {
                    ChangeAddressClient(client, Console.ReadLine());
                }

                if (Console.ReadLine() == "Passport")
                {
                    ChangePassportClient(client, Convert.ToInt32(Console.ReadLine()));
                }
            }

            if (Console.ReadLine() == "ShowClientLevel")
            {
                Console.WriteLine($"current level = {client.Level}");
            }
        }
    }
}