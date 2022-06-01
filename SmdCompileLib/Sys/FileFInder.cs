using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SmdCompileLib.Sys
{
    public class FileFInder
    {
        List<string> files_f = new List<string>();
        public string LocalPath
        {
            get; set;
        }
        public string RegexPattern
        {
            get; set;
        }
        public string Result
        {
            get; set;
        } = string.Empty;

        private bool st_ = true;
        public int max_count = 100;
        private int cur_count_ = 0;

        public bool IsExists
        {
            get
            {
                return File.Exists(Result);
            }
        }
        private void _find(string dir)
        {
            if (!Directory.Exists(dir) || !st_)
                return;
            foreach (var item in Directory.GetFiles(dir))
            {
                if( Regex.IsMatch( new FileInfo(item).Name ,RegexPattern) )
                {
                     
                    Result = item;
                    st_ = false;
                }
                
            }
            foreach (var item in Directory.GetDirectories(dir))
            {
                _find(item);
                cur_count_++;
                if (cur_count_ > max_count)
                {
                    st_ = false;
                }
            }
        }
        private void _find_array(string dir)
        {
            if (!Directory.Exists(dir) || !st_)
                return;
            string data_;
            foreach (var item in Directory.GetFiles(dir))
            {
                data_ = new FileInfo(item).Name;
               
                if (Regex.IsMatch(data_, RegexPattern))
                {
                    files_f.Add(item);
                 
                     
                }
                
            }
            foreach (var item in Directory.GetDirectories(dir))
            {
                _find_array(item);
                cur_count_++;
                if (cur_count_ > max_count)
                {
                    st_ = false;
                }
            }
        }
        public string Find()
        {
            Clear();
            _find(LocalPath);
            return Result;
        }
        public string[] FindArray()
        {
            Clear();
            _find_array(LocalPath);
            return files_f.ToArray();
        }
        public void Clear()
        {
            Result = "";
            cur_count_ = 0;
            st_ = true;
            files_f.Clear();
        }
        #region hide
        //public static string f_find_dir(string start_file_dir_, string name)
        //{
        //    if(start_file_dir_ == null || start_file_dir_ == "" || !Directory.Exists(start_file_dir_))
        //        return String.Empty;
        //    foreach (string dir in Directory.GetDirectories(start_file_dir_))
        //    {

        //        f_find_dir(dir, name);
        //        if (new DirectoryInfo(dir).Name == name)
        //        {
        //            Console.WriteLine(dir);
        //            return dir;
        //        }

        //    }
        //    return String.Empty;
        //} 
        #endregion

    }
}
