namespace HttpClientServerDemo
{
    using HttpClientServerDemo.Views;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    /// <summary>
    ///   This demo is for fun! 
    ///   Here you can't find anything useful! :D
    /// </summary>
    public class StartUp
    {
        private const string NewLine = "\r\n";
        private static HomeView homeView = new HomeView();
        private static ChatView chatView = new ChatView();
        private static string guestName;
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TcpListener tcpListener =
                new TcpListener(IPAddress.Loopback, 80);

            tcpListener.Start();

            while (true)
            {
                var clientResponse = await tcpListener.AcceptTcpClientAsync();
                using (var stream = clientResponse.GetStream())
                {
                    var buffer = new byte[200_000];
                    var length = stream.Read(buffer, 0, buffer.Length);

                    var clientRequest = Encoding.UTF8.GetString(buffer, 0, length);
                    if (string.IsNullOrEmpty(clientRequest))
                    {
                        continue;
                    }

                    Console.WriteLine(clientRequest);

                    var infoRequest = clientRequest.Split(NewLine);

                    //This get all meta information by the client.
                    var clientResponseDictionary = clientRequest.Split(NewLine)
                                .Select(part => part.Split(": "))
                                .Where(part => part.Length == 2)
                                .ToDictionary(sp => sp[0], sp => sp[1]);

                    var typeRequest = infoRequest[0]
                                        .Split("/", StringSplitOptions.RemoveEmptyEntries)
                                        .First()
                                        .TrimEnd();

                    if (typeRequest == "POST")
                    {
                        var body = infoRequest[infoRequest.Length - 1]
                             .Split("&", StringSplitOptions.RemoveEmptyEntries)
                             .Select(part => part.Split("="))
                             .ToDictionary(x => x[0], x => x[1]);

                        if (clientResponseDictionary["Referer"] == "http://localhost/")
                        {

                            var fullName = new List<string>();
                            foreach (var kvp in body)
                            {
                                fullName.Add(kvp.Value);
                            }
                            guestName = string.Join(" ", fullName);
                            ServerResponse(stream, chatView.GetChatHtml(string.Join(" ", guestName)));
                        }
                        else if(clientResponseDictionary["Referer"] == "http://localhost/chat")
                        {
                            var message = body["msg"];
                            chatView.AddMessage(message);
                            ServerResponse(stream, chatView.GetChatHtml(string.Join(" ", guestName)));
                        }
                        continue;
                    }

                    ServerResponse(stream, homeView.GetHomeHtml());
                }
            }
        }

        private static void ServerResponse(NetworkStream stream, string htmlResponse)
        {
            var serverResponse = "HTTP/1.1 200 OK" + NewLine +
                                                     "Server: MyDemoServer 2022" + NewLine +
                                                     "Content-Type: text/html; charset=utf-8" + NewLine +
                                                     $"Content-Length: {htmlResponse.Length}" + NewLine +
                                                     NewLine +
                                                     htmlResponse +
                                                     NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(serverResponse);
            stream.Write(responseBytes);

            Console.WriteLine(new String('=', 80));
        }
    }
}