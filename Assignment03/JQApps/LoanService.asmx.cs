using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace JQApps
{
    /// <summary>
    /// Summary description for LoanService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LoanService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod]
        public double ComputeMonthlyPayment(double amt, double rate, double dur)
        {
            double monthly = amt * rate / 1200.0 *
                Math.Pow(rate / 1200.0 + 1, dur) / (Math.Pow(rate / 1200.0 + 1, dur) - 1);
            return monthly;
        }

        [WebMethod]
        [ScriptMethod]
        public double ComputeTotalPayment(double amt, double rate, double dur)
        {
            double total = amt * Math.Pow((1 + rate / 1200.0), dur / 12.0);
            return total;
        }
    }
}
