using AutoFixture;
using ppedv.ProjectSelma.Domain;
using System;

namespace ppedv.ProjectSelma.Hardware.RoboRecruiter
{
    public class XingRecruiter3000
    {
        private Fixture fix = new Fixture();

        public Person RecruitPersonFromXING()
        {
            Console.Beep();
            return fix.Create<Person>();
        }
    }
}
