/*
 * arithSUnitTest.cs
 * 
 * Bailey Thompson
 * 28 October 2019
 * 
 * Class Overview: Unit Test class for arithS object in P3
 * 
 */

using System;
using P3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P3Tests
{
    [TestClass]
    public class arithSUnitTest
    {
        [TestMethod]
        public void TestModeOnInitialization1()
        {
            //Arrange
            arithS AS = new arithS();
            string mode;
            //Act
            mode = AS.getMode();
            //Assert
            Assert.AreEqual("advance", mode);
        }
        [TestMethod]
        public void TestModeOnInitialization2()
        {
            //Arrange
            int commonDiff = 3;
            arithS AS = new arithS(commonDiff);
            string mode;
            //Act
            mode = AS.getMode();
            //Assert
            Assert.AreEqual("advance", mode);
        }
        [TestMethod]
        public void TestMode1()
        {
            //Arrange
            int commonDiff = 2;
            int calls = 6;
            arithS AS = new arithS(commonDiff);
            int[] forbidden = { 6, 8, 10, 12, 14 };
            string mode;
            //Act
            for (int i = 0; i < calls; i++)
                AS.next();
            mode = AS.getMode();
            //Assert
            Assert.AreEqual("forbidden advance", mode);
        }
        [TestMethod]
        public void TestNumGen1()
        {
            //Arrange
            arithS AS = new arithS();
            int numGenCount;
            //Act
            numGenCount = AS.numGen();
            //Assert
            Assert.AreEqual(0, numGenCount);
        }
        [TestMethod]
        public void TestNumGen2()
        {
            //Arrange
            arithS AS = new arithS();
            int numGenCount;
            //Act
            AS.next();
            numGenCount = AS.numGen();
            //Assert
            Assert.AreEqual(1, numGenCount);
        }
        public void TestNumGen3()
        {
            //Arrange
            arithS AS = new arithS();
            int numGenCount;
            //Act 
            AS.next();
            AS.next();
            AS.reset();
            numGenCount = AS.numGen();
            //Assert
            Assert.AreEqual(0, numGenCount);
        }
        [TestMethod]
        public void TestNext1()
        {
            //Arrange
            arithS AS = new arithS();
            int nextcall;
            //Act
            nextcall = AS.next();
            //Assert
            Assert.AreEqual(2, nextcall);

        }
        [TestMethod]
        public void TestNext2()
        {
            //Arrange
            int commonDiff = 3;
            arithS AS = new arithS(commonDiff);
            int nextcall;
            //Act
            nextcall = AS.next();
            //Assert
            Assert.AreEqual(3, nextcall);
        }
        [TestMethod]
        public void TestNext3()
        {
            //Arrange
            int commonDiff = 4;
            arithS AS = new arithS(commonDiff);
            int nextcall;
            //Act
            AS.next();
            AS.next();
            nextcall = AS.next();
            //Assert
            Assert.AreEqual(12, nextcall);
        }
        [TestMethod]
        public void TestNext4()
        {
            //Arrange
            int commonDiff = 4;
            arithS AS = new arithS(commonDiff);
            int nextcall;
            //Act
            AS.next();
            AS.next();
            AS.reset();
            nextcall = AS.next();
            //Assert
            Assert.AreEqual(4, nextcall);
        }
        [TestMethod]
        public void TestNext5()
        {
            //Arrange
            int commonDiff = 2;
            int calls = 6;
            arithS AS = new arithS(commonDiff);
            int[] forbidden = { 10, 12, 14, 16, 18};
            AS.setForbiddenSet(forbidden);
            int nextcall;
            //Act
            for (int i = 0; i < calls; i++)
                AS.next();
            nextcall = AS.next();
            //Assert
            Assert.AreEqual(-1, nextcall);
        }
        [TestMethod]
        public void TestSwitchModes1()
        {
            //Arrange
            arithS AS = new arithS();
            string mode;
            //Act
            AS.switchMode();
            mode = AS.getMode();
            //Assert
            Assert.AreEqual("retreat", mode);

        }
        [TestMethod]
        public void TestSwitchModes2()
        {
            //Arrange
            arithS AS = new arithS();
            string mode;
            //Act
            AS.switchMode();
            AS.switchMode();
            mode = AS.getMode();
            //Assert
            Assert.AreEqual("stuck", mode);
        }
        [TestMethod]
        public void TestQueryModeSwitches1()
        {
            //Arrange
            arithS AS = new arithS();
            int modeSwitches;
            //Act
            modeSwitches = AS.queryModeSwitches();
            //Assert
            Assert.AreEqual(0, modeSwitches);
        }
        [TestMethod]
        public void TestQueryModeSwitches2()
        {
            //Arrange
            arithS AS = new arithS();
            int modeSwitches;
            //Act
            AS.switchMode();
            AS.switchMode();
            modeSwitches = AS.queryModeSwitches();
            //Assert
            Assert.AreEqual(2, modeSwitches);
        }
        [TestMethod]
        public void TestQueryModeSwitches3()
        {
            //Arrange
            arithS AS = new arithS();
            int modeSwitches;
            //Act
            AS.switchMode();
            AS.switchMode();
            AS.reset();
            modeSwitches = AS.queryModeSwitches();
            //Assert
            Assert.AreEqual(0, modeSwitches);
        }
    }
}
