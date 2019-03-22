using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Hardware.RoboRecruiter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ppedv.ProjectSelma.Logic.Driver
{
    public class RoboRecruiterDriver
    {
        public RoboRecruiterDriver()
        {
            machine = new XingRecruiter3000();
        }
        private readonly XingRecruiter3000 machine;

        public IEnumerable<Person> RecruitPersons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return machine.RecruitPersonFromXING(); // "Treiber" ruft Funktionalität der "Maschine" auf
            }
        }
    }
}
