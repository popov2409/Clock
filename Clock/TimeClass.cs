using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Clock
{
    class TimeClass
    {
        DispatcherTimer timer;
        private TextBlock currentTextBlock;
        private TextBlock docladTextBlocks;


        public TimeClass(TextBlock currentTb, TextBlock docladTb)
        {
            this.currentTextBlock = currentTb;
            this.docladTextBlocks = docladTb;
            InitializeTimer();
        }

        void InitializeTimer()
        {
            timer = new DispatcherTimer
            { Interval = new TimeSpan(seconds: 1, hours: 0, minutes: 0) };
            timer.Tick += Timer_Tick;
            docTime = new TimeSpan(0);

            timer.Start();


        }



        public void StartTimer()
        {
            timeDocEnabled = !timeDocEnabled;
        }


        public void ClearTime()
        {
            docTime = new TimeSpan(0);
        }

        private TimeSpan docTime;
        public bool timeDocEnabled = false;
        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTextBlock.Text = DateTime.Now.ToLongTimeString();
            docladTextBlocks.Text = new DateTime(docTime.Ticks).ToLongTimeString();

            if (timeDocEnabled)
            {
                docTime = docTime.Add(new TimeSpan(seconds: 1, hours: 0, minutes: 0));
            }
        }


    }
}
