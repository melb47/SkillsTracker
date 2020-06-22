using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        [HttpGet]
        [Route("/skills/")]
        public IActionResult Index()
        {
            string html = "<h1>Skills Tracker</h1>" +
                "\n<h2>Coding Languages</h2>" +
                "<ol>" +
                "<li name='cs'>C#</li>" +
                "<li name='python'>Python</li>" +
                "<li name='cp'>C++</li>" +
                "</ol>";
            return Content(html, "text/html");
        }

        [HttpGet("/skills/form")]
        public IActionResult Form()
        {
            string formText = "<form method='post' action='/skills/form'>" +
                "<label>Date:" +
                "<input type='date' name='date'>" +
                "</label><br>" +
                    SelectBox("cs", "C#") + "<br>" +
                    SelectBox("python", "Python") + "<br>" +
                    SelectBox("cp", "C++") + "<br>" +
                "<input type='submit'>" +
                "</form>";
            return Content(formText, "text/html");
        }

        [Route("/skills/form")]
        [HttpPost]
        public IActionResult DisplayResults(string date, string cs, string python, string cp)
        {
            string results = $"<h1> {date} </h1>\n<ol>" +
                "<li>C#: "+ cs +"</li>" +
                $"<li>Python: {python}</li>" +
                $"<li>C++: {cp}</li>" +
                "</ol>";
            return Content(results, "text/html");
        }
        private string SelectBox(string name, string label)
        {
            return $"<label>{label}" +
                        $"<select name='{name}'>" +
                            "<option value=''>--Select your experience level--</option>" +
                            "<option value='novice'>Just the basics</option>" +
                            "<option value='competent'>Making programs and apps</option>" +
                            "<option value='master'>Master of the code</option>" +
                        "</select>" +
                    "</label>";
        }
    }
}
