using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// House:实体类(属性说明自动提取数据库字段的描述信息)
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
        [DisplayName("标题") ]
        [Required(ErrorMessage="{0}不能为空")]
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
        [DisplayName("面积")]
        [Required(ErrorMessage = "{0}不能为空")]
		public decimal Floorage
		{
			set{ _floorage=value;}
			get{return _floorage;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("价格")]
        [Required(ErrorMessage = "{0}不能为空")]
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
        [DisplayName("联系方式")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^\d{6,20}$", ErrorMessage = "{0}格式错误")]
		public string Contract
		{
			set{ _contract=value;}
			get{return _contract;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("详细信息")]
        [Required(ErrorMessage = "{0}不能为空")]
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

