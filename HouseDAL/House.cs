using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Houses.Model;

namespace Houses.DAL
{
    /// <summary>
    /// 数据访问类:House
    /// </summary>
    public partial class HouseService
    {
        public HouseService()
        { }
        #region  Method

        //        /// <summary>
        //        /// 得到最大ID
        //        /// </summary>
        //        public int GetMaxId()
        //        {
        //        return DbHelperSQL.GetMaxID("HouseId", "House"); 
        //        }

        //        /// <summary>
        //        /// 是否存在该记录
        //        /// </summary>
        //        public bool Exists(int HouseId)
        //        {
        //            StringBuilder strSql=new StringBuilder();
        //            strSql.Append("select count(1) from House");
        //            strSql.Append(" where HouseId=@HouseId ");
        //            SqlParameter[] parameters = {
        //                    new SqlParameter("@HouseId", SqlDbType.Int,4)};
        //            parameters[0].Value = HouseId;

        //            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        //        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<House> GetList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  h.*,s.Name StreetName,d.Id DistrictId, d.Name DistrictName,t.Name TypeName from House h ");
            strSql.Append(" inner join Street s on s.Id=h.StreetId ");
            strSql.Append(" inner join District d on d.Id=s.DistrictId ");
            strSql.Append(" inner join HouseType t on t.Id=h.TypeId ");

            return GetItemsBySql(strSql.ToString());
        }

        private List<House> GetItemsBySql(string safeSql)
        {
            var list = new List<House>();

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, safeSql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(FillModel(row));
                }
            }

            return list;
        }


        private House FillModel(DataRow dr)
        {
            House model = new House();
            if (dr["HouseId"].ToString() != "")
            {
                model.HouseId = int.Parse(dr["HouseId"].ToString());
            }
            model.Title = dr["Title"].ToString();
            if (dr["TypeId"].ToString() != "")
            {
                model.TypeId = int.Parse(dr["TypeId"].ToString());
            }
            if (dr["Floorage"].ToString() != "")
            {
                model.Floorage = decimal.Parse(dr["Floorage"].ToString());
            }
            if (dr["Price"].ToString() != "")
            {
                model.Price = decimal.Parse(dr["Price"].ToString());
            }
            if (dr["StreetId"].ToString() != "")
            {
                model.StreetId = int.Parse(dr["StreetId"].ToString());
            }
            model.Contract = dr["Contract"].ToString();
            model.Description = dr["Description"].ToString();
            if (dr["PublishUser"].ToString() != "")
            {
                model.PublishUserId = int.Parse(dr["PublishUser"].ToString());
            }
            if (dr["PublishTime"].ToString() != "")
            {
                model.PublishTime = DateTime.Parse(dr["PublishTime"].ToString());
            }

            model.HouseType = new HouseType() { Id = int.Parse(dr["TypeId"].ToString()), Name = dr["TypeName"].ToString() };
            model.Street = new Street()
            {
                Id = int.Parse(dr["StreetId"].ToString()),
                Name = dr["StreetName"].ToString(),
                District = new District()
                {
                    Id = int.Parse(dr["DistrictId"].ToString()),
                    Name = dr["DistrictName"].ToString(),
                }
            };
        //   model.DistinctId= int.Parse(dr["DistrictId"].ToString());
           

            return model;

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(House model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into House(");
            strSql.Append("Title,TypeId,Floorage,Price,StreetId,Contract,Description,PublishUser,PublishTime)");
            strSql.Append(" values (");
            strSql.Append("@Title,@TypeId,@Floorage,@Price,@StreetId,@Contract,@Description,@PublishUser,@PublishTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@TypeId", SqlDbType.Int,4),
                    new SqlParameter("@Floorage", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@StreetId", SqlDbType.Int,4),
                    new SqlParameter("@Contract", SqlDbType.NVarChar,50),
                    new SqlParameter("@Description", SqlDbType.NVarChar,1000),
                    new SqlParameter("@PublishUser", SqlDbType.Int,4),
                    new SqlParameter("@PublishTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Floorage;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.StreetId;
            parameters[5].Value = model.Contract;
            parameters[6].Value = model.Description??"";
            parameters[7].Value = model.PublishUserId;
            parameters[8].Value = model.PublishTime;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update( House model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update House set ");
            strSql.Append("Title=@Title,");
            strSql.Append("TypeId=@TypeId,");
            strSql.Append("Floorage=@Floorage,");
            strSql.Append("Price=@Price,");
            strSql.Append("StreetId=@StreetId,");
            strSql.Append("Contract=@Contract,");
            strSql.Append("Description=@Description");
            //strSql.Append("PublishUser=@PublishUser,");
            //strSql.Append("PublishTime=@PublishTime");
            strSql.Append(" where HouseId=@HouseId");
            SqlParameter[] parameters = {
                    new SqlParameter("@HouseId", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@TypeId", SqlDbType.Int,4),
                    new SqlParameter("@Floorage", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@StreetId", SqlDbType.Int,4),
                    new SqlParameter("@Contract", SqlDbType.NVarChar,50),
                    new SqlParameter("@Description", SqlDbType.NVarChar,1000)
                    //new SqlParameter("@PublishUser", SqlDbType.Int,4),
                    //new SqlParameter("@PublishTime", SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.HouseId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.TypeId;
            parameters[3].Value = model.Floorage;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.StreetId;
            parameters[6].Value = model.Contract;
            parameters[7].Value = model.Description??"";
            //parameters[8].Value = model.PublishUser;
            //parameters[9].Value = model.PublishTime;

            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int HouseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from House ");
            strSql.Append(" where HouseId=@HouseId");
            SqlParameter[] parameters = {
                    new SqlParameter("@HouseId", SqlDbType.Int,4)
};
            parameters[0].Value = HouseId;

            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //        /// <summary>
        //        /// 删除一条数据
        //        /// </summary>
        //        public bool DeleteList(string HouseIdlist )
        //        {
        //            StringBuilder strSql=new StringBuilder();
        //            strSql.Append("delete from House ");
        //            strSql.Append(" where HouseId in ("+HouseIdlist + ")  ");
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
        public House GetModel(int HouseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 h.*,s.Name StreetName,d.Id DistrictId, d.Name DistrictName,t.Name TypeName from House h ");
            strSql.Append(" inner join Street s on s.Id=h.StreetId ");
            strSql.Append(" inner join District d on d.Id=s.DistrictId ");
            strSql.Append(" inner join HouseType t on t.Id=h.TypeId ");
            strSql.Append(" where HouseId=@HouseId");
            SqlParameter[] parameters = {
                    new SqlParameter("@HouseId", SqlDbType.Int,4)
};
            parameters[0].Value = HouseId;

            var model = new House();
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = FillModel(ds.Tables[0].Rows[0]);
                model.PublishUser = new UserService().GetModel(model.PublishUserId);
                return model;
            }
            else
            {
                return null;
            }
        }

        //        /// <summary>
        //        /// 获得数据列表
        //        /// </summary>
        //        public DataSet GetList(string strWhere)
        //        {
        //            StringBuilder strSql=new StringBuilder();
        //            strSql.Append("select HouseId,Title,TypeId,Floorage,Price,StreetId,Contract,Description,PublishUser,PublishTime ");
        //            strSql.Append(" FROM House ");
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
        //            strSql.Append(" HouseId,Title,TypeId,Floorage,Price,StreetId,Contract,Description,PublishUser,PublishTime ");
        //            strSql.Append(" FROM House ");
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
        //            parameters[0].Value = "House";
        //            parameters[1].Value = "HouseId";
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

