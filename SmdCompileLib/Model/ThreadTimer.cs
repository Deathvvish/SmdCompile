using System;
using System.Threading;
using System.Windows;

public class ThreadTimer
{
    public Thread thread;
    Window win = null;
    public Action<int, int> Tick;
    public Action<bool> ChangedStatus;
    public Action<string> errors;

    public int TickTime { get; set; } = 1;
    private bool status = false;

    #region FrameRate
    private static int lastTick;
    private static int lastFrameRate;
    private static int frameRate;
    static int CalculateFrameRate()
    {
        if (System.Environment.TickCount - lastTick >= 1000)
        {
            lastFrameRate = frameRate;
            frameRate = 0;
            lastTick = System.Environment.TickCount;
        }
        frameRate++;
        return lastFrameRate;
    }
    #endregion  
    public bool Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;

            if (ChangedStatus != null)
                ChangedStatus(Status);
        }
    }
    public ThreadTimer(Window wind)
    {
        win = wind;
        thread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            int count_ = 0;
            int FrameRate = 0;
            //try
            //{
            while (true)
            {
                if (Status)
                {
                    Thread.Sleep(TickTime);
                    continue;
                }
                if(win == null)
                {
                    Tick(count_, FrameRate);
                }
                else
                {
                    win.Dispatcher.BeginInvoke((ThreadStart)delegate ()
                    {
                        Tick(count_, FrameRate);
                        FrameRate = CalculateFrameRate();
                    }, new object[] { });
                }
               
                

                Thread.Sleep(TickTime);
                count_++;
            }
            //}
            //catch (Exception e) { errors(e.Message); }
        });

    }
    public void initialize()
    {
        thread.Start();
    }

}