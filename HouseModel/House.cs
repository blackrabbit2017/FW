using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// House:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class House
	{
		public House()
		{}
		#region Model
		private int? _houseid;
		private string _title;
		private int _typeid;
		private decimal _floorage;
		private decimal _price;
		private int _streetid;
		private string _contract;
		private string _description;
		private int _publishuser;
		private DateTime _publishtime= DateTime.Now;

        
        public HouseType HouseType{get;set;}
        public Street Street { get; set; }
        public User PublishUser { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public int? HouseId
		{
			set{ _houseid=value;}
			get{return _houseid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("����") ]
        [Required(ErrorMessage="{0}����Ϊ��")]
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("���")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
		public decimal Floorage
		{
			set{ _floorage=value;}
			get{return _floorage;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("�۸�")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StreetId
		{
			set{ _streetid=value;}
			get{return _streetid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("��ϵ��ʽ")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
        [RegularExpression(@"^\d{6,20}$", ErrorMessage = "{0}��ʽ����")]
		public string Contract
		{
			set{ _contract=value;}
			get{return _contract;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("��ϸ��Ϣ")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int PublishUserId { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime PublishTime
		{
			set{ _publishtime=value;}
			get{return DateTime.Now;}
		}
		#endregion Model

	}
}

