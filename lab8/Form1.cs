using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;



namespace lab2
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                using (TextFieldParser tfp = new TextFieldParser(openFileDialog1.FileName))
                {

                    tfp.TextFieldType = FieldType.Delimited;
                    tfp.SetDelimiters("%");

                    while (!tfp.EndOfData)
                    {
                        string[] data = tfp.ReadFields();

                        dataGridView1.Rows.Add(data);

                    }
                }
            }
        }

        private void cSVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                                if (j < dataGridView1.ColumnCount - 1) sw.Write("%"); // не пишем пробел после последней колонки
                            }
                            sw.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void xNLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var col = new Dictionary<int, string>()
            {
                { 0, "fio"},
                { 1, "departament"},
                { 2, "power"},
                { 3, "lang"},
                { 4, "ide"},
                { 5, "tech"}
            };
            Object[] row = new object[6];
            String name="";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                
                using (XmlTextReader reader = new XmlTextReader(openFileDialog2.FileName))
                {
                    try
                    {

                        while (reader.Read())
                        {

                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: 
                                    name = reader.Name;
                                    break;
                                case XmlNodeType.Text: 
                                    foreach (var key in col.Keys)
                                    {
                                        if (col[key] == name)
                                        {
                                            row[key] = reader.Value;

                                            if (col[key] == "lang") dataGridView1.Rows.Add(row);
                                        }
                                    }
                                    break;
                                


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                
            }
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument xmlDoc = new XDocument();
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {

                    XElement cafedraElem = new XElement("Cafedra");

                    for (int i = 0; i < dataGridView1.RowCount-1; i++)
                    {
                        XElement personElem = new XElement("person");

                        XElement fioElem = new XElement("fio", dataGridView1[0, i].Value.ToString());
                        XElement departamentElem = new XElement("departament", dataGridView1[1, i].Value.ToString());
                        XElement powerElem = new XElement("power", dataGridView1[2, i].Value.ToString());
                        XElement techElem = new XElement("tech", dataGridView1[5, i].Value.ToString());
                        XElement ideElem = new XElement("ide", dataGridView1[4, i].Value.ToString());
                        XElement langElem = new XElement("lang", dataGridView1[3, i].Value.ToString());

                        personElem.Add(fioElem);
                        personElem.Add(departamentElem);
                        personElem.Add(powerElem);
                        personElem.Add(techElem);
                        personElem.Add(ideElem);
                        personElem.Add(langElem);

                        cafedraElem.Add(personElem);
                    }

                    xmlDoc.Add(cafedraElem);
                    xmlDoc.Save(saveFileDialog2.FileName);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Object[] row = new Object[6];
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    JsonTextReader reader = new JsonTextReader(new StreamReader(openFileDialog3.FileName));
                    reader.SupportMultipleContent = true;
                    while (reader.Read())
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        Specialists specialist = serializer.Deserialize<Specialists>(reader);
                        row[0]=specialist.Fio;
                        row[1]=specialist.Department;
                        row[2]=specialist.Power;
                        row[5]=specialist.Tech;
                        row[4]=specialist.Ide;
                        row[3]=specialist.Lang;
                        dataGridView1.Rows.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                
            }
        }

        private void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog3.FileName, String.Empty);
                    for (int i = 0; i < dataGridView1.RowCount-1; i++)
                    {
                        Specialists specialist = new Specialists(dataGridView1[0,i].Value.ToString(), dataGridView1[1,i].Value.ToString(), dataGridView1[2,i].Value.ToString(), dataGridView1[5,i].Value.ToString(), dataGridView1[4,i].Value.ToString(), dataGridView1[3,i].Value.ToString());
                        string JsonObject=JsonConvert.SerializeObject(specialist);
                        File.AppendAllText(saveFileDialog3.FileName, JsonObject);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }


            }
        }

        


        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.Text= string.Empty;
            textBox3.Text= string.Empty;
            textBox5.Text= string.Empty;
            textBox6.Text= string.Empty;
            textBox7.Text= string.Empty;
            comboBox1.Text= string.Empty;
        }
        public void filter(String str,int col) 
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                
                dataGridView1.Rows[i].Visible = false;
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }

            var values = str.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                foreach (string value in values)
                {
                    var row = dataGridView1.Rows[i];

                    if (row.Cells[col].Value.ToString().Contains(value))
                    {
                        row.Visible = true;
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            filter(textBox2.Text, 0);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            filter(textBox3.Text, 1);
        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            filter(textBox5.Text, 3);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            filter(textBox6.Text, 4);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            filter(textBox7.Text, 5);
        }


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            filter(comboBox1.Text, 2);
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    public class Specialists
    {
        public String Fio { get; set; }
        public String Department { get; set; }
        public String Power { get; set; }
        public String Tech { get; set; }
        public String Ide { get; set; }
        public String Lang { get; set; }
        public Specialists( String Fio, String Department, String Power, String Tech, String Ide, String Lang)
        {
            this.Fio = Fio;
            this.Department = Department;
            this.Power = Power;
            this.Tech = Tech;
            this.Ide = Ide;
            this.Lang = Lang;
        }


    }
}
