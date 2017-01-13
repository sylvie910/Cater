using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class MemberTypeInfoBll
    {
        private MemberTypeInfoDal _dal;

        public MemberTypeInfoBll()
        {
            _dal = new MemberTypeInfoDal();
        }

        public IList<MemberTypeInfo> GetList()
        {
            return _dal.GetList();
        }

        public bool Add(MemberTypeInfo mti)
        {
            return _dal.Insert(mti) > 0;
        }

        public bool Edit(MemberTypeInfo mti)
        {
            return _dal.Update(mti) > 0;
        }

        public bool Remove(int id)
        {
            return _dal.Delete(id) > 0;
        }
    }
}
