﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDDIVAPlugin;
using EliteDangerousNetLogMonitor;
using System.IO;
using System;

namespace Tests
{
    [TestClass]
    public class CoriolisTests
    {
        [TestMethod]
        public void TestCompressData()
        {
            string data = "1111111111111111";
            string base64Data = LZString.compressToBase64(data);
            Assert.AreEqual("Iw1/EA==", base64Data);
        }

        [TestMethod]
        public void TestCompressData2()
        {
            string data = "111111111111111111111111";
            var base64Data = LZString.compressToBase64(data);
            Assert.AreEqual("Iw18aQ==", base64Data);
        }

        [TestMethod]
        public void TestCompressData3()
        {
            string data = "000000000000000000000000";
            var base64Data = LZString.compressToBase64(data);
            Assert.AreEqual("Aw17aQAA", base64Data);
        }

        [TestMethod]
        public void TestDecompressData()
        {
            string base64Data = "Iw1/EA==";
            var data = LZString.decompressFromBase64(base64Data);
            Assert.AreEqual("1111111111111111", data);
        }

        [TestMethod]
        public void TestDecompressData2()
        {
            string base64Data = "IwgMIyKA";
            var data = LZString.decompressFromBase64(base64Data);
            Assert.AreEqual("1110111111111111", data);
        }

        // Does not work - need more data to understand the issue
        //[TestMethod]
        //public void TestDecompressData3()
        //{
        //    string base64Data = "CwBgjCnlPm8Qkm==";
        //    var data = LZString.decompressFromBase64(base64Data);
        //    Assert.AreEqual("1110111111111111", data);
        //}

        //[TestMethod]
        //public void TestNetLog()
        //{
        //    NetLogMonitor monitor = new NetLogMonitor("C:\\Program Files (x86)\\Elite\\Products\\elite-dangerous-64\\Logs", null);
        //    monitor.start();
        //    System.Threading.Thread.Sleep(180000);
        //    monitor.stop();
        //    //NetLogMonitor.Monitor("C:\\Program Files (x86)\\Elite\\Products\\elite-dangerous-64\\Logs", null);
        //}

        [TestMethod]
        public void TestUri()
        {
            string data = "BZ+24 123";
            string uriData = Uri.EscapeDataString(data);
            Assert.AreEqual("BZ%2B24%20123", uriData);
        }
    }
}
