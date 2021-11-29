using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divakar_Vaccination_Assignment
{
    /// <summary>
    /// Enum DataType for vaccination Types
    /// </summary>
    public enum VaccineType
    {
        Covaccine = 1,
        Covishield,
        Sputnik
    }

    /// <summary>
    /// VaccinationClass used to initialize vaccination process fields.
    /// </summary>
    public class VaccinationClass
    {
        public DateTime DateOfVaccination { get; set; }
        public int DosageCount { get; set; }
        public VaccineType VaccineType { get; set; }


        public VaccinationClass(int vaccinationtype, int dose)
        {

            this.DateOfVaccination = DateTime.Now;

            this.DosageCount = dose;

            this.VaccineType = (VaccineType)vaccinationtype;

        }
    }
}
