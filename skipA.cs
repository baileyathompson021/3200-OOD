/*
 * skipA.cs
 * 
 * Bailey Thompson
 * 28 October 2019
 * Version 1
 * 
 * Class Overview: Program that creates skipA objects with available public functions numGen(), reset(), getMode(), switchMode(), queryModeSwitches(), next(), 
 *   genNextNum(), setForbiddenSet()
 * 
 * Interface Invariant: 
 * > skipA operates exactly like an arithS object, except that values returned from a skipA object reflect the skipping of 'skipInt' values
 * > No parameters constructor initializes 'skipInt' to be 0, meaning no integers are skipped and therefore the object behaves exactly like the arithS class
 *   no parameter object
 * > Parameter constructor takes in value for common difference (generating the sequence exactly like the arithS class) and the 'skipInt' integer
 * 
 * Class Invariant:
 * > skipInt is created to be the positive value of whatever integer the user passes in
 *   when integers are skipped in a skipA object, they are only skipped in a positive direction (cannot skip to become a smaller integer unless common difference
 *   is negative)
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    public class skipA : arithS
    {
        private int skipInt;

        public skipA() : base()
        {
            skipInt = 0;
        }
        public skipA(int commonDifference, int skipInt) : base(commonDifference)
        {
            this.skipInt = Math.Abs(skipInt);
        }
        public override int next()
        {
            int check;
            for (int i = 0; i < skipInt; i++)
                check = base.next();
            return base.next();
        }
    }
}
/*
 * Implementation Invariant: 
 * > skipA IS-A arithS
 * > Generation of next number in sequence uses Constructor Injection for the amount of number that are skipped in the sequence
 * > No parameter ctor uses the base class no parameter ctor and behaves exactly as so
 *   Parameters ctor uses the one parameter ctor from base class to generate the value of the common difference
 * > skipInt is a stable, internal value used to determine how many numbers in the sequence are skipped in a call to next()
 *   This value may not be changed or removed after initialization of object
 * > next() function is updated to skip 'skipInt' values and return the next call to the base class version of next()
 *   integer 'check' was implemented for tracing purposes
 * 
 */
