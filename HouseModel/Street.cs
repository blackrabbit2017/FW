using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// Street:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Street
	{
		public Street()
		{}
		#region Model
		private int _id;
		private string _name;
		private int _districtid;

        public District District { get; set; }

		/// <summary>
		/// 
		/// </summary>
        [DisplayName("街道")]
        [Required(ErrorMessage = "请选择{0}")]
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DistrictId
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		#endregion Model

	}
}

