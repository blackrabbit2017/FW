using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// District:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class District
	{
		public District()
		{}
		#region Model
		private int _id;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("区域")]
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
		#endregion Model

	}
}

