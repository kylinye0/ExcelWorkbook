using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DbHelper.Factory
{
    public class DbUtils
    {
        public static string DbConnString()
        {
            return @"Data Source=127.0.0.1;Initial Catalog=WebApiContext;Persist Security Info=True;User ID=sa;Password=Aurisco..;Max Pool Size=500;Min Pool Size=5;";
        }

        public static string DbConnString(string svname,string dbname)
        {
            return @"Data Source="+ svname.Trim() + ";Initial Catalog=" + dbname.Trim() + ";Persist Security Info=True;User ID=sa;Password=Aurisco..;Max Pool Size=200;Min Pool Size=5;";
        }
        //执行sql,返回datatable
        public static DataSet ExecuteDataTable(string sSql, params SqlParameter[] parameters)
        {
            using (SqlConnection myConn = new SqlConnection(DbConnString()))
            {
                myConn.Open();
                using (SqlCommand com = myConn.CreateCommand())
                {
                    //com.CommandTimeout = 180;
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    try
                    {
                        da.Fill(ds, "Tables");
                    }
                    catch (SqlException ex)
                    {
                        throw (ex);
                    }
                    return ds;
                }
            }
            
        }

        /// <summary>
        /// 获得一个sqldataReader
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReader(string sSql, params SqlParameter[] parameters)
        {
            using (SqlConnection myConn = new SqlConnection(DbConnString()))
            {
                myConn.Open();
                using (SqlCommand com = myConn.CreateCommand())
                {
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }

                    SqlDataReader dr = com.ExecuteReader();
                    return dr;
                }
            }
        }

        //执行SQL，返回影响的行数
        public static int ExecuteNonQuery(string sSql, params SqlParameter[] parameters)
        {
            int i = 0;

            using (SqlConnection conn = new SqlConnection(DbConnString()))
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }
                    i = com.ExecuteNonQuery();
                }
            }

            return i;
        }

        public static object ExceuteScalar(string sSql, params SqlParameter[] parameters)
        {
            object o;

            using (SqlConnection conn = new SqlConnection(DbConnString()))
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }
                    o = com.ExecuteScalar();
                }
            }

            return o;
        }
        public static DataSet ExecuteDataTable(string sSql, string svname, string dbname, params SqlParameter[] parameters)
        {
            using (SqlConnection myConn = new SqlConnection(DbConnString( svname,  dbname)))
            {
                myConn.Open();
                using (SqlCommand com = myConn.CreateCommand())
                {
                    //com.CommandTimeout = 180;
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    try
                    {
                        da.Fill(ds, "Tables");
                    }
                    catch (SqlException ex)
                    {
                        throw (ex);
                    }
                    return ds;
                }
            }

        }

        /// <summary>
        /// 获得一个sqldataReader
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReader(string sSql, string svname, string dbname, params SqlParameter[] parameters)
        {
            using (SqlConnection myConn = new SqlConnection(DbConnString(svname, dbname)))
            {
                myConn.Open();
                using (SqlCommand com = myConn.CreateCommand())
                {
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }

                    SqlDataReader dr = com.ExecuteReader();
                    return dr;
                }
            }
        }

        //执行SQL，返回影响的行数
        public static int ExecuteNonQuery(string sSql, string svname, string dbname, params SqlParameter[] parameters)
        {
            int i = 0;

            using (SqlConnection conn = new SqlConnection(DbConnString(svname, dbname)))
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }
                    i = com.ExecuteNonQuery();
                }
            }

            return i;
        }

        public static object ExceuteScalar(string sSql, string svname, string dbname, params SqlParameter[] parameters)
        {
            object o;

            using (SqlConnection conn = new SqlConnection(DbConnString(svname, dbname)))
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sSql;
                    foreach (SqlParameter p in parameters)
                    {
                        com.Parameters.Add(p);
                    }
                    o = com.ExecuteScalar();
                }
            }

            return o;
        }
    }
}
