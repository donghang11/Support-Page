using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupportPage.Models;

namespace SupportPage.ActNum
{
    public class Node
    {
        public int counter;
        public int? parent;

        public Node(int _counter, int? _parent)
        {
            counter = _counter;
            parent = _parent;
        }            
    }
}