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
        /// <summary>
        /// Открыть ранее сохраненный результат
        /// </summary>
        /// <returns></returns>
        public static String OpenData(String Path)
        {
            String Result = "";
            String [] Tmp = new String[2];
            int Tmp32 = 0;
            StreamReader SR = null;
            try
            {              
                 if (Path.Length >= 5)//Если длина пути соответствует минимально допустимой(Например, "D://1")
                     SR = new StreamReader(Path);
                 else
                 {
                     return "Что-то не так с путем до файла.";
                 }

                 Result += SR.ReadLine();//Читаем результат

                 if (Result.Length < 10)//Если Result не содержит что-то похожее по длине на стандартные сообщения, генерируемые программой
                 {
                     SR.Close();
                     return "Файл плохой, дайте хороший!";
                 }

                 Result += "\nКоординаты (x ; y): ";

                 for (int i = 0; i < 2; i++)//Проверяем
                 {
                     Tmp[i] += SR.ReadLine();
                     Tmp32 = Convert.ToInt32(Tmp[i]);
                 }

                 Result += Tmp[0] + " ; " + Tmp[1];

                 SR.Close();
                return Result;
            }
            catch (System.Exception)
            {
                if (SR != null)
                    SR.Close();
                return "Файл плохой, дайте хороший!";
            }
        }
    }
}