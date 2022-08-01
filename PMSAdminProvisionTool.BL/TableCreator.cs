using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PMSAdminProvisionTool.BL
{
    public class TableCreator
    {
        public void Create(string sqlQuery, bool createDB)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(createDB ? Helper.ConnectionStringForCreating : Helper.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;

                        var scripts = Regex.Split(sqlQuery, @"\r\nGO", RegexOptions.Multiline);
                        foreach (var splitScript in scripts)
                        {
                            cmd.CommandText = splitScript;
                            cmd.ExecuteNonQuery();
                        }

                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
