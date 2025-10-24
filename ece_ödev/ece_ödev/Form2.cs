using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ece_ödev
{
    public partial class Form2 : Form
    {
        
        private string isim, soyisim, medeniDurum, mezun, hobiler = "";
        private string selectedPhotoPath = null;

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Fotoğraf Seç";
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp|Tüm Dosyalar|*.*";

            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                resim.ImageLocation = openFileDialog.FileName;
                selectedPhotoPath = openFileDialog.FileName; 
                resim.ImageLocation = selectedPhotoPath; 
                resim.SizeMode = PictureBoxSizeMode.StretchImage;
               
                string selectedFilePath = openFileDialog.FileName;
                resim.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            
            Font yeniFont = new Font("Modern No. 20", 12, FontStyle.Bold); 

           
            foreach (Control kontrol in this.Controls)
            {
                kontrol.Font = yeniFont;

               
            }
            panel1.Visible = false;
           
            comboBox1.Items.AddRange(new string[]
            {
                "Türkiye",
                "İngiltere",
                "İspanya",
                "İtalya",
                "Fransa",
                "Almanya",
                "Hollanda",
                "Portekiz",
                "Belçika",
                "Yunanistan"
            });
            comboBox1.SelectedItem = "Türkiye"; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            İsim.Text = isimm.Text;
            Soyisim.Text = soyisimm.Text;

            
            if (int.TryParse(yass.Text.Replace("Yaş: ", ""), out int yaş))
            {
                textBox1.Text = yaş.ToString();
            }

            
            string mevcutUyruk = uyruk.Text.Replace("Uyruk: ", "");
            comboBox1.SelectedItem = mevcutUyruk;

           
            if (medeni.Text.Contains("Evli"))
                radioButton5.Checked = true;
            else if (medeni.Text.Contains("Bekar"))
                radioButton6.Checked = true;

          
            if (mezunn.Text.Contains("İlkokul"))
                radioButton1.Checked = true;
            else if (mezunn.Text.Contains("Lise"))
                radioButton2.Checked = true;
            else if (mezunn.Text.Contains("Üniversite"))
                radioButton3.Checked = true;
            else if (mezunn.Text.Contains("Yüksek Lisans"))
                radioButton4.Checked = true;

            checkBox1.Checked = hobilerr.Text.Contains("İnternet");
            checkBox2.Checked = hobilerr.Text.Contains("Futbol");
            checkBox3.Checked = hobilerr.Text.Contains("Basketbol");
            checkBox4.Checked = hobilerr.Text.Contains("Sinema");
            checkBox5.Checked = hobilerr.Text.Contains("Tenis");
            checkBox6.Checked = hobilerr.Text.Contains("Tiyatro");

           
            if (!string.IsNullOrEmpty(selectedPhotoPath))
            {
                resim.ImageLocation = selectedPhotoPath;
                resim.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide(); 
            form.ShowDialog(); 
            this.Close();


        }

        private int yasdeger;

        public Form2()
        {
            InitializeComponent(); 
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
            isim = İsim.Text; 
            soyisim = Soyisim.Text; 
            if (string.IsNullOrEmpty(selectedPhotoPath))
            {
                MessageBox.Show("Lütfen bir fotoğraf seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pictureBox2.ImageLocation = selectedPhotoPath; 
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            
            if (int.TryParse(textBox1.Text, out yasdeger))
            {
                yass.Text = "Yaş: " + yasdeger; 
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir yaş giriniz!");
                return; 
            }

            
            if (radioButton1.Checked)
                mezun = "İlkokul";
            else if (radioButton2.Checked)
                mezun = "Lise";
            else if (radioButton3.Checked)
                mezun = "Üniversite";
            else if (radioButton4.Checked)
                mezun = "Yüksek Lisans";

            
            if (radioButton5.Checked)
                medeniDurum = "Evli";
            else if (radioButton6.Checked)
                medeniDurum = "Bekar";

            List<string> hobiListesi = new List<string>();
            if (checkBox1.Checked) hobiListesi.Add("İnternet");
            if (checkBox2.Checked) hobiListesi.Add("Futbol");
            if (checkBox3.Checked) hobiListesi.Add("Basketbol");
            if (checkBox4.Checked) hobiListesi.Add("Sinema");
            if (checkBox5.Checked) hobiListesi.Add("Tenis");
            if (checkBox6.Checked) hobiListesi.Add("Tiyatro");

            hobiler = string.Join(Environment.NewLine, hobiListesi); 
            string uyrukk = comboBox1.SelectedItem.ToString();

            
            isimm.Text = isim; 
            soyisimm.Text = soyisim;
            yass.Text = "Yaş: " + yasdeger;
            medeni.Text = "Medeni Durum: " + medeniDurum;
            mezunn.Text = "Mezuniyet: " + mezun;
            hobilerr.Text = "Hobiler: \n " + hobiler;
            uyruk.Text = "Uyruk: " + uyrukk;


           
            panel1.Visible = true; 
            ResetFormFields();
        }

        private void ResetFormFields()
        {
            
            İsim.Text = "";
            Soyisim.Text = "";
            textBox1.Text = "";

           
            comboBox1.SelectedItem = "Türkiye";

         
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

          
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;

         
            resim.Image = null;

            
            selectedPhotoPath = null;
        }
    }
}
