/*
 * oscillateAUnitTest.cs
 * 
 * Bailey Thompson
 * 28 October 2019
 * 
 * Class Overview: Unit Test class for oscillateA object in P3
 * 
 */
using System;
using P3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P3Tests
{
    [TestClass]
    public class oscillateAUnitTest
    {
        [TestMethod]
        public void TestModeOnInitialization1()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            string mode;
            //Act
            mode = OS.getMode();
            //Assert
            Assert.AreEqual("advance", mode);
        }
        [TestMethod]
        public void TestModeOnInitialization2()
        {
            //Arrange
            int commonDiff = 3;
            oscillateA OS = new oscillateA(commonDiff);
            string mode;
            //Act
            mode = OS.getMode();
            //Assert
            Assert.AreEqual("advance", mode);
        }
        [TestMethod]
        public void TestMode1()
        {
            //Arrange
            int commonDiff = 2;
            int calls = 6;
            oscillateA OS = new oscillateA(commonDiff);
            int[] forbidden = { 6, 8, 10, 12, 14 };
            string mode;
            //Act
            for (int i = 0; i < calls; i++)
                OS.next();
            mode = OS.getMode();
            //Assert
            Assert.AreEqual("forbidden advance", mode);
        }
        [TestMethod]
        public void TestNumGen1()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            int numGenCount;
            //Act
            numGenCount = OS.numGen();
            //Assert
            Assert.AreEqual(0, numGenCount);
        }
        [TestMethod]
        public void TestNumGen2()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            int numGenCount;
            //Act
            OS.next();
            numGenCount = OS.numGen();
            //Assert
            Assert.AreEqual(1, numGenCount);
        }
        public void TestNumGen3()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            int numGenCount;
            //Act 
            OS.next();
            OS.next();
            OS.reset();
            numGenCount = OS.numGen();
            //Assert
            Assert.AreEqual(0, numGenCount);
        }
        [TestMethod]
        public void TestNext1()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            int nextcall;
            //Act
            nextcall = OS.next();
            //Assert
            Assert.AreEqual(2, nextcall);
        }
        [TestMethod]
        public void TestNext2()
        {
            //Arrange
            int commonDiff = 3;
            oscillateA OS = new oscillateA(commonDiff);
            int nextcall;
            //Act
            nextcall = OS.next();
            //Assert
            Assert.AreEqual(3, nextcall);
        }
        [TestMethod]
        public void TestNext3()
        {
            //Arrange
            int commonDiff = 4;
            oscillateA OS = new oscillateA(commonDiff);
            int nextcall;
            //Act
            OS.next();
            OS.next();
            nextcall = OS.next();
            //Assert
            Assert.AreEqual(12, nextcall);
        }
        [TestMethod]
        public void TestNext4()
        {
            //Arrange
            int commonDiff = 4;
            oscillateA OS = new oscillateA(commonDiff);
            int nextcall;
            //Act
            OS.next();
            OS.next();
            OS.reset();
            nextcall = OS.next();
            //Assert
            Assert.AreEqual(4, nextcall);
        }
        [TestMethod]
        public void TestNext5()
        {
            //Arrange
            int commonDiff = 2;
            int calls = 6;
            oscillateA OS = new oscillateA(commonDiff);
            int[] forbidden = { 10, 12, 14, 16, 18 };
            OS.setForbiddenSet(forbidden);
            int nextcall;
            //Act
            for (int i = 0; i < calls; i++)
                OS.next();
            nextcall = OS.next();
            //Assert
            Assert.AreEqual(1, nextcall);
        }
        [TestMethod]
        public void TestSwitchModes1()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            string mode;
            //Act
            OS.switchMode();
            mode = OS.getMode();
            //Assert
            Assert.AreEqual("retreat", mode);

        }
        [TestMethod]
        public void TestSwitchModes2()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            string mode;
            //Act
            OS.switchMode();
            OS.switchMode();
            mode = OS.getMode();
            //Assert
            Assert.AreEqual("stuck", mode);
        }
        [TestMethod]
        public void TestQueryModeSwitches1()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            int modeSwitches;
            //Act
            modeSwitches = OS.queryModeSwitches();
            //Assert
            Assert.AreEqual(0, modeSwitches);
        }
        [TestMethod]
        public void TestQueryModeSwitches2()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            int modeSwitches;
            //Act
            OS.switchMode();
            OS.switchMode();
            modeSwitches = OS.queryModeSwitches();
            //Assert
            Assert.AreEqual(2, modeSwitches);
        }
        [TestMethod]
        public void TestQueryModeSwitches3()
        {
            //Arrange
            oscillateA OS = new oscillateA();
            int modeSwitches;
            //Act
            OS.switchMode();
            OS.switchMode();
            OS.reset();
            modeSwitches = OS.queryModeSwitches();
            //Assert
            Assert.AreEqual(0, modeSwitches);
        }
    }
}
