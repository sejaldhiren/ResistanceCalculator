using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebResistanceCalculator;
using WebResistanceCalculator.Controllers;
using OhmCalculator;

namespace WebResistanceCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestFourBandCalculation()
        {
            //Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            //Act
            int result = ohmValueCalculator.CalculateOhmValue("yellow", "violet", "brown", "gold");

            //Assert
            Assert.AreEqual(470, result);
        }

        [TestMethod]
        public void TestSmallValue()
        {
            //Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            //Act
            int result = ohmValueCalculator.CalculateOhmValue("brown", "black", "black", "brown");

            //Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TestLargeValue()
        {
            //Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            //Act
            int result = ohmValueCalculator.CalculateOhmValue("white", "white", "blue", "silver");

            //Assert
            Assert.AreEqual(99000000, result);
        }
        

        [TestMethod]
        public void ZeroBandCalculation()
        {
            Exception exceptionResult = null;

            try
            {    // Arrange 
                IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

                // Act
                ohmValueCalculator.CalculateOhmValue(null, null, null, null);
            }
            catch (Exception exception)
            {
                exceptionResult = exception;
            }

            // Assert
            Assert.IsNotNull(exceptionResult);
            Assert.IsInstanceOfType(exceptionResult, typeof(ArgumentException));
        }

    }
}
