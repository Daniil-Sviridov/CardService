
using CardsServiceProtos;
using Grpc.Net.Client;
using static CardsServiceProtos.CardsService;
using static CardsServiceProtos.ClientService;

namespace ConsoleCardService
{ 

    public class Program
    {
     

        public static void Main()
        {
            Console.WriteLine("Client start ... ");

            AppContext.SetSwitch("system.net.http.socketshttphandler.http2unencryptedsupport", true);

            using var chanel = GrpcChannel.ForAddress("http://localhost:5001/");



            ClientServiceClient clientService = new ClientServiceClient(chanel);
            clientService.Create(new ClientCreateRequst() { FirstName = "Daniil", Patronymic = "Sergeevich", Surname = "GRPC" });

            Console.WriteLine("");

            CardsServiceClient cardsServiceClient = new CardsServiceClient(chanel);

            GetByClientIDResponse getByClientIDResponse = cardsServiceClient.GetByClientID(new GetByClientIDRequst() { ClientId = 1 });

            Console.WriteLine(getByClientIDResponse.ToString());

            Console.ReadKey();

        }
    }

}