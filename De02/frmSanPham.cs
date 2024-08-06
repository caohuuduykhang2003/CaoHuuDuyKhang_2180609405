using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De02
{
    public partial class frmQLSP : Form
    {
        public frmQLSP()
        {
            InitializeComponent();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                ListViewItem item = new ListViewItem(txtMaSP.Text);
                item.SubItems.Add(txtTenSP.Text);
                item.SubItems.Add(dtpNgaynhap.Value.ToShortDateString());

                listView1.Items.Add(item);

                txtMaSP.Clear();
                txtTenSP.Clear();
                dtpNgaynhap.Value = DateTime.Now;
                txtMaSP.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các mục đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        listView1.Items.Remove(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một mục để xóa!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                item.Text = txtMaSP.Text;
                item.SubItems[1].Text = txtTenSP.Text;
                item.SubItems[2].Text = dtpNgaynhap.Value.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa!");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tắt?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTim.Text.ToLower();

            foreach (ListViewItem item in listView1.Items)
            {
                bool found = false;
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(tuKhoa))
                    {
                        found = true;
                        break;
                    }
                }
            }
        }
    }
}

        