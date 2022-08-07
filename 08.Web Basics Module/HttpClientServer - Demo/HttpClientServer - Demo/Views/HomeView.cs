namespace HttpClientServerDemo.Views
{
    public class HomeView
    {
        public string GetHomeHtml()
        {
            var html = $"<h1>Welcome to my chat! - {DateTime.Now.ToString("G")}</h1>" +
                        @$"<form action=/chat method=post>
                              <label style=background-color:powderblue;> 
                                    Please, fill the fields!
                              </label>
                              <br><label> First name:</label><br>
                              <input name=firstName>
                              <br><label> Last name: </label><br>
                              <input name=lastName>
                              <input style=background-color:green; type=submit value=Login>
                          </form>";
            return html;
        }
    }
}
