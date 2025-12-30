using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsApplicationType {

        private enum enMode { AddNew, Update}
        private enMode _Mode = enMode.AddNew;

        public enum enApplicationType {

            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6, RetakeTest = 7
        };

        public int TypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        private clsApplicationType(int TypeID, string Title, decimal Fees) {

            this.TypeID = TypeID;
            this.Title = Title;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }

        public static clsApplicationType Find(int TypeID) {

            string Title = string.Empty;
            decimal Fees = -1;

            if (clsApplicationTypeDataAccess.GetApplicationTypeByID(TypeID, ref Title, ref Fees)) 
                return new clsApplicationType(TypeID, Title, Fees);
            else 
                return null;
        }

        public bool _UpdateApplicationType() => clsApplicationTypeDataAccess.UpdateApplicationType(this.TypeID, this.Title, this.Fees);

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    // No need to add new currently
                    return false;
                }
                case enMode.Update: {

                    return _UpdateApplicationType();
                }
            }

            return false;
        }

        public static DataTable GetAllApplicationTypes() => clsApplicationTypeDataAccess.GetApplicationTypes();

    }
}