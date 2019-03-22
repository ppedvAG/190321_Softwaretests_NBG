using ppedv.ProjectSelma.Data.EF;
using ppedv.ProjectSelma.Hardware.RoboRecruiter;
using ppedv.ProjectSelma.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ProjectSelma.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new Core(new EFRepository(new EFContext()), new XingRecruiter3000());

            var people = core.RecruitPersons(50);
            var savedPeople = core.SaveRecruitedPeopleInDB(people);

            Console.WriteLine(savedPeople);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
