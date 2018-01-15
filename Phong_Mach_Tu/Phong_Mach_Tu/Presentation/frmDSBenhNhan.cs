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
    public partial class frmDSBenhNhan : Form
    {
        public frmDSBenhNhan()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        
        private void frmDSBenhNhan_Load(object sender, EventArgs e)
        {

            loadListBenhNhan();
        }

        void loadListBenhNhan()
        {
            List<BenhNhanDTO> listBenhNhan = BenhNhanBUS.SelectAllBenhNhan();
            dgvDsBN.DataSource = listBenhNhan;
        }
       
        //nhập
        private void button1_Click(object sender, EventArgs e)
        {

            BenhNhanDTO BenhNhan = new BenhNhanDTO();

            string day = dateTimePicker2.Value.Date.ToString("yyyy/MM/dd");
            BenhNhan.MaBN = txtMaBN.Text;
            BenhNhan.HoTen = txtHoTen.Text;
            BenhNhan.GioiTinh = "nam";
            if (radioNam.Checked == true)
            {
                BenhNhan.GioiTinh = "Nam";
            }
            else
            {
                BenhNhan.GioiTinh = "Nu";
            }
            BenhNhan.NamSinh = day;
            BenhNhan.DiaChi = txtDiaChi.Text;


            DbAck ack = BenhNhanBUS.Insert(BenhNhan);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thêm Thành Công", "Thông báo");
            }
            else
            {
                if (ack == DbAck.Unknown)
                {
                    MessageBox.Show("Lỗi không xác định", "Thông báo");
                }
                else
                {

                }
            }
            loadListBenhNhan();

        }

        private void txtNext_Click(object sender, EventArgs e)
        {
            frmPhieuKhamBenh phieukhambenh = new frmPhieuKhamBenh();
            phieukhambenh.ShowDialog();
        }
    }
}
