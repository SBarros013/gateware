using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace q2
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexOne = "^\\+[0-9]{13}$"; //cellphone in format +5541999999999;
            //string regexTwo = "^\\([0-9]{2}\\) 9{1} [0-9]{4}\\-[0-9]{4}$"; //cellphone in format (41) 9 9999-9999;

            //Directory Name
            string directory = "files";

            //Files in Directory
            string[] files = Directory.GetFiles(directory);
            
            //Find files with numbers that match regex
            List<string> filesWithRightNumber = FindRightFiles(files, regexOne);

            Console.WriteLine(string.Join(", ", filesWithRightNumber));

        }

        public static List<string> FindRightFiles(string[] files, string regex)
        {
            List<string> filesWithRightNumber = new List<string>();

            foreach(var f in files)
            {
                //Open File
                var fileStream = new FileStream($@"{f}", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    //Read First Line
                    string line = streamReader.ReadLine();

                    //Verify if first line match regex
                    if (Regex.IsMatch(line, regex))
                        filesWithRightNumber.Add(f);
                }
            }

            return filesWithRightNumber;
        }
    }
}
