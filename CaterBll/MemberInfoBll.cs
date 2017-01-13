using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class MemberInfoBll
    {
        private MemberInfoDal _dal;

        public MemberInfoBll()
        {
            _dal = new MemberInfoDal();
        }

        public IList<MemberInfo> GetList(Dictionary<string, string> dictionary)
        {
            return _dal.GetList(dictionary);
        }

        public bool Add(MemberInfo mi)
        {
            return _dal.Insert(mi) > 0;
        }

        public bool Edit(MemberInfo mi)
        {
            return _dal.Update(mi) > 0;
        }
        public bool Remove(int id)
        {
            return _dal.Delete(id) > 0;
        }
    }
}
