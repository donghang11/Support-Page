using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SupportPage;

namespace DatabaseUtils
{
    class DBUtils
    {
        SqlConnection conn;

        public DBUtils(string connection_string)
        {
            try
            {
                conn = new SqlConnection(connection_string);
            }

            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ReadData(string item_name, string group_name)
        {
            SqlDataReader reader = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select " + item_name + " from " + group_name, conn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["City"]);
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public Data ReadAllFromARowWithRowIdIncident(string table, string rowId)
        {
            SqlDataReader reader = null;
            Data data = new Data();

            try
            {
                conn.Open();
                string command = "select * " + " from " + table + " where id = " + rowId + ";";
                SqlCommand cmd = new SqlCommand(command, conn);
                Console.WriteLine(command);
                reader = cmd.ExecuteReader();
                Console.WriteLine("field count" + reader.FieldCount);
                reader.Read();
                data.AddWithNothing(reader.GetInt32(0).ToString());
                if (!reader.IsDBNull(1))
                {
                    data.AddWithNothing(reader.GetInt32(1).ToString());
                }

                else
                    data.Add("no");

                data.AddWithNothing(reader.GetString(2));
                data.AddWithNothing(reader.GetString(3));
                data.AddWithNothing(reader.GetString(4));
                data.AddWithNothing(reader.GetInt32(5).ToString());
                data.AddWithNothing(reader.GetInt32(6).ToString());
                data.AddWithNothing(reader.GetDateTime(7).ToString());
                data.AddWithNothing(reader.GetDateTime(8).ToString());

            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return data;
        }

        public void insert(string table_name, string name, string city)
        {

            try
            {
                conn.Open();

                string insertString = @"insert into " + table_name + " values " + "('" + name + "'" + "," + "'" + city + "')";

                Console.WriteLine(insertString);
                SqlCommand cmd = new SqlCommand(insertString, conn);

                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void update_using_id(string group_name, string item_name, string ID, string new_value)
        {

            try
            {
                conn.Open();

                string updateString = @"update " + group_name + " set " + item_name + " = " + "'" + new_value + "'" + " where " + " ID = " + "'" + ID + "'";

                Console.WriteLine(updateString);
                SqlCommand cmd = new SqlCommand(updateString, conn);

                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void delete_using_id(string group_name, string ID)
        {

            try
            {
                conn.Open();

                string insertString = @"delete from " + group_name + " where " + " ID " + " = " + ID;

                SqlCommand cmd = new SqlCommand(insertString, conn);

                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int count()
        {
            int count = -1;

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select count(*) from students", conn);

                count = (int)cmd.ExecuteScalar();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }
    }
}
