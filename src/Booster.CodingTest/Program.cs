namespace Booster.CodingTest
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var stream = new Library.WordStream();
            StreamAnalyzer.ProcessText(stream, true);
        }
    }
}