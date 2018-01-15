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
using Phong_Mach_Tu.DAO;
using Phong_Mach_Tu.BUS;

namespace Phong_Mach_Tu.Presentation
{
    public partial class frmDonVi : Form
    {
        public frmDonVi()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDonVi_Load(object sender, EventArgs e)
        {
            loadListDonVi();
        }

        void loadListDonVi()
        {
            List<DonViDTO> listDonVi = DonViBUS.SelectAllDonVi();
            dgvDsDonVi.DataSource = listDonVi;
        }

        //thêm
        private void button1_Click(object sender, EventArgs e)
        {
            DonViDTO DonVi = new DonViDTO();
            DonVi.TenDonVi = txtTenDonVi.Text;
            


            DbAck ack = DonViBUS.Insert(DonVi);
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
            loadListDonVi();
            txtTenDonVi.Text = null;
            
        }
        //xoá
        private void button3_Click(object sender, EventArgs e)
        {
            DonViDTO DonVi = new DonViDTO();
            DonVi.TenDonVi = txtTenDonVi.Text;
            DbAck ack = DonViBUS.Delete(DonVi);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Lỗi không xác định", "Thông báo");
            }
            else
            {
                if (ack == DbAck.Unknown)
                {
                    MessageBox.Show("Thêm Thành Công", "Thông báo");
                }
                else
                {

                }
            }
            loadListDonVi();
            txtTenDonVi.Text = null;
        }
       
        //huỷ
        private void button4_Click(object sender, EventArgs e)
        {
            frmDonVi log = new frmDonVi();
            this.Close();
        }
    }
}
