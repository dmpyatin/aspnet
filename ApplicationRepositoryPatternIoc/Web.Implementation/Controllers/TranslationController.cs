using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using Web.Implementation.Models;
using Web.Implementation.Infrastructure;
using System.Text.RegularExpressions;


namespace Web.Implementation.Controllers
{
    public class TranslationController : Controller
    {
        private IDataService DataService;
        public TranslationController(IDataService dataService)
        {
            this.DataService = dataService;
        }

        public string Replace(string text, string start, string end, int? cultureId)
        {
            string regex = string.Format("{0}(.*?){1}", Regex.Escape(start), Regex.Escape(end));
            var m = Regex.Matches(text, regex, RegexOptions.Singleline).Cast<Match>().Select(match => match.Groups[1].Value);
            foreach (var p in m)
            {
                text = text.Replace(start + p + end, DataService.GetTranslation(p, cultureId).Text);
            }
            return text;
        }

        public ContentResult TranslateView(ViewResult view, ControllerContext context, int? cultureId)
        {

            if (cultureId == null)
                cultureId = 1;

            var text = view.Capture(context);
            text = Replace(text, "&lt;tag&gt;", "&lt;/tag&gt;", cultureId);
            text = Replace(text, "<tag>", "</tag>", cultureId);
            var scriptNames = new List<string>() { "testscript.js" , "testscript2.js" };
            var translationsList = new List<Translation>(); 
            foreach (var sn in scriptNames)
            {
                var translations = DataService.GetTranslations(cultureId, sn).ToList();
                foreach(var t in translations){
                    if (!translationsList.Any(p => p.Name == t.Name))
                    {
                        translationsList.Add(t);
                    }
                }
            }

            string addBlock = "<script>";
            foreach (var t in translationsList)
            {
                addBlock += "var " + t.Name + " = \"" + t.Text + "\"; ";
            }
            addBlock += "</script>";

            var splitText = text.Split(new string[] {"</body>"}, StringSplitOptions.RemoveEmptyEntries);
            text = splitText[0] + addBlock + "</body>" + splitText[1];
            return Content(text);
        }

 
        public string GetJsonTranslation(TranslationPageQueryModel model)
        {

            var translations = DataService.GetTranslations(model.cultureId, model.spaceName).ToList();
  
            var result = "{\"dev\" : {\"translation\": {";

            for (int i = 0; i < translations.Count; ++i)
            {
                if (i == translations.Count - 1)
                    result += "\"" + translations[i].Name + "\":\"" + translations[i].Text + "\" ";
                else
                    result += "\"" + translations[i].Name + "\":\"" + translations[i].Text + "\", ";
            }
            
            result += "}}}";


            return result;
        }

    }
}