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
    public class GiaoVienDAO
    {
        public static SqlConnection con;
        // load dữ liệu, hiển thị theo yêu cầu, thêm sửa xóa
        // Load dữ liệu
        public static DataTable LoadDataGiaoVien()
        {
            string sTruyVan = "select * from tblGiaoVien";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        
        // hiển thị theo yêu cầu
        public static DataTable HienThiYeuCau(GiaoVienDTO gv)
        {
            string sTruyVan = string.Format("select * from tblGiaoVien where IDGIaoVien={0}", gv.IDGiaoVien);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
       
        //thêm giáo viên
        public static bool ThemGV(GiaoVienDTO gv)
        {
            try
            {
                string sTruyVan = string.Format("insert into tblGiaoVien values({0},N'{1}',{2},N'{3}',{4}, N'{5}', {6})", gv.IDGiaoVien,
                                                                                                                        gv.HoTen, 
                                                                                                                        gv.NgaySinh,
                                                                                                                        gv.GioiTinh,
                                                                                                                        gv.IDMon,
                                                                                                                        gv.DiaChi, 
                                                                                                                        gv.SDT);
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

        //sửa giáo viên
        public static bool SuaGiaoVien(GiaoVienDTO gv)
        {
            try
            {
                string sTruyVan = string.Format("update tblGiaoVien set HoTen=N'{0}', NgaySinh={1}, GioiTinh=N'{2}', IDMon={3}, DiaChi=N'{4}', SDT= {5} where IDGiaoVien={6}",gv.HoTen,
                                                                                                                                                                              gv.NgaySinh,
                                                                                                                                                                              gv.GioiTinh,
                                                                                                                                                                              gv.IDMon,
                                                                                                                                                                              gv.DiaChi,
                                                                                                                                                                              gv.SDT,
                                                                                                                                                                              gv.IDGiaoVien);
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
        
        //xóa giáo viên
        public static bool XoaGV( GiaoVienDTO gv)
        {
            try
            {
                string sTruyVan = string.Format("delete from tblGiaoVien where IDGiaoVien = {0}", gv.IDGiaoVien);
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
