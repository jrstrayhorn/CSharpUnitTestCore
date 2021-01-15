namespace TestNinjaCore.Fundamentals
{
    // unit tests should test all scenarios
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            // // 3 scenarios - execution paths
            // // Scenario #1 - when user isAdmin
            // if (user.IsAdmin)
            //     return true;

            // // Scenario #2 - when user is MadeBy user or person who made reservation
            // if (MadeBy == user)
            //     return true;

            // // Scenario #3 - when user is someone else trying to cancel
            // return false;

            // refactored
            return (user.IsAdmin || MadeBy == user);
        }
        
    }

    
    public class User
    {
        public bool IsAdmin { get; set; }
    }
}