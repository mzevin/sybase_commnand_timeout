using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection = new OdbcConnection("Driver={Adaptive Server Enterprise};ServerInitiatedTransactions=0;NA=ase_server;CommandTimeout=2");

            try
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "<sp_name>";
                //cmd.CommandTimeout = 2;
                var sw = new Stopwatch();
                sw.Start();
                var reader = cmd.ExecuteReader();
                reader.Read();
                sw.Stop();
                System.Console.WriteLine(sw.Elapsed.TotalSeconds);
            }
            catch (Exception e)
            {
                
                System.Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            
            
        }
    }
}
