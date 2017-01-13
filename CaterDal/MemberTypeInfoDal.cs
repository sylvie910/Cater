using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class MemberTypeInfoDal
    {
        public IList<MemberTypeInfo> GetList()
        {
            string sql = "select * from MemberTypeInfo where MIsDelete=0";
            DataTable dt = SqLiteHelper.GetDataTable(sql);
            IList<MemberTypeInfo> list = new List<MemberTypeInfo>();
            foreach (DataRow dataRow in dt.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    MId = Convert.ToInt32(dataRow["mid"]),
                    MType = dataRow["mtype"].ToString(),
                    MDiscount = Convert.ToDecimal(dataRow["MDiscount"])
                });
            }
            return list;
        }

        public int Insert(MemberTypeInfo mti)
        {
            string sql = "insert into MemberTypeInfo (MType, MDiscount, MIsDelete) values (@type, @discount, 0)";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@type", mti.MType),
                new SQLiteParameter("@discount", mti.MDiscount)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(MemberTypeInfo mti)
        {
            string sql = "update memberTypeInfo set mtype=@type,mdiscount=@discount where mid=@id";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@type", mti.MType),
                new SQLiteParameter("@discount", mti.MDiscount),
                new SQLiteParameter("@id", mti.MId),
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(int id)
        {
            string sql = "update MemberTypeInfo set MIsDelete = 1 where MId= @id";
            SQLiteParameter parameter = new SQLiteParameter("@id", id);
            return SqLiteHelper.ExecuteNonQuery(sql, parameter);
        }
    }
}
