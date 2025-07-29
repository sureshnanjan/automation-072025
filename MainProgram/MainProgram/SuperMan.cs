using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    public class SuperMan
    {

        public SuperMan() { }

        public void Play(Action subtitle) {
            // Play Movie 
            subtitle();

        }
    }
}
