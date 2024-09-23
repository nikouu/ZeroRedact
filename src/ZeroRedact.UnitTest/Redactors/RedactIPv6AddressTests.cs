﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactIPv6AddressTests
    {
        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { ":1", "********" };
            yield return new object[] { "2001:db8::2:1", "*************" };
            yield return new object[] { "::1", "***" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "***************************************" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { ":1", "********" };
            yield return new object[] { "2001:db8::2:1", "********" };
            yield return new object[] { "::1", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { ":1", "********" };
            yield return new object[] { "2001:db8::2:1", "****:***::*:*" };
            yield return new object[] { "::1", "::*" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "****:****:****:****:****:****:****:****" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7335", "****:****:****:****:****:****:****:****" };
        }

        private static IEnumerable<object[]> ShowLastQuartet_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { ":1", "********" };
            yield return new object[] { "2001:db8::2:1", "****:***::*:1" };
            yield return new object[] { "::1", "::1" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "****:****:****:****:****:****:****:7334" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7335", "****:****:****:****:****:****:****:7335" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_All_ShouldReturnRedactedRedactIPv6_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input, new IPv6RedactorOptions { RedactorType = IPv6Redaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_All_ShouldReturnRedactedRedactIPv6_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input.AsSpan(), new IPv6RedactorOptions { RedactorType = IPv6Redaction.All });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_FixedLength_ShouldReturnRedactedRedactIPv6_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input, new IPv6RedactorOptions { RedactorType = IPv6Redaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_FixedLength_ShouldReturnRedactedRedactIPv6_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input.AsSpan(), new IPv6RedactorOptions { RedactorType = IPv6Redaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_Full_ShouldReturnRedactedRedactIPv6_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input, new IPv6RedactorOptions { RedactorType = IPv6Redaction.Full });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_Full_ShouldReturnRedactedRedactIPv6_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input.AsSpan(), new IPv6RedactorOptions { RedactorType = IPv6Redaction.Full });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastQuartet_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_ShowLastQuartet_ShouldReturnRedactedRedactIPv6_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input, new IPv6RedactorOptions { RedactorType = IPv6Redaction.ShowLastQuartet });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastQuartet_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv6_ShowLastQuartet_ShouldReturnRedactedRedactIPv6_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv6Address(input.AsSpan(), new IPv6RedactorOptions { RedactorType = IPv6Redaction.ShowLastQuartet });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }
    }
}