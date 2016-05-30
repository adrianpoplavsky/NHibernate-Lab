using System;
using System.Web.UI;

namespace NH.Lab.Market
{
    public partial class Step1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Register a script reference:
            Page.ClientScript.RegisterClientScriptInclude(GetType(), "headPageScriptdefault", "/Scripts/default.js");
            Page.ClientScript.RegisterClientScriptInclude(GetType(), "headPageScriptconfiguration", "/Scripts/configuration.js");
        }
    }
}