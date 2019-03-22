using System.Collections.Generic;

namespace ppedv.ProjectSelma.Domain
{
    public class Department
    {
        public string Name { get; set; }
        public virtual Person Head { get; set; }
        public virtual HashSet<Person> Member { get; set; } = new HashSet<Person>();
    }
}
