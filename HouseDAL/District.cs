using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Houses.Model;

namespace Houses.DAL
{
	/// <summary>
	/// 数据访问类:District
	/// </summary>
	public partial class DistrictService
	{
        public DistrictService()
		{}
		#region  Method

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return DbHelperSQL.GetMaxID("Id", "District"); 
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int Id)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from District");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4)};
        //    parameters[0].Value = Id;

        //    return DbHelperSQL.Exists(strSql.ToString(),parameters);
        //}


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public void Add(bdqn.houses.Model.District model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into District(");
        //    strSql.Append("Id,Name)");
        //    strSql.Append(" values (");
        //    strSql.Append("@Id,@Name)");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4),
        //            new SqlParameter("@Name", SqlDbType.NVarChar,50)};
        //    parameters[0].Value = model.Id;
        //    parameters[1].Value = model.Name;

        //    DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //}
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(bdqn.houses.Model.District model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update District set ");
        //    strSql.Append("Name=@Name");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4),
        //            new SqlParameter("@Name", SqlDbType.NVarChar,50)};
        //    parameters[0].Value = model.Id;
        //    parameters[1].Value = model.Name;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int Id)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from District ");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4)};
        //    parameters[0].Value = Id;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string Idlist )
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from District ");
        //    strSql.Append(" where Id in ("+Idlist + ")  ");
        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public bdqn.houses.Model.District GetModel(int Id)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select  top 1 Id,Name from District ");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4)};
        //    parameters[0].Value = Id;

        //    bdqn.houses.Model.District model=new bdqn.houses.Model.District();
        //    DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
        //        {
        //            model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        //        }
        //        model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
        //        return model;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<District> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM District ");

            return GetItemsBySql(strSql.ToString());
        }

        private List<District> GetItemsBySql(string safeSql)
        {
            List<District> list = new List<District>();

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, safeSql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    District item = new District();

                    item.Id = (int)row["Id"];
                    item.Name = (string)row["Name"];

                    list.Add(item);
                }
            }

            return list;
        }

        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top,string strWhere,string filedOrder)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ");
        //    if(Top>0)
        //    {
        //        strSql.Append(" top "+Top.ToString());
        //    }
        //    strSql.Append(" Id,Name ");
        //    strSql.Append(" FROM District ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "District";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

