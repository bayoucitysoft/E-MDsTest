using E_MDsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_MDsTest.Controllers
{
    public class PeopleController : ApiController
    {
        private PersonModelCollection _people; 

        public PeopleController()
        {
            _people = new PersonModelCollection();
            _people.PopulateContents();
        }

        [HttpGet]
        public IHttpActionResult FullNames()
        {
            List<string> Names = new List<string>();
            IHttpActionResult response = null;
            foreach (var person in _people.Contents)
                Names.Add(person.FullName);
            response = Ok(Names);
            return response; 
        }

        [HttpPost]
        public IHttpActionResult Person(string fullName)
        {
            IHttpActionResult response = null;
            response = Ok(_people.Contents.Where(person => person.FullName == fullName));
            return response; 
        }
    }
}
