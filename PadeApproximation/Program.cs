using MultiPrecision;
using System;

namespace PadeApproximation {
    internal class Program {
        static void Main() {
            (var m, var n) = PadeSolver<Pow2.N8>.Solve(new MultiPrecision<Pow2.N8>[] {
                1,
                1,
                MultiPrecision<Pow2.N8>.Rcp(2),
                MultiPrecision<Pow2.N8>.Rcp(6),
                MultiPrecision<Pow2.N8>.Rcp(24),
                MultiPrecision<Pow2.N8>.Rcp(120),
                MultiPrecision<Pow2.N8>.Rcp(720),
                MultiPrecision<Pow2.N8>.Rcp(5040),
                MultiPrecision<Pow2.N8>.Rcp(40320),
                MultiPrecision<Pow2.N8>.Rcp(362880),
                MultiPrecision<Pow2.N8>.Rcp(3628800),
            }, 5, 5);

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
