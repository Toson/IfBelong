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
    static class Save_Coords
    {
        /// <summary>
        /// Сохранить результат в файл
        /// </summary>
        /// <param name="Path">Путь до файла</param>
        /// <param name="Result">Результат</param>
        /// <param name="Pnt_Coords">Координаты точки</param>
        /// <returns></returns>
        public static bool SaveData(String Path, String Result, Points Pnt_Coords)
        {
            StreamWriter SW = null;
            try
            {
                if(Path.Length >= 5)//Если длина пути соответствует минимально допустимой(Например, "D://1")
                    SW = new StreamWriter(Path, false);
                else
                    return false;

                if (Result.Length >= 10)//Если Result содержит что-то похожее по длине на стандартные сообщения, генерируемые программой
                    SW.Write(Result);//Пишем результат
                else
                {
                    SW.Close();//Закрываем поток
                    return false;
                }

                SW.WriteLine();
                SW.Write(Pnt_Coords.X.ToString());//Пишем координату по X
                SW.WriteLine();
                SW.Write(Pnt_Coords.Y.ToString());//Пишем координату по Y

                SW.Flush();//Вызываем запись

                SW.Close();//Закрываем поток

                return true;
            }
            catch (System.Exception)
            {
                if (SW != null)
                    SW.Close();
                return false;
            }

        }
    }
}
