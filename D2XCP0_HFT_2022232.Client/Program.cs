using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using System;
using System.Linq;

namespace D2XCP0_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookDbcontext ctx = new BookDbcontext();

            var a = ctx.Authors.ToArray();

            ;
            
        }
    }
}
