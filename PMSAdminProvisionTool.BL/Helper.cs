using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSAdminProvisionTool.BL
{
    public class Helper
    {
        public static string ConnectionString { get; set; } = "Data Source=localhost;Initial Catalog = PMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string ConnectionStringForCreating { get; set; } = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static bool CreateComponentTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateComponentQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateDocumentTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateDocumentQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateEmployeeTable()
        { 
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateEmployeeQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateCredentialTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateCredentialQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateFormTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateFormQuery(), false);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateMemberTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateMemberQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreatePrivelegeTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreatePrivelegeQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateProjectTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateProjectQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateProjectEmployeeTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateProjectEmployeeQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateProjectRoleTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateProjectRoleQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateRoleTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateRoleQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateSectionTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateSectionQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static bool CreateStageTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateStageQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }


            return ret;
        }

        public static bool CreateStageLineTable()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreateStageLineQuery(), true);
            }
            catch (Exception ex)
            {
                ret = false;
            }


            return ret;
        }

        public static bool CreateDB()
        {
            bool ret = true;

            try
            {
                TableCreator creator = new TableCreator();
                creator.Create(Query.CreatePMSDBQuery(), true);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }

            return ret;
        }
    }
}
