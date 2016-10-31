using E_MDsTest.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace E_MDsTest.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        

        public Person()
        {
            
        }

        public Person(DataRow row)
        {
            if (!DBNull.Value.Equals(row["first_name"]))
                FirstName = (string)row["first_name"];
            if (!DBNull.Value.Equals(row["last_name"]))
                LastName = (string)row["last_name"];
            if (!DBNull.Value.Equals(row["gender"]))
                Gender = (string)row["gender"];
            if (!DBNull.Value.Equals(row["dob"]))
                DOB = (string)row["dob"];
            FullName = FirstName + " " + LastName;
        }
    }

    public class PersonModelCollection : ModelCollection<Person>
    {
        public override void PopulateContents()
        {
            SQLAccess db = new SQLAccess();
            db.Procedure = "GetPeople";
            db.ExecuteProcedure();
            if (db.HasData)
                foreach (DataRow person in db.Response.Rows)
                    this.Contents.Add(new Person(person));
        }
    }
}