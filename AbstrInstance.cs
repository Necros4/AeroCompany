using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    abstract class AbstrInstance
    {
        private bool isDone = false;

        protected abstract void Init();
        protected abstract void Idle();
        protected void CleanUp()
        {
            Console.Clear();
        }

        protected void SetDone()
        {
            isDone = true;
        }

        protected bool Done()
        {
            return isDone;
        }

        public void Run()
        {
            Init();
            while (!Done())
                Idle();
            CleanUp();
        }
    }
}
