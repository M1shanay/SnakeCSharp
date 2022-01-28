using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursWinForms
{
   public class UpdateSys
   {
        public delegate void Event(Object myObject, EventArgs eventArgs);
        public event Event UpdateGame;
        private int MinInter=20;
        private int MaxInter=200;
        private Timer timer = new Timer();
        public UpdateSys()
        {
            timer.Tick += new EventHandler(Update);
        }
        public int GetInterval()
        {
            return timer.Interval;
        }
        public int MaxInterval
        {
            get { return MaxInter; }
        }
        public int MinInterval
        {
            get { return MinInter; }
            set { MinInter = value;}
        }
        public void Init(int interval,Event Udp)
        {
            UpdateGame += Udp;
            TimerInterval(interval);
            StartUpdating();
        }
        public void TimerInterval(int Inter)
        {
            MaxInter = Inter;
            timer.Interval = Inter;
        }
        public void UpdateTimerIntervalPlus(int Inter)
        {
            timer.Interval += Inter;
            if (timer.Interval > MaxInter)
                timer.Interval = MaxInter;
        }
        public void UpdateTimerIntervalMinus(int Inter)
        {
            if (timer.Interval <= MinInter)
                return;
            timer.Interval -= Inter;
        }
        public void StartUpdating()
        {
            timer.Enabled = true;
        }

        public void Update(Object myObject, EventArgs eventArgs)
        {
            if (timer.Interval > 200)
                timer.Interval = 200;
            UpdateGame(myObject, eventArgs);
        }
   }
}
