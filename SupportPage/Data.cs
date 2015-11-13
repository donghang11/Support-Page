using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace SupportPage
{
    public class Data:ArrayList
    {

        public void AddWithNothing(object value)
        {
            if (value == null)
                Add("Nothing here yet...");
            else
                Add(value); 
        }
    }
}