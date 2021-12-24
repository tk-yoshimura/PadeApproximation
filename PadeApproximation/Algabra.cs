using MultiPrecision;
using System;

namespace PadeApproximation {
    internal static class Algabra<N> where N : struct, IConstant {
        public static MultiPrecision<N>[,] Invert(MultiPrecision<N>[,] m) {
            if (m.GetLength(0) != m.GetLength(1)) {
                throw new ArgumentException(null, nameof(m));
            }

            int n = m.GetLength(0);
            MultiPrecision<N> pivot, inv_mii, mul, swap;

            MultiPrecision<N>[,] v = new MultiPrecision<N>[n, n];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    v[i, j] = (i == j) ? 1 : 0;
                }
            }

            for (int i = 0; i < n; i++) {
                pivot = MultiPrecision<N>.Abs(m[i, i]);
                int p = i;

                for (int j = i + 1; j < n; j++) {
                    if (MultiPrecision<N>.Abs(m[i, j]) > pivot) {
                        pivot = MultiPrecision<N>.Abs(m[i, j]);
                        p = j;
                    }
                }

                if (pivot.Exponent < -MultiPrecision<N>.Bits) {
                    throw new ArgumentException("Matrix is invalid.", nameof(m));
                }

                if (p != i) {
                    for (int j = 0; j < n; j++) {
                        swap = m[i, j];
                        m[i, j] = m[p, j];
                        m[p, j] = swap;
                    }

                    for (int j = 0; j < n; j++) {
                        swap = v[i, j];
                        v[i, j] = v[p, j];
                        v[p, j] = swap;
                    }
                }

                inv_mii = 1 / m[i, i];
                m[i, i] = 1;
                for (int j = i + 1; j < n; j++) {
                    m[i, j] *= inv_mii;
                }
                for (int j = 0; j < n; j++) {
                    v[i, j] *= inv_mii;
                }

                for (int j = i + 1; j < n; j++) {
                    mul = m[j, i];
                    m[j, i] = 0;
                    for (int k = i + 1; k < n; k++) {
                        m[j, k] -= m[i, k] * mul;
                    }
                    for (int k = 0; k < n; k++) {
                        v[j, k] -= v[i, k] * mul;
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--) {
                for (int j = i - 1; j >= 0; j--) {
                    mul = m[j, i];
                    for (int k = i; k < n; k++) {
                        m[j, k] = 0;
                    }
                    for (int k = 0; k < n; k++) {
                        v[j, k] -= v[i, k] * mul;
                    }
                }
            }

            return v;
        }

        public static MultiPrecision<N>[] Mul(MultiPrecision<N>[,] m, MultiPrecision<N>[] v) {
            if (m.GetLength(1) != v.Length) {
                throw new ArgumentException(null, nameof(m));
            }

            MultiPrecision<N>[] u = new MultiPrecision<N>[m.GetLength(0)];

            for (int i = 0; i < u.Length; i++) {
                MultiPrecision<N> s = 0;

                for (int j = 0; j < v.Length; j++) {
                    s += m[i, j] * v[j];
                }

                u[i] = s;
            }

            return u;
        }
    }
}
