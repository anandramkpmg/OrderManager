﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransactionExporter.Interface
{
    public interface IFileReader
    {
        IEnumerable<T> ReadFiles<T>(string csvPath);
        Task Write(string csvPath, IEnumerable<object> records);
    }
}
