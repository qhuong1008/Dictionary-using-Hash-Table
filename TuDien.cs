using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class TuDien : Form
    {
        static HashTable dictionary = new HashTable();
        public TuDien()
        {
            InitializeComponent();
            docFile();
            setWordOfTheDay();
        }
        private void docFile()
        {
            LinkedList mylist = new LinkedList();
            FileStream fs = new FileStream(@"D:\GiaoTrinh_DaiHoc\HK1 Năm 2\Cautrucdulieu_vagiaithuat\DoAn(update)\(update)PhamQuynhHuong_TranThiBaoNgoc\Bai3\tudienAnhViet.txt", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);

            string englishmean, type;
            string viet = String.Empty;
            string line = rd.ReadLine();
          
            while ((line = rd.ReadLine()) != null)
            {
                if (line.StartsWith("@"))
                {
                    mylist.AddVietMean(viet);
                    englishmean = String.Empty;
                    type = String.Empty;
                    viet = String.Empty;
                    int vitribatdau = line.IndexOf('/');
                    if (vitribatdau > -1)
                    {
                        int vitriketthuc = line.LastIndexOf('/');
                        englishmean = line.Substring(1, vitribatdau - 1);
                        englishmean = englishmean.Trim();
                        englishmean = englishmean.ToLower();
                        type = line.Substring(vitribatdau, vitriketthuc - vitribatdau + 1);

                        if (viet.Contains("-")) viet.Replace("-", "");
                        mylist.AddLast(englishmean, type, viet);
                    }
                    else
                    {
                        englishmean = line.Substring(1);
                        mylist.AddLast(englishmean, type, viet);
                    }
                }
                else
                {
                    string v = string.Concat(viet, line);
                    v = String.Concat(v, "\n");
                    viet = v;
                }
            }
            mylist.AddVietMean(viet);
            rd.Close();
           
            dictionary.initHashtable();
            Node temp = mylist.Head;
            dictionary.InsertWord(temp.english, temp.type, temp.meaning);
            while (temp != null)
            {
                dictionary.InsertWord(temp.english, temp.type, temp.meaning);

                temp = temp.Next;
            }

            dictionary.Kitu();

        }
        private void setWordOfTheDay()
        {
            Console.OutputEncoding = Encoding.UTF8;
            txtWordoftheday.Text = "Word of the day: take off" +
                "\nNếu máy bay, chim hoặc côn trùng cất cánh, nó sẽ rời khỏi mặt đất và bắt đầu bay." +
                "\n*The plane took off at 8.30 a.m.";
        }
        private void button2_Click(object sender, EventArgs e)//button sua
        {
            string eng = txtEnglish.Text;
            string type = txtType.Text;
            string meaning = txtMeaning.Text;
            if (txtEnglish.Text == "" || txtMeaning.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
            else
            {
                Node p = dictionary.UpdateWord(eng, type, meaning); ;                        
                if (p != null)
                {                   
                    MessageBox.Show("Update thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy từ cần sửa!");
                }
            }
                
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if(txtEnglish.Text == "" || txtMeaning.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
            else
            {
                string eng = txtEnglish.Text;
                string type = txtType.Text;
                string meaning = txtMeaning.Text;
                Node p = dictionary.SearchWord(eng);
                if(p == null)
                {
                    dictionary.InsertWord(eng, type, meaning);
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Đã có từ này trong từ điển! Hãy xóa hoặc chỉnh sửa.");
                }
            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string s1 = txtSearch.Text;
            string s  = s1.ToLower();
            
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ cần tìm!");
            }
            else
            {
                Node p = dictionary.searchInHash(s);
                if (p != null)
                {

                    txtEnglish.Text = p.english;
                    txtType.Text = p.type;
                    txtMeaning.Text = p.meaning;
                }
                else
                {
                    MessageBox.Show("Không tồn tại từ cần tìm!");
                }
            }
            
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtEnglish.Text = "";
            txtMeaning.Text = "";
            txtType.Text = "";
        }

        
    }
}
