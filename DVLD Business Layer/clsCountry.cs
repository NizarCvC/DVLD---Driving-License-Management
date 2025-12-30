using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsCountry {

        public short CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(short CountryID, string CountryName) {

            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find(short CountryID) {

            string CountryName = string.Empty;

            if (clsCountryDataAccess.GetCountryInfoByID(CountryID, ref CountryName)) 
                return new clsCountry(CountryID, CountryName);
            else 
                return null;
        }

        public static clsCountry Find(string CountryName) {

            short CountryID = -1;

            if (clsCountryDataAccess.GetCountryInfoByName(ref CountryID, CountryName)) 
                return new clsCountry(CountryID, CountryName);
            else 
                return null;
        }

        public static DataTable GetAllCountryNames() => clsCountryDataAccess.GetAllCountryNames();
    
    }
}