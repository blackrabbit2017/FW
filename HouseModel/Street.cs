using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// Street:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        [DisplayName("�ֵ�")]
        [Required(ErrorMessage = "��ѡ��{0}")]
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

