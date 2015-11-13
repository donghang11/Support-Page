using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupportPage
{
    public class ExportExcel
    {
        public void ExportData(GridView obj)
        {
            try
            {
                

            }
            catch
            {
            }
        }

        public void ChangeControlsToValue(Control gv)
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();         
            string name = String.Empty;
            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }

                //else if (gv.Controls[i].GetType() == typeof(DropDownList))
                //{
                //    //l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                //    gv.Controls.Remove(gv.Controls[i]);
                //    //gv.Controls.AddAt(i, l);
                //}

                else if (gv.Controls[i].GetType() == typeof(HyperLink))
                {
                    //l.Text = (gv.Controls[i] as HyperLink).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    //gv.Controls.AddAt(i, l);                
                }
                    
                else if (gv.Controls[i].GetType() == typeof(GridView))
                {
                    //l.Text = (gv.Controls[i] as HyperLink).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    //gv.Controls.AddAt(i, l);                
                }

                else if (gv.Controls[i].GetType() == typeof(TableHeaderCell))
                {
                    l.Text = (gv.Controls[i] as HyperLink).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);                
                }


                //else if (gv.Controls[i].GetType() == typeof(CheckBox))
                //{
                //    l.Text = (gv.Controls[i] as HyperLink).Text;
                //    gv.Controls.Remove(gv.Controls[i]);
                //    gv.Controls.AddAt(i, l);
                //}   

                if (gv.Controls[i].HasControls())
                {
                    ChangeControlsToValue(gv.Controls[i]);
                } 

            }
        }

    }

}