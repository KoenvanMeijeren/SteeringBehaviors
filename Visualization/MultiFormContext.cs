﻿using System.Threading;
using System.Windows.Forms;

namespace SteeringCS
{
    public class MultiFormContext : ApplicationContext
    {
        public MultiFormContext(params Form[] forms)
        {
            int openForms = forms.Length;

            foreach (Form form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    //When we have closed the last of the "starting" forms, 
                    //end the program.
                    if (Interlocked.Decrement(ref openForms) == 0)
                    {
                        ExitThread();
                    }
                };

                form.Show();
            }
        }
    }
}
