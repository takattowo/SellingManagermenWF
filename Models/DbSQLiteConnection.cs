using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingManagermenWF.Models
{
    class DbSQLiteConnection
    {
        static private readonly string ConnectionString = @$"Data Source={Application.StartupPath}\data.db;";

        public static SqliteConnection Connect()
        {      
            SqliteConnection con  = new SqliteConnection(ConnectionString);


            con.Open();
            return con;
        }

        public static DataTable GetDataTable(string query)
        {
            DataTable entries = new DataTable();

            using (var db = new SqliteConnection(ConnectionString))
            {
                SqliteCommand selectCommand = new SqliteCommand(query, db);
                try
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                    db.Open();
                    SqliteDataReader reader = selectCommand.ExecuteReader();

                    if (reader.HasRows)
                        for (int i = 0; i < reader.FieldCount; i++)
                            entries.Columns.Add(new DataColumn(reader.GetName(i)));

                    int j = 0;
                    while (reader.Read())
                    {
                        DataRow row = entries.NewRow();
                        entries.Rows.Add(row);

                        for (int i = 0; i < reader.FieldCount; i++)
                            entries.Rows[j][i] = (reader.GetValue(i));

                        j++;
                    }

                    db.Close();
                }
                catch (SqliteException e)
                {
                    MessageBox.Show(e.Message);
                    db.Close();
                }
                return entries;
            }
        }

        public static bool AddUser(UserLogin dne)
        {
            string qr = $"Insert into DangNhap values('{dne.TenDN}','{dne.MatKhau}','{dne.Quyen}','{dne.TrangThai}','{dne.HoTen}','{0}')";
            return ExecuteQuery(qr);
        }
        public static bool UpdateUser(UserLogin dne)
        {
            string qr = $"Update DangNhap set MatKhau='{dne.MatKhau}',Quyen='{dne.Quyen}',TrangThai='{dne.TrangThai}',HoTen='{dne.HoTen}',loi='{dne.Loi}' where TenDN='{dne.TenDN}'";
            return ExecuteQuery(qr);
        }

        public static bool RemoveUser(UserLogin dne)
        {
            string qr = $"Delete From DangNhap where TenDN ='{dne.TenDN}'";
            return ExecuteQuery(qr);
        }

        public static bool ExecuteQuery(string query)
        {
            using (var db = new SqliteConnection(ConnectionString))
            {
                SqliteCommand selectCommand = new SqliteCommand(query, db);
                try
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                    db.Open();
                    selectCommand.ExecuteNonQuery();
                    db.Close();
                    return true;
                }
                catch (SqliteException e)
                {
                    MessageBox.Show(e.Message);
                    db.Close();
                    return false;
                }
            }
        }
    }
}
