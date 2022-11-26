using System.IO;
using System.Linq;
using TransactionExporter.Interface;
using TransactionExporter.Oms.Exceptions;
using TransactionExporter.Tests;
using Xunit;

namespace OrderManager.Tests
{
    public class TransactionExporterTests
    {
        private readonly IFileReader _fileReader;
        private readonly TransactionExporter _orderManager;
        public TransactionExporterTests()
        {
            _fileReader = new FileReader();
            _orderManager = new TransactionExporter(_fileReader);
            CleanUp();
        }

        [Theory]
        [InlineData("AAA")]
        [InlineData("aaa")]
        public async void OrderManager_TypeAAA_ExportsAAAFile(string omsType)
        {
            await _orderManager.ExportCsvFile(omsType);

            var omsaaa = _fileReader.ReadFiles<TransactionA>(@"\files\results.aaa");

            Assert.Single<TransactionA>(omsaaa);
            Assert.True(omsaaa.First().TransactionType == "BUY");
            Assert.True(omsaaa.First().Isin == "ISIN11111111");
            Assert.True(omsaaa.First().PortfolioCode == "p1");
            Assert.True(omsaaa.First().Nominal == 10);
        }

        [Theory]
        [InlineData("BBB")]
        [InlineData("bbb")]
        public async void OrderManager_TypeBBB_ExportsBBBFile(string omsType)
        {
            await _orderManager.ExportCsvFile(omsType);

            var omsbbb = _fileReader.ReadFiles<TransactionB>(@"\files\results.bbb");

            Assert.Single<TransactionB>(omsbbb);
            Assert.True(omsbbb.First().TransactionType == "SELL");
            Assert.True(omsbbb.First().Cusip == "CUSIP0002");
            Assert.True(omsbbb.First().PortfolioCode == "p2");
            Assert.True(omsbbb.First().Nominal == 20);
        }

        [Theory]
        [InlineData("CCC")]
        [InlineData("ccc")]
        public async void OrderManager_TypeBBB_ExportsCCCFile(string omsType)
        {
            await _orderManager.ExportCsvFile(omsType);

            var omsccc = _fileReader.ReadFiles<TransactionC>(@"\files\results.ccc");

            Assert.Single<TransactionC>(omsccc);
            Assert.True(omsccc.First().TransactionType == "BUY");
            Assert.True(omsccc.First().Ticker == "s1");
            Assert.True(omsccc.First().PortfolioCode == "p2");
            Assert.True(omsccc.First().Nominal == 30);
        }

        [Theory]
        [InlineData("")]
        [InlineData("DDD")]
        public async void OrderManager_InValidOmsType_ThrowsException(string omsType)
        {
            await Assert.ThrowsAsync<MissingOmsTypeException>(() => _orderManager.ExportCsvFile(omsType));
        }

        private static void CleanUp()
        {
            var strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var strWorkPath = Path.GetDirectoryName(strExeFilePath);

            if (File.Exists(strWorkPath + @"\files\results.aaa"))
            {
                File.Delete(strWorkPath + @"\files\results.aaa");
            }

            if (File.Exists(strWorkPath + @"\files\results.bbb"))
            {
                File.Delete(strWorkPath + @"\files\results.bbb");
            }

            if (File.Exists(strWorkPath + @"\files\results.ccc"))
            {
                File.Delete(strWorkPath + @"\files\results.ccc");
            }
        }
    }
}

