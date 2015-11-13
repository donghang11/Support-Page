using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupportPage.Models;

namespace SupportPage.ActNum
{
    public class CalActs
    {
        public List<Node> caselist = new List<Node>();

        public CalActs()
        {
            Support s = new Support();
            List<Incident> cases = new List<Incident>();
            foreach (Incident i in s.Incidents.ToList())
            {
                int counter = 0;

                foreach (action_model a in s.Actions.ToList())
                {
                    if (a.incident == i.id)
                        counter += 1;
                }

                Node no = new Node(counter, null);
                if (i.parent != null)
                {
                    no.parent = i.parent;
                }
                caselist.Add(no);
            }
        }
    }
}