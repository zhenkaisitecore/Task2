using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Diagnostics;
using System.IO;

namespace Task2
{
    public class Global : System.Web.HttpApplication
    {
        private string LOG_FILE_LOC { get; set; }
        private string LOG_SERVER_LOC { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            LOG_FILE_LOC = Server.MapPath("/MY_LOG.txt");
            LOG_SERVER_LOC = Server.MapPath("/SERVER_LOG.txt");
            LogServer(true);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Debug.WriteLine($"A session was started! ID={Session.SessionID}");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            
            try
            {
                Debug.WriteLine($"The log has been saved to {LOG_FILE_LOC}");
                fs = new FileStream(LOG_FILE_LOC, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                Queue<string> feedbackQueue = Session["feedbackQueue"] as Queue<string>;
                int visitCount = Feedback.VisitCounter[Session.SessionID];

                sw.WriteLine($"User:\t\t{Session.SessionID}");
                sw.WriteLine($"Visit count:\t{visitCount}");
                sw.WriteLine($"Feedbacks:");
                int counter = 1;
                while (feedbackQueue.Count>0)
                {
                    sw.WriteLine($"\t\t({counter}) "+feedbackQueue.Dequeue());
                    counter++;
                }

                sw.WriteLine("");

            }
            finally
            {
                sw?.Close();
                fs?.Close();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            LogServer(false);
        }

        private void LogServer(bool serverUp)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(LOG_SERVER_LOC, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.Write("Server was ");
                sw.Write(serverUp ? "up" : "down");
                sw.Write($" at {DateTime.Now.ToString()}\n");
            }
            finally
            {
                sw?.Close();
                fs?.Close();
            }
        }
    }
}