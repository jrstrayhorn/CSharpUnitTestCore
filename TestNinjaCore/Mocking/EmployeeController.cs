using Microsoft.EntityFrameworkCore;

namespace TestNinjaCore.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _storage;

        public EmployeeController(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _storage.DeleteEmployee(id);
            // since this is a private method we don't want to test this
            // this is an implementation detail that might change in the future
            // so we don't want to test if this exact method is being called
            // just that the expected return value is returned correctly
            // in the future we might directly return the object and not
            // call the method which would break the test
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}