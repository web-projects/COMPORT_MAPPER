using Common.LoggerManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Text;

namespace ComportMapper.ComPortFinder
{
    static class ComportSearcher
    {
        static private List<ManagementObject> ComPortList = new List<ManagementObject>();
        static private string currentlySelectedComport = string.Empty;

        static private void DeviceLogger(string message)
        {
            Console.WriteLine(message);
            Debug.WriteLine(message);
            Logger.info(message);
        }

        static public int FindAllComports()
        {
            try
            {
                // Get all serial (COM)-ports you can see in the devicemanager
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\cimv2",
                    "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");

                // Add all available (COM)-ports to the combobox
                foreach (ManagementObject managementObject in searcher.Get())
                {
                    ComPortList.Add(managementObject);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exceptin in FindAllComports: {ex.Message}");
            }

            return ComPortList.Count;
        }

        static public void ListAllDevices()
        {
            try
            {
                foreach (ManagementObject managementObject in ComPortList)
                {
                    StringBuilder buffer = new StringBuilder(128);
                    buffer.AppendFormat($"{managementObject["Name"]},{managementObject["Status"]},{managementObject["ErrorDescription"] ?? "NOERRORS"}");
                    buffer
                       .Replace("(TM)", "™")
                       .Replace("(tm)", "™")
                       .Replace("(R)", "®")
                       .Replace("(r)", "®")
                       .Replace("(C)", "©")
                       .Replace("(c)", "©")
                       .Replace("    ", " ")
                       .Replace("  ", " ");

                    DeviceLogger($"[IPA5.DAL.Core] device: [{buffer}]");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exceptin in ListAllDevices: {ex.Message}");
            }
        }

        static public void ComportSelector()
        {
            // Set the right port for the selected item.
            // The portname is based on the "COMx" part of the string (SelectedItem)
            string item = ComPortList.ToString();

            // Search for the expression "(COM" in the "selectedItem" string
            if (item.Contains("(COM"))
            {
                // Get the index number where "(COM" starts in the string
                int indexOfCom = item.IndexOf("(COM");

                // Set PortName to COMx based on the expression in the "selectedItem" string
                // It automatically gets the correct length of the COMx expression to make sure 
                // that also a COM10, COM11 and so on is working properly.
                currentlySelectedComport = item.Substring(indexOfCom + 1, item.Length - indexOfCom - 2);
            }
        }
    }
}
