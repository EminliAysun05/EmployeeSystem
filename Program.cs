namespace EmployeeSystem
{
    internal class Program
    {

        static List<string> namesList = new List<string>();
        static List<string> surnameList = new List<string>();
        static List<string> fatherNameList = new List<string>();
        static List<int> ageList = new List<int>();
        static List<string> finCodesList = new List<string>();
        static List<string> phoneNumberList = new List<string>();
        static List<string> positionList = new List<string>();
        static List<int> salaryList = new List<int>();

        static void Main(string[] args)
        {


            while (true) {
                
                Console.WriteLine("Please, enter the name of employee: ");            
                string name = Console.ReadLine();

                if (!ValidateAndPrint(name, "name"))
                {
                    continue;
                }

                Console.WriteLine("Please, enter the surname of employee");
                string surname = Console.ReadLine();

                if (!ValidateAndPrint(surname, "surname"))
                {
                    continue ;
                }


                Console.WriteLine("Please, enter the father name of employee");
                string fatherName = Console.ReadLine();

                if (!ValidateAndPrint(fatherName, "fatherName")){
                    continue ;
                }
                
                Console.WriteLine("Please, enter the age of employee");
                int age =  Int16.Parse(Console.ReadLine());

                if (!(age > 18 && age < 65))
                {
                    Console.WriteLine("Your age range must be 19-65");
                    continue ;
                }


                Console.WriteLine("Please, emter the fin code of employee");
                string fincode = Console.ReadLine();

                if (!ValidateFincCode(fincode)){
                    continue;
                }


                Console.WriteLine("Please, emter the phone number of employee");
                string phoneNumber = Console.ReadLine();

                if (!ValidatePhoneNumber(phoneNumber))
                {
                    continue ;
                }
                
                Console.WriteLine("Please, emter the position of employee");
                string positionName = Console.ReadLine();

                if (positionName != "HR" && positionName != "Audit" && positionName != "Engineer") 
                {
                    Console.WriteLine("Your position only must be HR, Audit, Enginner");
                    continue ;
                
                }

                Console.WriteLine("Please, emter the salary of employee");
                int salary = Int16.Parse(Console.ReadLine());


                if (salary > 5000 && salary < 1500)
                {
                    Console.WriteLine("Your salaary exception is not okay for us");
                    continue;
                }

                AddSystem(name, surname, fatherName, age, fincode, phoneNumber, positionName, salary);

            }
        }

        private static void AddSystem(string name, string surname, string fatherName, int age, string fincode, string phoneNumber, string positionName, int salary)
        {
            
            Console.WriteLine($"Your data added to the system:\n" +
                              $"Name: {name}\n" +
                              $"Surname: {surname}\n" +
                              $"Father's Name: {fatherName}\n" +
                              $"Age: {age}\n" +
                              $"FIN Code: {fincode}\n" +
                              $"Phone Number: {phoneNumber}\n" +
                              $"Position Name: {positionName}\n" +
                              $"Salary: {salary}");

            namesList.Add(name); surnameList.Add(surname); fatherNameList.Add(fatherName); ageList.Add(age); finCodesList.Add(fincode); phoneNumberList.Add(phoneNumber); salaryList.Add(salary); positionList.Add(positionName);
               
        }

        private static bool ValidateAndPrint(string input, string fieldName)
        {
            
            if (ValidateCharacter(input))
            {
                Console.WriteLine($"{fieldName} is not containts letter");
                return false;
            }
            if (ValidateLenght(input, 2, 20))
            {
                Console.WriteLine($"Lenght of {fieldName} should be range of 2 and 20");
                return false;
            }
            if (ValidateFirstCharUppercase(input))
            {
                Console.WriteLine($"{fieldName} first character is not upper case");
                return false;
            }

            return true;
            
        }
    

        private static bool ValidateLenght(string letter, int min_length, int max_length)
        {
            if (letter.Length > max_length || letter.Length < min_length)
            {
                return true;
            }
            return false;
        }

        private static bool ValidateCharacter(string letter)
        {

            foreach (char s in letter)
            {
                int asciiValue = (int)(s);
                if (!(asciiValue >= 65 && asciiValue <= 90 || asciiValue >= 97 && asciiValue <= 122))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ValidateFirstCharUppercase(string letter)
        {
            int firstCharAscii = (int)(letter[0]);
            if (!(firstCharAscii >= 65 && firstCharAscii <= 90))
            {
                return true;
            }
            return false;
        }

        private static bool ValidateFincCode(string fincCode) 
        { 

            if (fincCode.Length != 7) {
                Console.WriteLine("FinCode should be 7"); 
                return false;
            }
        
           foreach (char c in fincCode)
            {
                if (!((c>=65 && c<=90) || (c>=48 && c <= 571)))
                {
                    Console.WriteLine("the character of fin code should be uppercase and numbers omly");
                    return false;
                }
            }
            return true;
        
        }

        private static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 13)
            {
                Console.WriteLine("Phone number must be 11 characters long, including the leading '+'.");
                return false;
            }

            if (phoneNumber[0] != '+')
            {
                Console.WriteLine("The first character of the phone number must be a '+'.");
                return false;
            }

            for (int i = 1; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit(phoneNumber[i]))
                {
                    Console.WriteLine("All characters after the '+' in the phone number must be digits.");
                    return false;
                }
            }

            return true;
        }

    }

}



