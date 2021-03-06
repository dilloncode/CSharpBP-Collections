﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendEmailTest()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Company",
                "Message sent: Important message for: XYZ Inc"
            };
            var vendors = vendorsCollection.ToList();

            //Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestArray()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Company",
                "Message sent: Important message for: XYZ Inc"
            };
            var vendors = vendorsCollection.ToArray();
            Console.WriteLine(vendors.Length);

            //Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestDictionary()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC Company",
                "Message sent: Important message for: XYZ Inc"
            };
            var vendors = vendorsCollection.ToDictionary(v => v.CompanyName);

            //Act
            var actual = Vendor.SendEmail(vendors.Values, "Test Message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}