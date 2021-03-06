﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class HocSinhDAO
    {
        public static SqlConnection con;
        // load dữ liệu, hiển thị theo yêu cầu, thêm sửa xóa
        // Load dữ liệu
        public static DataTable LoadDataHocSinh()
        {
            string sTruyVan = "select * from tblHocSinh";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        // hiển thị theo yêu cầu
        public static DataTable HienThiYeuCau(HocSinhDTO hs)
        {
            string sTruyVan = string.Format("select * from tblHocSinh where IDHocSinh={0}", hs.IDHocSinh);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        // thêm học sinh
        public static bool ThemHS(HocSinhDTO hs)
        {
            try
            {
                string sTruyVan = string.Format("insert into tblHocSinh values({0},N'{1}',{2},{3},N'{4}',N'{5}',{6})",  hs.IDHocSinh,
                                                                                                                        hs.HoTen,
                                                                                                                        hs.IDLop,
                                                                                                                        hs.NgaySinh,
                                                                                                                        hs.GioiTinh,
                                                                                                                        hs.DiaChi,
                                                                                                                        hs.SDT);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }

            catch
            {
                return false;
            }
        }
        // sửa học sinh
        public static bool SuaHS(HocSinhDTO hs)
        {
            try
            {
                string sTruyVan = string.Format("update tblHocSinh set HoTen=N'{0}', IDLop={1}, NgaySinh={2}, GioiTinh=N'{3}', DiaChi=N'{4}', SDT={5} where IDHocSinh={6}",  hs.HoTen,
                                                                                                                                                                             hs.IDLop,
                                                                                                                                                                             hs.NgaySinh,
                                                                                                                                                                             hs.GioiTinh,
                                                                                                                                                                             hs.DiaChi,
                                                                                                                                                                             hs.SDT,
                                                                                                                                                                             hs.IDHocSinh);
                                                                                                                       
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }

            catch
            {
                return false;
            }
        }
        // xóa học sinh
        public static bool XoaHS(HocSinhDTO hs)
        {
            try
            {
                string sTruyVan = string.Format("delete from tblHocSinh where IDHocSinh = {0}",hs.IDHocSinh);
                con = DataProvider.KetNoi();
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
