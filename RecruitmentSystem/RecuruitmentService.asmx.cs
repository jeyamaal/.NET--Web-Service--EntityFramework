using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Script.Services;

namespace RecruitmentSystem
{
    /// <summary>
    /// Summary description for RecuruitmentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RecuruitmentService : System.Web.Services.WebService
    {
        RecruitmentSystemEntities em = new RecruitmentSystemEntities();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        // Returning in String Value in JSON
        [WebMethod]
        public string getRoleDetails()
        {
            var json = "";
            var roles = from a in em.Roles select a.role_name;
            string ss = roles.ToString();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            json = jss.Serialize(roles);
            return json;
        }

        //Returnining in Role table in List value
        [WebMethod]
        public List <Role> LoadRoles()
        {

            var myRoles = new List<Role>();
            myRoles = (from a in em.Roles select a).ToList();
            return myRoles;
        }

        //[WebMethod]
        //public ActionResult roleDetails1() {

            //var movies = new List<object>();

            //movies.Add(new { Title = "Ghostbusters", Genre = "Comedy", Year = 1984 });
            //movies.Add(new { Title = "Gone with Wind", Genre = "Drama", Year = 1939 });
            //movies.Add(new { Title = "Star Wars", Genre = "Science Fiction", Year = 1977 });

            //return Json.Encode(movies);

            //var myRoles = new List<Role>();
            //myRoles = (from a in em.Roles select a).ToList();

            //return new JsonResult() { Data = myRoles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            //return Json(movies, JsonRequestBehavior.AllowGet);

            // var movies = new List<object>();

            //var movies = new List<object>();
            //var roles = (from a in em.Roles select a).ToList();
            // movies.Add(roles);
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //json = jss.Serialize(roles);
            // Role r = new Role();
            //return Json(movies, JsonRequestBehavior.AllowGet);
      //  }

        //[WebMethod]
        //public ActionResult Movies()
        //{
        //    var movies = new List<object>();

        //    movies.Add(new { Title = "Ghostbusters", Genre = "Comedy", Year = 1984 });
        //    movies.Add(new { Title = "Gone with Wind", Genre = "Drama", Year = 1939 });
        //    movies.Add(new { Title = "Star Wars", Genre = "Science Fiction", Year = 1977 });

        //    return Json(movies, JsonRequestBehavior.AllowGet);
        //}


        // List of Json
       // [WebMethod]
        [WebMethod]
        public void getRole2()
        {
            var myRoles = new List<Role>();
            myRoles = (from a in em.Roles select a).ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(myRoles));
        }


    }
}
