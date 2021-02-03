namespace TestNinjaCore.Mocking
{
    public interface IEmployeeStorage
    {
        void DeleteEmployee(int id);
    }

    // can be called EmployeeService as well although
    // application service layer - responsible for high level orchestration
    // delegate tasks to different objects
    // may talk to database object to store
    // may talk to notification object to send notification
    // finally may tlak to logger object
    // high level orchestration then use a service
    // if just deleting an employee then just employeestorage
    // it's only responsible for storage to database
    // it could be repository but it shouldn't have a Save method
    // repository acts on object like using objects then use UnitOfWork with repository
    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }

        // do we need unit tests here???
        // NO, because we are directly interacting with an external resource
        // the proper way to test this is with an integration test
        // we call the method against a database
        // for unit testing, we don't care about the implementation details
        // which is way we mock this
        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return;   // escape early
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}