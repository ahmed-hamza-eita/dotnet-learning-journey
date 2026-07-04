using System;

namespace _1_ReverseEngineeringByPMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TechTalkContext())
            {
                foreach (var i in context.Speakers)
                {
                    Console.WriteLine(i.FirstName + i.LastName);
                }
            }

        }
    }
}
