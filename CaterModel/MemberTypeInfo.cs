using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    [Serializable]
    public partial class MemberTypeInfo
    {
        public int MId { get; set; }
        public string MType { get; set; }
        public decimal? MDiscount { get; set; }
        public bool MIsDelete { get; set; }
    }
}
