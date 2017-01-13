using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class ManagerInfoBll
    {
        ManagerInfoDal dal = new ManagerInfoDal();
        public IList<ManagerInfo> GetList()
        {
            return dal.GetList();
        }

        public bool Add(ManagerInfo mi)
        {
            return dal.Insert(mi) > 0;
        }

        public bool Edit(ManagerInfo mi)
        {
            return dal.Update(mi) > 0;
        }

        public bool Remove(int id)
        {
            return dal.Delete(id) > 0;
        }

        public LoginState Login(string name, string pwd, out int type)
        {
            ManagerInfo mi = dal.GetByName(name);
            type = -1;
            if (mi == null)
            {
                return LoginState.NameError;
            }
            if (mi.MPwd.Equals(Md5Helper.EncryptString(pwd)))
            {
                type = mi.MType;
                return LoginState.Ok;
            }
            return LoginState.PwdError;
        }
    }
}
