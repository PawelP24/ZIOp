using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_biblioteczny
{
    public class DBHandler
    {
        private string connectionString ;
        SqlConnection connection;
        public DBHandler()
        {
            this.connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Biblioteka; Integrated Security = True; Pooling = False";
            connection = new SqlConnection(this.connectionString);
            connection.Open();
        }

        public void Add_Pracownik()
        {
            SqlCommand command = connection.CreateCommand();
            

           
        }
    }
}
