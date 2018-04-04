using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Script.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace RecruitmentSystem
{
    /// <summary>
    /// Summary description for RecuruitmentService
    /// </summary>
    [WebService(Namespace = "http://kpmgSL-recruitment.com/")]
    // http://tempuri.org/ default namespace
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RecuruitmentService : System.Web.Services.WebService
    {
        RecruitmentSystemEntities em = new RecruitmentSystemEntities();

        JavaScriptSerializer js = new JavaScriptSerializer();


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
            json = js.Serialize(roles);
            return json;
        }

        //Returnining in Role table in List value
        [WebMethod]
        public List<Role> LoadRoles()
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
            Context.Response.Write(js.Serialize(myRoles));
        }


        // Getting Nationality 
        [WebMethod]
        public void getNationality()
        {
            try
            {
                var nationals = new List<Nationality>();
                nationals = (from a in em.Nationalities select a).ToList();
                Context.Response.Write(js.Serialize(nationals));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        // Getting Nationality 
        [WebMethod]
        public void getNationalityAsSelectedValues()
        {
            try
            {
               
                var nationals = (from a in em.Nationalities select new {a.Name,a.Remarks}).ToList();
                Context.Response.Write(js.Serialize(nationals));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addRoleTest(int  i)
        {
           if (i==3)
            {
                int k = 2;
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(js.Serialize(k));
                Debug.WriteLine("Post method Success");
            }

            else
            {
                Debug.WriteLine("Post method Failure");
            }

         }
        /**
           This method pass the name as string and address as Address array
        */

        [WebMethod]
        public void addAddress(string name, string address)
        {
            int res=-9;

            try {
                Address [] addr= JsonConvert.DeserializeObject<Address[]>(address);
                Address addre = new Address();
                foreach (var dd in addr)
                {
                    Debug.WriteLine( "Street Name is"+dd.streetName);

                    addre.name = name;
                    addre.streetName = dd.streetName;
                    addre.area = dd.area;
                    em.Addresses.Add(addre);
                    res = em.SaveChanges();
                }
                // if sucessful insertion 
                if (res > 0)
                {
                    int k = 2;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Clear();
                    Context.Response.ContentType = "application/json";
                    Context.Response.Write(js.Serialize(k));
                    Debug.WriteLine("Address Data Sucessfully Inserted");
                }
                else
                {
                    Debug.WriteLine("Address Data Not Inserted");
                }

                /**
                  if Not in array format "[{"x":"y","l":"m"}]"
                */
                //var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(address);
                //foreach (var kv in dict)
                //{

                //    Debug.WriteLine("Key Value Pair is" + kv.Key + ":" + kv.Value);

                //    Debug.WriteLine("Value is" + kv.Value);
                //}
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

    }
}
