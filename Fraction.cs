using System;
using System.Numerics;

namespace FractionClass {
  public class Fraction {
    public Fraction(int numerator = 0, int denominator = 1) {
      _numerator = numerator;
      _denominator = denominator;
      Reduction();
    }

    public int Numerator {
      get => _numerator;
      set {
        _numerator = value;
        Reduction();
      }
    }

    public int Denominator {
      get => _denominator;
      set {
        _denominator = value;
        Reduction();
      }
    }

    public static Fraction operator +(Fraction fraction1, Fraction fraction2) {
      Fraction fraction = new Fraction();

      fraction._denominator = (int) ((long) fraction1._denominator * fraction2._denominator /
                                     (long) BigInteger.GreatestCommonDivisor((BigInteger) fraction1._denominator,
                                       (BigInteger) fraction2._denominator));

      fraction._numerator =
        fraction1._numerator * (fraction._denominator / fraction1._denominator) +
        fraction2._numerator * (fraction._denominator / fraction2._denominator);
      fraction.Reduction();
      return fraction;
    }

    public static Fraction operator -(Fraction fraction1, Fraction fraction2) {
      Fraction fraction = fraction1 + (-fraction2);
      fraction.Reduction();
      return fraction;
    }


    public static Fraction operator -(Fraction fraction1) {
      Fraction fraction = new Fraction();
      fraction._numerator = -fraction1._numerator;
      fraction._denominator = fraction1._denominator;
      return fraction;
    }

    public static Fraction operator *(Fraction fraction1, Fraction fraction2) {
      Fraction fraction = new Fraction();
      fraction._numerator = fraction1._numerator * fraction2._numerator;
      fraction._denominator = fraction1._denominator * fraction2._denominator;
      fraction.Reduction();
      return fraction;
    }

    public static Fraction operator /(Fraction fraction1, Fraction fraction2) {
      Fraction fraction = new Fraction();
      fraction._numerator = fraction1._numerator * fraction2._denominator;
      fraction._denominator = fraction1._denominator * fraction2._numerator;
      fraction.Reduction();
      return fraction;
    }

    public static bool operator <(Fraction fraction1, Fraction fraction2) {
      return (fraction1._numerator * fraction2._denominator < fraction2._numerator * fraction1._denominator);
    }

    public static bool operator >(Fraction fraction1, Fraction fraction2) {
      return (fraction2 < fraction1);
    }

    public static bool operator <=(Fraction fraction1, Fraction fraction2) {
      return !(fraction1 > fraction2);
    }

    public static bool operator >=(Fraction fraction1, Fraction fraction2) {
      return !(fraction1 < fraction2);
    }

    private void Reduction() {
      if (_denominator == 0) {
        throw new DivideByZeroException("Didviding by zero!!!");
      }

      if (_denominator < 0) {
        _numerator = -_numerator;
        _denominator = -_denominator;
      }

      int gcdNumber = (int) BigInteger.GreatestCommonDivisor((BigInteger) _numerator, (BigInteger) _denominator);
      if (gcdNumber != 1) {
        _numerator = _numerator / gcdNumber;
        _denominator = _denominator / gcdNumber;
      }
    }

    public override bool Equals(object obj) {
      if (obj == null) {
        throw new NullReferenceException();
      }

      if (!(obj is Fraction)) {
        throw new ArgumentException("Argument shold be Fraction type");
      }

      return (_numerator * (obj as Fraction)._denominator == (obj as Fraction)._numerator * _denominator);
    }

    public override int GetHashCode() {
      return HashCode.Combine(_numerator, _denominator);
    }

    public static bool operator ==(Fraction fraction1, Fraction fraction2) {
      return (fraction1._numerator * fraction2._denominator == fraction2._numerator * fraction1._denominator);
    }

    public static bool operator !=(Fraction fraction1, Fraction fraction2) {
      return !(fraction1 == fraction2);
    }

    public double Output() {
      double outputNumber = (double) _numerator / _denominator;
      return outputNumber;
    }

    private int _numerator;
    private int _denominator;
  }
}