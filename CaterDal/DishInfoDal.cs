﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class DishInfoDal
    {
        public List<DishInfo> GetList(Dictionary<string, string> dic)
        {
            string sql = @"select di.*,dti.dtitle as dTypeTitle 
                from dishinfo as di
                inner join dishtypeinfo as dti
                on di.dtypeid=dti.did
                where di.dIsDelete=0 and dti.dIsDelete=0";

            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    //sql += " and di.dtitle like @dtitle";

                    sql += " and di." + pair.Key + " like @" + pair.Key;
                    listP.Add(new SQLiteParameter("@" + pair.Key, "%" + pair.Value + "%"));
                }
            }

            DataTable dt = SqLiteHelper.GetDataTable(sql, listP.ToArray());

            List<DishInfo> list = new List<DishInfo>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["did"]),
                    DTitle = row["dtitle"].ToString(),
                    DTypeTitle = row["dtypeTitle"].ToString(),
                    DPrice = Convert.ToDecimal(row["dprice"])
                });
            }

            return list;
        }

        public int Insert(DishInfo di)
        {
            string sql = "insert into dishinfo(dtitle,dtypeid,dprice,dIsDelete) values(@title,@tid,@price,0)";
            SQLiteParameter[] p =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@tid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
            };

            return SqLiteHelper.ExecuteNonQuery(sql, p);
        }

        public int Update(DishInfo di)
        {
            string sql = "update dishinfo set dtitle=@title,dtypeid=@tid,dprice=@price where did=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@tid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@id",di.DId)
            };

            return SqLiteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            string sql = "update dishinfo set dIsDelete=1 where did=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);

            return SqLiteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
