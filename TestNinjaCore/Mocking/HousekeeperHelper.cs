using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TestNinjaCore.Mocking
{
    public class HousekeeperHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementGenerator _statementGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IXtraMessageBox _messageBox;

        public HousekeeperHelper(
            IUnitOfWork unitOfWork, 
            IStatementGenerator statementGenerator, 
            IEmailSender emailSender,
            IXtraMessageBox messageBox
            )
        {
            this._statementGenerator = statementGenerator;
            this._emailSender = emailSender;
            this._messageBox = messageBox;
            this._unitOfWork = unitOfWork;
        }

        // what should the tests be?
        // for given statementDate if there are statements to send, should send them return true
        // if error during send of email, throws exception
        // what s
        public bool SendStatementEmails(DateTime statementDate)
        {
            // repository - external dep - don't want to run during test - use repository
            // refactored to IUnitOfWork
            var housekeepers = _unitOfWork.Query<Housekeeper>();

            foreach (var housekeeper in housekeepers)
            {
                if (housekeeper.Email == null)
                    continue;

                // storage - external dep - don't want to run during test
                var statementFilename = _statementGenerator.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    // emailer - external dep - don't want to run during test
                    _emailSender.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    // messageBox? - don't want this to run
                    _messageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                        MessageBoxButtons.OK);
                }
            }

            return true;
        }



        
    }

    public enum MessageBoxButtons
    {
        OK
    }

    public interface IXtraMessageBox
    {
        void Show(string s, string housekeeperStatements, MessageBoxButtons ok);
    }

    // since we already have access to this class we can just extract an interface from the class
    // no need create an extra class just to wrap this class
    // now if it's a 3rd party class that you have no control over then yes, wrap (encapsulate) in a class
    // you control THEN extract an interface
    public class XtraMessageBox : IXtraMessageBox
    {
        public void Show(string s, string housekeeperStatements, MessageBoxButtons ok)
        {
        }
    }

    public class MainForm
    {
        public bool HousekeeperStatementsSending { get; set; }
    }

    public class DateForm
    {
        public DateForm(string statementDate, object endOfLastMonth)
        {
        }

        public DateTime Date { get; set; }

        public DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }
    }

    public enum DialogResult
    {
        Abort,
        OK
    }

    public class SystemSettingsHelper
    {
        public static string EmailSmtpHost { get; set; }
        public static int EmailPort { get; set; }
        public static string EmailUsername { get; set; }
        public static string EmailPassword { get; set; }
        public static string EmailFromEmail { get; set; }
        public static string EmailFromName { get; set; }
    }

    public class Housekeeper
    {
        public string Email { get; set; }
        public int Oid { get; set; }
        public string FullName { get; set; }
        public string StatementEmailBody { get; set; }
    }

    public class HousekeeperStatementReport
    {
        public HousekeeperStatementReport(int housekeeperOid, DateTime statementDate)
        {
        }

        public bool HasData { get; set; }

        public void CreateDocument()
        {
        }

        public void ExportToPdf(string filename)
        {
        }
    }
}