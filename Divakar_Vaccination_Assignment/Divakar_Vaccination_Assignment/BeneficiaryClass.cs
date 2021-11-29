using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divakar_Vaccination_Assignment
{
    /// <summary>
    /// Enum Data Type for Gender
    /// </summary>
    public enum Gender
    {
        Male = 1,
        Female,
        Transgender
    }
    /// <summary>
    /// BeneficiaryClass is used to initialize registration process fields.
    /// </summary>
    public class BeneficiaryClass
    {
        public int VaccinationIdNumber { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryMobileNumber { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string BeneficiaryAge { get; set; }
        public Gender BeneficiaryGender { get; set; }

        private static int _autoIncrementvaccinationIdNumber = 1000;

        public List<VaccinationClass> VaccinatedPersonsInfo = new List<VaccinationClass>();

        public BeneficiaryClass(string beneficiaryName, long beneficiaryMobileNumber, string beneficiaryAddress, int beneficiaryAge, Gender beneficiaryGender)
        {
            this.BeneficiaryName = beneficiaryName;

            this.BeneficiaryMobileNumber = beneficiaryMobileNumber.ToString();

            this.BeneficiaryAddress = beneficiaryAddress;

            this.BeneficiaryAge = beneficiaryAge.ToString();

            this.BeneficiaryGender = beneficiaryGender;

            _autoIncrementvaccinationIdNumber += 1;

            this.VaccinationIdNumber = _autoIncrementvaccinationIdNumber;

        }
        /// <summary>
        /// ToGetVaccination is used to get vaccinated according to dosage.
        /// </summary>
        /// <param name="vaccinationType"></param>
        /// <returns></returns>
        public string ToGetVaccination(int vaccinationType)
        {
            string Text = null;

            if (VaccinatedPersonsInfo.Count == 0)
            {

                VaccinationClass VaccinationClassObject = new VaccinationClass(vaccinationType, 1);

                VaccinatedPersonsInfo.Add(VaccinationClassObject);

                Text = $"Your Next dose due time is {VaccinationClassObject.DateOfVaccination.AddDays(30).ToString()}.";

            }
            else if (VaccinatedPersonsInfo.Count == 1)
            {
                //if else condition for 2nd dose gap Period.
                if (VaccinatedPersonsInfo[0].DateOfVaccination > VaccinatedPersonsInfo[0].DateOfVaccination.AddDays(30))
                {
                    VaccinationClass VaccinationClassObject = new VaccinationClass(vaccinationType, 2);

                    VaccinatedPersonsInfo.Add(VaccinationClassObject);

                    Text = "Vaccination Process of 2 dosage completed";

                    return Text;
                }
                else
                {
                    Text = $"You are not allowed for 2nd dose your due date is{VaccinatedPersonsInfo[0].DateOfVaccination.AddDays(30).ToString("dd/MM/yyyy")}.";

                    return Text;
                }
            }
            else
            {
                Text = "Both Dose Competed";

                return Text;
            }

            return Text;

        }
        /// <summary>
        /// CalculateDueDate Method is used for due date calculation.
        /// </summary>
        /// <returns></returns>
        public string CalculateDueDate()
        {
            string Text = null;

            if (VaccinatedPersonsInfo.Count == 1)
            {
                Text = $"Next Due Date is  {VaccinatedPersonsInfo[0].DateOfVaccination.AddDays(30).ToString("dd/MM/yyyy")}.";

                return Text;

            }
            else
            {
                Text = "Vaccination Process of 2 dosage completed ";

                return Text;
            }
        }
    }
}
