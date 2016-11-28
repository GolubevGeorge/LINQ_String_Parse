using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQStringParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 55;

            string phrase = "The “C# Professional” course includes the topics I discuss in my CLR via C# book and" +
            "teaches how the CLR works thereby showing you how to develop applications and reusable" +
            "components for the .NET Framework.";

            string[] splitPhrase = phrase.Split(new char[] { ' ' });

            List<string> listOfSplitPhrase = splitPhrase.ToList<string>();
            IEnumerable<string> uniqListOfSplitPhrase = listOfSplitPhrase.Distinct();

            var orderedWords =
                from word in uniqListOfSplitPhrase
                orderby word.Length
                group word by word.Length;

            foreach (var orderedWord in orderedWords)
            {
                int count = orderedWord.Count(p => p.Length == orderedWord.Key);
                Console.WriteLine("\nWords of length: {0}, Count: {1}", orderedWord.Key, count);

                foreach (var word in orderedWord)
                {
                    Console.WriteLine(word);

                }
            }

            Console.ReadKey();
        }
    }
}
