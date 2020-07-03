using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryAndFile
{
    public class Helper
    {
        public void CreateDirectory(string Path)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);                
            }
        }

        public void RemoveDirectory(string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            foreach (string file in dirs)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-30))
                    Directory.Delete(file, true);
            }
        }

        public string UniqueText(int length)
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string result = string.Empty;
            int charlenth = characters.Length;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                result += characters[random.Next(charlenth)];
            }
            return result;
        }
        public void createText(string data)
        {
            DateTime date = TimeZoneInfo
                .ConvertTimeFromUtc(
                    DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time")
                    );
            string text = date.ToString("hh-mm-ss-tt") + " Error :{ " + data + " }";
            //string path = HttpContent.Current.Server.MapPath("~/Error/") + date.ToString("dd-MMM-yyyy");
            string path = $"~/Error" + date.ToString("dd-MMM-yyyy");
            //string Removepath = HttpContext.Current.Server.MapPath("~/Error/") + date.AddDays(-30).ToString("dd-MMM-yyyy");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }           
            path = path + "/Error.txt";
            StreamWriter sw = null;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                sw = File.CreateText(path);
                sw.WriteLine(text);
                sw.Close();
            }
            else
            {
                //append text when file is exists
                sw = File.AppendText(path);
                sw.WriteLine(Environment.NewLine + text);
                sw.Close();
            }
        }
        public void fileMoving(string source, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            if (!File.Exists(destination) || !File.Exists(source))
            {
                File.Move(source, destination);
            }
        }
    }
}
