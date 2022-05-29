using System;

namespace AuthorProblem
{
    [Author("Viktor")]
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            var track = new Tracker();
            track.PrintMethodsByAuthor();
        }
    }
}
