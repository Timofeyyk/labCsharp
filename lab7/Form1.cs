using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Itnit> lItnit = new List<Itnit>
        {
            new Itnit(){Id=1,Name="Прикладная математика и информатика"},
            new Itnit(){Id=2,Name="Математика и компьютерные науки"},
            new Itnit(){Id=3,Name="Физика"},
            new Itnit(){Id=4,Name="Радиофизика"},
            new Itnit(){Id=5,Name="Прикладная информатика"},
            new Itnit(){Id=6,Name="Информационная безопасность"},
            new Itnit(){Id=7,Name="Техносферная безопасность"},
            new Itnit(){Id=8,Name="Профессиональное обучение"},
            new Itnit(){Id=9,Name="Педагогическое образование "},
        };
        List<Ui> lUi = new List<Ui>
        {
            new Ui(){Id=0,Name="Юриспруденция"}
        };
        class Institut 
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Itnit : Institut { }
        class Ui:Institut { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                
                case 9:
                    {
                        comboBox2.DataSource = lItnit;
                        comboBox2.ValueMember= "Id";
                        comboBox2.DisplayMember= "Name";
                        break;
                    }
                case 11: 
                    {
                        comboBox2.DataSource = lUi;
                        comboBox2.ValueMember = "Id";
                        comboBox2.DisplayMember = "Name";
                        break;
                    }

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try {
                if (dataGridView1.Rows.Count==0 )
                {
                    throw new Exception();
                }
                else {
                    comboBox3.Text = "";
                    cueTextBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    cueTextBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    comboBox1.SelectedText = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    comboBox2.SelectedText = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    comboBox3.SelectedText = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка! Выделена пустая строка"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                if (cueTextBox1.Text != "" && cueTextBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (cueTextBox2.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                        {
                            throw new Exception("Номер зачетной книжки повторяется");
                        }
                    }
                    if (cueTextBox2.Text.Length != 8)
                    {
                        throw new Exception("Неправильный формат зачетной книжки");
                    }
                    string group = string.Format("{0:####-####}", comboBox3.Text);
                    if (group.Length <7) { throw new Exception("Введите полное название группы"); }
                    else
                    {
                        for (int i = 0; i < group.Length; i++)
                        {
                            if (!Char.IsDigit(group[i]) && i < 3)
                            {
                                throw new Exception("Неправильный формат группы");
                            }
                            if ((group[i]!='б'&& group[i] != 'а') && i == 3)
                            {
                                throw new Exception("Неправильный формат группы");
                            }
                            if (!Char.IsLetter(group[i]) && i > 4)
                            {
                                throw new Exception("Неправильный формат группы");
                            }
                        }
                    }
                        dataGridView1.Rows.Add(cueTextBox2.Text, cueTextBox1.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Value, group);
                    
                }
                else { throw new Exception("Заполните все поля"); }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count!=0)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка! Выделена незаполненная строка"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    int flag = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (cueTextBox2.Text == dataGridView1.Rows[i].Cells[0].Value.ToString() && dataGridView1.Rows[i].Cells[0].Value != dataGridView1.CurrentRow.Cells[0].Value)
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0) {
                        if (cueTextBox1.Text != "" && cueTextBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                        {
                            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                            string group = string.Format("{0:####-####}", comboBox3.Text);
                            dataGridView1.Rows.Add(cueTextBox2.Text, cueTextBox1.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Value, group);
                        }
                        else { MessageBox.Show("Строка не выбрана", "Ошибка!"); } 
                    }
                    else { MessageBox.Show("Такой номер книжки уже есть", "Предупреждение"); }
                }
            }
            catch(Exception ex) { MessageBox.Show("Строка не выбрана", "Ошибка!"); }
        }

        private void cueTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && cueTextBox2.Text.Length<8 || Char.IsControl(e.KeyChar))
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cueTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar)|| Char.IsControl(e.KeyChar))
            {
            }

            else
            {
                e.Handled = true;
            }
        }
    }
}
