using System;

namespace Banks
{
    public class Terminal : ClientManager
    {
        public void Cmd(Client client)
        {
            Console.WriteLine("Client-Address/Passport");

            if (Console.ReadLine() == "Client")
            {
                if (Console.ReadLine() == "Address")
                {
                    ChangeAddressClient(client, Console.ReadLine());
                }

                if (Console.ReadLine() == "Passport")
                {
                    ChangePassportClient(client, Console.ReadLine());
                }
            }
        }
    }
}