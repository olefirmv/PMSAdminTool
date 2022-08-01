using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSAdminProvisionTool.BL
{
    public class GeneralCreator
    {
        public bool CreateDBWithTable()
        {
            bool result = true;

            result = result && Helper.CreateDB();
            result = result && Helper.CreateFormTable();
            result = result && Helper.CreateCredentialTable();
            result = result && Helper.CreatePrivelegeTable();
            result = result && Helper.CreateRoleTable();
            result = result && Helper.CreateEmployeeTable();
            result = result && Helper.CreateDocumentTable();
            result = result && Helper.CreateProjectTable();
            result = result && Helper.CreateMemberTable();
            result = result && Helper.CreateProjectEmployeeTable();
            result = result && Helper.CreateSectionTable();
            result = result && Helper.CreateProjectRoleTable();
            result = result && Helper.CreateComponentTable();
            result = result && Helper.CreateStageTable();
            result = result && Helper.CreateStageLineTable();

            return result;
        }
    }
}
