using _2_ReverseEngineeringNETCLI.Data;
using System;

namespace _2_ReverseEngineeringNETCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var i in context.Speakers)
                {
                    Console.WriteLine(i.FirstName + i.LastName);
                }
            }
        }
    }
}
