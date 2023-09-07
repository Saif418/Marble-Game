using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saif_assignment_2
{
    class Button2D : Button
    {
        public int row;
        public int column;


        private int rowProp;

        public int Row
        {
            get
            {
                return rowProp;
            }
            set
            {
                rowProp = value;
            }
        }
    }
}
