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
    public partial class frmTienKham : Form
    {
        public frmTienKham()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TienKhamDTO TienKham = new TienKhamDTO();
            TienKham.Tien = int.Parse(txtTienKham.Text);
            DbAck ack = TienKhamBUS.Update(TienKham);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thay đổi thành công", "Thông báo");
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
            txtTienKham.Text =TienKham.Tien.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmTienKham log = new frmTienKham();
            this.Close();
        }

        private void frmTienKham_Load(object sender, EventArgs e)
        {

        }
    }
}
