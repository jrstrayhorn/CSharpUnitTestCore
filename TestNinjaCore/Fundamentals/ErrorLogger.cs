using System;

namespace TestNinjaCore.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 

        private Guid _errorId;
        
        public void Log(string error)
        {
            // how many test cases?
            // 3
            // null check
            // ""
            // " "
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error; 
            
            // Write the log to a storage
            // ...

            //_errorId = Guid.NewGuid();
            OnErrorLogged(Guid.NewGuid());
        }

        // this method is an implementation detail
        // and can change from version to version
        // we shouldn't test against this, should only test
        // the Log method
        // making this public is bad, we are leaking implementation
        // public virtual void OnErrorLogged()
        // {
            
        // }

        // if you have too many private methods, or too many execution paths
        // in a single class, then might be a code smell
        // maybe those private methods or execution paths should be in 
        // another class
        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}