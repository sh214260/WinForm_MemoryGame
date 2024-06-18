using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstGui
{
    public class Card
    {
        public Image Image { get; private set; }
        public bool IsMatched { get; private set; }

        public Card(Image image)
        {
            Image = image;
            IsMatched = false;
        }

        public void Flip()
        {
            IsMatched = !IsMatched; 
        }

    }

}
