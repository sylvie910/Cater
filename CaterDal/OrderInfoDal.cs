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
    public partial class OrderInfoDal
    {
        public int KaiOrder(int tableId)
        {
            string sql = "insert into orderinfo(odate,ispay,tableId) values(datetime('now', 'localtime'),0,@tid);" +
                "update tableinfo set tIsFree=0 where tid=@tid;" +
                "select oid from orderinfo order by oid desc limit 0,1";
            SQLiteParameter p = new SQLiteParameter("@tid", tableId);
            return Convert.ToInt32(SqLiteHelper.ExecuteScalar(sql,p));
        }

        public int GetOrderIdByTableId(int tableId)
        {
            string sql = "select oid from orderinfo where tableId=@tableid and ispay=0";
            SQLiteParameter p = new SQLiteParameter("@tableId", tableId);
            return Convert.ToInt32(SqLiteHelper.ExecuteScalar(sql, p));
        }

        public int DianCai(int orderid, int dishId)
        {
            string sql = "select count(*) from orderDetailInfo where orderId=@oid and dishId=@did";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid", orderid),
                new SQLiteParameter("@did", dishId)
            };
            int count = Convert.ToInt32(SqLiteHelper.ExecuteScalar(sql, ps));
            if (count > 0)
            {
                sql = "update orderDetailInfo set count=count+1 where orderId=@oid and dishId=@did";
            }
            else
            {
                sql = "insert into orderDetailInfo(orderid,dishId,count) values(@oid,@did,1)";
            }
            return SqLiteHelper.ExecuteNonQuery(sql, ps);
        }

        public int UpdateCountByOId(int oid, int count)
        {
            string sql = "update orderDetailInfo set count=@count where oid=@oid";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@count", count),
                new SQLiteParameter("@oid", oid)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, ps);
        }

        public List<OrderDetailInfo> GetDetailList(int orderId)
        {
            string sql = @"select odi.oid,di.dTitle,di.dPrice,odi.count from dishinfo as di
            inner join orderDetailInfo as odi
            on di.did=odi.dishid
            where odi.orderId=@orderid";
            SQLiteParameter p = new SQLiteParameter("@orderid", orderId);

            DataTable dt = SqLiteHelper.GetDataTable(sql, p);
            List<OrderDetailInfo> list = new List<OrderDetailInfo>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new OrderDetailInfo()
                {
                    OId = Convert.ToInt32(row["oid"]),
                    DTitle = row["dtitle"].ToString(),
                    DPrice = Convert.ToDecimal(row["dprice"]),
                    Count = Convert.ToInt32(row["count"])
                });
            }

            return list;
        }

        public decimal GetTotalMoneyByOrderId(int orderid)
        {
            string sql = @"	select sum(oti.count*di.dprice) 
	            from orderdetailinfo as oti
	            inner join dishinfo as di
	            on oti.dishid=di.did
	            where oti.orderid=@orderid";
            SQLiteParameter p = new SQLiteParameter("@orderid", orderid);

            object obj = SqLiteHelper.ExecuteScalar(sql, p);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(obj);
        }

        public int SetOrderMomey(int orderid, decimal money)
        {
            string sql = "update orderinfo set omoney=@money where oid=@oid";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@money", money),
                new SQLiteParameter("@oid", orderid)
            };
            return SqLiteHelper.ExecuteNonQuery(sql, ps);
        }

        public int DeleteDetailById(int oid)
        {
            string sql = "delete from orderDetailInfo where oid=@oid";
            SQLiteParameter p = new SQLiteParameter("@oid", oid);
            return SqLiteHelper.ExecuteNonQuery(sql, p);
        }

        public int Pay(bool isUseMoney, int memberId, decimal payMoney, int orderid, decimal discount)
        {
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["itcastCater"].ConnectionString))
            {
                int result = 0;
                conn.Open();
                SQLiteTransaction tran = conn.BeginTransaction();
                SQLiteCommand cmd = new SQLiteCommand {Transaction = tran};
                try
                {
                    SQLiteParameter[] ps;
                    var sql = "";
                    if (isUseMoney)
                    {
                        sql = "update MemberInfo set mMoney=mMoney-@payMoney where mid=@mid";
                        ps = new[]
                        {
                            new SQLiteParameter("@payMoney", payMoney),
                            new SQLiteParameter("@mid", memberId)
                        };
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(ps);
                        result += cmd.ExecuteNonQuery();
                    }
                    sql = "update orderInfo set isPay=1,memberId=@mid,discount=@discount where oid=@oid";
                    ps = new[]
                    {
                        new SQLiteParameter("@mid", memberId),
                        new SQLiteParameter("@discount", discount),
                        new SQLiteParameter("@oid", orderid)
                    };
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(ps);
                    result += cmd.ExecuteNonQuery();

                    sql = "update tableInfo set tIsFree=1 where tid=(select tableId from orderinfo where oid=@oid)";
                    SQLiteParameter p = new SQLiteParameter("@oid", orderid);
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(p);
                    result += cmd.ExecuteNonQuery();

                    tran.Commit();
                }
                catch
                {
                    result = 0;

                    tran.Rollback();
                }
                return result;
            }
        }
    }
}
