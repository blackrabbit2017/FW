using System;
using System.Data;
using System.Collections.Generic;
using Houses.DAL;
using Houses.Model;

namespace Houses.BLL
{
	/// <summary>
	/// District
	/// </summary>
	public partial class DistrictManager
	{
        private readonly DistrictService dal = new DistrictService();
        public DistrictManager()
		{}
		#region  Method

        public List<District> GetAll()
        {
            return dal.GetList();
        }

		#endregion  Method
	}
}

