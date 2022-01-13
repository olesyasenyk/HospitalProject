using BL = HospitalProject.BusinessLogic.BusinessLogic;

namespace HospitalProject.Presentation
{
    public class Presentation
    {
        public static async Task Run()//?????????????
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            //BL BusinessLogic = new();

            while (true)
            {
                Console.WriteLine("Select an action:" +
                "\n1. Work with a patient (edit, remove, manage records)" + // work with a record - search by id and then the rest of actions
                "\n2. Add a new patient" +
                "\n3. View departments" +
                "\n4. Search a department" +
                "\nEXIT - to exit the application");

                int userChoice = Int32.Parse(Console.ReadLine().Trim());

                Console.WriteLine();

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Search by:\n1. ID\n2. Last Name");
                        int choiceIdOrLastName = Int32.Parse(Console.ReadLine().Trim());

                        Patient searchedPatient = new();

                        switch (choiceIdOrLastName)
                        {
                            default:
                                Console.WriteLine();
                                Console.WriteLine("Enter ID of the patient you want to work with:");
                                int patientId = Int32.Parse(Console.ReadLine().Trim());
                                var patientFoundById = BL.SearchPatient(patientId);

                                if (patientFoundById == null)
                                {
                                    Console.WriteLine("Nothing found.");
                                }
                                    
                                searchedPatient.PatientID = patientFoundById.PatientID;
                                searchedPatient.FirstName = patientFoundById.FirstName;
                                searchedPatient.LastName = patientFoundById.LastName;
                                searchedPatient.Gender = patientFoundById.Gender;
                                searchedPatient.BirthDate = patientFoundById.BirthDate;
                                searchedPatient.Address = patientFoundById.Address;
       
                                break;

                            case 2:
                                Console.WriteLine();
                                Console.WriteLine("Enter patient Last Name:");
                                string patientName = Console.ReadLine().Trim();

                                var searchedPatients = BL.SearchPatient(patientName);

                                Console.WriteLine();
                                Console.WriteLine("Search results:");

                                if (searchedPatients.Count == 0)
                                {
                                    Console.WriteLine("Nothing found.");
                                    break;
                                }

                                if (searchedPatients.Count > 1)
                                {
                                    foreach (var patientSearchedByName in searchedPatients)
                                    {
                                        Console.WriteLine($"Patient ID: {patientSearchedByName.PatientID}");
                                        Console.WriteLine($"First Name: {patientSearchedByName.FirstName}");
                                        Console.WriteLine($"Last Name: {patientSearchedByName.LastName}");
                                        Console.WriteLine($"Gender: {patientSearchedByName.Gender}");
                                        Console.WriteLine($"Birth Date: {patientSearchedByName.BirthDate}");
                                        Console.WriteLine($"Address: {patientSearchedByName.Address}");
                                        Console.WriteLine();
                                    }

                                    goto default;
                                }

                                searchedPatient.PatientID = searchedPatients[0].PatientID;
                                searchedPatient.FirstName = searchedPatients[0].FirstName;
                                searchedPatient.LastName = searchedPatients[0].LastName;
                                searchedPatient.Gender = searchedPatients[0].Gender;
                                searchedPatient.BirthDate = searchedPatients[0].BirthDate;
                                searchedPatient.Address = searchedPatients[0].Address;

                                break;        
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Patient ID: {searchedPatient.PatientID}");
                        Console.WriteLine($"First Name: {searchedPatient.FirstName}");
                        Console.WriteLine($"Last Name: {searchedPatient.LastName}");
                        Console.WriteLine($"Gender: {searchedPatient.Gender}");
                        Console.WriteLine($"Birth Date: {searchedPatient.BirthDate}");
                        Console.WriteLine($"Address: {searchedPatient.Address}");
                        Console.WriteLine();

                        Console.WriteLine("Select an action:" +
                        "\n1. Edit the patient" +
                        "\n2. Remove the patient" +
                        "\n3. View records of the patient" +
                        "\n4. Search a record" + //edit, remove, view tests, search a test (edit, remove), add a test, view therapies, search a therapy (edit, remove), add a therapy
                        "\n5. Add a record" +
                        "\nEXIT. Go to the main menu");

                        int patientAction = Int32.Parse(Console.ReadLine().Trim());

                        switch (patientAction)
                        {
                            case 1:
                                while (true)
                                {
                                    Console.WriteLine("What would you like to edit?" +
                                        "\n1 - First Name" +
                                        "\n2 - Last Name" +
                                        "\n3 - Gender" +
                                        "\n4 - Birth Date" +
                                        "\n5 - Address" +
                                        "\n6 - Finish editing and go to the main menu");

                                    int editChoice = Int32.Parse(Console.ReadLine().Trim());

                                    switch (editChoice)
                                    {
                                        case 1:
                                            Console.WriteLine("Edit First Name:");
                                            searchedPatient.FirstName = Console.ReadLine().Trim();
                                            Console.WriteLine();
                                            break;

                                        case 2:
                                            Console.WriteLine("Edit Last Name:");
                                            searchedPatient.LastName = Console.ReadLine().Trim();
                                            Console.WriteLine();
                                            break;

                                        case 3:
                                            Console.WriteLine("Edit Gender:");
                                            searchedPatient.Gender = Console.ReadLine().Trim();
                                            Console.WriteLine();
                                            break;

                                        case 4:
                                            Console.WriteLine("Edit Birth Date:");
                                            searchedPatient.BirthDate = DateTime.Parse(Console.ReadLine().Trim());
                                            Console.WriteLine();
                                            break;

                                        case 5:
                                            Console.WriteLine("Edit Address:");
                                            searchedPatient.Address = Console.ReadLine().Trim();
                                            Console.WriteLine();
                                            break;

                                        case 6:
                                            BL.UpdatePatient(searchedPatient.PatientID, 
                                                searchedPatient.FirstName, 
                                                searchedPatient.LastName,
                                                searchedPatient.Gender,
                                                searchedPatient.BirthDate,
                                                searchedPatient.Address);

                                            string queryString4 = $@"
                UPDATE [dbo].[Patient]
                SET 
                [First Name] = '{editedPatient.FirstName}', 
                [Last Name]= '{editedPatient.LastName}',
                [Gender] = '{editedPatient.Gender}',
                [Birth Date] = {reader3[4]}, 
                [Address] = '{editedPatient.Address}'
                WHERE Id = {editedPatient.PatientID}";// BirthDate!!!!!!!!!!!!!!!

                                            SqlConnection connection4 = new(connectionString);
                                            connection4.Open();
                                            SqlCommand command4 = new(queryString4, connection4);
                                            int result4 = command4.ExecuteNonQuery();

                                            if (result4 < 0)
                                            {
                                                Console.WriteLine("Error updating patient data");
                                                Console.WriteLine();
                                                break;
                                            }
                                            Console.WriteLine("The patient was edited successfully");
                                            Console.WriteLine();
                                            await Run();
                                            break;
                                    }
                                }
                        }

                        






                        break;
                }
            }
            
        }
    }
}







//int patientAction = Int32.Parse(Console.ReadLine().Trim());

//switch (patientAction)
//{
//    case 1:
//        break;

//}

//break;

//START HERE

//Add a patient
//case 2:
//    Patient newPatient = new();
//    Console.WriteLine("First Name: ");
//    newPatient.FirstName = Console.ReadLine().Trim();
//    Console.WriteLine("Last Name: ");
//    newPatient.LastName = Console.ReadLine().Trim(); ;
//    Console.WriteLine("Gender: ");
//    newPatient.Gender = Console.ReadLine().Trim(); ;
//    Console.WriteLine("Birth Date: ");
//    newPatient.BirthDate = DateTime.Parse(Console.ReadLine().Trim());
//    Console.WriteLine("Address: ");
//    newPatient.Address = Console.ReadLine().Trim(); ;

//    string queryString = $@"
//    INSERT INTO 
//    [dbo].[Patient]
//    ([First Name], 
//    [Last Name], 
//    [Gender], 
//    [Birth Date], 
//    [Address])
//    VALUES('{newPatient.FirstName}', '{newPatient.LastName}', '{newPatient.Gender}', '{newPatient.BirthDate}', '{newPatient.Address}')";

//    SqlConnection connection = new(connectionString);
//    connection.Open();
//    SqlCommand command = new(queryString, connection);
//    int result = command.ExecuteNonQuery();

//    // Check Error
//    if (result < 0)
//    {
//        Console.WriteLine("Error inserting data into Database");
//        break;
//    }
//    Console.WriteLine("The patient was added successfully");

//    break;

//case 3:

//    //This is edit the patient
//    Console.WriteLine("Enter Patient ID: ");
//    string Id = Console.ReadLine().Trim();
//    Console.WriteLine();

//    string queryString3 = $@"
//    SELECT
//    p.[Id],
//    p.[First Name],
//    p.[Last Name],
//    p.[Gender],
//    p.[Birth Date],
//    p.[Address]
//    FROM [dbo].[Patient] AS p                  
//    WHERE p.[Id] = '{Id}'";

//    SqlConnection connection3 = new(connectionString);
//    connection3.Open();
//    SqlCommand command3 = new(queryString3, connection3);
//    SqlDataReader reader3 = command3.ExecuteReader();

//    if (!reader3.HasRows)
//    {
//        Console.WriteLine("Nothing found");
//        Console.WriteLine();
//        break;
//    }

//    Patient editedPatient = new();

//    while (reader3.Read())
//    {

//        editedPatient.PatientID = (int)reader3[0];
//        editedPatient.FirstName = (string)reader3[1];
//        editedPatient.LastName = (string)reader3[2];
//        editedPatient.Gender = (string)reader3[3];
//        //editedPatient.BirthDate = (DateTime)reader3[4];//????????????????????
//        editedPatient.Address = (string)reader3[5];

//        Console.WriteLine($"Patient ID: {reader3[0]}");
//        Console.WriteLine($"First Name: {reader3[1]}");
//        Console.WriteLine($"Last Name: {reader3[2]}");
//        Console.WriteLine($"Gender: {reader3[3]}");
//        Console.WriteLine($"Birth Date: {reader3[4]}");
//        Console.WriteLine($"Address: {reader3[5]}");
//        Console.WriteLine();
//    }
//    reader3.Close();



//case 4:

//    //this is create record
//    Console.WriteLine("You can create a record for an existing patient only. Enter Patient ID:"); // plus by name
//    string patientId = Console.ReadLine().Trim();
//    Console.WriteLine();

//    string queryString5 = $@"
//    SELECT
//    p.[Id],
//    p.[First Name],
//    p.[Last Name],
//    p.[Gender],
//    p.[Birth Date],
//    p.[Address]
//    FROM [dbo].[Patient] AS p                  
//    WHERE p.[Id] = '{patientId}'";

//    SqlConnection connection5 = new(connectionString);
//    connection5.Open();
//    SqlCommand command5 = new(queryString5, connection5);
//    SqlDataReader reader5 = command5.ExecuteReader();

//    if (!reader5.HasRows)
//    {
//        Console.WriteLine("Nothing found");
//        Console.WriteLine();
//        break;
//    }

//    Record record = new();
//    Console.WriteLine("Hospitalization Date: ");
//    record.HospitalizationDate = DateTime.Parse(Console.ReadLine().Trim());
//    Console.WriteLine("Discharge Date: ");
//    record.DischargeDate = DateTime.Parse(Console.ReadLine().Trim());
//    Console.WriteLine("Diagnosis: ");
//    record.Diagnosis = Console.ReadLine().Trim();
//    record.PatientID = Int32.Parse(patientId);
//    Console.WriteLine("Doctor ID: ");
//    record.DoctorID = Int32.Parse(Console.ReadLine().Trim());//menu
//    Console.WriteLine("Department ID: ");
//    record.DepartmentID = Int32.Parse(Console.ReadLine().Trim());//menu
//    Console.WriteLine("Ward ID: ");
//    record.WardID = Int32.Parse(Console.ReadLine().Trim());//menu

//    string queryString6 = $@"
//    INSERT INTO [dbo].[Record]
//    ([Hospitalization Date], 
//    [Discharge Date], 
//    [Diagnosis], 
//    [Patient Id],
//    [Doctor ID], 
//    [Department ID],
//    [Ward ID]
//    VALUES('{record.HospitalizationDate}', '{record.DischargeDate}', '{record.Diagnosis}', '{record.PatientID}', '{record.DoctorID}, {record.DepartmentID}, {record.WardID}')";

//    SqlConnection connection6 = new(connectionString);
//    connection5.Open();
//    SqlCommand command6 = new(queryString5, connection5);
//    int result5 = command5.ExecuteNonQuery();

//    // Check Error
//    if (result5 < 0)
//    {
//        Console.WriteLine("Error");
//        break;
//    }
//    Console.WriteLine("The record was created successfully");

//    break;
//}
//await Run();
