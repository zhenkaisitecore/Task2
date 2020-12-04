using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Task2
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null && Request.UrlReferrer.AbsoluteUri == "http://localhost:52450/Feedback.aspx")
            {
                lblFeedback.Visible = true;
            }

            btnEndSession.Click += btnEndSession_Click;
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //var feedback = Request.QueryString["feedback"];
            //if (feedback!=null)
            //{
            //    lblSubmitSuccess.Visible = true;
            //}
        }
    }
}