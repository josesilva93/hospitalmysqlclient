using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using testefcore.DAO;
using testefcore.models;

namespace testefcore.service
{
    public class Service
    {
        sqlConnection sqlcon = new sqlConnection();
       
        public List<Paciente> GetAllPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
           
            String displayQuery = "SELECT * FROM Paciente";
            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlcon.OpenConnection());
            SqlDataReader dataReader = viewCommand.ExecuteReader();
            while (dataReader.Read())
            {
                 Paciente paciente = new Paciente();
                 paciente.id = dataReader.GetInt32(0);
                if(dataReader.GetValue(1)!= null)
                {
                    paciente.diagnostico = dataReader.GetValue(1).ToString();
                }                 
                 paciente.dias_Ingresado = dataReader.GetInt32(2);
                if(dataReader.GetValue(3) != null)
                {
                    paciente.pronostico = dataReader.GetValue(3).ToString();
                }                
                 paciente.dado_Alta = dataReader.GetBoolean(4);
                 paciente.dni = dataReader.GetValue(5).ToString();
                 paciente.nombre = dataReader.GetValue(6).ToString();
                 paciente.direccion = dataReader.GetValue(7).ToString();
                 pacientes.Add(paciente);


            }
            dataReader.Close();
            sqlcon.CloseConnection();
            return pacientes;
        }
        public void Save(Paciente paciente)
        {
            String insertQuery = "INSERT INTO Paciente (diagnostico,dias_Ingresado,pronostico,dado_Alta,dni,nombre,direccion) " +
                "VALUES('" + paciente.diagnostico + "'," + paciente.dias_Ingresado + ",'" 
                + paciente.pronostico + "'," + 0 + ",'" + paciente.dni + "'" +
                ",'" + paciente.nombre + "','" + paciente.direccion + "' )";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlcon.OpenConnection());
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Data stored successfully");
            sqlcon.CloseConnection();
        }
        public void AltaPacienteByDNI(string dni)
        {
            String updateQuery = "UPDATE Paciente SET dado_Alta = '" + true + "' WHERE dni = '" + dni + "'";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlcon.OpenConnection());
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Successfully updated");
            sqlcon.CloseConnection();            
        }

        public int GetIdByDNI(string dni)
        {
            int idPaciente = 0;
            String displayQuery = "SELECT id FROM Paciente WHERE dni = '" + dni + "'";
            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlcon.OpenConnection());
            SqlDataReader dataReader = viewCommand.ExecuteReader();
            while (dataReader.Read())
            {
                idPaciente = dataReader.GetInt32(0);
            }
                
            dataReader.Close();
            sqlcon.CloseConnection();
            return idPaciente;
        }
        public void AsignarMedicamentoPaciente(string nombreMedicamento, int idPaciente)
        {
            String insertQuery = "INSERT INTO Medicamento (nombre, pacienteid) " +
    "VALUES('" + nombreMedicamento + "'," + idPaciente + " )";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlcon.OpenConnection());
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Data stored successfully");
            sqlcon.CloseConnection();
        }
        public void AsignarMedicamentoPrueba(string nombreMedicamento, int idPaciente)
        {
            String insertQuery = "INSERT INTO Prueba (nombre, pacienteid) " +
    "VALUES('" + nombreMedicamento + "'," + idPaciente + " )";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlcon.OpenConnection());
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Data stored successfully");
            sqlcon.CloseConnection();
        }
        public void BorrarPaciente(String dni) 
        {
            String deleteQuery = "DELETE FROM Paciente WHERE dni = '" + dni + "'";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlcon.OpenConnection());
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Successfully deleted");
            sqlcon.CloseConnection();
        }
    }

}
