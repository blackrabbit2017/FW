using System;
using System.Data;
using System.Collections.Generic;
using Houses.DAL;
using Houses.Model;

namespace Houses.BLL
{
	/// <summary>
	/// Street
	/// </summary>
	public partial class StreetManager
	{
        private readonly  StreetService dal = new StreetService();
        public StreetManager()
		{}

		#region  Method
        public List<Street> GetAll()
        {
            return dal.GetList();
        }

        public List<Street> GetList(int distinctId)
        {
            return dal.GetList(distinctId);
        }

		#endregion  Method
	}
}

