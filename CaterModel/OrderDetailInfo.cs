using System;

namespace CaterModel
{
    [Serializable]
    public partial class OrderDetailInfo
    {
        private int _oid;
        private int? _orderid;
        private int? _dishid;
        private int? _count;

        public int OId
        {
            set { _oid = value; }
            get { return _oid; }
        }

        public int? OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        public int? DishId
        {
            set { _dishid = value; }
            get { return _dishid; }
        }

        public int? Count
        {
            set { _count = value; }
            get { return _count; }
        }
    }
}

