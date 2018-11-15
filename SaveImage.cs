using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ParseProject
{
    [Serializable]
    public class SaveImage
    {
        public Bitmap bitmap { get; private set; }

        public SaveImage(Bitmap _bitmap)
        {
            bitmap = _bitmap;
        }
        
    }
}
