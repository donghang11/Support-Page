using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportPage
{
    public class ModelUtil
    {
        public string model(int type)
        {
            switch (type)
            {
                case 1:
                    return "GigaE";
                case 2:
                    return "USB2";
                case 3:
                    return "USB3";
                case 4:
                    return "Camera Link";
                case 5:
                    return "DVI/SDI";
                case 6:
                    return "Analog";
                case 7:
                    return "TV format";
                case 8:
                    return "Industry";
                default:
                    return null;
            }
        }
    }
}