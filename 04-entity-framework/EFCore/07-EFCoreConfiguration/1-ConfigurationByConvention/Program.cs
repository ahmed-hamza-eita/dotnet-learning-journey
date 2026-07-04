using _1_ConfigurationByConvention.Data;

namespace _1_ConfigurationByConvention
{
      class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDBContext())
            {
                Console.WriteLine("-------- Users -----------");
                Console.WriteLine();
                foreach (var user in context.tblUsers)
                {
                    Console.WriteLine(user.Username);
                }
                Console.WriteLine();
                Console.WriteLine("-------- Tweets -----------");
                Console.WriteLine();
                foreach (var tweet in context.tblTweets)
                {
                    Console.WriteLine(tweet.TweetText);
                }
                Console.WriteLine();
                Console.WriteLine("-------- Comments -----------");
                Console.WriteLine();
                foreach (var comment in context.tblComments)
                {
                    Console.WriteLine(comment.CommentText);
                }
            }
            Console.ReadKey();
        }
    }
}
