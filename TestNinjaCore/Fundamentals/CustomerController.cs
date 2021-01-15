namespace TestNinjaCore.Fundamentals
{
    public class CustomerController
    {
        // How many tests?
        // 2 because there are 2 execution paths
        public ActionResult GetCustomer(int id)
        {
            if (id == 0)
                return new NotFound();

            return new Ok();
        }
    }

    public class ActionResult {}

    public class NotFound : ActionResult {}

    public class Ok : ActionResult {}
}