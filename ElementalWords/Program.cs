using static Preloaded.Words;

namespace ElementalWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var displayItems = TestWords.Concat(TopThousandWords)
                .Select(word => new DisplayItem
                    {
                        Word = word,
                        Results = Kata.ElementalWords.ElementalForms(word)
                    })
                .Where(item => item.Results.Any())
                .OrderByDescending(item => TestWords.Contains(item.Word))
                .ThenByDescending(item => item.Results.Length);

            foreach (var displayItem in displayItems)
            {
                Display(displayItem);
            }
        }

        private static void Display(DisplayItem displayItem)
        {
            Console.WriteLine(displayItem.Word.ToUpper() + ":");

            foreach (var elementalWord in displayItem.Results)
            {
                var result = string.Join(", ", elementalWord);
                Console.WriteLine("\t- " + result);
            }

            Console.WriteLine();
        }
    }
}
