using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LordOfTheRingsWordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var x = char.IsPunctuation(char.Parse("'"));
                //var y = char.IsPunctuation(char.Parse("?"));
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Books\Lord Of The Rings Apocalyptic Prophecies.txt");
                string[] files = File.ReadAllLines(path);
                string BookAllText = System.IO.File.ReadAllText(path);
                string[] BookAllTextArray = BookAllText.Split(" ");
                Dictionary<string, int> BookAllDictionary = new Dictionary<string, int>();
                foreach (var word in BookAllTextArray)
                {
                    if (word != "")
                    {
                        var WordFormatted = word.ToLower();
                        if (WordFormatted.EndsWith("'s"))
                        {
                            WordFormatted = word.Substring(0, word.Length - 2);
                        }
                        WordFormatted = GlobalFunctions.RemovePunctuation(WordFormatted);
                        if (BookAllDictionary.ContainsKey(WordFormatted))
                        {
                            BookAllDictionary[WordFormatted] += 1;
                        }
                        else
                        {
                            BookAllDictionary.Add(WordFormatted, 1);
                        }
                    }

                }
                var BookAllDictionaryOrderAsc = BookAllDictionary.OrderByDescending(key => key.Value).ToList();
                Console.WriteLine("Top 10 Words");
                for (int i = 0; i < 10 && i < BookAllDictionaryOrderAsc.Count; i++)
                {
                    Console.WriteLine(BookAllDictionaryOrderAsc[i].Key + " : " + BookAllDictionaryOrderAsc[i].Value);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error reading the file");
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
