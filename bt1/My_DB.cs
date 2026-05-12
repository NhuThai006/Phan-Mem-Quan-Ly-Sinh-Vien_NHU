    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    namespace bt1
    {
    internal class My_DB
        {
        public SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;");
        public SqlConnection getConnection
            {
                get
                {
                    return conn;
                }
            }
            public void openConnection()
            {
                if ((conn.State == ConnectionState.Closed))
                    conn.Open();
            }
            public void closeConnection()
            {
                if ((conn.State == ConnectionState.Open))
                    conn.Close();
            }
        }
    }
