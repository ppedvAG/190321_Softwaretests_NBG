﻿using System;

namespace Taschenrechner
{
    public class Taschenrechner
    {
        public int Add(int z1, int z2)
        {
            return checked(z1 + z2);
        }
    }
}
