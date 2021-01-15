using System;

namespace TestNinjaCore.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        
        // how many test cases?
        // 3
        public void Log(string error)
        {
            // null check
            // ""
            // " "
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error; 
            
            // Write the log to a storage
            // ...

            ErrorLogged?.Invoke(this, Guid.NewGuid());
        }
    }
}