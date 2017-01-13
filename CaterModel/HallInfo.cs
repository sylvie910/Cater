using System;

namespace CaterModel
{
    [Serializable]
    public partial class HallInfo
    {
        private int _hid;
        private string _htitle;
        private bool _hisdelete;
        public int HId
        {
            set { _hid = value; }
            get { return _hid; }
        }
        public string HTitle
        {
            set { _htitle = value; }
            get { return _htitle; }
        }
        public bool HIsDelete
        {
            set { _hisdelete = value; }
            get { return _hisdelete; }
        }
    }
}

