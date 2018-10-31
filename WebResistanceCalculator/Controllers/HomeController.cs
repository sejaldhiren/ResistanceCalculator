using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebResistanceCalculator.Models;
using OhmCalculator;

namespace WebResistanceCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                //Load selectors for Band A, Band B, Band C, and Band D
                ColorSelectOnLoad selectOnLoad = new ColorSelectOnLoad();

                //Return index view containing the color code calculator user interface
                return View(selectOnLoad);
            }
            catch (Exception ex)
            {
                // if exception then return error as response 
                return Json(new { error = "Exception ocurred while loading select controls: " + ex.Message });
            }
        }

        /// <summary>
        /// Calls the resistance calculation method in ColorCodeCalculator class library
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>Returns a JSON response contain the resistance value </returns>
        [HttpPost]
        public ActionResult GetResistanceValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {

                // initialize interface object 
                IOhmValueCalculator objResistance = new ResistanceCalculator();

                // Call the method that calculates resistance value 
                int resultResistance = objResistance.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

                /// return JSON response
                return Json(new { resistance = resultResistance });
            }
            catch (Exception ex)
            {
                // if exception then return error as response 
                return Json(new { error = "Exception ocurred while calculating resistance value: " + ex.Message });
            }
        }
    }
}