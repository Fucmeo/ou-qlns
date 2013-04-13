using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;
using SystemConfig;

namespace DataProvider
{
    public class DataProvider
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlTransaction trans;

        public DataProvider()
        {
            SystemConfig.SystemConfig config = new SystemConfig.SystemConfig();
            conn = new NpgsqlConnection();
            cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            conn.ConnectionString = Stringconnection = config.ConnectionString;
        }


        #region khai báo biến thành viên

        private string stringconnection;
        private string Stringconnection
        {
            get { return stringconnection; }
            set { stringconnection = value; }
        }

        private string command; // SQL query
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        private CommandType commandtype = CommandType.Text; // Type of command
        public CommandType Commandtype
        {
            get { return commandtype; }
            set { commandtype = value; }
        }

        private string error;
        public string Error
        {
            get { return error; }
            set { error = value; }
        }


        #endregion

        #region Khai báo các phương thức thành viên

        private void Connect()  // Connect to Database
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (NpgsqlException ex)
                {
                    if (ex.BaseMessage == "Failed to establish a connection to '10.1.14.30'.")
                    {
                        throw new Exception("Lỗi kết nối tới hệ quản trị cơ sở dữ liệu Postgres.\r\nNguyên nhân có thể do: \r\n " +
                                            "\t 1.Dịch vụ Postgres chưa khởi động. \r\n \t2.Tên đăng nhập và mật khẩu cho Postgres không đúng với mặc định." +
                                            "\r\n \t(Tên đăng nhập và mật khẩu mặc định là \"postgres\").");
                    }
                    else
                        throw new Exception("Lỗi kết nối tới hệ quản trị cơ sở dữ liệu Postgres.");

                }

            }
        }

        private void Disconnect()// disconnect to database
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                // conn.Dispose();
            }
        }

        /// <summary>
        /// Lấy dữ liệu từ câu lệnh chứa trong thuộc tính Command
        /// </summary>
        /// <returns></returns>
        private DataSet getData() //Get data with SQLcommand
        {
            Connect();
            trans = conn.BeginTransaction();
            DataSet ds = new DataSet();
            cmd.Connection = conn;
            cmd.CommandText = Command;
            cmd.CommandType = Commandtype;
            cmd.Transaction = trans;
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            try
            {
                adapter.Fill(ds);
                trans.Commit();
                Disconnect();
                return ds;
            }
            catch (NpgsqlException ex)
            {
                Error = ex.Message;
                trans.Rollback();
            }
            return null;
        }
        public DataSet getData(string command) //Get data with SQLcommand
        {
            Command = command;
            Commandtype = CommandType.Text;
            return getData();
        }
        public DataSet getDataProc(string procedureName, params IDataParameter[] commandParameters)
        {
            cmd = new NpgsqlCommand();
            NpgsqlParameter[] sqlCommandParameters = null;
            if (commandParameters != null)
            {
                sqlCommandParameters = new NpgsqlParameter[commandParameters.Length];
                for (int intIndex = 0; intIndex <= commandParameters.Length - 1; intIndex++)
                {
                    sqlCommandParameters[intIndex] = (NpgsqlParameter)commandParameters[intIndex];
                }
                cmd.Parameters.AddRange(sqlCommandParameters);
            }
            Command = procedureName;
            Commandtype = CommandType.StoredProcedure;

            return getData();
        }

        /// <summary>
        /// Lấy dữ liệu từ câu lệnh select
        /// </summary>
        /// <param name="command">SQL String</param>
        /// <returns>Dữ Liệu DataTable</returns>
        public DataTable getDataTable(string _command) //Get data with SQLcommand and datatable name
        {
            try
            {
                cmd = new NpgsqlCommand();
                return getData(_command).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return null;
        }
        public DataTable getDataTableProc(string procedureName, params IDataParameter[] commandParameters)
        {
            try
            {
                DataSet ds = new DataSet();
                if ((ds = getDataProc(procedureName, commandParameters)).Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            catch { }
            return null;
        }


        /// <summary>
        /// Lấy Dữ Liệu Từng Dòng
        /// </summary>
        /// <returns>IDataReader</returns>
        private IDataReader getDataReader() // Đọc dữ liệu dạng Datareader
        {
            Connect();
            trans = conn.BeginTransaction();
            NpgsqlDataReader datard = null;
            try
            {
                cmd.CommandText = Command;
                cmd.CommandType = Commandtype;
                cmd.Transaction = trans;
                datard = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                trans.Commit();
            }
            catch (NpgsqlException ex)
            {
                Error = ex.Message;
                trans.Rollback();

            }
            // Disconnect();
            return datard;
        }
        public IDataReader getDataReader(string _command)
        {
            Command = _command;
            Commandtype = CommandType.Text;
            return getDataReader();

        }
        public IDataReader getDataReaderProc(string procedureName)
        {
            try
            {
                return getDataTableProc(procedureName, null).CreateDataReader();
            }
            catch { }
            return null;
        }
        public IDataReader getDataReaderProc(string procedureName, params IDataParameter[] commandParameters)
        {
            try
            {
                return getDataTableProc(procedureName, commandParameters).CreateDataReader();
            }
            catch { }
            return null;
        }


        /// <summary>
        /// Thực Thi các câu lệnh SQL (thường là UPDATE)
        /// </summary>
        /// <returns>giá trị các dòng có ảnh hưởng</returns>
        private int executeNonQuery()// Execute a command without return
        {
            Connect();
            trans = conn.BeginTransaction();
            cmd.CommandText = Command;
            cmd.CommandType = Commandtype;
            cmd.Connection = conn;
            cmd.Transaction = trans;
            int rowEffect = 0;
            try
            {
                rowEffect = cmd.ExecuteNonQuery();

                trans.Commit();
            }
            catch (NpgsqlException ex)
            {
                Error = ex.Message;
                trans.Rollback();
            }
            Disconnect();
            return rowEffect;
        }
        public int executeNonQuery(string _command)
        {
            Command = _command;
            Commandtype = CommandType.Text;
            return executeNonQuery();
        }
        public int executeNonQueryProc(string procedureName)
        {
            return executeNonQueryProc(procedureName, null);
        }
        public int executeNonQueryProc(string procedureName, params IDataParameter[] commandParameters)
        {
            cmd = new NpgsqlCommand();
            NpgsqlParameter[] sqlCommandParameters = null;
            if (commandParameters != null)
            {
                sqlCommandParameters = new NpgsqlParameter[commandParameters.Length];
                for (int intIndex = 0; intIndex <= commandParameters.Length - 1; intIndex++)
                {
                    sqlCommandParameters[intIndex] = (NpgsqlParameter)commandParameters[intIndex];
                }

                cmd.Parameters.AddRange(sqlCommandParameters);
            }
            Command = procedureName;
            Commandtype = CommandType.StoredProcedure;

            return this.executeNonQuery();
        }

        /// <summary>
        /// thực thi SQL, thường dùng cho các dòng lệnh MAX,AVG,COUNT,.....
        /// </summary>
        /// <returns>Object</returns>
        private object executeScalar()// Execute a command return only 1 value
        {
            Connect();
            trans = conn.BeginTransaction();
            cmd.CommandText = Command;
            cmd.CommandType = Commandtype;
            cmd.Transaction = trans;
            cmd.Connection = conn;
            object obj = null;
            try
            {
                obj = cmd.ExecuteScalar();
                trans.Commit();
            }
            catch (NpgsqlException ex)
            {
                trans.Rollback();
                if (ex.Code == "23505")
                {
                    if(ex.BaseMessage.Contains("quyet_dinh"))
                        throw new Exception("Mã quyết định đã tồn tại, xin vui lòng kiểm tra lại.");
                    else if(ex.BaseMessage.Contains("ma_nv"))
                        throw new Exception("Mã nhân viên đã tồn tại, xin vui lòng kiểm tra lại.");
                }
                throw new Exception(ex.Message);
                
            }
            Disconnect();
            return obj;
        }
        public object executeScalar(string _command)// Execute a command return ony 1 value
        {
            Command = _command;
            Commandtype = CommandType.Text;
            return executeScalar();
        }
        public object executeScalarProc(string procedureName)
        {
            return executeScalarProc(procedureName, null);
        }
        public object executeScalarProc(string procedureName, params IDataParameter[] commandParameters)
        {
            cmd = new NpgsqlCommand();
            NpgsqlParameter[] sqlCommandParameters = null;
            if (commandParameters != null)
            {
                sqlCommandParameters = new NpgsqlParameter[commandParameters.Length];
                for (int intIndex = 0; intIndex <= commandParameters.Length - 1; intIndex++)
                {
                    sqlCommandParameters[intIndex] = (NpgsqlParameter)commandParameters[intIndex];
                }
                cmd.Parameters.AddRange(sqlCommandParameters);
            }
            Command = procedureName;
            Commandtype = CommandType.StoredProcedure;
            return executeScalar();
        }

        /// <summary>
        /// Xây dựng câu lệnh Select
        /// </summary>
        /// <param name="tableName">Bảng bị tác động</param>
        /// <param name="condition">Điều kiện</param>
        /// <param name="fields">Lấy ra trường nào</param>
        /// <returns></returns>
        public DataSet customSelectExecute(string tableName, string condition, params string[] fields)
        {
            try
            {
                string sql = " SELECT ";
                sql = sql + " " + String.Join(",", fields) + " ";
                if (condition != "")
                {
                    sql += " WHERE " + condition;
                }
                return getData(sql);
            }
            catch { }

            return null;

        }
        public DataTable customSelectExecuteToDatatable(string tableName, string condition, params string[] fields)
        {
            try
            {
                return customSelectExecute(tableName, condition, fields).Tables[0];
            }
            catch { }
            return null;
        }
        #endregion
    }
}
