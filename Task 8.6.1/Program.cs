using System.Diagnostics;
using System.Formats.Tar;

namespace Task_8._6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\nisso\Desktop\Task 8.6.1";
            ClearNotUsedFoldersAndFiles(filePath);
        }

        public static void ClearNotUsedFoldersAndFiles(string filePath)
        {
            try
            {
                if (Directory.Exists(filePath))
                {
                    string[] dirs = Directory.GetDirectories(filePath);
                    foreach (var dir in dirs)
                    {
                        string[] files = Directory.GetFiles(dir);
                        foreach (var file in files)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            if (DateTime.Now.Subtract(fileInfo.LastAccessTime).TotalMinutes > 1)
                            {
                                File.Delete(file);
                            }
                        }

                        try
                        {
                                Directory.Delete(dir);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The requested folder does not exist");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("You need admin rights to do this", ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.Message);
            }
        }
    }
}
