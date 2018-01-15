using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.BUS;
using Phong_Mach_Tu.DAO;
namespace Phong_Mach_Tu.Presentation
{
    public partial class frmPhieuKhamBenh : Form
    {
        public frmPhieuKhamBenh()
        {
            InitializeComponent();
        }

        private void frmPhieuKhamBenh_Load(object sender, EventArgs e)
        {
            GetMaBenhNhan();
            GetTrieuChung();
            GetThuoc();
            LoadDsThuoc();

        }

        public void GetMaBenhNhan()
        {
            List<BenhNhanDTO> listBenhNhan = BenhNhanBUS.SelectAllBenhNhan();
            cbbMaBN.DisplayMember = "MaBN";
            cbbMaBN.ValueMember = "HoTen";
            cbbMaBN.DataSource = listBenhNhan;
        }
        public void GetTrieuChung()
        {
            List<LoaiBenhDTO> listLoaiBenh = LoaiBenhBUS.SelectAllLoaiBenh();
            cbbDuDoanBenh.DisplayMember = "Ma";
            cbbDuDoanBenh.ValueMember = "Ten";
            cbbDuDoanBenh.DataSource = listLoaiBenh;
        }
        public void GetThuoc()
        {
            List<ThuocDTO> listThuoc = ThuocBUS.SelectAllThuoc();
            cbbThuoc.DisplayMember = "MaThuoc";
            cbbThuoc.ValueMember = "MaThuoc";
            cbbThuoc.DataSource = listThuoc;
        }
        //thêm thuốc vào hoá đơn
        private void button1_Click(object sender, EventArgs e)
        {
            //ThuocDTO thuoc = new ThuocDTO();
            //thuoc = ThuocBUS.getThuoc(cbbThuoc.Text);
            PhieuKhamBenhDTO phieu = new PhieuKhamBenhDTO();
            phieu.MaPhieu = txtMaPhieu.Text;
            phieu.MaThuoc = cbbThuoc.Text;
            phieu.SoLuong = int.Parse(txtSl.Text);
            phieu.Gia = 0;
            DbAck ack = PhieuKhamBenhBUS.InsertCTPhieu(phieu);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thong bao", "Thay doi Thanh Cong");
               // LoadDsThuoc();



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

        public void LoadDsThuoc()
        {
            List<CTPhieuDTO> listCTPhieu = CTPhieuBUS.SelectAllCTPhieuKhamBenh();
            dgvThemThuoc.DataSource = listCTPhieu;
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            PhieuKhamBenhDTO phieu = new PhieuKhamBenhDTO();
            phieu.MaPhieu = txtMaPhieu.Text;
            phieu.MaBN = cbbMaBN.Text;
            phieu.Ngay = DtpDay.Value.Date.ToString("yyyy/MM/dd");
            phieu.TrieuChung = txtTrieuChung.Text;
            phieu.DuDoanBenh = cbbDuDoanBenh.Text;
            DbAck ack = PhieuKhamBenhBUS.Insert(phieu);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thay đổi thành công", "Thông Báo");
                //LoadDsThuoc();

            }
            else
            {
                if (ack == DbAck.Unknown)
                {
                    MessageBox.Show("Lỗi không xác định", "Thông Báo");
                }
                else
                {

                }
            }

        }
    }
}
