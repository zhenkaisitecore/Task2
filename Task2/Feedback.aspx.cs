using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task2
{
    public partial class Feedback : System.Web.UI.Page
    {
        public static Dictionary<string, int> VisitCounter { get; private set; }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Session {Session.SessionID} requested for Feedback page!");
            if (VisitCounter == null) VisitCounter = new Dictionary<string, int>();
            if (!IsPostBack)
            {
                if (VisitCounter.ContainsKey(Session.SessionID))
                {
                    VisitCounter[Session.SessionID]++;
                }
                else
                {
                    VisitCounter.Add(Session.SessionID, 1);
                }
            }
        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            btnSubmitFeedback.Click += btnSubmitFeeback_Click;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitFeeback_Click(object sender, EventArgs e)
        {
            SaveFeedback(tbxFeedback.Text);
            Response.Redirect("/Default.aspx?feedback=true", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void SaveFeedback(string feedback)
        {
            if (Session["feedbackQueue"] == null)
            {
                Session["feedbackQueue"] = new Queue<string>();
            }

            (Session["feedbackQueue"] as Queue<string>).Enqueue(feedback);
        }
    }
}