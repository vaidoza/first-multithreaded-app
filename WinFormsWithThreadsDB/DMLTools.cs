using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Diagnostics;   //TODO: reiks pasalinti

namespace WinFormsWithThreadsDB
{
    class DMLTools
    {
        string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=ThreadLogas.mdb;";

        public List<ThreadData> ThreadListTable()
        {
            List<ThreadData> loglist = new List<ThreadData>();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string selectquerystr = "SELECT TOP 20 * FROM ThreadsLog ORDER BY ThreadTime DESC;";

                OleDbCommand command = new OleDbCommand(selectquerystr, conn);
                try
                {
                    conn.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        loglist.Add(new ThreadData() { threadId = reader["ThreadID"].ToString(), threadTime = (DateTime)reader["ThreadTime"], threadData = reader["Data"].ToString() });
#if DEBUG
                        Debug.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
#endif
                    }
                    reader.Close();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
#if DEBUG
                    Debug.WriteLine(ex.Message);
#endif
                }
            }
            return loglist;
        }

        private static string TextGenerator(int length)
        {
            Random rnd = new Random();
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var chars = Enumerable.Range(0, length).Select(x => pool[rnd.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        public string[] InsertINTOAccessTable(string threadId)
        {
            string insertqerystr = "";
            string[] lvArray = new string[2];

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string rndstr;
                
                Random rnd = new Random();
                rndstr = TextGenerator(rnd.Next(5, 11));
                OleDbCommand command = new OleDbCommand(insertqerystr, conn);

                command.CommandText = "INSERT INTO ThreadsLog (ThreadID,ThreadTime,Data) VALUES (@threadid,@threadtime,@threadgentxt)";
                command.Parameters.AddWithValue("@threadid", threadId);
                command.Parameters.AddWithValue("@threadtime", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@threadgentxt", rndstr);
                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    //conn.Close();
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);
                }
                lvArray[0] = threadId;
                lvArray[1] = rndstr;
            }
            return lvArray;
        }
        
    }
}
