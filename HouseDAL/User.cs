using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Houses.Model;

namespace Houses.DAL
{
	/// <summary>
	/// 数据访问类:User
	/// </summary>
	public partial class UserService
	{
        public UserService()
		{}
		#region  Method

//        /// <summary>
//        /// 得到最大ID
//        /// </summary>
//        public int GetMaxId()
//        {
//        return DbHelperSQL.GetMaxID("LoginId", "User"); 
//        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [User]");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.NVarChar,20)};
            parameters[0].Value = LoginName;

            return Convert.ToBoolean(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, strSql.ToString(), parameters));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [User](");
            strSql.Append("LoginName,UserName,Password,Telephone)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@UserName,@Password,@Telephone)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.NVarChar,20),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,10),
                    new SqlParameter("@Password", SqlDbType.NVarChar,50),
                    new SqlParameter("@Telephone", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Telephone;

            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        public bool Update(bdqn.houses.Model.User model)
//        {
//            StringBuilder strSql=new StringBuilder();
//            strSql.Append("update User set ");
//            strSql.Append("LoginName=@LoginName,");
//            strSql.Append("UserName=@UserName,");
//            strSql.Append("Password=@Password,");
//            strSql.Append("Telephone=@Telephone");
//            strSql.Append(" where LoginId=@LoginId");
//            SqlParameter[] parameters = {
//                    new SqlParameter("@LoginId", SqlDbType.Int,4),
//                    new SqlParameter("@LoginName", SqlDbType.NVarChar,20),
//                    new SqlParameter("@UserName", SqlDbType.NVarChar,10),
//                    new SqlParameter("@Password", SqlDbType.NVarChar,50),
//                    new SqlParameter("@Telephone", SqlDbType.NVarChar,20)};
//            parameters[0].Value = model.LoginId;
//            parameters[1].Value = model.LoginName;
//            parameters[2].Value = model.UserName;
//            parameters[3].Value = model.Password;
//            parameters[4].Value = model.Telephone;

//            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
//            if (rows > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        public bool Delete(int LoginId)
//        {
			
//            StringBuilder strSql=new StringBuilder();
//            strSql.Append("delete from User ");
//            strSql.Append(" where LoginId=@LoginId");
//            SqlParameter[] parameters = {
//                    new SqlParameter("@LoginId", SqlDbType.Int,4)
//};
//            parameters[0].Value = LoginId;

//            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
//            if (rows > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        public bool DeleteList(string LoginIdlist )
//        {
//            StringBuilder strSql=new StringBuilder();
//            strSql.Append("delete from User ");
//            strSql.Append(" where LoginId in ("+LoginIdlist + ")  ");
//            int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
//            if (rows > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public User GetModel(string LoginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LoginId,LoginName,UserName,Password,Telephone from [User] ");
            strSql.Append(" where LoginName=@LoginName");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.NVarChar,20)
};
            parameters[0].Value = LoginName;

            User model = new User();
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString,CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return FillModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public User GetModel(int LoginId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LoginId,LoginName,UserName,Password,Telephone from [User] ");
            strSql.Append(" where LoginId=@LoginId");  
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginId", SqlDbType.Int,4)
};
            parameters[0].Value = LoginId;

            User model = new User();
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return FillModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        private User FillModel(DataRow dr)
        {
            User model = new User();
            if (dr["LoginId"].ToString() != "")
            {
                model.LoginId = int.Parse(dr["LoginId"].ToString());
            }
            model.LoginName = dr["LoginName"].ToString();
            model.UserName = dr["UserName"].ToString();
            model.Password = dr["Password"].ToString();
            model.Telephone = dr["Telephone"].ToString();
            return model;

        }

//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public DataSet GetList(string strWhere)
//        {
//            StringBuilder strSql=new StringBuilder();
//            strSql.Append("select LoginId,LoginName,UserName,Password,Telephone ");
//            strSql.Append(" FROM User ");
//            if(strWhere.Trim()!="")
//            {
//                strSql.Append(" where "+strWhere);
//            }
//            return DbHelperSQL.Query(strSql.ToString());
//        }

//        /// <summary>
//        /// 获得前几行数据
//        /// </summary>
//        public DataSet GetList(int Top,string strWhere,string filedOrder)
//        {
//            StringBuilder strSql=new StringBuilder();
//            strSql.Append("select ");
//            if(Top>0)
//            {
//                strSql.Append(" top "+Top.ToString());
//            }
//            strSql.Append(" LoginId,LoginName,UserName,Password,Telephone ");
//            strSql.Append(" FROM User ");
//            if(strWhere.Trim()!="")
//            {
//                strSql.Append(" where "+strWhere);
//            }
//            strSql.Append(" order by " + filedOrder);
//            return DbHelperSQL.Query(strSql.ToString());
//        }

//        /*
//        /// <summary>
//        /// 分页获取数据列表
//        /// </summary>
//        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
//        {
//            SqlParameter[] parameters = {
//                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
//                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
//                    new SqlParameter("@PageSize", SqlDbType.Int),
//                    new SqlParameter("@PageIndex", SqlDbType.Int),
//                    new SqlParameter("@IsReCount", SqlDbType.Bit),
//                    new SqlParameter("@OrderType", SqlDbType.Bit),
//                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
//                    };
//            parameters[0].Value = "User";
//            parameters[1].Value = "LoginId";
//            parameters[2].Value = PageSize;
//            parameters[3].Value = PageIndex;
//            parameters[4].Value = 0;
//            parameters[5].Value = 0;
//            parameters[6].Value = strWhere;	
//            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
//        }*/

		#endregion  Method
	}
}

