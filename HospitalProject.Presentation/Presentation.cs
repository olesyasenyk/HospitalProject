using System.Text;
using BL = HospitalProject.BusinessLogic.BusinessLogic;

namespace HospitalProject.Presentation
{
    public class Presentation
    {
        public static async Task Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            BL BusinessLogic = new();
        }
    }
}
