using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
using CaterModel;

namespace CaterDal
{
    public partial class ManagerInfoDal
    {
        public IList<ManagerInfo> GetList()
        {
            string sql = "select * from ManagerInfo";
            DataTable dt = SqLiteHelper.GetDataTable(sql);
            IList<ManagerInfo> list = new List<ManagerInfo>();
            foreach (DataRow dataRow in dt.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    MId = Convert.ToInt32(dataRow["mid"]),
                    MName = dataRow["MName"].ToString(),
                    MPwd = dataRow["MPwd"].ToString(),
                    MType = Convert.ToInt32(dataRow["MType"])
                });
            }
            return list;
        }

        public int Insert(ManagerInfo mi)
        {
            string sql = @"insert into ManagerInfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@name", mi.MName),
                new SQLiteParameter("@pwd",Md5Helper.EncryptString(mi.MPwd)),
                new SQLiteParameter("@type",mi.MType)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(ManagerInfo mi)
        {
            IList<SQLiteParameter> list = new List<SQLiteParameter>();
            string sql = "update ManagerInfo set mname=@name";
            list.Add(new SQLiteParameter("@name", mi.MName));
            if (!mi.MPwd.Equals("original?"))
            {
                sql += ", mpwd=@pwd";
                list.Add(new SQLiteParameter("@pwd", Md5Helper.EncryptString(mi.MPwd)));
            }
            sql += ", mtype=@type where mid=@id";
            list.Add(new SQLiteParameter("@type", mi.MType));
            list.Add(new SQLiteParameter("@id", mi.MId));
            return SqLiteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        public int Delete(int id)
        {
            string sql = "delete from ManagerInfo where mid = @id";
            SQLiteParameter parameter = new SQLiteParameter("@id", id);
            return SqLiteHelper.ExecuteNonQuery(sql, parameter);
        }

        public ManagerInfo GetByName(string name)
        {
            ManagerInfo mi = null;
            string sql = "select * from ManagerInfo where mname = @name";
            SQLiteParameter parameter = new SQLiteParameter("@name", name);
            DataTable dt = SqLiteHelper.GetDataTable(sql, parameter);
            if (dt.Rows.Count > 0)
            {
                mi = new ManagerInfo()
                {
                    MId = Convert.ToInt32(dt.Rows[0][0]),
                    MName = name,
                    MPwd = dt.Rows[0][2].ToString(),
                    MType = Convert.ToInt32(dt.Rows[0][3])
                };
            }
            return mi;
        }
    }
}
