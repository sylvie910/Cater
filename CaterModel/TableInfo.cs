using System;

namespace CaterModel
{
    [Serializable]
    public partial class TableInfo
    {
        private int _tid;
        private string _ttitle;
        private int? _thallid;
        private bool _tisfree;
        private bool _tisdelete;

        public int TId
        {
            set { _tid = value; }
            get { return _tid; }
        }
        public string TTitle
        {
            set { _ttitle = value; }
            get { return _ttitle; }
        }
        public int? THallId
        {
            set { _thallid = value; }
            get { return _thallid; }
        }
        public bool TIsFree
        {
            set { _tisfree = value; }
            get { return _tisfree; }
        }
        public bool TIsDelete
        {
            set { _tisdelete = value; }
            get { return _tisdelete; }
        }
    }
}

