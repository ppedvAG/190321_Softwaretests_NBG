using System.Collections.Generic;

namespace ppedv.ProjectSelma.Domain
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public decimal AnnualIncome { get; set; }
        public virtual HashSet<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
