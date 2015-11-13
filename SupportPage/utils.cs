using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace SupportPage
{
    public class utils
    {
        public string caselistquery = "with cte(id, parent,description, level, model, drafter, reportdate, sales,supportteam, technote, instruction, faq,allcompany, other,handler,enddate," 
            +"lastupdatedate,cusname,discom,cuscom,dispname,sort) as (select id, parent,description, 1 level, model, drafter, reportdate, sales,supportteam, technote, instruction, faq,allcompany, other,"
            + "handler,enddate,lastupdatedate,cusname,discom,cuscom,dispname, CONVERT (varchar(20), DATEDIFF(second, '2050-1-1', reportdate), 20)  + description from Incident a WHERE a.parent is null union ALL select b.id, b.parent,REPLICATE ('|-   ' , level) + b.description,"
            +"level+1, b.model,b.drafter,b.reportdate, b.sales,b.supportteam, b.technote, b.instruction, b.faq, b.allcompany, b.other,b.handler,b.enddate,b.lastupdatedate,b.cusname,b.discom,b.cuscom,b.dispname,"
            +"RTRIM(sort) + '|- ' + b.description from Incident b join cte c on b.parent = c.id) select id, parent,description, model, drafter, reportdate, sales,supportteam, technote, instruction, faq,allcompany,"
            +"other,handler,enddate,lastupdatedate,cusname,discom,cuscom,dispname from cte";

        public string interfaceUntil(int option)
        {
            switch (option)
            {
                case 1:
                    return "~/Images/l1.jpg";
                case 2:
                    return "~/Images/l2.jpg";
                case 3:
                    return "~/Images/l3.jpg";
                case 4:
                    return "~/Images/l4.jpg";
                case 5:
                    return "~/Images/l5.jpg";
                case 6:
                    return "~/Images/l6.jpg";
                case 7:
                    return "~/Images/l7.jpg";
                case 8:
                    return "~/Images/l8.jpg";
                case 9:
                    return "~/Images/l9.jpg";
                default:
                    return "";
            }
        }

        public string interfaceUntilToText(int option)
        {
            switch (option)
            {
                case 1:
                    return "~/Images/l1.jpg";
                case 2:
                    return "~/Images/l2.jpg";
                case 3:
                    return "~/Images/l3.jpg";
                case 4:
                    return "~/Images/l4.jpg";
                case 5:
                    return "~/Images/l5.jpg";
                case 6:
                    return "~/Images/l6.jpg";
                case 7:
                    return "~/Images/l7.jpg";
                case 8:
                    return "~/Images/l8.jpg";
                case 9:
                    return "~/Images/l9.jpg";
                default:
                    return "";
            }
        }
    } 
}