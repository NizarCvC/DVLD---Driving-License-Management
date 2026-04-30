using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsTestType {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        public enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        private clsTestType(enTestType ID, string Title, string Description, decimal Fees) {

            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }

        public static clsTestType Find(enTestType TestID) {

            string Title = string.Empty , Description = string.Empty;
            decimal Fees = -1;

            if (clsTestTypeDataAccess.GetTestTypeByID((int)TestID, ref Title, ref Description, ref Fees)) 
                return new clsTestType(TestID, Title, Description, Fees);
            else
                return null;
        }

        private bool _UpdateTestType() {

            return clsTestTypeDataAccess.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    // Not need to add new currently
                    return false;
                }
                case enMode.Update: {

                    return _UpdateTestType();
                }
            }

            return false;
        }

        public static DataTable GetAllTestTypes() => clsTestTypeDataAccess.GetAllTestTypes();

        public static int NumberOfTestTypes() => clsTestTypeDataAccess.NumberOfTestTypes();

    }
}