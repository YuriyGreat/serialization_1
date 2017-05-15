using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace seri2
{
    public partial class Form1 : Form
    {
        List<Engine> engineList = new List<Engine>();
        List<TextBox> textBoxList = new List<TextBox>();
        List<Label> labelList = new List<Label>();
        List<Engine> engineObjects = new List<Engine>();

        public Form1()
        {
            InitializeComponent();
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox7);
            labelList.Add(label1);
            labelList.Add(label2);
            labelList.Add(label3);
            labelList.Add(label4);
            labelList.Add(label5);
            labelList.Add(label6);
            labelList.Add(label7);
            engineObjects.Add(new VType());
            engineObjects.Add(new Straight());
            engineObjects.Add(new Opposite());
            engineObjects.Add(new Rotor());
            engineObjects.Add(new Reactive());
            engineObjects.Add(new Electric());
            comboBox2.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendCaracteristicsToForm(engineList[comboBox1.SelectedIndex]);
            button3.Enabled = true;
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Serialize();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            Deserialize();
        }

        private void Serialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("seri.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, engineList);
                MessageBox.Show("список сериализован");
            }
        }

        private void Deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("seri.dat", FileMode.OpenOrCreate))
            {
                engineList = (List<Engine>)formatter.Deserialize(fs);
                MessageBox.Show("список десериализован");
            }
            foreach (Engine engine in engineList)
            {
                comboBox1.Items.Add(engine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            engineList.RemoveAt(comboBox1.SelectedIndex);
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex); 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            ClearAllFields();
            string[] specificationsArray = engineObjects[comboBox2.SelectedIndex].GetAllFields();
            for (int i=0; i< specificationsArray.Length; i++)
            {
                textBoxList[i].Visible = true;
                labelList[i].Text = specificationsArray[i];
            }
        }

        private void ClearAllFields()
        {
            for (int i=0; i < textBoxList.Count; i++)
            {
                labelList[i].Text = "";
                textBoxList[i].Visible = false;
                textBoxList[i].Text = "";
            }
        }

        private string[] MakeCaracteristicsArray()
        {
            string[] caracteristics = null;
            int length = 0;
            foreach (TextBox textbox in textBoxList)
            {
                if (textbox.Visible)
                {
                    length++;
                    Array.Resize<string>(ref caracteristics, length);
                    caracteristics[length - 1] = textbox.Text;
                }
            }
            return caracteristics;
        }

        private void SendCaracteristicsToForm(Engine engine)
        {
            ClearAllFields();
            string[] infoArray = engine.GetAllFields();
            string[] caracteristics = engine.GetCaracteristics();
            for (int i = 0; i < infoArray.Length; i++)
            {
                textBoxList[i].Visible = true;
                textBoxList[i].Text = caracteristics[i];
                labelList[i].Text = infoArray[i];
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Engine tempNewObj = (Engine)engineObjects[comboBox2.SelectedIndex].Clone();
            string[] caracteristics = MakeCaracteristicsArray();
            if (!tempNewObj.SetCaracteristics(caracteristics))
            {
                MessageBox.Show("неверные поля");
                return;
            }
            engineList.Add(tempNewObj);
            comboBox1.Items.Add(tempNewObj);
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            string[] caracteristics = MakeCaracteristicsArray();
            if (!engineList[comboBox1.SelectedIndex].SetCaracteristics(caracteristics))
            {
                MessageBox.Show("неверные поля");
                return;
            }
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
