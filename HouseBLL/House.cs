using System;
using System.Data;
using System.Collections.Generic;
using Houses.DAL;
using Houses.Model;

namespace Houses.BLL
{
    /// <summary>
    /// House
    /// </summary>
    public partial class HouseManager
    {
        private readonly HouseService dal = new HouseService();
        public HouseManager()
        { }
        #region  Method

        public List<House> GetAll()
        {
            return dal.GetList();
        }

        public House GetHouse(int houseId)
        {
            return dal.GetModel(houseId);
            
        }

        public bool Add(House house)
        {
            EditHelp(house);
            return dal.Add(house) > 0;
        }

        public bool Update(House house)
        {
            EditHelp(house);
            return dal.Update(house);
        }

        private void EditHelp(House house)
        {
            house.TypeId = house.HouseType.Id;
            house.StreetId = house.Street.Id;
        }

        public bool Delete(int houseId)
        {
            return dal.Delete(houseId);
        }
        #endregion
    }
}