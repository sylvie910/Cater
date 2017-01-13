using System;

namespace CaterModel
{
	[Serializable]
	public partial class DishTypeInfo
	{
		public DishTypeInfo()
		{}
		#region Model
		private int _did;
		private string _dtitle;
		private bool _disdelete;

		public int DId
		{
			set{ _did=value;}
			get{return _did;}
		}

		public string DTitle
		{
			set{ _dtitle=value;}
			get{return _dtitle;}
		}

		public bool DIsDelete
		{
			set{ _disdelete=value;}
			get{return _disdelete;}
		}
		#endregion Model

	}
}

