using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_MDsTest.Models
{
    public abstract class ModelCollection<T>
    {
        public List<T> Contents { get; set; }

        public ModelCollection()
        {
            Contents = new List<T>();
        }

        public abstract void PopulateContents();
    }
}