using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divakar_Vaccination_Assignment
{
    class BeneficiaryDetails
    {

        public List<BeneficiaryClass> RegisteredPersonsInfo = new List<BeneficiaryClass>();


        static void Main(string[] args)
        {
            int Choice = 0;

            BeneficiaryDetails BeneficiaryDetailsObject = new BeneficiaryDetails();

            BeneficiaryDetailsObject.DefaultBeneficiaryDetails();


            Console.WriteLine("---------------------Welcome To Vaccination Camp-------------------------");
            do
            {
                Console.WriteLine("Enter corresponding number for action take place, 1 -> Vaccination Registeration, 2 -> Vaccination, 3 -> Exit");
                int Option = int.Parse(Console.ReadLine());

                switch (Option)
                {
                    case 1:
                        BeneficiaryDetailsObject.VaccinationRegisteration();
                        break;

                    case 2:
                        BeneficiaryDetailsObject.VaccinationProcess();
                        break;

                    case 3:
                        Choice = 2;
                        break;

                    default:
                        Console.WriteLine("Invalid input enter again ");
                        break;

                }
                do
                {
                    if (Choice != 2)
                    {
                        Console.WriteLine("Do you want to Continue from Home again 1 -> yes ,Exit -> 2 ");
                        Choice = int.Parse(Console.ReadLine());
                    }

                    if (Choice == 2)
                    {
                        break;
                    }
                    else if (Choice != 1 && Choice != 2)
                    {
                        Console.WriteLine("Invalid Input enter again");
                    }
                } while (Choice != 1 && Choice != 2);

            } while (Choice == 1);

            Console.WriteLine("----------------The End--------------------");

            Console.ReadKey();

        }
        /// <summary>
        /// VaccinationRegisteration Method is used to register for vaccination.
        /// </summary>
        private void VaccinationRegisteration()
        {
            int Choice = 0;

            do
            {
                Console.WriteLine("-----------------------Vaccination Process------------------------------");
                Console.WriteLine("Enter the following details for vaccination proccess");

                Console.WriteLine("Name : ");
                string BeneficiaryName = Console.ReadLine();

                Console.WriteLine("MobileNumber : ");
                long BeneficiaryMobileNumber = long.Parse(Console.ReadLine());

                Console.WriteLine("Address : ");
                string BeneficiaryAddress = Console.ReadLine();

                Console.WriteLine("Age in Number : ");
                int BeneficiaryAge = int.Parse(Console.ReadLine());

                Console.WriteLine("Gender :\n male -> 1 , Female -> 2 , Transgender -> 3  ");
                Gender BeneficiaryGender = (Gender)int.Parse(Console.ReadLine());

                BeneficiaryClass BenificiaryClassObject = new BeneficiaryClass(BeneficiaryName, BeneficiaryMobileNumber, BeneficiaryAddress, BeneficiaryAge, BeneficiaryGender);

                RegisteredPersonsInfo.Add(BenificiaryClassObject);

                Console.WriteLine($"VaccinationId Number : {BenificiaryClassObject.VaccinationIdNumber}");

                Console.WriteLine("------------------- Vaccination Registeration Process Completed Successfully-----------------------");

                do
                {
                    Console.WriteLine("do you want to register for another user 1 -> yes , 2 -> no");
                    Choice = int.Parse(Console.ReadLine());

                    if (Choice == 2)
                    {
                        break;
                    }
                    else if (Choice == 1 && Choice == 2)
                    {
                        Console.WriteLine("Invalid Input Try again");
                    }

                } while (Choice == 1 && Choice == 2);
                
            } while (Choice == 1);

        }
        /// <summary>
        /// DefaultBeneficiaryDetails Method is used to add default values to list.
        /// </summary>
        private void DefaultBeneficiaryDetails()
        {
            BeneficiaryClass BenificiaryClassObject1 = new BeneficiaryClass("Divakar", 8973969798, "namakkal", 23, (Gender).1);

            BeneficiaryClass BenificiaryClassObject2 = new BeneficiaryClass("ram", 90762238, "chennai", 24, (Gender).1);


            BenificiaryClassObject1.ToGetVaccination(1);

            BenificiaryClassObject2.ToGetVaccination(2);


            RegisteredPersonsInfo.Add(BenificiaryClassObject1);

            RegisteredPersonsInfo.Add(BenificiaryClassObject2);
        }
        /// <summary>
        /// VaccinationProcess Method is used to selection Process.
        /// </summary>
        private void VaccinationProcess()
        {

            int flag = 1;
            do
            {
                listAllBeneficieries();
                Console.WriteLine("---------------------Get in to Vaccination Procedure----------------------");

                Console.WriteLine("Enter your registration ID:");
                int registeredId = int.Parse(Console.ReadLine());

                BeneficiaryClass currentBenificiary = null;

                foreach (BeneficiaryClass beneficiary in RegisteredPersonsInfo)
                {
                    if (registeredId == beneficiary.VaccinationIdNumber)
                    {
                        currentBenificiary = beneficiary;
                    }
                }

                if (currentBenificiary != null)
                {
                    int beneficiaryOption = 1;
                    do
                    {
                        Console.WriteLine("-------------------Vaccination------------------------");

                        Console.WriteLine("Enter corresponding number for action take place :\n1 -> Take Vaccination\n2 -> Vaccination History \n3 -> Next Dose Due Date\n4 -> Exit - vaccine Menu");
                        beneficiaryOption = int.Parse(Console.ReadLine());

                        switch (beneficiaryOption)
                        {
                            case 1:
                                TakeVaccination(currentBenificiary);
                                break;

                            case 2:
                                VaccinationHistory(currentBenificiary);
                                break;

                            case 3:
                                Console.WriteLine(currentBenificiary.CalculateDueDate());
                                break;

                            case 4:
                                flag = 0;
                                break;

                            default:
                                Console.WriteLine("invalid input");
                                break;

                        }
                    } while (beneficiaryOption != 4);
                }

                else
                {
                    Console.WriteLine("Incorrect registration number");
                }
            } while (flag == 1);


        }
        /// <summary>
        /// TakeVaccination Method is used to get into vaccination Process.
        /// </summary>
        /// <param name="currentBeneficiary"></param>
        private static void TakeVaccination(BeneficiaryClass currentBeneficiary)
        {

            do
            {
                Console.WriteLine("--------------------Vaccination Process-----------------------");

                Console.WriteLine("Choose your Vaccine:\n1 -> Covaccine\n2 -> Covishield\n3 -> Sputnik");
                int vaccineType = int.Parse(Console.ReadLine());

                if (currentBeneficiary.VaccinatedPersonsInfo.Count == 0)
                {
                    Console.WriteLine($"You are Vaccinated {currentBeneficiary.ToGetVaccination(vaccineType)}");
                    break;
                }
                else if (currentBeneficiary.VaccinatedPersonsInfo.Count == 1)
                {
                    if ((VaccineType)vaccineType == currentBeneficiary.VaccinatedPersonsInfo[0].VaccineType)
                    {
                        Console.WriteLine(currentBeneficiary.ToGetVaccination(vaccineType));
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input Your First Vaccination Type is {currentBeneficiary.VaccinatedPersonsInfo[0].VaccineType}");
                    }
                }

            } while (true);
        }
        /// <summary>
        /// VaccinationHistory Method is used to print history of particular person.
        /// </summary>
        /// <param name="currentBeneficiary"></param>
        private static void VaccinationHistory(BeneficiaryClass currentBeneficiary)
        {
            Console.WriteLine("--------------------Vaccination History-----------------------");

            foreach (VaccinationClass TempVaccinationClass in currentBeneficiary.VaccinatedPersonsInfo)
            {
                Console.WriteLine($"Vaccine type: {TempVaccinationClass.VaccineType} \n Dosage:{TempVaccinationClass.DosageCount} dose \n Last vaccinated Date:{TempVaccinationClass.DateOfVaccination.ToString("dd/MM/yyyy")}");
            }
        }
        /// <summary>
        /// listAllBeneficieries Method is used to print all registered person details.
        /// </summary>
        private void listAllBeneficieries()
        {
            Console.WriteLine("-------------------Displaying All Beneficieries---------------------------");

            foreach (BeneficiaryClass beneficiary in RegisteredPersonsInfo)
            {
                Console.WriteLine($"Vaccination Id Number : {beneficiary.VaccinationIdNumber} \n Beneficiary Name :{beneficiary.BeneficiaryName}");
            }

            Console.WriteLine("-------------------End Of List-----------------");
        }


    }
}
    

