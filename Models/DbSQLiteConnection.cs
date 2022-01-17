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

        public static bool AddExportingBill(ExportingBill dne)
        {
            string qr = $"Insert into PhieuXuat values('{dne.MaPX}','{dne.MaKH}','{dne.MaHang}','{dne.NgayBan}','{dne.SoLuongBan}','{dne.GiaBan}')";
            return ExecuteQuery(qr);
        }

        public static bool AddImportingBill(ImportingBill dne)
        {
            string qr = $"Insert into PhieuNhap values('{dne.MaPN}','{dne.MaNCC}','{dne.MaHang}','{dne.NgayNhap}','{dne.SoLuongNhap}','{dne.GiaNhap}')";
            return ExecuteQuery(qr);
        }
        public static bool RemoveImportingBill(ImportingBill dne)
        {
            string qr = $"Delete From PhieuNhap where MaPN ='{dne.MaPN}'";
            return ExecuteQuery(qr);
        }
        public static bool UpdateImportingBill(ImportingBill dne)
        {
            string qr = $"Update PhieuNhap set MaNCC='{dne.MaNCC}',MaHang='{dne.MaHang}',NgayNhap='{dne.NgayNhap}',SoLuongNhap='{dne.SoLuongNhap}',GiaNhap='{dne.GiaNhap}' where MaPN='{dne.MaPN}'";
            return ExecuteQuery(qr);
        }

        public static bool RemoveExportingBill(ExportingBill dne)
        {
            string qr = $"Delete From PhieuXuat where MaPX ='{dne.MaPX}'";
            return ExecuteQuery(qr);
        }
        public static bool UpdateExportingBill(ExportingBill dne)
        {
            string qr = $"Update PhieuXuat set MaKH='{dne.MaKH}',MaHang='{dne.MaHang}',NgayBan='{dne.NgayBan}',SoLuongBan='{dne.SoLuongBan}',GiaBan='{dne.GiaBan}' where MaPX='{dne.MaPX}'";
            return ExecuteQuery(qr);
        }

        public static bool AddProvider(Provider dne)
        {
            string qr = $"Insert into NhaCungCap values('{dne.MaNCC}','{dne.TenNCC}','{dne.DiaChiNCC}','{dne.DienThoaiNCC}')";
            return ExecuteQuery(qr);
        }

        public static bool RemoveProvider(Provider dne)
        {
            string qr = $"Delete From NhaCungCap where MaNCC ='{dne.MaNCC}'";
            return ExecuteQuery(qr);
        }
        public static bool UpdateProvider(Provider dne)
        {
            string qr = $"Update NhaCungCap set TenNCC='{dne.TenNCC}',DiaChiNCC='{dne.DiaChiNCC}',DienThoaiNCC='{dne.DienThoaiNCC}' where MaNCC='{dne.MaNCC}'";
            return ExecuteQuery(qr);
        }
        public static bool AddUser(UserLogin dne)
        {
            string qr = $"Insert into DangNhap values('{dne.TenDN}','{dne.MatKhau}','{dne.Quyen}','{dne.TrangThai}','{dne.HoTen}','{0}')";
            return ExecuteQuery(qr);
        }
        public static bool AddClient(Customer dne)
        {
            string qr = $"Insert into KhachHang values('{dne.MaKH}','{dne.TenKH}','{dne.DiaChiKH}','{dne.DienThoaiKH}')";
            return ExecuteQuery(qr);
        }
        public static bool UpdateUser(UserLogin dne)
        {
            string qr = $"Update DangNhap set MatKhau='{dne.MatKhau}',Quyen='{dne.Quyen}',TrangThai='{dne.TrangThai}',HoTen='{dne.HoTen}',loi='{dne.Loi}' where TenDN='{dne.TenDN}'";
            return ExecuteQuery(qr);
        }
        public static bool UpdateClient(Customer dne)
        {
            string qr = $"Update KhachHang set TenKH='{dne.TenKH}',DiaChiKH='{dne.DiaChiKH}',DienThoaiKH='{dne.DienThoaiKH}' where MaKH='{dne.MaKH}'";
            return ExecuteQuery(qr);
        }

        public static bool RemoveUser(UserLogin dne)
        {
            string qr = $"Delete From DangNhap where TenDN ='{dne.TenDN}'";
            return ExecuteQuery(qr);
        }

        public static bool RemoveClient(Customer dne)
        {
            string qr = $"Delete From KhachHang where MaKH ='{dne.MaKH}'";
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
