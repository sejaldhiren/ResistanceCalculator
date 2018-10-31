using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator
{
    public class ResistanceCalculator : IOhmValueCalculator
    {
        /// <summary>
        /// Calculates the Ohm values of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>An integer representing actual resistance value in ohms</returns>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            
            //Intialize color-code dictionary checkers 
            OhmCalculationInput ohmInput = new OhmCalculationInput();
            int result;
            try
            {
                //get color codes from color-code dictionaries
                int ohmValue = ohmInput.significantFigures[bandAColor] * 10 + ohmInput.significantFigures[bandBColor];
                int multiplier = ohmInput.multiplier[bandCColor];
                double tolerance = ohmInput.tolerance[bandDColor];

                //you can find maximum and minimum resistance values, these would be range of resitance values... not used in this implementation SG 10/30/2018
                //double resultMax = (ohmValue * Math.Pow(10, multiplier) * (1 + tolerance));
                //double resultMin = (ohmValue * Math.Pow(10, multiplier) * (1 - tolerance));

                // save the results in integer without tolerance..this will throw exception when multiplier is 8 or larger as it gets outside of int range
                 result = Convert.ToInt32(ohmValue * Math.Pow(10, multiplier));
            }
           catch (OverflowException e)
            {
                //Exception occurs when multiplier (band C color) is selected as Grey or White because the resulting value is too large for int to handle
                throw;
            }
            catch(InvalidCastException e)
            {
                throw;
            }

            // return resistance value.
            return result;
        }

    }
}
