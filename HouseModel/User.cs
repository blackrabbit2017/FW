using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User
	{
		public User()
		{}
		#region Model
		private int _loginid;
		private string _loginname;
		private string _username;
		private string _password;
		private string _telephone;
		/// <summary>
		/// 
		/// </summary>
		public int LoginId
		{
			set{ _loginid=value;}
			get{return _loginid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("用户名")]
        [Required(ErrorMessage="{0}不能为空")]
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("用户姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("密码")]
        [Required(ErrorMessage = "{0}不能为空")]
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}

        [DisplayName("确认密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Compare("Password", ErrorMessage = "两次密码输入不一致")]
        public string RePassword { get; set; }

		/// <summary>
		/// 
		/// </summary>
        [DisplayName("电话")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^\d{6,20}$",ErrorMessage="{0}格式错误")]
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		#endregion Model

	}
}

