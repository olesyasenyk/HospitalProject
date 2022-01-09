using System.Data.SqlClient;
using System.Linq;

namespace HospitalProject.DataAccess
{
    public class DataAccess
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;Database=Hospital;Integrated Security=True";
        public static Patient SearchPatient(int patientId)
        {
            string queryString = $@"
            SELECT
            p.[Id],
            p.[First Name],
            p.[Last Name],
            p.[Gender],
            p.[Birth Date],
            p.[Address]
            FROM [dbo].[Patient] AS p                  
            WHERE p.[Id] = '{patientId}'";

            SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(queryString, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            Patient patient = new();

            while (reader.Read())
            {
                patient.PatientID = (int)reader[0];
                patient.FirstName = (string)reader[1];
                patient.LastName = (string)reader[2];
                patient.Gender = (string)reader[3];
                patient.BirthDate = (DateTime)reader[4];
                patient.Address = (string)reader[5];   
            }
            reader.Close();
            connection.Close();//??????????

            return patient;
        }

        public static List<Patient> SearchPatient(string lastName)
        {
            List<Patient> patients = new();

            string queryString = $@" 
            SELECT TOP (1000)
            p.[Id],
            p.[First Name],
            p.[Last Name],
            p.[Gender],
            p.[Birth Date],
            p.[Address]
            FROM [dbo].[Patient] AS p                  
            WHERE p.[Last Name] = '{lastName}'";

            SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(queryString, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
                Console.WriteLine(reader[1]);
                Console.WriteLine(reader[2]);
            }

            //Patient patient = new();

            //while (reader.Read())
            //{
            //    patient.PatientID = (int)reader[0];
            //    patient.FirstName = (string)reader[1];
            //    patient.LastName = (string)reader[2];
            //    patient.Gender = (string)reader[3];
            //    patient.BirthDate = (DateTime)reader[4];
            //    patient.Address = (string)reader[5];
            //}
            reader.Close();

            connection.Close();//???????????????

            //patients.Append(patient);

            return patients;
        }
    }
}
