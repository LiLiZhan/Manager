using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class IniFile
    {
        public string Path { get; private set; }
        public IniFile(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void WriteString(string section, string key, string value)
        {
            WinAPI.WritePrivateProfileString(section, key, value, this.Path);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回的键值</returns>
        public string ReadString(string section, string key, string def)
        {
            StringBuilder temp = new StringBuilder(255);
            WinAPI.GetPrivateProfileString(section, key, def, temp, 255, this.Path);
            return temp.ToString();
        }

        public string[] ReadAllSectionNames()
        {
            int MAX_BUFFER = 32767;
            byte[] buff = new byte[MAX_BUFFER];
            int size = WinAPI.GetPrivateProfileSectionNames(buff, buff.Length, this.Path);
            if (size == 0)
                return null;
            string info = Encoding.Default.GetString(buff, 0, size - 1);
            return info.Split('\0');
        }

        public int ReadInt(string section, string key, int def)
        {
            return WinAPI.GetPrivateProfileInt(section, key, def, this.Path);
        }

        public void WriteInt(string section, string key, int val)
        {
            WriteString(section, key, val.ToString());
        }

        /// <summary>
        /// 删除INI文件中的某个键值
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">要删除的键</param>
        public void DeleteKey(string section, string key)
        {
            WinAPI.WritePrivateProfileString(section, key, null, this.Path);
        }

        /// <summary>
        /// 删除INI文件中的某个键值
        /// </summary>
        /// <param name="section">段落</param>
        public void DeleteSection(string section)
        {
            WinAPI.WritePrivateProfileString(section, null, null, this.Path);
        }
    }
}

