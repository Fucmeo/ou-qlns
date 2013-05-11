using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace Business
{
    public class FTP
    {
        public enum FileCate { HinhDaiDien, HDQD };
        string URI = "ftp://123.30.210.98/", globalFolderName, downloadPath  ;
        string UserName = "Administrator", Password = "QLNS@123qlns";
        public FileCate oFileCate = new FileCate();
        long lFileSizeLimit = 2621440;  // 2,5 mb
        public FTP()
        {
            //downloadPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            downloadPath = Path.GetTempPath();
            
        }

        /// <summary>
        /// Upload file len VPS
        /// </summary>
        /// <param name="ServerFilesPath">Mang chua duong dan file o may client</param>
        /// <param name="ServerFilesName">Mang chua ten file (Name + Extension) o may client</param>
        /// <param name="m_Ma">Ma nv hoac ma qd hoac ma hd - dung de dat ten file tren server</param>
        /// <returns>Tra ve mang chua duong dan file tren server, dung de luu xuong DB</returns>
        public  string[] UploadFile(string[] ServerFilesPath, string[] ServerFilesName, string m_Ma)
        {
            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            string[] DBPath = new string[ServerFilesName.Length];
            //oFileCate = FileCate.HinhDaiDien;
            switch (oFileCate)
            {
                case FileCate.HinhDaiDien:
                    //CreateFTPFolderIfNotExists("hinh_dai_dien");
                    globalFolderName = "hinh_dai_dien";
                    break;
                case FileCate.HDQD:
                    globalFolderName = "hinh_quyet_dinh";
                    break;
                default:
                    globalFolderName = "hinh_dai_dien";
                    break;
            }

            Stream strm = null;
            FileStream fs = null;
            for (int i = 0; i < ServerFilesPath.Length; i++)
            {
                string ServerFileName = MakeFileName(m_Ma, ServerFilesName[i]);
                FileInfo fileInf = new FileInfo(ServerFilesPath[i]);

                //123.30.210.98
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URI + globalFolderName + "/" + ServerFileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(UserName, Password);
                request.UseBinary = true;
                request.ContentLength = fileInf.Length;

                // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
                fs = fileInf.OpenRead();

                try
                {
                    // Stream to which the file to be upload is written
                    strm = request.GetRequestStream();

                    // Read from the file stream 2kb at a time
                    contentLen = fs.Read(buff, 0, buffLength);

                    // Till Stream content ends
                    while (contentLen != 0)
                    {
                        // Write Content from the file stream to the FTP Upload Stream
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }

                }
                catch (Exception)
                {
                    if (strm != null)
                        strm.Close();

                    if (fs != null)
                        fs.Close();

                    throw;
                }
                
                
                DBPath[i] = globalFolderName + "/" + ServerFileName;
            }

            // Close the file stream and the Request Stream
            if(strm != null) 
                strm.Close();

            if(fs != null)
                fs.Close();


            return DBPath;

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

        public bool ChecFileSize(string[] Paths)
        {
            for (int i = 0; i < Paths.Length; i++)
            {
                FileInfo fi = new FileInfo(Paths[i]);
                if (fi.Length >= lFileSizeLimit)
                {
                    return false;
                }
            }
            return true;
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


        public string[] DownloadFile(string[] ServerFilesPath)
        {
            string[] ClientFilesPath = new string[ServerFilesPath.Length];
            string[] ServerFilesName = new string[ServerFilesPath.Length];
            for (int i = 0; i < ServerFilesPath.Length; i++)
            {
                ServerFilesName[i] = ServerFilesPath[i].Split('/').Last();
            }

            // check xem file da co tren may client chua
            GetFilesIfExists(ref ClientFilesPath, ref ServerFilesName, ref ServerFilesPath);

            if (ServerFilesPath.Length > 0) // co file chua co tren client
            {
                FtpWebRequest reqFTP;
                FileStream outputStream = null;
                FtpWebResponse response = null;
                Stream ftpStream = null;
                try
                {

                    //filePath = <<The full path where the file is to be created.>>, 
                    //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                    for (int i = 0; i < ServerFilesPath.Length; i++)
                    {
                        outputStream = new FileStream(downloadPath + "\\" + ServerFilesName[i], FileMode.OpenOrCreate);

                        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI + "/" + ServerFilesPath[i]));
                        reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                        reqFTP.UseBinary = true;
                        reqFTP.Credentials = new NetworkCredential(UserName, Password);
                        response = (FtpWebResponse)reqFTP.GetResponse();
                        ftpStream = response.GetResponseStream();
                        long cl = response.ContentLength;
                        int bufferSize = 2048;
                        int readCount;
                        byte[] buffer = new byte[bufferSize];

                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                        while (readCount > 0)
                        {
                            outputStream.Write(buffer, 0, readCount);
                            readCount = ftpStream.Read(buffer, 0, bufferSize);
                        }

                        ClientFilesPath[i] = downloadPath + "\\" + ServerFilesName[i];
                    }


                    ftpStream.Close();
                    outputStream.Close();
                    response.Close();
                }
                catch (Exception)
                {
                    //throw new Exception(ex.Message);
                    ClientFilesPath[0] = downloadPath + "\\" + ServerFilesName[0];
                    return ClientFilesPath;
                }
                finally
                {
                    if (outputStream != null)
                    {
                        outputStream.Close();
                    }
                }
            }
            

            return ClientFilesPath;
        }

        /// <summary>
        /// kiem tra xem hinh can download co tren client o, neu co thi add path vao ClientFilesPath va exclude file do ra khoi ServerFilesPath
        /// </summary>
        /// <param name="ClientFilesPath">mang path cua file tra len cho giao dien</param>
        /// <param name="ServerFilesName">ten cua file luu o db</param>
        /// <param name="ServerFilesPath"></param>
        private void GetFilesIfExists(ref string[] ClientFilesPath, ref string[] ServerFilesName, ref string[] ServerFilesPath)
        {
            List<string> LstServerFilesPath = new List<string>(ServerFilesPath);
            for (int i = 0; i < ServerFilesPath.Length; i++)
            {
                if (File.Exists(downloadPath + "\\" + ServerFilesName[i]))
                {
                    ClientFilesPath[i] = downloadPath + "\\" + ServerFilesName[i];
                    LstServerFilesPath.RemoveAt(i);
                }
            }

            ServerFilesPath = LstServerFilesPath.ToArray();
        }

        //private static bool IsFileLocked(Exception exception)
        //{
        //    int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
        //    return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        //}
    }
}
