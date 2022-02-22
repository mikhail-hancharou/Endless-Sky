using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    class Draw
    {
        public Draw() { }

        public void drawAll(IDraw obj1, IDraw obj2, IDraw obj3)
        {
            obj1.draw();
            obj2.draw();
            obj3.draw();
            //GL.Viewport(0, 0, window.Width, window.Height);
        }
    }
}
