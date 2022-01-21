using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebApiContext.Entity;
using DbHelper.Factory;

namespace WebApiContext.DAL
{
    public class UserDao
    {
        private const string InsertCommand = "INSERT INTO [dbo].[User] ([UserNo] ,[UserName],[PassWord],[Email],[UserLock],[SafeLevel],[TwoValidPassword]) " +
                                     "VALUES  (@UserNo,,@UserName,@PassWord,@Email,@UserLock,@SafeLevel,@TwoValidPassword)";
        private const string UpdateCommand = "UPDATE [dbo].[User] SET [UserNo] = @UserNo,[UserName] =@UserName,[PassWord] = @PassWord,[Email] = @Email,[UserLock] = @UserLock,[SafeLevel] = @SafeLevel,[TwoValidPassword] = @TwoValidPassword WHERE (([UserNo] = @Original_UserNo))";
        private const string DeleteCommand = "DELETE FROM [dbo].[User] WHERE (([UserNo] = @Original_UserNo))";
        private const string SelectCommand = "SELECT [ID],[UserNo],[UserName],[PassWord],[Email],[UserLock],[SafeLevel],[TwoValidPassword] FROM [dbo].[User]";
        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// 

        public void Insert(User user)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.Factory.DbUtils.DbConnString()))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = InsertCommand;
                    cmd.Parameters.Add("@UserNo", SqlDbType.UniqueIdentifier).Value = user.UserNo;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
                    cmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = user.PassWord;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.Add("@UserLock", SqlDbType.Bit).Value = user.UserLock;
                    cmd.Parameters.Add("@SafeLevel", SqlDbType.Int).Value = user.SafeLevel;
                    cmd.Parameters.Add("@TwoValidPassword", SqlDbType.NVarChar).Value = user.TwoValidPassword;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw (ex);
                    }
                }
            }
        }


        public void Update(User user, String svname, String dbname)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.Factory.DbUtils.DbConnString(svname, dbname)))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = UpdateCommand;
                    cmd.Parameters.Add("@UserNo", SqlDbType.UniqueIdentifier).Value = user.UserNo;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
                    cmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = user.PassWord;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.Add("@UserLock", SqlDbType.Bit).Value = user.UserLock;
                    cmd.Parameters.Add("@SafeLevel", SqlDbType.Int).Value = user.SafeLevel;
                    cmd.Parameters.Add("@TwoValidPassword", SqlDbType.NVarChar).Value = user.TwoValidPassword;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw (ex);
                    }
                }
            }
        }

        public User GetDataByUserName(String username, String svname, String dbname)
        {
            DataTable dt = DbHelper.Factory.DbUtils.ExecuteDataTable(SelectCommand + " WHERE UserName = @UserName", svname.Trim(), dbname.Trim(), new SqlParameter("@UserName", username.Trim())).Tables[0];
            return DbHelper.Factory.ModelConvertHelper<User>.ConvertToModel(dt);
        }


    }
}
