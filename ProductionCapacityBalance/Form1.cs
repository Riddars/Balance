using ProductionCapacityBalance.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionCapacityBalance
{
    public partial class Form1 : Form
    {
        int testsNumber;
        int testingHours;
        List<double> haffStaffEveryHour;
        List<double> haffStaffEveryHourAvg;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear(); //очищается график с формы на случай если он был не пуст


            testsNumber = Convert.ToInt32(textBox6.Text);//количество тестов для усредения
            testingHours = Convert.ToInt32(textBox5.Text); //часы работы системы для теста
            haffStaffEveryHour =new List<double>(new double[testingHours]); //вспомогательный лист
                                                                            //На основании него в дальнейшем строится график    
            Random random = new Random();
            
            Model model = new Model(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox4.Text), random, testingHours); //инициализация модели

            for (int i = 0; i < testsNumber; i++) //цикл прогонки заданое количество раз
            {
                model.MakeOneDraw(); //проводится розыгрыш
                for (int j = 0; j < testingHours; j++)
                {
                    haffStaffEveryHour[j] += model.halfStuffEachHour[j]; //результаты розыгрыша собираются в лист для нахождения среднего арифметического
                }

            }
            RefreshCharts(); //обновляется график на форме
        }
        void RefreshCharts() 
        { //Вывод графика со средними значениями полуфабрикатов на складе каждый час
            for (int i = 0; i < testingHours; i++) 
            {
                chart1.Series["Series1"].Points.AddY(haffStaffEveryHour[i]/testsNumber);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
