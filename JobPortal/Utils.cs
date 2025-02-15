﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal
{
    public class Utils
    {
        public static bool isValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtension = { ".jpg", ".jpeg", ".png" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        public static bool isValidExtension4Resume(string fileName)
        {
            bool isValid = false;
            string[] fileExtension = { ".doc", ".docx", ".pdf" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }

}
