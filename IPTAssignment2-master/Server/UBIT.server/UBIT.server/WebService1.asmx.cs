using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication3
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
       public static List <SubjectsData> subjectsData= new List<SubjectsData>();
        public static List<StudentsData> studentsData = new List<StudentsData>();
        public void AddSubjects()
        {
            string subjectsStr = HttpContext.Current.Request.Params["request"];
            SubjectsData subjects = JsonConvert.DeserializeObject<SubjectsData>(subjectsStr);
            subjectsData.Add(subjects);
        }

        public string GetData()
        {
            string subjectsReturn = JsonConvert.SerializeObject(subjectsData);
            return subjectsReturn;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        public class StudentsData
        {
            public string name { get; set; }
            public int noOfSub { get; set; }
            public SubjectsData subjects { get; set; }
        }
        public class SubjectsData
        {
            public string subjectName { get; set; }
            public int subMarks { get; set; }
           
        }
    }
}
