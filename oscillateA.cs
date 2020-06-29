/*
 * oscillateA.cs
 * 
 * Bailey Thompson
 * 28 October 2019
 * Version 1
 * 
 * Class Overview: Program that creates oscillateA objects with available public functions numGen(), reset(), getMode(), switchMode(), queryModeSwitches(), next(), 
 *   genNextNum(), setForbiddenSet()
 * 
 * Interface Invariant: 
 * > oscillateA object operates exactly like an arithS object, except that successive values returned from an oscillateA object
 * oscillate between negative and positive values.
 * > No parameters contructor and parameters constructor initialize the oscillateA object in the same exact way as the default and one parameter ctors in the arithS class
 * 
 * Class Invariant:
 * > Regardless of whether or not the next value in the sequence is negative or positive, a call to next() oscillates between positive and negative values, starting with positive
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    public class oscillateA : arithS
    {
        public oscillateA() : base() { }
        public oscillateA(int commonDifference) : base(commonDifference) { }
        public override int next()
        {
            if (nextCalls % 2 == 1)
                return -Math.Abs(base.next());
            return Math.Abs(base.next());
        }
    }
}
/*
 * Implementation Invariant: 
 * > oscillateA IS-A arithS
 * > Overrides next() function to alternate between returning positive and negative values, starting with positive
 * > Since next() function in arithS returns -1 for some values instead of throwing an exception, these values may be 
 *   changed to 1 since the oscillateA object oscillates between negative and positive
 */
