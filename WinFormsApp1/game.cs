using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKAnimation
{
    public class game
    {
        double theta = 0.0;
        GameWindow window;

        [Obsolete]
        public game(GameWindow window)
        {
            this.window = window;
            Start();
        }

        [Obsolete]
        void Start()
        {
            window.Load += Loaded;
            window.Resize += Resize;
            window.RenderFrame += RenderF;
            window.Run(1.0 / 60.0);
        }

        void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(1f, 1f, 1f, 1f);
        }

        [Obsolete]
        void RenderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Rotate(theta, 0.0, 0.0, 1.0);
            GL.Begin(BeginMode.Quads);

            GL.Color3(0.8, 0.0, 0.0);
            GL.Vertex2(30.0, 30.0);
            GL.Color3(0.1, 0.0, 0.0);
            GL.Vertex2(-30.0, 30.0);
            GL.Color3(0.0, 0.5, 0.5);
            GL.Vertex2(-30.0, -30.0);
            GL.Color3(0.0, 0.0, 0.5);
            GL.Vertex2(30.0, -30.0);

            GL.End();
            window.SwapBuffers();

            theta += 0.5;
            if (theta > 360.0)
                theta -= 360.0;
        }

        void Resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}