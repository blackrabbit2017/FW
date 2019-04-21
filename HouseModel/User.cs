using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Houses.Model
{
	/// <summary>
	/// User:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        [DisplayName("�û���")]
        [Required(ErrorMessage="{0}����Ϊ��")]
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("�û�����")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DisplayName("����")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}

        [DisplayName("ȷ������")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
        [Compare("Password", ErrorMessage = "�����������벻һ��")]
        public string RePassword { get; set; }

		/// <summary>
		/// 
		/// </summary>
        [DisplayName("�绰")]
        [Required(ErrorMessage = "{0}����Ϊ��")]
        [RegularExpression(@"^\d{6,20}$",ErrorMessage="{0}��ʽ����")]
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		#endregion Model

	}
}

