using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ece_ödev
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> userCvData = new Dictionary<string, string>(); 
        private ErrorProvider errorProvider;

        public Form1()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkBlue;
            
            Font yeniFont = new Font("Modern No. 20", 12, FontStyle.Bold); 

            
            foreach (Control kontrol in this.Controls)
            {
                kontrol.Font = yeniFont;


            }

            listView1.View = View.Details;
            listView1.Columns.Add("Kullanıcı Adı", 150);
            listView1.Columns.Add("Şifre", 150);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(kullaniciAdi))
            {
                errorProvider.SetError(txtKullaniciAdi, "Kullanıcı adı boş bırakılamaz!");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtKullaniciAdi, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(sifre))
            {
                errorProvider.SetError(txtSifre, "Şifre boş bırakılamaz!");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtSifre, string.Empty);
            }

            if (!isValid)
            {
                return;
            }

            ListViewItem item = new ListViewItem(kullaniciAdi);
            item.SubItems.Add(sifre);
            listView1.Items.Add(item);

            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtKullaniciAdi.Text = kullaniciAdi; 
            txtSifre.Text = sifre;
        }

       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            
            ListViewItem selectedItem = listView1.SelectedItems[0];
            txtKullaniciAdi.Text = selectedItem.Text; 
            txtSifre.Text = selectedItem.SubItems[1].Text; 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) 
            {
                MessageBox.Show("Devam etmek için Kullanıcı Sözleşmesi'ni kabul etmelisiniz!",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen giriş yapmak için bir kayıt seçin!",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ListViewItem selectedItem = listView1.SelectedItems[0];
            string kullaniciAdi = selectedItem.Text;

            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if(listView1.SelectedItems.Count == 0)
    {
                MessageBox.Show("Lütfen silmek istediğiniz kullanıcıyı seçin!",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?",
                                                  "Kullanıcı Silme Onayı",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            
            if (result == DialogResult.Yes)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0]; 
                listView1.Items.Remove(selectedItem); 

                MessageBox.Show("Kullanıcı başarıyla silindi!",
                                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


