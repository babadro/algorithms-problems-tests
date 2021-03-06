﻿using System;
using System.ComponentModel;

namespace _09_Dispose
{
    class Program
    {
        public class MyResource : IDisposable
        {
            private IntPtr handle;

            private Component component = new Component();

            private bool disposed = false;


            public MyResource(IntPtr handle)
            {
                this.handle = handle;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                        component.Dispose();

                    CloseHandle(handle);
                    handle = IntPtr.Zero;

                    disposed = true;
                }
            }

            [System.Runtime.InteropServices.DllImport("Kernel32")]
            private extern static Boolean CloseHandle(IntPtr handle);

            ~MyResource()
            {
                Dispose(false);
            }
        }
        static void Main(string[] args)
        {
            // Insert code here to create and use the MyResource object.
        }
    }
}
