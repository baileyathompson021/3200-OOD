/*
 * P3.cs
 * 
 * Bailey Thompson
 * 28 October 2019
 * Version 1
 * 
 * Class Overview: Driver class to demonstrate capabilities of arithS as well as descendant classes oscillateA and skipA
 * > initialize(AS/OS/SA) initializes each heterogeneous array with objects of each type, alternating between the default ctor and parameter ctor, 
 *   where each array is 'size' in size
 *   Randomly generates a forbidden set for every two objects, but randomly decides which objects are assigned forbidden sets
 * > displayModes() displays the mode of each object
 * > getNumValuesGenerated() displays the call to the numGen() function for each object
 * > resetAll() resets all of the objects
 * > testNextCall() 
 * > switchModes() 
 * > displayNumModeSwitches() 
 * 
 * Class initializes all of the arrays, displays their initial modes, calls next() function for each object 'testTimes' times, switches modes, 
 * displays that mode, and repeats for 'testTimes' times
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class P3
    {
        static int size = 6; //Assumes this integer is positive and even
        
        static int testTimes = 6;
        static int testNextTimes = 5;

        static int forbiddenSetSize = 5;
        static int forbiddenSetMin = 1;
        static int forbiddenSetMax = 10;

        static int commonDiffMax = 10;
        static int skipMax = 20;

        arithS[] testAS = new arithS[size];
        oscillateA[] testOS = new oscillateA[size];
        skipA[] testSA = new skipA[size];
        
        static void Main(string[] args)
        {
            P3 test = new P3();

            test.initializeAS();
            test.initializeOS();
            test.initializeSA();

            test.displayModes();
            test.getNumValuesGenerated();
            
            test.testNextCall(testTimes);

            for (int i = 0; i < testTimes; i++)
            {
                test.switchModes();
                test.displayModes();
                test.testNextCall(testNextTimes);
            }

            test.displayNumModeSwitches();

            test.resetAll();
            test.displayModes();
        }

        public void initializeAS()
        {
            Random rand = new Random();
            for (int i = 0; i < size - 1; i += 2)
            {
                int[] forbiddenSet = new int[forbiddenSetSize];
                for (int j = 0; j < forbiddenSetSize; j++)
                    forbiddenSet[i] = rand.Next(forbiddenSetMin, forbiddenSetMax);
                testAS[i] = new arithS();
                if (rand.Next(commonDiffMax) % 2 == 0)
                    testAS[i].setForbiddenSet(forbiddenSet);
                testAS[i + 1] = new arithS(rand.Next(commonDiffMax));
                if (rand.Next(commonDiffMax) % 2 == 0)
                    testAS[i + 1].setForbiddenSet(forbiddenSet);
            }
        }
        public void initializeOS()
        {
            Random rand = new Random();
            for (int i = 0; i < size - 1; i+=2)
            {
                int[] forbiddenSet = new int[forbiddenSetSize];
                for (int j = 0; j < forbiddenSetSize; j++)
                    forbiddenSet[i] = rand.Next(forbiddenSetMin, forbiddenSetMax);
                testOS[i] = new oscillateA();
                testOS[i + 1] = new oscillateA(rand.Next(commonDiffMax));
                if (rand.Next(commonDiffMax) % 2 == 0)
                    testOS[i].setForbiddenSet(forbiddenSet);
                if (rand.Next(commonDiffMax) % 2 == 0)
                    testOS[i + 1].setForbiddenSet(forbiddenSet);
            }
        }
        public void initializeSA()
        {
            Random rand = new Random();
            for (int i = 0; i < size - 1; i+=2)
            {
                int[] forbiddenSet = new int[forbiddenSetSize];
                for (int j = 0; j < forbiddenSetSize; j++)
                    forbiddenSet[i] = rand.Next(forbiddenSetMin, forbiddenSetMax);
                testSA[i] = new skipA();
                testSA[i + 1] = new skipA(rand.Next(commonDiffMax), rand.Next(skipMax));
                if (rand.Next(commonDiffMax) % 2 == 0)
                    testSA[i].setForbiddenSet(forbiddenSet);
                if (rand.Next(commonDiffMax) % 2 == 0)
                    testSA[i + 1].setForbiddenSet(forbiddenSet);
            }
        }
        public void displayModes()
        {
            for (int i = 0; i < size; i++)
                Console.WriteLine("arithS" + (i + 1) + " mode is in " + testAS[i].getMode() + " mode");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.WriteLine("oscillateA" + (i + 1) + " mode is in " + testOS[i].getMode() + " mode");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.WriteLine("skipA" + (i + 1) + " mode is in " + testSA[i].getMode() + " mode");
            Console.WriteLine();
        }
        public void getNumValuesGenerated()
        {
            for (int i = 0; i < size; i++)
                Console.WriteLine("arithS" + (i + 1) + " has generated " + testAS[i].numGen() + " values");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.WriteLine("oscillateA" + (i + 1) + " has generated " + testOS[i].numGen() + " values");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.WriteLine("skipA" + (i + 1) + " has generated " + testSA[i].numGen() + " values");
            Console.WriteLine();
        }
        public void resetAll()
        {
            for (int i = 0; i < size; i++)
            {
                testAS[i].reset();
                testSA[i].reset();
                testOS[i].reset();
            }
            Console.WriteLine("All objects have been reset.");
            Console.WriteLine();
        }
        public void testNextCall(int testTimes)
        {
            for (int j = 0; j < testTimes; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("arithA" + (i + 1) + "'s call to next() returns " + testAS[i].next());
                }
                Console.WriteLine();
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("oscillateA" + (i + 1) + "'s call to next() returns " + testOS[i].next());
                }
                Console.WriteLine();
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("skipA" + (i + 1) + "'s call to next() returns " + testSA[i].next());
                }
                Console.WriteLine();
            }
        }
        public void switchModes()
        {
            for (int i = 0; i < size; i++)
            {
                testAS[i].switchMode();
                testOS[i].switchMode();
                testSA[i].switchMode();
            }
            Console.WriteLine("All objects have switched modes");
            Console.WriteLine();
        }
        public void displayNumModeSwitches()
        {
            for (int i = 0; i < size; i++)
                Console.WriteLine("arithS" + (i + 1) + " has switched modes " + testAS[i].queryModeSwitches() + " times");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.WriteLine("oscillateA" + (i + 1) + " has switched modes " + testOS[i].queryModeSwitches() + " times");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.WriteLine("skipA" + (i + 1) + " has switched modes " + testSA[i].numGen() + " times");
            Console.WriteLine();
        }
    }
}
