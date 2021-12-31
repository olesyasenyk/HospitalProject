using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace HospitalProject.BusinessLogic
{
    class Record // central notion: a doctor has many records, a patient has many records, a ward has many records. 
    {
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int DepartmentID { get; set; }
        public int WardID { get; set; }
        public DateTime HospitalizationDate { get; set; } = new(default);
        public DateTime DischargeDate { get; set; } = new(default);
        public string? Diagnosis { get; set; }
        public List<Test> Tests { get; set; } = new(); //search, delete, add
        public List<Therapy> Therapies { get; set; } = new(); //search, delete, add

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"Record ID {RecordID}, Patient ID {PatientID}, diagnosed with {Diagnosis}, Department ID {DepartmentID}, Doctor ID {DoctorID}, Ward ID {WardID}, hospitalized {HospitalizationDate}, discharged {DischargeDate}");
            builder.Append("\nTests: ");
            foreach (var test in Tests)
                builder.Append(test);
            builder.Append("\nTherapies: ");
            foreach (var therapy in Therapies)
                builder.Append(therapy);
            return builder.ToString();
        }
        //edit
    }

    class Test
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; }
        public string TestResult { get; set; }

        //public override string ToString()

        //edit
    }

    class Therapy
    {
        public int TherapyID { get; set; }
        public string TherapyName { get; set; }
        public DateTime TherapyTime { get; }
        string TherapyComment { get; set; }
        //public override string ToString() { }
        //edit
    }

    class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"Patient {PatientID}, {FirstName}, {LastName}, {Gender}, born {BirthDate}, resides at {Address}");
            builder.Append("Medical records:");

            return builder.ToString();
        }
        //edit
    }

    class Doctor
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string DepartmentID { get; set; }
        //public override string ToString() { }
        //edit
    }

    class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public List<Doctor> Doctors { get; set; } = new();
        public List<Ward> Wards { get; set; } = new();

        //public override string ToString() { }
        //search, edit, delete, add
    }

    class Ward
    {
        public int WardID { get; set; }
        public int WardNumber { get; set; }
        public int BedsTotal { get; set; }
        //public override string ToString() { }
        //search, edit, delete, add
    }
    public class BusinessLogic
    {
        //public static Patient SearchPatient(string name) and by ID
        //{

        //}
        public static async Task Run()
        {
            Console.WriteLine("Select an action:" +
                "\n1. Search a patient" +
                "\n2. Add a patient" +
                "\n3. View departments" +
                "\n4. Search a department" +
                "\nEXIT - to exit the application");

            string userChoice = Int32.Parse(Console.ReadLine().Trim());

            string connectionString = @"Data Source=.\SQLEXPRESS;Database=Hospital;Integrated Security=True";

            switch (userChoice)
            {   //Search a patient
                case 1:
                    Console.WriteLine("Enter patient ID or Last Name: ");
                    string patient = Console.ReadLine().Trim();
                    Console.WriteLine();

                    if (patient.All(char.isDigit))
                    {
                        string queryString1 = $@"
                        SELECT
                        p.[Id],
                        p.[First Name],
                        p.[Last Name],
                        p.[Gender],
                        p.[Birth Date],
                        p.[Address]
                        FROM [dbo].[Patient] AS p                  
                        WHERE p.[Id] = '{Id}'";

                        SqlConnection connection1 = new(connectionString);
                        connection1.Open();
                        SqlCommand command1 = new(queryString3, connection3);
                        SqlDataReader reader1 = command3.ExecuteReader();

                        if (!reader1.HasRows)
                        {
                            Console.WriteLine("Nothing found");
                            Console.WriteLine();
                            break;
                        }

                        while (reader1.Read())
                        {
                            Console.WriteLine($"Patient ID: {reader3[0]}");
                            Console.WriteLine($"First Name: {reader3[1]}");
                            Console.WriteLine($"Last Name: {reader3[2]}");
                            Console.WriteLine($"Gender: {reader3[3]}");
                            Console.WriteLine($"Birth Date: {reader3[4]}");
                            Console.WriteLine($"Address: {reader3[5]}");
                            Console.WriteLine();
                        }
                        reader3.Close();
                    }
                    //write 2 overloads for Patient search - by name and by ID - 2 static methods
                    string queryString2 = $@" 
                    SELECT
                    p.[Id],
                    p.[First Name],
                    p.[Last Name],
                    p.[Gender],
                    p.[Birth Date],
                    p.[Address]
                    FROM [dbo].[Patient] AS p                  
                    WHERE p.[Last Name] = '{surname}'";

                    SqlConnection connection2 = new(connectionString);
                    connection2.Open();
                    SqlCommand command2 = new(queryString2, connection2);
                    SqlDataReader reader2 = command2.ExecuteReader();

                    if (!reader2.HasRows)
                    {
                        Console.WriteLine("Nothing found");
                        Console.WriteLine();
                        break;
                    }

                    while (reader2.Read())
                    {
                        Console.WriteLine($"Patient ID: {reader2[0]}");
                        Console.WriteLine($"First Name: {reader2[1]}");
                        Console.WriteLine($"Last Name: {reader2[2]}");
                        Console.WriteLine($"Gender: {reader2[3]}");
                        Console.WriteLine($"Birth Date: {reader2[4]}");
                        Console.WriteLine($"Address: {reader2[5]}");
                        Console.WriteLine();
                    }
                    reader2.Close();

                    break;

                    Console.WriteLine("Select an action:" +
                    "\n1. Edit the patient" +
                    "\n2. Remove the patient" +
                    "\n3. View records of the patient" +
                    "\n4. Search a record" + //edit, remove, view tests, search a test (edit, remove), add a test, view therapies, search a therapy (edit, remove), add a therapy
                    "\n5. Add a record" +
                    "\nEXIT. Go to the main menu");

                    //START HERE

                //Add a patient
                case 2:
                    Patient patient = new();
                    Console.WriteLine("First Name: ");
                    patient.FirstName = Console.ReadLine().Trim();
                    Console.WriteLine("Last Name: ");
                    patient.LastName = Console.ReadLine().Trim(); ;
                    Console.WriteLine("Gender: ");
                    patient.Gender = Console.ReadLine().Trim(); ;
                    Console.WriteLine("Birth Date: ");
                    patient.BirthDate = DateTime.Parse(Console.ReadLine().Trim());
                    Console.WriteLine("Address: ");
                    patient.Address = Console.ReadLine().Trim(); ;

                    string queryString = $@"
                    INSERT INTO 
                    [dbo].[Patient]
                    ([First Name], 
                    [Last Name], 
                    [Gender], 
                    [Birth Date], 
                    [Address])
                    VALUES('{patient.FirstName}', '{patient.LastName}', '{patient.Gender}', '{patient.BirthDate}', '{patient.Address}')";

                    SqlConnection connection = new(connectionString);
                    connection.Open();
                    SqlCommand command = new(queryString, connection);
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database");
                        break;
                    }
                    Console.WriteLine("The patient was added successfully");

                    break;

                case 3:

                    //This is edit the patient
                    Console.WriteLine("Enter Patient ID: ");
                    string Id = Console.ReadLine().Trim();
                    Console.WriteLine();

                    string queryString3 = $@"
                    SELECT
                    p.[Id],
                    p.[First Name],
                    p.[Last Name],
                    p.[Gender],
                    p.[Birth Date],
                    p.[Address]
                    FROM [dbo].[Patient] AS p                  
                    WHERE p.[Id] = '{Id}'";

                    SqlConnection connection3 = new(connectionString);
                    connection3.Open();
                    SqlCommand command3 = new(queryString3, connection3);
                    SqlDataReader reader3 = command3.ExecuteReader();

                    if (!reader3.HasRows)
                    {
                        Console.WriteLine("Nothing found");
                        Console.WriteLine();
                        break;
                    }

                    Patient editedPatient = new();

                    while (reader3.Read())
                    {

                        editedPatient.PatientID = (int)reader3[0];
                        editedPatient.FirstName = (string)reader3[1];
                        editedPatient.LastName = (string)reader3[2];
                        editedPatient.Gender = (string)reader3[3];
                        //editedPatient.BirthDate = (DateTime)reader3[4];//????????????????????
                        editedPatient.Address = (string)reader3[5];

                        Console.WriteLine($"Patient ID: {reader3[0]}");
                        Console.WriteLine($"First Name: {reader3[1]}");
                        Console.WriteLine($"Last Name: {reader3[2]}");
                        Console.WriteLine($"Gender: {reader3[3]}");
                        Console.WriteLine($"Birth Date: {reader3[4]}");
                        Console.WriteLine($"Address: {reader3[5]}");
                        Console.WriteLine();
                    }
                    reader3.Close();

                    while (true)
                    {
                        Console.WriteLine("What would you like to edit?" +
                            "\n1 - First Name" +
                            "\n2 - Last Name" +
                            "\n3 - Gender" +
                            "\n4 - Birth Date" +
                            "\n5 - Address" +
                            "\n6 - Finish editing and go to the main menu");
                        string editChoice = Console.ReadLine().Trim();

                        switch (editChoice)
                        {
                            case "1":
                                Console.WriteLine("Edit First Name:");
                                editedPatient.FirstName = Console.ReadLine().Trim();
                                Console.WriteLine();
                                break;

                            case "2":
                                Console.WriteLine("Edit Last Name:");
                                editedPatient.LastName = Console.ReadLine().Trim();
                                Console.WriteLine();
                                break;

                            case "3":
                                Console.WriteLine("Edit Gender:");
                                editedPatient.Gender = Console.ReadLine().Trim();
                                Console.WriteLine();
                                break;

                            case "4":
                                Console.WriteLine("Edit Birth Date:");
                                editedPatient.BirthDate = DateTime.Parse(Console.ReadLine().Trim());
                                Console.WriteLine();
                                break;

                            case "5":
                                Console.WriteLine("Edit Address:");
                                editedPatient.Address = Console.ReadLine().Trim();
                                Console.WriteLine();
                                break;

                            case "6":

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

                case 4:

                    //this is create record
                    Console.WriteLine("You can create a record for an existing patient only. Enter Patient ID:"); // plus by name
                    string patientId = Console.ReadLine().Trim();
                    Console.WriteLine();

                    string queryString5 = $@"
                    SELECT
                    p.[Id],
                    p.[First Name],
                    p.[Last Name],
                    p.[Gender],
                    p.[Birth Date],
                    p.[Address]
                    FROM [dbo].[Patient] AS p                  
                    WHERE p.[Id] = '{patientId}'";

                    SqlConnection connection5 = new(connectionString);
                    connection5.Open();
                    SqlCommand command5 = new(queryString5, connection5);
                    SqlDataReader reader5 = command5.ExecuteReader();

                    if (!reader5.HasRows)
                    {
                        Console.WriteLine("Nothing found");
                        Console.WriteLine();
                        break;
                    }

                    Record record = new();
                    Console.WriteLine("Hospitalization Date: ");
                    record.HospitalizationDate = DateTime.Parse(Console.ReadLine().Trim());
                    Console.WriteLine("Discharge Date: ");
                    record.DischargeDate = DateTime.Parse(Console.ReadLine().Trim());
                    Console.WriteLine("Diagnosis: ");
                    record.Diagnosis = Console.ReadLine().Trim();
                    record.PatientID = Int32.Parse(patientId);
                    Console.WriteLine("Doctor ID: ");
                    record.DoctorID = Int32.Parse(Console.ReadLine().Trim());//menu
                    Console.WriteLine("Department ID: ");
                    record.DepartmentID = Int32.Parse(Console.ReadLine().Trim());//menu
                    Console.WriteLine("Ward ID: ");
                    record.WardID = Int32.Parse(Console.ReadLine().Trim());//menu

                    string queryString6 = $@"
                    INSERT INTO [dbo].[Record]
                    ([Hospitalization Date], 
                    [Discharge Date], 
                    [Diagnosis], 
                    [Patient Id],
                    [Doctor ID], 
                    [Department ID],
                    [Ward ID]
                    VALUES('{record.HospitalizationDate}', '{record.DischargeDate}', '{record.Diagnosis}', '{record.PatientID}', '{record.DoctorID}, {record.DepartmentID}, {record.WardID}')";

                    SqlConnection connection6 = new(connectionString);
                    connection5.Open();
                    SqlCommand command6 = new(queryString5, connection5);
                    int result5 = command5.ExecuteNonQuery();

                    // Check Error
                    if (result5 < 0)
                    {
                        Console.WriteLine("Error");
                        break;
                    }
                    Console.WriteLine("The record was created successfully");

                    break;
                }
                await Run();       
            }
        }
    } 
       
    
