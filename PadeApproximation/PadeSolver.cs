using MultiPrecision;
using System;
using System.Linq;

namespace PadeApproximation {
    internal static class PadeSolver<N> where N : struct, IConstant {
        public static (MultiPrecision<N>[] ms, MultiPrecision<N>[] ns) Solve(MultiPrecision<N>[] cs, int m, int n) {
            if (m < 0) {
                throw new ArgumentOutOfRangeException(nameof(m));
            }
            if (n < 0) {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            if (cs.Length != checked(m + n + 1)) {
                throw new ArgumentException("Illegal length.", nameof(cs));
            }

            int k = m + n;

            MultiPrecision<N>[,] a = new MultiPrecision<N>[k, k];
            MultiPrecision<N>[] c = cs[1..];

            for (int j = 0; j < k; j++) {
                for (int i = 0; i < k; i++) {
                    a[j, i] = 0;
                }
            }

            for (int i = 0; i < m; i++) {
                a[i, i] = 1;
            }

            for (int i = m; i < k; i++) {
                for (int j = i - m, r = 0; j < k; j++, r++) {
                    a[j, i] = -cs[r];
                }
            }

            MultiPrecision<N>[] v = Algabra<N>.Mul(Algabra<N>.Invert(a), c);
            MultiPrecision<N>[] ms = new MultiPrecision<N>[] { cs[0] }.Concat(v[..m]).ToArray();
            MultiPrecision<N>[] ns = new MultiPrecision<N>[] { 1 }.Concat(v[m..]).ToArray();

            return (ms, ns);
        }
    }
}
