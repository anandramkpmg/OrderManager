﻿using System.Threading.Tasks;
using TransactionExporter.Interface;
using TransactionExporter.Models;
using TransactionExporter.Oms;
using TransactionExporter.Oms.Exceptions;

namespace OrderManager
{
    public class TransactionExporter
    {
        private readonly string _transactionsFilePath = @"\files\transactions.csv";
        private readonly string _securitiesFilePath = @"\files\securities.csv";
        private readonly string _portfoliosFilePath = @"\files\portfolios.csv";
        private readonly IFileReader _fileReader;
        public TransactionExporter(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public async Task ExportCsvFile(string omsType)
        {
            if (string.IsNullOrEmpty(omsType)) { throw new MissingOmsTypeException($" Missing OMS Type { omsType } "); }

            var transactions = _fileReader.ReadFiles<Transaction>(_transactionsFilePath);
            var securities = _fileReader.ReadFiles<Securities>(_securitiesFilePath);
            var portfolios = _fileReader.ReadFiles<Portfolio>(_portfoliosFilePath);

            var mappedTransactions = Mapper.Map(transactions, securities, portfolios);

            await OmsTypeFactory.GetOmsType(omsType).ExportOms(mappedTransactions);             
        }
    }
}