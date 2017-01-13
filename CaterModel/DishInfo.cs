﻿using System;

namespace CaterModel
{
	[Serializable]
	public partial class DishInfo
	{
		public DishInfo()
		{}
		#region Model
		private int _did;
		private string _dtitle;
		private int? _dtypeid;
		private decimal? _dprice;
		private string _dchar;
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

		public int? DTypeId
		{
			set{ _dtypeid=value;}
			get{return _dtypeid;}
		}

		public decimal? DPrice
		{
			set{ _dprice=value;}
			get{return _dprice;}
		}

		public string DChar
		{
			set{ _dchar=value;}
			get{return _dchar;}
		}

		public bool DIsDelete
		{
			set{ _disdelete=value;}
			get{return _disdelete;}
		}
		#endregion Model

	}
}

