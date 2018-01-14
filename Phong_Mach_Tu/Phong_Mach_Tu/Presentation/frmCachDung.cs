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
    public partial class frmCachDung : Form
    {
        public frmCachDung()
        {
            InitializeComponent();
        }

        private void frmCachDung_Load(object sender, EventArgs e)
        {
            loadListCachdung();
        }
        //thêm
        private void button1_Click(object sender, EventArgs e)
        {
            CachDungDTO CachDung = new CachDungDTO();
            CachDung.Ma = txtMaCachDung.Text;
            CachDung.Ten = txtCachDung.Text;


            DbAck ack = CachDungBUS.Insert(CachDung);
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
            loadListCachdung();
            txtCachDung.Text = null;
            txtMaCachDung.Text = null;
        }
        //xoá
        private void button3_Click(object sender, EventArgs e)
        {
            CachDungDTO CachDung = new CachDungDTO();
            CachDung.Ma = txtMaCachDung.Text;
            DbAck ack = CachDungBUS.Delete(CachDung);
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
            loadListCachdung();
            txtCachDung.Text = null;
            txtMaCachDung.Text = null;
        }
        //sửa
        private void button2_Click(object sender, EventArgs e)
        {
            CachDungDTO CachDung = new CachDungDTO();
            CachDung.Ma = txtMaCachDung.Text;
            CachDung.Ten = txtCachDung.Text;
            DbAck ack = CachDungBUS.Update(CachDung);
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
            loadListCachdung();
            txtCachDung.Text = null;
            txtMaCachDung.Text = null;
        }
        //huỷ
        private void button4_Click(object sender, EventArgs e)
        {
            frmCachDung log = new frmCachDung();
            this.Close();
        }

        void loadListCachdung()
        {
            List<CachDungDTO> listCachDung = CachDungBUS.SelectAllCachDung();
            dgvListLoaiBenh.DataSource = listCachDung;
        }
    }
}
