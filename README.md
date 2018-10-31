# ResistanceCalculator
Calculates Resistance (Ohm Value) from electronic color code per the following requirements:

1. The electronic color code (http://en.wikipedia.org/wiki/Electronic_color_code) is used to indicate the values or ratings of electronic components, very commonly for resistors. Write a class that implements the following interface. Feel free to include any supporting types as necessary.

public interface IOhmValueCalculator
{
   /// <summary>
   /// Calculates the Ohm value of a resistor based on the band colors.
   /// </summary>
   /// <param name="bandAColor">The color of the first figure of component value band.</param>
   /// <param name="bandBColor">The color of the second significant figure band.</param>
   /// <param name="bandCColor">The color of the decimal multiplier band.</param>
   /// <param name="bandDColor">The color of the tolerance value band.</param>
   int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
}

2. Create an ASP.NET MVC or React JS web interface that will allow someone to use the calculator you created in step one.

3. Using your favorite unit test framework, write the unit tests you feel are necessary to adequately test the code you wrote as your answer to question one.

Instructions: 
This project was completed in ASP.NET MVC usinf Visual Studio 2017 Enterprise. The solution contains 3 projects:
a) OhmCalculator (target .NET framework 4.6.2) - Class Library which implements the above interface and calculator
b) WebResistanceCalculator (target .NET framework 4.6.2) - MVC web application to test the the calculator
c) WebResistanceCalculator.Tests (target .NET framework 4.6.2) - Unit tests project using visual studio unit test framework

The repository includes all the source code files and should build without any issues. 
WebResistanceCalculator project should be set as StartUp project and the applciation can be run to test calculator interface
