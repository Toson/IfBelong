using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IfBelong
{
    public static class Determine
    {
        private static string NotBelong = "Вне области", Belong = "Внутри области", OnEdge = "На границе";

        /// <summary>
        /// Определить принадлежность заштрихованной области
        /// </summary>
        /// <param name="Pnt_Chk">координаты точки</param>
        /// <param name="Pnt_Cntr">Координата центра окружности</param>
        /// <param name="R">Радиус окружности</param>
        /// <param name="Rect">Ограничивающий прямоугольник</param>
        /// <returns>Результат</returns>
        /// 
        public static string Determine_Attachment(Points Pnt_Chk, Points Pnt_Cntr, float R, RectangleF Rect)
        {
            if (Rect_Contain(Rect, Pnt_Chk))//Если ограничивающий прямоугольник включает нашу точку
            {
                float In_Or_Out = Circle_Contain(Pnt_Chk, Pnt_Cntr);//Узнаем, находится ли точка в круге

                if (In_Or_Out - R*R <= 0.02f && In_Or_Out - R*R >= -0.02f)
                {
                    In_Or_Out = R*R;
                }

                if (In_Or_Out < R*R)//Если находится
                {
                    return NotBelong;
                }
                else if (In_Or_Out == R*R)//Если на границе круга
                {
                    return OnEdge;
                }
                else
                {
                    if (Rect_Edge_Contain(Rect, Pnt_Chk))//Если на границе прямоугольника
                        return OnEdge;
                    else
                        return Belong;
                }
            }
            else
            {
                return NotBelong;
            }
        }

        //Проверяет, находится ли в окружности точка
        private static float Circle_Contain(Points Pnt_Chk, Points Pnt_Cntr)
        {
            return ((Pnt_Chk.Y - Pnt_Cntr.Y) * (Pnt_Chk.Y - Pnt_Cntr.Y) + (Pnt_Chk.X - Pnt_Cntr.X) * (Pnt_Chk.X - Pnt_Cntr.X));
        }

        //Проверяет, находится ли в квадрате точка
        private static bool Rect_Contain(RectangleF Rect, Points Pnt_Chk)
        {
            float X = Pnt_Chk.X;
            float Y = Pnt_Chk.Y;

            if (X >= Rect.X && Y <= Rect.Y)
            {
                if (X <= Rect.Width && Y >= Rect.Height)
                    return true;
            }

            return false;
        }

        //Проверяет, находится ли на границе квадрата точка
        private static bool Rect_Edge_Contain(RectangleF Rect, Points Pnt_Chk)
        {
            float X = Pnt_Chk.X;
            float Y = Pnt_Chk.Y;

            if (X >= Rect.X && X<=Rect.Width && (Y == Rect.Y || Y == Rect.Height))
            {
                return true;
            }
            else if (Y <= Rect.Y && Y >= Rect.Height && (X == Rect.X || X == Rect.Width))
            {
                return true;
            }

            return false;
        }

    }
}
