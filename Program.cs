using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpAdvanced
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintDirectoryFileSystem(@"C:\Users\jorya\source\repos\CSharpAdvanced", 1);
            var size = calculateDirectoySize(@"C:\Users\jorya\source\repos\CSharpAdvanced");
            Console.WriteLine($"Size: {size / 1024} KB");
        }

        static void PrintDirectoryFileSystem(string dirPath, int level)
        {
            foreach (var fileName in Directory.GetFiles(dirPath))
                Console.WriteLine($"{new string ('-', level)} {new FileInfo(fileName).Name}");

            foreach (var dirName in Directory.GetDirectories(dirPath))
            {
             Console.WriteLine($"{new string('-', level)} {new DirectoryInfo(dirName).Name}");
                PrintDirectoryFileSystem(dirName,level+1);
            }

        }

        static long calculateDirectoySize(string dirPath)
        {
            long size = 0;
            foreach (var fileName in Directory.GetFiles(dirPath))
                size += new FileInfo(fileName).Length;

            foreach (var dirName in Directory.GetDirectories(dirPath))
            {
                size += calculateDirectoySize(dirName);
            }
            return size;    
        }
    }
}
