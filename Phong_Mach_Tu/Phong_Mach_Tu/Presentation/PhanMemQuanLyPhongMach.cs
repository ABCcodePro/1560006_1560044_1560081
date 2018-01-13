using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phong_Mach_Tu.Presentation
{
    public partial class PhanMemQuanLyPhongMach : Form
    {
        public PhanMemQuanLyPhongMach()
        {
            InitializeComponent();
        }
        private void PhanMemQuanLyPhongMach_Load(object sender, EventArgs e)
        {

        }
        //chuyển form đơn vị
        private void button3_Click(object sender, EventArgs e)
        {
            frmDonVi donvi = new frmDonVi();
            donvi.ShowDialog();
        }
        //chuyển form cách dùng
        private void button2_Click(object sender, EventArgs e)
        {
            frmCachDung cachdung = new frmCachDung();
            cachdung.ShowDialog();
        }
        //chuyển form loại bệnh
        private void button4_Click(object sender, EventArgs e)
        {
            frmLoaiBenh loaibenh = new frmLoaiBenh();
            loaibenh.ShowDialog();
        }
        //chuyển form tiền khám
        private void button6_Click(object sender, EventArgs e)
        {
            frmTienKham tienkham = new frmTienKham();
            tienkham.ShowDialog();
        }
    }
}
