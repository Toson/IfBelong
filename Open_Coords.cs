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
    static class Open_Coords
    {
        
        private static Return_Information RI;
        /// <summary>
        /// Открыть ранее сохраненный результат
        /// </summary>
        /// <returns></returns>
        public static Return_Information OpenData(String Path)
        {
            String Result = "";
            String [] Tmp = new String[2];
            float [] Tmp32 = new float [2];
            StreamReader SR = null;
            try
            {              
                 if (Path.Length >= 5)//Если длина пути соответствует минимально допустимой(Например, "D://1")
                     SR = new StreamReader(Path);
                 else
                 {
                     RI = new Return_Information("Что-то не так с путем до файла.", -10, -10, false);
                     return RI;
                 }

                 Result += SR.ReadLine();//Читаем результат

                 if (Result.Length < 10)//Если Result не содержит что-то похожее по длине на стандартные сообщения, генерируемые программой
                 {
                     SR.Close();
                     RI = new Return_Information("Файл плохой, дайте хороший!", -10, -10, false);
                     return RI;
                 }

                 Result += "\nКоординаты (x ; y): ";

                 for (int i = 0; i < 2; i++)//Проверяем
                 {
                     Tmp[i] += SR.ReadLine();
                     Tmp32[i] = (float)Convert.ToDouble(Tmp[i]);
                 }

                 Result += Tmp[0] + " ; " + Tmp[1];

                 RI = new Return_Information(Result, Tmp32[0], Tmp32[1], true);

                 SR.Close();
                return RI;
            }
            catch (System.Exception)
            {
                if (SR != null)
                    SR.Close();
                return RI = new Return_Information("Файл плохой, дайте хороший!", -10, -10, false);
            }
        }
    }
}