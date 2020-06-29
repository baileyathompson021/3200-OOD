/*
 * skipAUnitTest.cs
 * 
 * Bailey Thompson
 * 28 October 2019
 * 
 * Class Overview: Unit Test class for skipA object in P3
 * 
 */
using System;
using P3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P3Tests
{
    /// <summary>
    /// Summary description for skipAUnitTest
    /// </summary>
    [TestClass]
    public class skipAUnitTest
    {
        [TestMethod]
        public void TestModeOnInitialization1()
        {
            //Arrange
            skipA SA = new skipA();
            string mode;
            //Act
            mode = SA.getMode();
            //Assert
            Assert.AreEqual("advance", mode);
        }
        [TestMethod]
        public void TestModeOnInitialization2()
        {
            //Arrange
            int commonDiff = 3;
            int skipInt = 2;
            skipA SA = new skipA(commonDiff, skipInt);
            string mode;
            //Act
            mode = SA.getMode();
            //Assert
            Assert.AreEqual("advance", mode);
        }
        [TestMethod]
        public void TestMode1()
        {
            //Arrange
            int calls = 6;
            int commonDiff = 2;
            int skipInt = 2;
            skipA SA = new skipA(commonDiff, skipInt);
            int[] forbidden = { 6, 8, 10, 12, 14 };
            string mode;
            //Act
            for (int i = 0; i < calls; i++)
                SA.next();
            mode = SA.getMode();
            //Assert
            Assert.AreEqual("forbidden advance", mode);
        }
        [TestMethod]
        public void TestNumGen1()
        {
            //Arrange
            skipA SA = new skipA();
            int numGenCount;
            //Act
            numGenCount = SA.numGen();
            //Assert
            Assert.AreEqual(0, numGenCount);
        }
        [TestMethod]
        public void TestNumGen2()
        {
            //Arrange
            skipA SA = new skipA();
            int numGenCount;
            //Act
            SA.next();
            numGenCount = SA.numGen();
            //Assert
            Assert.AreEqual(1, numGenCount);
        }
        public void TestNumGen3()
        {
            //Arrange
            skipA SA = new skipA();
            int numGenCount;
            //Act 
            SA.next();
            SA.next();
            SA.reset();
            numGenCount = SA.numGen();
            //Assert
            Assert.AreEqual(0, numGenCount);
        }
        [TestMethod]
        public void TestNext1()
        {
            //Arrange
            skipA SA = new skipA();
            int nextcall;
            //Act
            nextcall = SA.next();
            //Assert
            Assert.AreEqual(2, nextcall);

        }
        [TestMethod]
        public void TestNext2()
        {
            //Arrange
            int commonDiff = 3;
            int skipInt = 2;
            skipA SA = new skipA(commonDiff, skipInt);
            int nextcall;
            //Act
            nextcall = SA.next();
            //Assert
            Assert.AreEqual(9, nextcall);
        }
        [TestMethod]
        public void TestNext3()
        {
            //Arrange
            int commonDiff = 4;
            int skipInt = 2;
            skipA SA = new skipA(commonDiff, skipInt);
            int nextcall;
            //Act
            SA.next();
            SA.next();
            nextcall = SA.next();
            //Assert
            Assert.AreEqual(36, nextcall);
        }
        [TestMethod]
        public void TestNext4()
        {
            //Arrange
            int commonDiff = 4;
            int skipInt = 2;
            skipA SA = new skipA(commonDiff, skipInt);
            int nextcall;
            //Act
            SA.next();
            SA.next();
            SA.reset();
            nextcall = SA.next();
            //Assert
            Assert.AreEqual(12, nextcall);
        }
        [TestMethod]
        public void TestNext5()
        {
            //Arrange
            int calls = 6;
            int commonDiff = 3;
            int skipInt = 2;
            skipA SA = new skipA(commonDiff, skipInt);
            int[] forbidden = { 54, 63, 66, 69, 72 };
            SA.setForbiddenSet(forbidden);
            int nextcall;
            //Act
            for (int i = 0; i < calls; i++)
                SA.next();
            nextcall = SA.next();
            //Assert
            Assert.AreEqual(-1, nextcall);
        }
        [TestMethod]
        public void TestSwitchModes1()
        {
            //Arrange
            skipA SA = new skipA();
            string mode;
            //Act
            SA.switchMode();
            mode = SA.getMode();
            //Assert
            Assert.AreEqual("retreat", mode);

        }
        [TestMethod]
        public void TestSwitchModes2()
        {
            //Arrange
            skipA SA = new skipA();
            string mode;
            //Act
            SA.switchMode();
            SA.switchMode();
            mode = SA.getMode();
            //Assert
            Assert.AreEqual("stuck", mode);
        }
        [TestMethod]
        public void TestQueryModeSwitches1()
        {
            //Arrange
            skipA SA = new skipA();
            int modeSwitches;
            //Act
            modeSwitches = SA.queryModeSwitches();
            //Assert
            Assert.AreEqual(0, modeSwitches);
        }
        [TestMethod]
        public void TestQueryModeSwitches2()
        {
            //Arrange
            skipA SA = new skipA();
            int modeSwitches;
            //Act
            SA.switchMode();
            SA.switchMode();
            modeSwitches = SA.queryModeSwitches();
            //Assert
            Assert.AreEqual(2, modeSwitches);
        }
        [TestMethod]
        public void TestQueryModeSwitches3()
        {
            //Arrange
            skipA SA = new skipA();
            int modeSwitches;
            //Act
            SA.switchMode();
            SA.switchMode();
            SA.reset();
            modeSwitches = SA.queryModeSwitches();
            //Assert
            Assert.AreEqual(0, modeSwitches);
        }
    }
}
