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

namespace Phong_Mach_Tu.Presentation
{
    public partial class frmLoaiBenh : Form
    {
        public frmLoaiBenh()
        {
            InitializeComponent();
        }
        //thêm loại bệnh
        private void button1_Click(object sender, EventArgs e)
        {
            LoaiBenhDTO loaiBenh = new LoaiBenhDTO();
            loaiBenh.Ma = txtMaLoaiBenh.Text;
            loaiBenh.Ten = txtTenLoaiBenh.Text;
             

            DbAck ack = LoaiBenhBUS.Insert(loaiBenh);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thong bao", "Them Thanh Cong");
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
            loadListLoaiBenh();
            txtMaLoaiBenh.Text = null;
            txtTenLoaiBenh.Text = null;
        }


        //đóng form
        private void button4_Click(object sender, EventArgs e)
        {
            frmLoaiBenh log = new frmLoaiBenh();
            this.Close();
            
        }

        //ds loại bệnh
        private void frmLoaiBenh_Load(object sender, EventArgs e)
        {
            loadListLoaiBenh();
        }

        void loadListLoaiBenh()
        {
            List<LoaiBenhDTO> listLoaiBenh = LoaiBenhBUS.SelectAllLoaiBenh();
            dgvListLoaiBenh.DataSource = listLoaiBenh;
        }
        //xoá
        private void button3_Click(object sender, EventArgs e)
        {
            LoaiBenhDTO loaiBenh = new LoaiBenhDTO();
            loaiBenh.Ma = txtMaLoaiBenh.Text;
            DbAck ack = LoaiBenhBUS.Delete(loaiBenh);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thong bao", "Loi khong xac dinh");
            }
            else
            {
                if (ack == DbAck.Unknown)
                {
                    MessageBox.Show("Thong bao", "Xoa Thanh cong");
                }
                else
                {

                }
            }
            loadListLoaiBenh();
        }
        //sửa
        private void button2_Click(object sender, EventArgs e)
        {
            LoaiBenhDTO loaiBenh = new LoaiBenhDTO();
            loaiBenh.Ma = txtMaLoaiBenh.Text;
            loaiBenh.Ten = txtMaLoaiBenh.Text;
            DbAck ack = LoaiBenhBUS.Update(loaiBenh);
            if (ack == DbAck.Ok)
            {
                MessageBox.Show("Thong bao", "Thay doi Thanh Cong");
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
            loadListLoaiBenh();
        }
    }
    
}
