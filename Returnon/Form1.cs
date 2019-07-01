using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Returnon
{
    public partial class Form1 : Form
    {
        public double SS;
        public double CP;
        public double SA;
        public double SK;
        public double f;
        public double ROM;
        public double ROE;
        public double ROA;

        public bool C1 = false;
        public bool C2 = false;

        public bool C5 = false;
      
        string attr;
      
        bool ended = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            C1 = false;
            C2 = false;
            
            
            C5 = false;
           

            
          
            ended = false;
            SS = Convert.ToDouble(SSBox.Text);//капитал
            CP = Convert.ToDouble(CPBox.Text);//риск в пунктах
            SA = Convert.ToDouble(SABox.Text);//риск в % от капитала * 0,01
            SK = Convert.ToDouble(SKBox.Text);//стоимость пункта для одного контракта
            
            
            ROM = (SS * (SA *0.01) )/( CP * SK);
            textBox1.Text = ROM.ToString();
            ROA = CP * SK;
            f = (ROA * SA) / SS;
            textBox3.Text = ROA.ToString();
            attr = "Объем позиции";
            while (!ended)
            {
                Cycle(attr);
            }
        }

        public void Cycle(string atr)
        {
            switch (atr)
            {
                case "Объем позиции":
                    if (SA > f)
                    {
                        C1 = true;
                        richTextBox1.Text = "Если выход бизнеса на фондовый рынок окажется неудачным, размер убытка составит: " + ROA +" что равняется " + f + " % от капитала.Из-за округления объема позиции возникла погрешность, тем не менее, видно, что формула позволяет «зашить» в сделку заранее известный и допустимый уровень риска.";
                    }
                    else
                    {
                        C2 = true;
                        richTextBox1.Text = "Выход на фондовый рынок не возможен.";

                    }
                    attr = "ROE";
                    break;
       
                
                default:
                    ended = true;
                    break;
                    
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
