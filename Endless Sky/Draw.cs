﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    class Draw
    {
        public Draw() { }

        public void drawAll(IDraw obj1, IDraw obj2)
        {
            obj1.draw();
            obj2.draw();
            //GL.Viewport(0, 0, window.Width, window.Height);

            GL.PointSize(8);
            GL.Begin(BeginMode.Points);
            GL.Vertex2(0, 0);
            GL.End();
        }

        public void TestDraw(IDraw obj)
        {
            obj.draw();
        }
    }
}
