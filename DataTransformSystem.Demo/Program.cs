using System;
using System.IO;
using DataTransformSystem;

namespace DataTransformSystem.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Started to transform ......");
                DataTransform.TransFile("../../../TestData/Input1.csv", FileType.AccountFormat1, true);
                DataTransform.TransFile("../../../TestData/Input2.csv", FileType.AccountFormat2, false, new string[]{"Name", "Type", "Currency", "Custodian Code"});
                Console.WriteLine("Finished, Check the log files to see if there are errors.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Press ENTER Key to exit.");
            Console.ReadLine();
        }
    }
}
