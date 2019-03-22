using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.ProjectSelma.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void Core_GetAllPeople_Get_Exactly_5_People()
        {
            var core = new Core(null); // hab kein EF/Azure etc...

            var result = core.GetAllPeople();
            Assert.Equal(5, result.Count());
        }
    }
}
