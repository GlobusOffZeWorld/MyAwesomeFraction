using System;

namespace FractionClass {

  class Program {
    static void Main(string[] args) {
      Fraction fraction = new Fraction(12, 11);
      Fraction fraction1 = new Fraction(10, 11);
      Fraction fractionOperation = fraction + fraction1;
      Console.WriteLine($"Numerator: {fractionOperation.Numerator}\n Denominator: {fractionOperation.Denominator}");
      Console.Write(fractionOperation.Output());

    }
  }
}