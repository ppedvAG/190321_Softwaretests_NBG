using AutoFixture;
using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Domain.Interfaces;
using System;

namespace ppedv.ProjectSelma.Hardware.RoboRecruiter
{
    public class XingRecruiter3000 : IDevice
    {
        private Fixture fix = new Fixture();

        public Person RecruitPerson()
        {
            return RecruitPersonFromXING();
        }

        public Person RecruitPersonFromXING()
        {
            Console.Beep();
            return fix.Create<Person>();
        }
    }
}
