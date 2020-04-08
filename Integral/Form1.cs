using System;
using System.Windows.Forms;
using System.IO;


namespace Integral
{
    
    public partial class Form1 : Form
    {
        About f;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (f == null || f.IsDisposed)
            {
                f = new About();
                f.Show();
            }
            else f.Activate();



        }

        public void SetResult()
        {
            int a = Convert.ToInt32(numericUpDown1.Value);
            try
            {
                if (Int32.Parse(EnterN.Text) == 0)
                {
                    Result.Text = "0";
                }
                else
                    Result.Text = Math.Round(Integral.integFT(double.Parse(EnterA.Text), double.Parse(EnterB.Text), Int32.Parse(EnterN.Text)), a).ToString();
            }
            catch (FormatException)
            {
                if (EnterN.Text == String.Empty || EnterA.Text == String.Empty || EnterB.Text == String.Empty)
                    MessageBox.Show("Не все данные введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Слишком большие числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        public string GetEnterA()
        {

            string a = EnterA.Text.ToString();

            return a;
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void закрытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

            SetResult();

        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {


            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "txt files (*.txt)|*.txt";
            s.FilterIndex = 2;
            s.RestoreDirectory = true;


            if (s.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = s.FileName;
            File.AppendAllText(filename, Result.Text + " ");
            File.AppendAllText(filename, EnterA.Text + " ");
            File.AppendAllText(filename, EnterB.Text + " ");
            File.AppendAllText(filename, EnterN.Text + " ");
            MessageBox.Show("Файл сохранен", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.None);
            

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "txt files (*.txt)|*.txt";
            o.FilterIndex = 2;
            o.RestoreDirectory = true;

            if (o.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = o.FileName;
            string filetext = File.ReadAllText(filename);

            string[] arr = filetext.Split(new char[] { ' ' }, 4);

            string entA = arr[1];
            string entB = arr[2];
            string entN = arr[3];
            string entResult = arr[0];
            
            Result.Text = entResult;
            EnterA.Text = entA;
            EnterB.Text = entB;
            EnterN.Text = entN;



            MessageBox.Show("Файл загружен", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.None);
            
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveMenuItem_Click(sender, e);

        }

        private void загрузитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            загрузитьToolStripMenuItem_Click(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}