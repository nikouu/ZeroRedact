#pragma warning disable CS8625
#pragma warning disable CS8618

using System.Globalization;

namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactDateTests
    {
        private Redactor _redactor;

        [TestInitialize]
        public void Setup()
        {
            _redactor = new Redactor();
        }
        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "**********" };
            yield return new object[] { null, 2023, 6, 15, "**********" };
            yield return new object[] { null, 2023, 11, 1, "**********" };
            yield return new object[] { null, 2023, 12, 31, "**********" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "*********" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "**********" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "*********" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "**********" };

            yield return new object[] { "en-US", 2023, 1, 1, "********" };
            yield return new object[] { "en-US", 2023, 6, 15, "*********" };
            yield return new object[] { "en-US", 2023, 11, 1, "*********" };
            yield return new object[] { "en-US", 2023, 12, 31, "**********" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "**********" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "**********" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "**********" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "**********" };
        }
        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "********" };
            yield return new object[] { null, 2023, 6, 15, "********" };
            yield return new object[] { null, 2023, 11, 1, "********" };
            yield return new object[] { null, 2023, 12, 31, "********" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "********" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "********" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "********" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "********" };

            yield return new object[] { "en-US", 2023, 1, 1, "********" };
            yield return new object[] { "en-US", 2023, 6, 15, "********" };
            yield return new object[] { "en-US", 2023, 11, 1, "********" };
            yield return new object[] { "en-US", 2023, 12, 31, "********" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "********" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "********" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "********" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "**/**/****" };
            yield return new object[] { null, 2023, 6, 15, "**/**/****" };
            yield return new object[] { null, 2023, 11, 1, "**/**/****" };
            yield return new object[] { null, 2023, 12, 31, "**/**/****" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "*/**/****" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "**/**/****" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "*/**/****" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "**/**/****" };

            yield return new object[] { "en-US", 2023, 1, 1, "*/*/****" };
            yield return new object[] { "en-US", 2023, 6, 15, "*/**/****" };
            yield return new object[] { "en-US", 2023, 11, 1, "**/*/****" };
            yield return new object[] { "en-US", 2023, 12, 31, "**/**/****" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "****/**/**" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "****/**/**" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "****/**/**" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "****/**/**" };
        }
        private static IEnumerable<object[]> Day_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "01/**/2023" };
            yield return new object[] { null, 2023, 6, 15, "06/**/2023" };
            yield return new object[] { null, 2023, 11, 1, "11/**/2023" };
            yield return new object[] { null, 2023, 12, 31, "12/**/2023" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "*/01/2023" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "**/06/2023" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "*/11/2023" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "**/12/2023" };

            yield return new object[] { "en-US", 2023, 1, 1, "1/*/2023" };
            yield return new object[] { "en-US", 2023, 6, 15, "6/**/2023" };
            yield return new object[] { "en-US", 2023, 11, 1, "11/*/2023" };
            yield return new object[] { "en-US", 2023, 12, 31, "12/**/2023" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "2023/01/**" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "2023/06/**" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "2023/11/**" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "2023/12/**" };
        }

        private static IEnumerable<object[]> Month_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "**/01/2023" };
            yield return new object[] { null, 2023, 6, 15, "**/15/2023" };
            yield return new object[] { null, 2023, 11, 1, "**/01/2023" };
            yield return new object[] { null, 2023, 12, 31, "**/31/2023" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "1/**/2023" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "15/**/2023" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "1/**/2023" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "31/**/2023" };

            yield return new object[] { "en-US", 2023, 1, 1, "*/1/2023" };
            yield return new object[] { "en-US", 2023, 6, 15, "*/15/2023" };
            yield return new object[] { "en-US", 2023, 11, 1, "**/1/2023" };
            yield return new object[] { "en-US", 2023, 12, 31, "**/31/2023" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "2023/**/01" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "2023/**/15" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "2023/**/01" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "2023/**/31" };
        }
        private static IEnumerable<object[]> Year_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "01/01/****" };
            yield return new object[] { null, 2023, 6, 15, "06/15/****" };
            yield return new object[] { null, 2023, 11, 1, "11/01/****" };
            yield return new object[] { null, 2023, 12, 31, "12/31/****" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "1/01/****" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "15/06/****" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "1/11/****" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "31/12/****" };

            yield return new object[] { "en-US", 2023, 1, 1, "1/1/****" };
            yield return new object[] { "en-US", 2023, 6, 15, "6/15/****" };
            yield return new object[] { "en-US", 2023, 11, 1, "11/1/****" };
            yield return new object[] { "en-US", 2023, 12, 31, "12/31/****" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "****/01/01" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "****/06/15" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "****/11/01" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "****/12/31" };
        }
        private static IEnumerable<object[]> DayAndMonth_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "**/**/2023" };
            yield return new object[] { null, 2023, 6, 15, "**/**/2023" };
            yield return new object[] { null, 2023, 11, 1, "**/**/2023" };
            yield return new object[] { null, 2023, 12, 31, "**/**/2023" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "*/**/2023" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "**/**/2023" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "*/**/2023" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "**/**/2023" };

            yield return new object[] { "en-US", 2023, 1, 1, "*/*/2023" };
            yield return new object[] { "en-US", 2023, 6, 15, "*/**/2023" };
            yield return new object[] { "en-US", 2023, 11, 1, "**/*/2023" };
            yield return new object[] { "en-US", 2023, 12, 31, "**/**/2023" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "2023/**/**" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "2023/**/**" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "2023/**/**" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "2023/**/**" };
        }
        private static IEnumerable<object[]> MonthAndYear_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "**/01/****" };
            yield return new object[] { null, 2023, 6, 15, "**/15/****" };
            yield return new object[] { null, 2023, 11, 1, "**/01/****" };
            yield return new object[] { null, 2023, 12, 31, "**/31/****" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "1/**/****" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "15/**/****" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "1/**/****" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "31/**/****" };

            yield return new object[] { "en-US", 2023, 1, 1, "*/1/****" };
            yield return new object[] { "en-US", 2023, 6, 15, "*/15/****" };
            yield return new object[] { "en-US", 2023, 11, 1, "**/1/****" };
            yield return new object[] { "en-US", 2023, 12, 31, "**/31/****" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "****/**/01" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "****/**/15" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "****/**/01" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "****/**/31" };
        }

        private static IEnumerable<object[]> DayAndYear_TestData()
        {
            yield return new object[] { null, 2023, 1, 1, "01/**/****" };
            yield return new object[] { null, 2023, 6, 15, "06/**/****" };
            yield return new object[] { null, 2023, 11, 1, "11/**/****" };
            yield return new object[] { null, 2023, 12, 31, "12/**/****" };

            yield return new object[] { "en-NZ", 2023, 1, 1, "*/01/****" };
            yield return new object[] { "en-NZ", 2023, 6, 15, "**/06/****" };
            yield return new object[] { "en-NZ", 2023, 11, 1, "*/11/****" };
            yield return new object[] { "en-NZ", 2023, 12, 31, "**/12/****" };

            yield return new object[] { "en-US", 2023, 1, 1, "1/*/****" };
            yield return new object[] { "en-US", 2023, 6, 15, "6/**/****" };
            yield return new object[] { "en-US", 2023, 11, 1, "11/*/****" };
            yield return new object[] { "en-US", 2023, 12, 31, "12/**/****" };

            yield return new object[] { "ja-JP", 2023, 1, 1, "****/01/**" };
            yield return new object[] { "ja-JP", 2023, 6, 15, "****/06/**" };
            yield return new object[] { "ja-JP", 2023, 11, 1, "****/11/**" };
            yield return new object[] { "ja-JP", 2023, 12, 31, "****/12/**" };
        }


        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_All_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.All });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_FixedLength_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.FixedLength });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_Full_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.Full });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }       

        [TestMethod]
        [DynamicData(nameof(Day_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_Day_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.Day });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }       

        [TestMethod]
        [DynamicData(nameof(Month_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_Month_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.Month });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        [DynamicData(nameof(Year_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_Year_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.Year });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(DayAndMonth_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_DayAndMonth_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.DayAndMonth });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(MonthAndYear_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_MonthAndYear_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.MonthAndYear });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(DayAndYear_TestData), DynamicDataSourceType.Method)]
        public void RedactDate_DayAndYear_ShouldReturnRedactedDate(string? cultureName, int year, int month, int day, string expected)
        {
            // Arrange
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = cultureName is null ? CultureInfo.InvariantCulture : new CultureInfo(cultureName);

            // Act
            string result = _redactor.RedactDate(new DateOnly(year, month, day), new DateRedactorOptions { RedactorType = DateRedaction.DayAndYear });

            CultureInfo.CurrentCulture = originalCulture;

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
