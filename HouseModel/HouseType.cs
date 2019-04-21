using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// HouseType:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class HouseType
	{
		public HouseType()
		{}
		#region Model
		private int _id;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("����")]
        [Required(ErrorMessage="��ѡ��{0}")]
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

