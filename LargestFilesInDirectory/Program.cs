using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\windows";
            largestFiles(path);
            Console.ReadLine();
        }


        private static void largestFiles(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

          

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0} ");
            }

            Console.WriteLine("***************************************");
            //below uses a diferent syntax but does the same thing,  looks more like SQL
            var query2 = new DirectoryInfo(path).GetFiles()
                       .OrderByDescending(f => f.Length)
                       .Take(5);

            foreach (var file in query2)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0} ");
            }
        }
    }
}
