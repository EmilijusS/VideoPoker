﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Card(SuitType.Spades, ValueType.Ace));

            Console.ReadLine();
        }
    }
}
