using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

using My_Tests.Shaders;
using System;

namespace My_Tests
{
    public class Window : GameWindow
    {
        int VertexBufferObject;

        Shader shader;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
                    : base(gameWindowSettings, nativeWindowSettings)
        {

        }
        protected override void OnLoad()
        {
            GL.ClearColor(0.02f, 1f, 0.5f, 1.0f);
            VertexBufferObject = GL.GenBuffer();

            shader = new Shader("shader.vert", "shader.frag");

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Code goes here.

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected void OnUpdateFrame(FrameEventArgs e)
        {
            SwapBuffers();
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        // Asta pentru ca bufferul trebuie sa fie sters manual la termianrea programului

        protected void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);

            shader.Dispose();
        }

    }
}