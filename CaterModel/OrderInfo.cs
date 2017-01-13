using System;

namespace CaterModel
{

    [Serializable]
    public partial class OrderInfo
    {
        private int _oid;
        private int? _memberid;
        private DateTime? _odate;
        private decimal? _omoney;
        private bool _ispay;
        private int? _tableid;
        private decimal? _discount;

        public int OId
        {
            set { _oid = value; }
            get { return _oid; }
        }

        public int? MemberId
        {
            set { _memberid = value; }
            get { return _memberid; }
        }

        public DateTime? ODate
        {
            set { _odate = value; }
            get { return _odate; }
        }

        public decimal? OMoney
        {
            set { _omoney = value; }
            get { return _omoney; }
        }

        public bool IsPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }

        public int? TableId
        {
            set { _tableid = value; }
            get { return _tableid; }
        }

        public decimal? Discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
    }
}

