using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class MemberInfoDal
    {
        public IList<MemberInfo> GetList(Dictionary<string, string> dictionary)
        {
            string sql = "select mi.*, mti.mType as MTypeTitle,mti.mDiscount " +
                         "from MemberInfo as mi " +
                         "inner join MemberTypeInfo as mti " +
                         "on mi.mTypeId=mti.mid " +
                         "where mi.mIsDelete=0 ";
            IList<SQLiteParameter> parameters = new List<SQLiteParameter>();
            if (dictionary.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in dictionary)
                {
                    sql += " and mi." + pair.Key + " like @" + pair.Key;
                    parameters.Add(new SQLiteParameter("@" + pair.Key, "%" + pair.Value + "%"));
                }
            }
            DataTable dt = SqLiteHelper.GetDataTable(sql, parameters.ToArray());
            IList<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPhone = row["mphone"].ToString(),
                    MMoney = Convert.ToDecimal(row["mmoney"]),
                    MTypeId = Convert.ToInt32(row["MTypeId"]),
                    MTypeTitle = row["MTypeTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["mdiscount"])
                });
            }
            return list;
        }

        public int Insert(MemberInfo mi)
        {
            string sql =
                "insert into MemberInfo(mtypeid,mname,mphone,mmoney,mIsDelete) values(@tid,@name,@phone,@money,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@tid", mi.MTypeId),
                new SQLiteParameter("@name", mi.MName),
                new SQLiteParameter("@phone", mi.MPhone),
                new SQLiteParameter("@money", mi.MMoney)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update(MemberInfo mi)
        {
            string sql = "update memberinfo set mname=@name,mphone=@phone,mmoney=@money,mtypeid=@tid where mid=@id";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@name", mi.MName),
                new SQLiteParameter("@phone", mi.MPhone),
                new SQLiteParameter("@money", mi.MMoney),
                new SQLiteParameter("@tid", mi.MTypeId),
                new SQLiteParameter("@id", mi.MId)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }
        public int Delete(int id)
        {
            string sql = "update memberinfo set mIsDelete=1 where mid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqLiteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
