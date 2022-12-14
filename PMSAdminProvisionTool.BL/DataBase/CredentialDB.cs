using PMSAdminProvisionTool.BL.Core;
using PMSAdminProvisionTool.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSAdminProvisionTool.BL.DataBase
{
    public class CredentialDB : DataBase
    {
        public override bool UpdateRecord<TEntity>(TEntity record)
        {
            bool result = true;

            if (record != null && record is Credential)
            {
                try
                {
                    using (DataContext dC = new DataContext(ConnectionString))
                    {
                        Credential obj = record as Credential;
                        var tempObj = dC.GetTable<Credential>().First(x => x.Login == obj.Login);
                        if (tempObj != null)
                        {
                            tempObj.Password = obj.Password;
                            dC.SubmitChanges();
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //
                    result = false;
                }

            }
            else
            {
                result = false;
            }

            return result;
        }

        public override bool InsertMethod<TEntity>(TEntity obj)
        {
            bool result = true;
            if (obj != null && obj is Credential)
            {
                try
                {
                    using (DataContext dC = new DataContext(ConnectionString))
                    {
                        Credential credential = obj as Credential;

                        credential.Password = PMSBLHelper.EncryptPassword(credential.Password);

                        dC.GetTable<Credential>().InsertOnSubmit(credential);
                        dC.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool IsExists(string login)
        {
            bool isExist = false;

            try
            {
                using (DataContext dC = new DataContext(ConnectionString))
                {
                    Credential credential = dC.GetTable<Credential>().First(x => x.Login == login);

                    if (credential != null)
                    {
                        isExist = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isExist;
        }

        public bool Auth(Credential credential)
        {
            bool auth = false;

            try
            {
                using (DataContext dc = new DataContext(ConnectionString))
                {
                    var resCredential = dc.GetTable<Credential>().First(x => x.Login == credential.Login && PMSBLHelper.EncryptPassword(credential.Password) == x.Password);
                    if (resCredential != null)
                    {
                        auth = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return auth;
        }

        private bool Validate()
        {
            return true;
        }
    }
}
