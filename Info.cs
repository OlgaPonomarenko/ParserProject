using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ParseProject
{
    class Info
    {
    }

    class LineInOutX
    {
        public float startOfLineInX { get; set; }
        public float endOfLineInX { get; set; }
        public float startOfLineOutX { get; set; }
        public float endOfLineOutX { get; set; }

        public LineInOutX(float _startOfLineInX, float _endOfLineInX, 
                                    float _startOfLineOutX, float _endOfLineOutX)
        {
            startOfLineInX = _startOfLineInX;
            endOfLineInX = _endOfLineInX;
            startOfLineOutX = _startOfLineOutX;
            endOfLineOutX = _endOfLineOutX;
        }
    }

    class GateNameLocation
    {
        public Gate thisGate = new Gate();
       
        Rectangle gateNameLocation = new Rectangle();
        public string textAboutGateNameLocation = "";


        public GateNameLocation(Gate _gate, int _gateNameStartUpX, int _gateNameStartUpY, float _textWidth, float _textHeigh)
        {
            thisGate = _gate;
            
            gateNameLocation.X = _gateNameStartUpX;
            gateNameLocation.Y = _gateNameStartUpY;
            gateNameLocation.Width = (int)_textWidth;
            gateNameLocation.Height = (int)_textHeigh;

 
            textAboutGateNameLocation += "\r\ngateNameLocation.X = " + gateNameLocation.X +
                            "\n gateNameLocation.Y = " + gateNameLocation.Y +
                            "\r\ngateNameLocation.Width = " + gateNameLocation.Width +
                            "\ngateNameLocation.Height = " + gateNameLocation.Height;
        }


        public bool ContainPointInRect(Point _point)
        {

            bool isContain = false;
            if (gateNameLocation.Contains(_point))
                isContain = true;
            return isContain;
        }
    }





}
