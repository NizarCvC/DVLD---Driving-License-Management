using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using My_Libraries;

namespace DVLD_Project {

    internal class clsHandleImage {

        public static bool CreateFolderIfDoesNotExist(string FolderPath) {

            if (!Directory.Exists(FolderPath)) {

                try {

                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex) {

                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
        }

        public static string ReplaceFileNameWithGUID(string sourceFile) {
 
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return clsUtil.GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile) {

            string destinationFolder = Path.Combine(Application.StartupPath, "DVLD-People-Images");

            if (!CreateFolderIfDoesNotExist(destinationFolder)) return false;

            string destinationFile = Path.Combine(destinationFolder, ReplaceFileNameWithGUID(sourceFile));

            try {

                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox) {

                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

    }
}