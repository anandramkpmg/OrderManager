using CsvHelper;
using OrderManager.Interface;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManager
{
    public class FileReader : IFileReader
    {
        string strExeFilePath, strWorkPath;
        public FileReader()
        {
            strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
        }

        public IEnumerable<T> ReadFiles<T>(string csvPath)  
        {
            var fullPath = strWorkPath + csvPath;
            // check for csv null as well
            if (!File.Exists(fullPath)) { throw new FileNotFoundException("File Not Found"); }

            using (var reader = new StreamReader(fullPath))
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB")))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

        public async Task Write(string csvPath, IEnumerable<object> records)
        {
            using (var writer = new StreamWriter(strWorkPath + csvPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
              await csv.WriteRecordsAsync(records);
            }
        }
    }
}
