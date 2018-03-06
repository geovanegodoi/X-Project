using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycSQL
{
    public class DataFile
    {
        public string FilePath { get; set; }

        private Dictionary<int, string> Header;

        private ICollection<Dictionary<string, string>> Data;

        public DataFile(string file)
        {
            var buffer = File.ReadAllLines(file);

            this.InitializeHeader(buffer);

            this.InitializeData(buffer);
        }

        public Dictionary<int, string> GetHeader()
        {
            return this.Header;
        }

        public ICollection<Dictionary<string, string>> GetData()
        {
            return this.Data;
        }

        private void InitializeHeader(string[] buffer)
        {
            var header = buffer[ConfigFile.HeaderRow].Split(ConfigFile.HeaderSeparator);

            this.Header = new Dictionary<int, string>();

            for (int i = 0; i < header.Length; i++)
            {
                this.Header[i] = header[i];
            }
        }

        private void InitializeData(string[] buffer)
        {
            var data = new string[buffer.Length - 1];

            Array.Copy(buffer, 1, data, 0, buffer.Length - 1);

            this.Data = new List<Dictionary<string, string>>();

            foreach (var row in data)
            {
                var split = row.Split(ConfigFile.RowSeparator);

                var dic = new Dictionary<string, string>();

                for (int i = 0; i < split.Length; i++)
                {
                    dic[Header[i]] = split[i];
                }
                this.Data.Add(dic);
            }
        }
    }
}
