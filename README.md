# PadeApproximation

Padé approximation is the best rational function that approximates a function.  
Formulated in the following equation:  

![pade1](https://github.com/tk-yoshimura/PadeApproximation/blob/main/figures/pade1.svg)  

It can also be written like this:  

![pade2](https://github.com/tk-yoshimura/PadeApproximation/blob/main/figures/pade2.svg)  

When the coefficients are obtained in the Maclaurin series as follows:

![pade3](https://github.com/tk-yoshimura/PadeApproximation/blob/main/figures/pade3.svg)  

With the following constraints:

![pade4](https://github.com/tk-yoshimura/PadeApproximation/blob/main/figures/pade4.svg)  

Each coefficient is uniquely determined.

![pade5](https://github.com/tk-yoshimura/PadeApproximation/blob/main/figures/pade5.svg)  

It is equivalent to solving the following simultaneous equations.

![pade6](https://github.com/tk-yoshimura/PadeApproximation/blob/main/figures/pade6.svg)  

## Implement
See below for an example implementation.  
Since this is a calculation that produces many digit loss, the double precision does not produce the expected results.  
[MultiPrecisionCurveFitting](https://github.com/tk-yoshimura/MultiPrecisionCurveFitting)

## See Also
[PadeInterpolation](https://github.com/tk-yoshimura/PadeInterpolation)