using System;
using System.Data.Entity;
using System.Linq;

namespace EnumCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EnumTestContext())
            {
                context.Departments.Add(new Department { Name = DepartmentNames.English });

                context.SaveChanges();

                var department = (from d in context.Departments
                                  where d.Name == DepartmentNames.English
                                  select d).FirstOrDefault();

                Console.WriteLine(
                    "DepartmentID: {0} Name: {1}",
                    department.DepartmentID,
                    department.Name);
            }
        }
    }

    public enum DepartmentNames
    {
        English,
        Math,
        Economics
    }

    public partial class Department
    {
        public int DepartmentID { get; set; }
        public DepartmentNames Name { get; set; }
        public decimal Budget { get; set; }
    }

    public partial class EnumTestContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}
