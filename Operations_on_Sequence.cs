﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sequence_Operations
{
    class Operations_on_Sequence
    {

        public static List<int> Accumulate_n(Func<int, int, int> op, int initial, List<List<int>> seqs)
        {
            List<int> result = new List<int>();
                result.Add(Accumulate(op,initial,Adding(seqs)));
            result.Add(Accumulate(op, initial, Adding(Select_Cdr_(seqs))));
            result.Add(Accumulate(op, initial, Adding(Select_Cdr_(Select_Cdr_(seqs)))));
            return result;

            List<int> Adding(List<List<int>> seq)
            {
                List<int> result = new List<int>();
                foreach(var i in seq)
                {
                    result.Add(Car(i));
                }
                return result;
            }
           
            
        }
        public static List<List<int>> Select_Cdr_(List<List<int>> seqs)
        {
            List<List<int>> result = new List<List<int>>();
            foreach(var i in seqs)
            {
                result.Add(Select_Cdr(i));
            }
            return result;
        }
        public static List<int> Select_Cdr(List<int> seq)
        {
            List<int> result = new List<int>();
            for(var i =1;i<seq.Count; i++)
            {
                result.Add(seq[i]);
            }
            return result;
        }
        public static List<int> Select_Car(List<int> seq)
        {
            List<int> result = new List<int>();
            if (seq.Count <= 0)
            {
                
                return result;
            }
            else
            {
                result.Add(seq.First());
                return  result;
            }
        }

        public static int Accumulate(Func<int, int, int> op, int initial, List<int> sequence)
        {
            if (sequence == null || sequence.Count <= 0)
            {
                return initial;
            }
            else
            {
                return op(Car(sequence), Accumulate(op, initial, Cdr(sequence)));
            }
            
        }

        private static List<int> Map(Func<int, int> proc, List<int> sequence)
        {
            var result = new List<int>();
          for(int i=0; i<sequence.Count; i++)
            {
                result.Add(proc(sequence[i]));
            }
            return result;
        }



        public static List<List<int>> Cdr(List<List<int>> list)
        {
            List<List<int>> result = new List<List<int>>();
            if (list == null || list.Count <= 0)
            {
                return default;
            }
            else
            {
                for (int i = 1; i < list.Count; i++)
                {
                    result.Add(list[i]);
                }
                return result;
            }
        }
        public static List<int> Cdr(List<int> list)
        {
            List<int> result = new List<int>();
            if(list == null || list.Count <= 0)
            {
                return default; 
            }
            else
            {
                for(int i =1; i<list.Count; i++)
                {
                    result.Add(list[i]);
                }
                return result;
            }
        }



        public static List<int> Car(List<List<int>> list)
        {
            if (list.Count <= 0 || list == null)
            {
                return default;
            }
            else
            {
                return list[0];
            }
        }
        public static int Car(List<int> list)
        {
            if (list.Count <= 0 || list == null)
            {
                return default;
            }
            else
            {
                return list[0];
            }
        }
        public  static int Plus(int a, int b)
        {
            return a + b;
        }
        private static int Minus(int a, int b)
        {
            return a - b;
        }
        private static int Multiply(int a, int b)
        {
            return a * b;
        }
        private static int Nul(int a, int b)
        {
            return default;
        }
    }
}
