using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfBelong
{
    public struct RectangleF
    {
        private float pX, pY, pWidth, pHeigth;

        public RectangleF(float nX, float nY, float nWidth, float nHeigth)
        {
            pX = nX;
            pY = nY;
            pWidth = nWidth;
            pHeigth = nHeigth;
        }

        public float X
        {
            get { return pX;}
        }

        public float Y
        {
            get { return pY; }
        }

        public float Width
        {
            get { return pWidth; }
        }

        public float Height
        {
            get { return pHeigth; }
        }
    }
    public struct Points
    {
        private float pX, pY;

        public Points(float nX, float nY)
        {
            pX = nX;
            pY = nY;
        }

        public float X
        {
            get { return pX; }
            set { pX = value;}
        }

        public float Y
        {
            get { return pY; }
            set { pY = value; }
        }
    }

    public struct Return_Information
    {
        private string pMessage;
        private float pX, pY;
        private bool pGood;

        public Return_Information(string newMessage, float nX, float nY, bool nGood)
        {
            pMessage = newMessage;
            pX = nX;
            pY = nY;
            pGood = nGood;
        }

        public bool Good
        {
            get { return pGood; }
        }

        public string Message
        {
            get { return pMessage; }
        }

        public float X
        {
            get { return pX; }
        }

        public float Y
        {
            get { return pY; }
        }
    }
}
