using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Houses.Model;

namespace Houses.DAL
{
	/// <summary>
	/// 数据访问类:Street
	/// </summary>
	public partial class StreetService
	{
        public StreetService()
		{}
		#region  Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Street> GetList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM Street ");

            return GetItemsBySql(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Street> GetList(int distinctId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM Street ");
            strSql.Append(" where DistrictId= " + distinctId);
            return GetItemsBySql(strSql.ToString());
        }

        private List<Street> GetItemsBySql(string safeSql)
        {
            List<Street> list = new List<Street>();

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, safeSql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Street item = new Street();

                    item.Id = (int)row["Id"];
                    item.Name = (string)row["Name"];

                    list.Add(item);
                }
            }

            return list;
        }


        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return DbHelperSQL.GetMaxID("Id", "Street"); 
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int Id)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from Street");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4)};
        //    parameters[0].Value = Id;

        //    return DbHelperSQL.Exists(strSql.ToString(),parameters);
        //}


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public void Add(bdqn.houses.Model.Street model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into Street(");
        //    strSql.Append("Id,Name,DistrictId)");
        //    strSql.Append(" values (");
        //    strSql.Append("@Id,@Name,@DistrictId)");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4),
        //            new SqlParameter("@Name", SqlDbType.NVarChar,50),
        //            new SqlParameter("@DistrictId", SqlDbType.Int,4)};
        //    parameters[0].Value = model.Id;
        //    parameters[1].Value = model.Name;
        //    parameters[2].Value = model.DistrictId;

        //    DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //}
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(bdqn.houses.Model.Street model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update Street set ");
        //    strSql.Append("Name=@Name,");
        //    strSql.Append("DistrictId=@DistrictId");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4),
        //            new SqlParameter("@Name", SqlDbType.NVarChar,50),
        //            new SqlParameter("@DistrictId", SqlDbType.Int,4)};
        //    parameters[0].Value = model.Id;
        //    parameters[1].Value = model.Name;
        //    parameters[2].Value = model.DistrictId;

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
        //    strSql.Append("delete from Street ");
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
        //    strSql.Append("delete from Street ");
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
        //public bdqn.houses.Model.Street GetModel(int Id)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select  top 1 Id,Name,DistrictId from Street ");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4)};
        //    parameters[0].Value = Id;

        //    bdqn.houses.Model.Street model=new bdqn.houses.Model.Street();
        //    DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
        //        {
        //            model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        //        }
        //        model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
        //        if(ds.Tables[0].Rows[0]["DistrictId"].ToString()!="")
        //        {
        //            model.DistrictId=int.Parse(ds.Tables[0].Rows[0]["DistrictId"].ToString());
        //        }
        //        return model;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select Id,Name,DistrictId ");
        //    strSql.Append(" FROM Street ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

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
        //    strSql.Append(" Id,Name,DistrictId ");
        //    strSql.Append(" FROM Street ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///*
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@tblName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@fldName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@PageSize", SqlDbType.Int),
        //            new SqlParameter("@PageIndex", SqlDbType.Int),
        //            new SqlParameter("@IsReCount", SqlDbType.Bit),
        //            new SqlParameter("@OrderType", SqlDbType.Bit),
        //            new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
        //            };
        //    parameters[0].Value = "Street";
        //    parameters[1].Value = "Id";
        //    parameters[2].Value = PageSize;
        //    parameters[3].Value = PageIndex;
        //    parameters[4].Value = 0;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = strWhere;	
        //    return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        //}*/

		#endregion  Method
	}
}

