using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Business
{
    public class FTP
    {
        public enum FileCate { HinhDaiDien, HopDong, QuyetDinh };
        string URI = "ftp://123.30.210.98/", globalFolderName;
        string UserName = "Administrator", Password = "QLNS@123qlns";
        FileCate oFileCate = new FileCate();

        /// <summary>
        /// Upload file len VPS
        /// </summary>
        /// <param name="FilesPath">Mang chua duong dan file o may client</param>
        /// <param name="FilesName">Mang chua ten file (Name + Extension) o may client</param>
        /// <param name="m_Ma">Ma nv hoac ma qd hoac ma hd - dung de dat ten file tren server</param>
        /// <returns>Tra ve mang chua duong dan file tren server, dung de luu xuong DB</returns>
        public  string[] UploadFile(string[] FilesPath, string[] FilesName, string m_Ma)
        {
            string[] DBPath = new string[FilesName.Length];
            Stream requestStream = null;
            oFileCate = FileCate.HinhDaiDien;
            switch (oFileCate)
            {
                case FileCate.HinhDaiDien:
                    CreateFTPFolderIfNotExists("hinh_dai_dien");
                    globalFolderName = "hinh_dai_dien";
                    break;
                case FileCate.HopDong:
                    break;
                case FileCate.QuyetDinh:
                    break;
                default:
                    break;
            }

            for (int i = 0; i < FilesPath.Length; i++)
            {
                string ServerFileName = MakeFileName(m_Ma, FilesName[i]);

                //123.30.210.98
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URI + globalFolderName + "/" + ServerFileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(UserName, Password);


                StreamReader sourceStream = new StreamReader(FilesPath[i]);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);

                DBPath[i] = globalFolderName + "/" + ServerFileName;
            }


            if (requestStream != null)
                requestStream.Close();

            return DBPath;

            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            //response.Close();
        }

        /// <summary>
        /// Tao ra ten file de luu tren server
        /// </summary>
        /// <param name="m_Ma">Ma nv hoac ma qd hoac ma hd</param>
        /// <param name="FileName">Ten file (Name + Extension)</param>
        /// <returns>Ten file dung de luu tren server (Ma + "_" + random(8) + "_" + FileName</returns>
        private  string MakeFileName(string m_Ma, string FileName)
        {
            string s = "";

            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(a => a[random.Next(a.Length)])
                          .ToArray());

            s = m_Ma + "_" + result.ToString() + "_" + FileName;

            return s;
        }

        /// <summary>
        /// KT Folder co ton tai tren server chua, neu chua se goi ham tao folder
        /// </summary>
        /// <param name="FolderName">Ten folder de kiem tra</param>
        private void CreateFTPFolderIfNotExists(string FolderName)
        {
            try
            {
                FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(URI + FolderName);
                requestDir.Method = WebRequestMethods.Ftp.ListDirectory;
                requestDir.Credentials = new NetworkCredential(UserName, Password);
                FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
                using (Stream ftpStream = response.GetResponseStream())
                {

                }

            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)     //  NOT EXISTS
                {
                    CreateFTPFolder(FolderName);
                    response.Close();
                }
                else
                {
                    response.Close();
                }


            }
        }

        /// <summary>
        /// Tao folder tren server
        /// </summary>
        /// <param name="FolderName">Ten folder de kiem tra</param>
        private void CreateFTPFolder(string FolderName)
        {
            WebRequest request = WebRequest.Create(URI + FolderName);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(UserName, Password);
            using (var resp = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine(resp.StatusCode);
            }
        }
    }
}
