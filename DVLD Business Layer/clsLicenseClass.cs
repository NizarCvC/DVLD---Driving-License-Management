using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsLicenseClass {

        private enum enMode { AddNew, Update}
        private enMode _Mode = enMode.AddNew;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees) {

            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            _Mode = enMode.Update;
        }
    
        public static clsLicenseClass Find(int LicenseClassID) {

            string ClassName = string.Empty, ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
            decimal ClassFees = -1;

            if (clsLicenseClassDataAccess.GetLicenseClassByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees)) 
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else 
                return null;
        }

        public static clsLicenseClass Find(string ClassName) {

            int LicenseClassID = -1;
            string ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
            decimal ClassFees = -1;

            if (clsLicenseClassDataAccess.GetLicenseClassByClassName(ref LicenseClassID, ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }

        private bool _UpdateLicenseClass() => clsLicenseClassDataAccess.UpdateLicenseClass(this.LicenseClassID,
                this.ClassName, this.ClassDescription, this.MinimumAllowedAge,
                this.DefaultValidityLength, this.ClassFees);

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    // No need to add
                    return false;
                }
                case enMode.Update: {

                    return _UpdateLicenseClass();
                } 
            }

            return false;
        }
    
        public static DataTable GetAllLicenseClasses() => clsLicenseClassDataAccess.GetAllLicenseClasses();

        public static DataTable GetAllLicenseClassNames() => clsLicenseClassDataAccess.GetAllLicenseClassNames();

        public static int GetNumberOfLicenseClasses() => clsLicenseClassDataAccess.NumberOfLicenseClasses();

    }
}