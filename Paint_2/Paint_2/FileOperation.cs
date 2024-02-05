using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_2
{
    internal class FileOperation
    {
        private string filename;
        private bool isFileSaved;
        private string fileLocation;


        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        public bool IsFileSaved
        {
            get { return isFileSaved; }
            set { isFileSaved = value; }
        }

        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }

        public void InitializeNewFile()
        {
            this.Filename = "Un_name";
            this.IsFileSaved = true;
        }

        public void OpenFile(string fileLocation)
        {
            Bitmap content;
            this.FileLocation = fileLocation;
            UpdateFileStatus();


        }

        public void SaveFile(string fileLocation, Bitmap img, int filterindex)
        {

            if (img != null)
            {

                try
                {
                    if (fileLocation != "")
                    {
                        this.FileLocation = fileLocation;
                        this.UpdateFileStatus();


                        // Saves the Image in the appropriate ImageFormat based upon the
                        // File type selected in the dialog box.
                        // NOTE that the FilterIndex property is one-based.
                        switch (filterindex)
                        {
                            case 1:
                                img.Save(fileLocation, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;

                            case 2:
                                img.Save(fileLocation, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case 3:
                                img.Save(fileLocation, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                        }
                        UpdateFileStatus();
                    }
                   

                }
                catch (Exception)
                {

                    MessageBox.Show("Can not save image", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        public void UpdateFileStatus()
        {
            string filename = FileLocation.Substring(FileLocation.LastIndexOf("\\") + 2);
            this.Filename = filename;
            this.IsFileSaved = true;
        }


    }
}
