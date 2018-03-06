using DinamycSQL.BO.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using DinamycSQL.TO;

namespace DinamycSQL
{
    public class DataFileProcessorBO : IDataFileProcessorBO
    {
        private const int         MINIMUM_FILE_SIZE = 2;
        private string[]          FileContent       = null;
        private DataFileHeaderTO  HeaderTO          = null;
        private DataFileContentTO ContentTO         = null;

        //public string FilePath { get; set; }

        //private Dictionary<int, string> Header;

        //private ICollection<Dictionary<string, string>> Data;

        //public DataFileProcessorBO(string file)
        //{
        //    var buffer = File.ReadAllLines(file);

        //    this.InitializeHeader(buffer);

        //    this.InitializeData(buffer);
        //}

        //public Dictionary<int, string> GetHeader()
        //{
        //    return this.Header;
        //}

        //public ICollection<Dictionary<string, string>> GetData()
        //{
        //    return this.Data;
        //}

        //private void InitializeHeader(string[] buffer)
        //{
        //    var header = buffer[ConfigFile.HeaderRow].Split(ConfigFile.HeaderSeparator);

        //    this.Header = new Dictionary<int, string>();

        //    for (int i = 0; i < header.Length; i++)
        //    {
        //        this.Header[i] = header[i];
        //    }
        //}

        //private void InitializeData(string[] buffer)
        //{
        //    var data = new string[buffer.Length - 1];

        //    Array.Copy(buffer, 1, data, 0, buffer.Length - 1);

        //    this.Data = new List<Dictionary<string, string>>();

        //    foreach (var row in data)
        //    {
        //        var split = row.Split(ConfigFile.RowSeparator);

        //        var dic = new Dictionary<string, string>();

        //        for (int i = 0; i < split.Length; i++)
        //        {
        //            dic[Header[i]] = split[i];
        //        }
        //        this.Data.Add(dic);
        //    }
        //}
        public void OpenFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName);

            FileContent = File.ReadAllLines(fileName);

            if (FileContent.Length < MINIMUM_FILE_SIZE)
            {
                throw new FileLoadException(fileName);
            }
        }

        public void ProcessFile()
        {
            this.HeaderTO = this.ProcessHeader();

            this.ContentTO = this.ProcessContent();
        }

        public DataFileHeaderTO GetFileHeader()
        {
            return this.HeaderTO;
        }

        public DataFileContentTO GetFileContent()
        {
            return this.ContentTO;
        }

        private DataFileHeaderTO ProcessHeader()
        {
            return new DataFileHeaderTO();
        }

        private DataFileContentTO ProcessContent()
        {
            return new DataFileContentTO();
        }
    }
}
