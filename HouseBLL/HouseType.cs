using System;
using System.Data;
using System.Collections.Generic;
using Houses.DAL;
using Houses.Model;

namespace Houses.BLL
{
	/// <summary>
	/// HouseType
	/// </summary>
	public partial class HouseTypeManager
	{
        private readonly HouseTypeService dal = new HouseTypeService();
        public HouseTypeManager()
		{}
		#region  Method
        public List<HouseType> GetAll()
        {
            return dal.GetList();
        }

		#endregion  Method
	}
}

