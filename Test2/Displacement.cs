using System;
using System.Collections;
using System.Collections.Generic;

namespace Test {
    public class Displacement {
        private List<int> ints = new List<int> ();
        private List<ulong> bools = new List<ulong> ();
        public void Ini () {
            for (int i = 0; i < 9; i++) {
                ints.Add (i);
            }
        }

        public void OPen (ulong value) {
            System.Console.WriteLine (value);
            for (int i = 0; i < ints.Count; i++) {
                System.Console.WriteLine (i + " : " + (value & ((ulong) 1 << (ints[i]))));
                bools.Add ((value & ((ulong) 1 << (ints[i]))));
            }
            for (int i = 0; i < bools.Count; i++) {
                System.Console.WriteLine ((i + 1) + "ulong槽位:  状态" + bools[i]);
            }
        }
        public void OPen (int value) {
            bools.Clear ();
            for (int i = 0; i < ints.Count; i++) {
                System.Console.WriteLine (i + " : " + (value & (1 << ints[i])));
                bools.Add ((ulong) (value & (1 << ints[i])));
            }
            for (int i = 0; i < bools.Count; i++) {
                System.Console.WriteLine ((i + 1) + "int 槽位:  状态" + bools[i]);
            }
        }
    }
}