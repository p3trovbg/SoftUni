namespace HttpClientServerDemo.Views
{
    public class ChatView
    {
        private static string html;
        private static string _fullName;
        private static List<string> messages = new List<string>();
        public string GetChatHtml(string fullName)
        {
            _fullName = fullName;
            html =
                $"<h2>" +
                    $"Welcome {string.Join(" ", fullName)} at {DateTime.Now.ToString("hh:mm:ss")}" +
                $"</h2>" +
                $"<div>" +
                  $"<form action=/chat method=post>" +
                    $"<h1>Chat</h1>" +
                    $"<label for=msg><b>Message</b></label>" +
                    $"<textarea placeholder=Type message.. name=msg required></textarea>" +
                    $"<button type=submit>Send</button>" +
                    $"<button type=button>Close</button>" +
                  $"</form>" +
                $"</div>" +
                $"<ul>" +
                    $"{string.Join(Environment.NewLine, messages)}" +
                $"</ul>";

            return html;
        }

        public void AddMessage(string message = "")
        {
            messages.Add($"<li>{_fullName} said - {message}</li>");
        }
    }
}
