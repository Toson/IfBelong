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

namespace IfBelong
{
    public partial class Form1 : Form
    {
        //////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////

        private int x_circl = 300,//Ширина квадрата, в который вписан круг
            y_circl = 300,//Высота квадрата, в который вписан круг
            x_TL = 50,//Кординаты левой
            y_TL = 50,//верхней точки квадрата
            R,//Радиус
            Step = 15;//Шаг сетки
        private Point Pnt = new Point(-20, -20);//Координаты точки
        private Point Pnt_Screen = new Point(-20, -20);//Экранные координаты точки
        private Point Pnt_Cntr = new Point(0, 0);//Центр окружности
        private Rectangle Border_Rect;//Границы
        private String Results = "";//Последний результат

        /////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Конструктор
        public Form1()
        {
            InitializeComponent();
            PB_Paint.Paint += PB_Paint_Paint;

            R = x_circl / (2*Step);//Считаем радиус
            Border_Rect = new Rectangle(PB_Paint.Width / 2, (PB_Paint.Height / 2) - Step, PB_Paint.Width, PB_Paint.Height);//Указываем область, в которую необходимо попасть
        }

        //Перерисовка PictureBox-a
        void PB_Paint_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Выбираем режим сглаживания
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Заполняем ограничивающий прямоугольник
            g.FillRectangle(Brushes.SkyBlue, Border_Rect);
            //Отрезаем ненужную часть круга
            g.FillEllipse(Brushes.White, (float)x_TL, (float)y_TL, (float)x_circl, (float)y_circl);

            Pen P = new Pen(Color.Red, 2.0f);
            //Рисуем круг
            g.DrawEllipse(P, (float)x_TL, (float)y_TL, (float)x_circl, (float)y_circl);
            //Рисуем ограничивающую линию
            g.DrawLine(P, 0, PB_Paint.Height / 2 - Step, PB_Paint.Width, PB_Paint.Height / 2 - Step);

            P.Color = Color.Black;
            P.Width = 1f;
            //Рисуем оси координат
            g.DrawLine(P, 0, PB_Paint.Height / 2, PB_Paint.Width, PB_Paint.Height / 2);
            g.DrawLine(P, PB_Paint.Width / 2, 0, PB_Paint.Width / 2, PB_Paint.Height);

            P.Color = Color.DarkBlue;
            P.Width = 2f;
            ///Рисуем шкалу на осях
            #region Шкала
            for (int i = PB_Paint.Width / 2, j = PB_Paint.Height / 2, k = 0; i <= PB_Paint.Width && j <= PB_Paint.Height; i += Step, j += Step, k++)
            {
                g.DrawEllipse(P, (float)(i - 2), (float)(PB_Paint.Height / 2 - 2), 4, 4);

                if(k>0)
                    g.DrawString(k.ToString(), new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, (float)(i-3), (float)(PB_Paint.Height / 2 + 8));

                g.DrawEllipse(P, (float)(PB_Paint.Width / 2 - 2), (float)(j - 2), 4, 4);

                if (k > 0)
                    g.DrawString("-"+k.ToString(), new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, (float)(PB_Paint.Width / 2) - 18, (float)(j-7));
            }

            for (int i = (PB_Paint.Width / 2) - Step, j = (PB_Paint.Height / 2) - Step, k = 1; i >= 0 && j >= 0; i -= Step, j -= Step, k++)
            {
                g.DrawEllipse(P, (float)(i - 2), (float)(PB_Paint.Height / 2 - 2), 4, 4);
                g.DrawString("-" + k.ToString(), new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, (float)(i - 7), (float)(PB_Paint.Height / 2 - 18));

                g.DrawEllipse(P, (float)(PB_Paint.Width / 2 - 2), (float)(j - 2), 4, 4);
                g.DrawString(k.ToString(), new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, (float)(PB_Paint.Width / 2) + 8, (float)(j - 7));
            }
            #endregion
            ///
            P.Color = Color.Green;
            P.Width = 4f;
            //Рисуем точку
            g.DrawEllipse(P, Pnt_Screen.X - 2, Pnt_Screen.Y - 2, 4, 4); 

        }

        private void button_check_Click(object sender, EventArgs e)
        {
            Pnt.X = (int)numeric_X.Value;//Узнаем
            Pnt.Y = (int)numeric_Y.Value;//Точку
            Results = Determine.Determine_Attachment(Pnt, Pnt_Cntr, R, new Rectangle(0, 1, 14, -14));//Определяем принадлежность

            Pnt_Screen = TranslateCoords(Pnt);//Переводим координаты точки для отображения на экране
            
            PB_Paint.Invalidate();

            MessageBox.Show(Results);//Показываем результат
        }

        //Переводим в экранную систему координат
        private Point TranslateCoords(Point Pnt_Tmp)
        {
            if (Pnt_Tmp.X == 0)
            {
                Pnt_Tmp.X = PB_Paint.Width / 2;
            }
            else if (Pnt_Tmp.X > 0)
            {
                Pnt_Tmp.X = (PB_Paint.Width / 2) + (Math.Abs(Pnt_Tmp.X) * Step);
            }
            else if (Pnt_Tmp.X < 0)
            {
                Pnt_Tmp.X = (PB_Paint.Width / 2) - (Math.Abs(Pnt_Tmp.X) * Step);
            }

            if (Pnt_Tmp.Y == 0)
            {
                Pnt_Tmp.Y = PB_Paint.Height / 2;
            }
            else if (Pnt_Tmp.Y < 0)
            {
                Pnt_Tmp.Y = (PB_Paint.Height / 2) + (Math.Abs(Pnt_Tmp.Y) * Step);
            }
            else if (Pnt_Tmp.Y > 0)
            {
                Pnt_Tmp.Y = (PB_Paint.Height / 2) - (Math.Abs(Pnt_Tmp.Y) * Step);
            }

            return Pnt_Tmp;

        }

        //Обрабатываем нажатие на кнопку "Открыть..."
        private void Open_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файл программы 'Определятор 3000'(*.det)|*.det";
            dialog.CheckFileExists = true; 
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(Open_Coords.OpenData(dialog.FileName));
            }
        }

        //Обрабатываем нажатие на кнопку "Сохранить..."
        private void Save_Button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Файл программы 'Определятор 3000'(*.det)|*.det";
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (Save_Coords.SaveData(dialog.FileName, Results, Pnt))
                {
                    MessageBox.Show("Сохранено.");
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить.\nВозможно, что вы еще не получили\nникаких результатов.");
                }
            }
        }
    }
}
