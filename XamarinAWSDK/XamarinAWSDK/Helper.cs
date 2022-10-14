using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinAWSDK.Interfaces;

namespace XamarinAWSDK
{
    public static class Helper
    {
        public static void Log(object ex, string Operation, string Location, string Method)
        {
            try
            {
                if (true)
                {
                    string exception = "\r\n\n" +
                                       "Date: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "\r\n" +
                                       "Operation: " + Operation + "\r\n" +
                                       "Location: " + Location + "\r\n" +
                                       "Method: " + Method + "\r\n\n" +
                                       Newtonsoft.Json.JsonConvert.SerializeObject(ex);

                    string log = "";
                    string storageFolderPath = DependencyService.Get<IStorageFolderPath>().GetStorageFolderPath();
                    string folderName = Path.Combine(storageFolderPath, "xamarinawsdk_logs");
                    string subFolderName = Path.Combine(folderName, "logs");

                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }

                    if (!Directory.Exists(subFolderName))
                    {
                        Directory.CreateDirectory(subFolderName);
                    }

                    string fileName = Path.Combine(subFolderName, "log(" + DateTime.Today.Date.ToString("dd.MM.yyyy") + ").txt");

                    if (!File.Exists(fileName))
                    {
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                            log = exception;
                            sw.WriteLine(log);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(fileName))
                        {
                            log = exception;

                            sw.WriteLine(log);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString() + "\r\n\n" + "Log(object ex, string Operation, string Location, string Method)" + "\r\n\n" + "\r\n\n");

                string exp = ex.ToString() + "\r\n\n" + Operation + "\r\n\n" + Location + "\r\n\n" + Method;
                System.Diagnostics.Debug.WriteLine(exp);

                Crashes.TrackError(new Exception(exp));
                Crashes.TrackError(e);
            }
        }
    }
}
