using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Utility.FileUtility
{
    using System.IO;

    public class FilesHandler
    {
        public List<string> getFilenamesFromFolder(string DirectoryOfFiles,string FilesPattern)
        {
            List<string> _filenamesPath = new List<string>();
            try
            {
                var files = Directory.GetFiles(DirectoryOfFiles, FilesPattern);

                for (int i = 0; i < files.Length; i++)
                {
                    _filenamesPath.Add(files[i].ToString());
                }

                return _filenamesPath;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        //private List<string> getF

        public DateTime getFileDateFromName(string FileName,int DatePartBegin,int DatePartLenth)
        {
            DateTime _fileDate;

            try
            {
                var fileDateString = FileName.Substring(DatePartBegin, DatePartLenth);

                _fileDate = Convert.ToDateTime(fileDateString);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return _fileDate;
        }
    }
}
