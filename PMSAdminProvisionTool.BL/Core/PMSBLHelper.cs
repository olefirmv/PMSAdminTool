using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSAdminProvisionTool.BL.Core
{
    public class PMSBLHelper
    {
        public static string EncryptPassword(string password)
        {
            string ret = "";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            ret = System.Text.Encoding.ASCII.GetString(data);

            return ret;
        }
    }
}
