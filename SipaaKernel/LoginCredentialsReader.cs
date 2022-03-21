using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel
{
    public class LoginCredentialsReader
    {
        string[] fileContent;
        string username, password;

        public LoginCredentialsReader()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "logincredentials.dat"))
            {
                StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "logincredentials.dat");
                writer.WriteLine("SipaaOS Login Credentials");
                writer.WriteLine("username=root");
                writer.WriteLine("password=empty");
                writer.Close();
            }
            fileContent = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "logincredentials.dat");
            username = fileContent[1].Replace("username=", "");
            if (fileContent[2].Replace("password=", "") == "empty")
            {
                password = "";
            }
            else
            {
                password = fileContent[2].Replace("password=", "");
            }
        }
        public string getUsername()
        {
            return username;
        }
        public string getPassword()
        {
            return password;
        }
    }
}
