using System;
using System.Data;
using System.Collections.Generic;
using Houses.DAL;
using Houses.Model;

namespace Houses.BLL
{
  
	/// <summary>
	/// User
	/// </summary>
	public partial class UserManager
	{
        static object userLock=new object();
        private readonly UserService dal = new UserService();
        public UserManager()
		{}
		#region  Method

        public bool Login(User user, out User gettedUser)
        {
             gettedUser = dal.GetModel(user.LoginName);
            if (gettedUser != null && gettedUser.Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(User user)
        {
            lock(userLock)
            {
                if (dal.Exists(user.LoginName))//�û��Ƿ����
                {
                    return false;

                }
                else
                {
                    if (dal.Add(user) > 0)//����û��ɹ�
                        return true;
                }
            }
            return false;
        }

		#endregion  Method
	}
}

