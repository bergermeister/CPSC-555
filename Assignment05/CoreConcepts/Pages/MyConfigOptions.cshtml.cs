using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CoreConcepts.Pages
{
   using Models;

   public class MyConfigOptionsModel : PageModel
   {
      public string Message { get; set; }
      IOptions< CompanyOptions > _copt;
      IOptions< EmailSettingsOptions > _emopt;

      public MyConfigOptionsModel( IOptions<CompanyOptions> copt, IOptions<EmailSettingsOptions> emopt )
      {
         _copt = copt;
         _emopt = emopt;
      }

      public void OnGet( )
      {
         string companyName = _copt.Value.CompanyName;
         string managerFirstName = _copt.Value.Manager.FirstName;
         string managerLastName = _copt.Value.Manager.LastName;
         string out1 = "Company Name:" + companyName + "<br/>" + "Manager:" + managerFirstName + " " + managerLastName + "<br/>";
         string emailFrom = _emopt.Value.EmailSettings.From;
         string emailSubject = _emopt.Value.EmailSettings.Subject;
         string emailSmtp = _emopt.Value.EmailSettings.Smtp;
         string out2 = "Email From:" + emailFrom + "<br/>" + "Subject:" + emailSubject + " SMPT:" + emailSmtp + "<br/>";
         Message = out1 + out2;
      }
   }
}
