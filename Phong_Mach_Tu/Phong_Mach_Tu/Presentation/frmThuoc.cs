using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phong_Mach_Tu.BUS;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;

namespace Phong_Mach_Tu.Presentation
{
    public partial class frmThuoc : Form
    {
        public frmThuoc()
        {
            InitializeComponent();
        }

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            LoadListThuoc();
            GetCachDung();
            GetDonVi();
            GetMaThuoc();
        }
        public void GetMaThuoc()
        {
            List<ThuocDTO> listThuoc = ThuocBUS.SelectAllThuoc();

            cbbMaThuoc1.DisplayMember = "MaThuoc";
            cbbMaThuoc1.ValueMember = "TenThuoc";
            cbbMaThuoc1.DataSource = listThuoc;
            cbbMaThuoc2.DisplayMember = "MaThuoc";
            cbbMaThuoc2.ValueMember = "TenThuoc";
            cbbMaThuoc2.DataSource = listThuoc;
            //dgvDanhSachThuoc.DataSource = listCachDung;
        }
        public void GetCachDung()
        {
            List<CachDungDTO> listCachDung = CachDungBUS.SelectAllCachDung();
            
            cbbCachDung.DisplayMember = "Ma";
            cbbCachDung.ValueMember = "Ten";
            cbbCachDung.DataSource = listCachDung;
            //dgvDanhSachThuoc.DataSource = listCachDung;
        }
        public void GetDonVi()
        {
            List<DonViDTO> listDonVi = DonViBUS.SelectAllDonVi();

            cbbDonVi.DisplayMember = "TenDonVi";
            cbbDonVi.ValueMember = "TenDonVi";
            cbbDonVi.DataSource = listDonVi;
            //dgvDanhSachThuoc.DataSource = listCachDung;
        }
        void LoadListThuoc()
        {
            List<ThuocDTO> listThuoc = ThuocBUS.SelectAllThuoc();
            dgvDanhSachThuoc.DataSource = listThuoc;
        }

        //thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThuocDTO Thuoc = new ThuocDTO();
            Thuoc.MaThuoc = txtMaThuoc.Text;
            Thuoc.TenThuoc = txtTenThuoc.Text;
            Thuoc.DonVi = cbbDonVi.Text;
            Thuoc.CachDung = cbbCachDung.Text;
            Thuoc.SoLuong = int.Parse(txtSoLuong.Text);
            Thuoc.GiaThuoc = int.Parse(txtGiaThuoc.Text);


            DbAck ack = ThuocBUS.Insert(Thuoc);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thong bao", "Them Thanh Cong");
                LoadListThuoc();
                GetMaThuoc();
                txtMaThuoc.Text = null;
                txtTenThuoc.Text = null;
                cbbDonVi.Text = null;
                cbbCachDung.Text = null;
                txtSoLuong.Text = null;
                txtGiaThuoc.Text = null;
            }
            else
            {
                if (ack == DbAck.Unknown)
                {
                    MessageBox.Show("Thong bao", "Loi khong xac dinh");
                }
                else
                {

                }
            }
            
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {

            ThuocDTO Thuoc = new ThuocDTO();
            Thuoc.MaThuoc = cbbMaThuoc1.Text;
            Thuoc.GiaThuoc = int.Parse(txtGiaThuoc1.Text);
            DbAck ack = ThuocBUS.Update(Thuoc);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thong bao", "Thay doi Thanh Cong");
                LoadListThuoc();
                GetMaThuoc();
                txtGiaThuoc1.Text = null;

            }
            else
            {
                if (ack == DbAck.Unknown)
                {
                    MessageBox.Show("Thong bao", "Loi khong xac dinh");
                }
                else
                {

                }
            }
        }
        //xoá
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ThuocDTO Thuoc = new ThuocDTO();
            Thuoc.MaThuoc = cbbMaThuoc2.Text;
            DbAck ack = ThuocBUS.Delete(Thuoc);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thong bao", "Xoa Thanh Cong");
                LoadListThuoc();
                GetMaThuoc();
            }
            else
            {
                if (ack == DbAck.Unknown)
                {
                    MessageBox.Show("Thong bao", "Loi khong xac dinh");
                    
                }
                else
                {

                }
            }
        }
    }
}
