﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;


public class WindowResizer
{
    private Window target = null;

    private bool resizeRight = false;
    private bool resizeLeft = false;
    private bool resizeUp = false;
    private bool resizeDown = false;

    private Dictionary<UIElement, short> leftElements = new Dictionary<UIElement, short>();
    private Dictionary<UIElement, short> rightElements = new Dictionary<UIElement, short>();
    private Dictionary<UIElement, short> upElements = new Dictionary<UIElement, short>();
    private Dictionary<UIElement, short> downElements = new Dictionary<UIElement, short>();

    private PointAPI resizePoint = new PointAPI();
    private Point resizeSize = new Point();
    private Point resizeWindowPoint = new Point();

    private delegate void RefreshDelegate();

    public WindowResizer(Window target)
    {
        this.target = target;

        if (target == null)
        {
            throw new Exception("Invalid Window handle");
        }
    }

    #region add resize components
    private void connectMouseHandlers(UIElement element)
    {
        element.MouseLeftButtonDown += new MouseButtonEventHandler(element_MouseLeftButtonDown);
        element.MouseEnter += new MouseEventHandler(element_MouseEnter);
        element.MouseLeave += new MouseEventHandler(setArrowCursor);
    }

    public void addResizerRight(UIElement element)
    {
        connectMouseHandlers(element);
        rightElements.Add(element, 0);
    }

    public void addResizerLeft(UIElement element)
    {
        connectMouseHandlers(element);
        leftElements.Add(element, 0);
    }

    public void addResizerUp(UIElement element)
    {
        connectMouseHandlers(element);
        upElements.Add(element, 0);
    }

    public void addResizerDown(UIElement element)
    {
        connectMouseHandlers(element);
        downElements.Add(element, 0);
    }

    public void addResizerRightDown(UIElement element)
    {
        connectMouseHandlers(element);
        rightElements.Add(element, 0);
        downElements.Add(element, 0);
    }

    public void addResizerLeftDown(UIElement element)
    {
        connectMouseHandlers(element);
        leftElements.Add(element, 0);
        downElements.Add(element, 0);
    }

    public void addResizerRightUp(UIElement element)
    {
        connectMouseHandlers(element);
        rightElements.Add(element, 0);
        upElements.Add(element, 0);
    }

    public void addResizerLeftUp(UIElement element)
    {
        connectMouseHandlers(element);
        leftElements.Add(element, 0);
        upElements.Add(element, 0);
    }
    #endregion

    #region resize handlers
    private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        GetCursorPos(out resizePoint);
        resizeSize = new Point(target.Width, target.Height);
        resizeWindowPoint = new Point(target.Left, target.Top);

        #region updateResizeDirection
        UIElement sourceSender = (UIElement)sender;
        if (leftElements.ContainsKey(sourceSender))
        {
            resizeLeft = true;
        }
        if (rightElements.ContainsKey(sourceSender))
        {
            resizeRight = true;
        }
        if (upElements.ContainsKey(sourceSender))
        {
            resizeUp = true;
        }
        if (downElements.ContainsKey(sourceSender))
        {
            resizeDown = true;
        }
        #endregion


        Thread t = new Thread(new ThreadStart(updateSizeLoop));
        t.Name = "Mouse Position Poll Thread";
        t.Start();
    }

    private void updateSizeLoop()
    {
        try
        {
            while (resizeDown || resizeLeft || resizeRight || resizeUp)
            {

                target.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new RefreshDelegate(updateSize));
                target.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new RefreshDelegate(updateMouseDown));
                Thread.Sleep(10);
            }

            target.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, new RefreshDelegate(setArrowCursor));
        }
        catch (Exception)
        {
        }
    }

    #region updates
    private void updateSize()
    {
        PointAPI p = new PointAPI();
        GetCursorPos(out p);

        if (resizeRight)
        {
            target.Width = Math.Abs(this.resizeSize.X - (resizePoint.X - p.X));
        }

        if (resizeDown)
        {
            target.Height = Math.Abs(resizeSize.Y - (resizePoint.Y - p.Y));
        }

        if (resizeLeft)
        {
            double w_ = resizeSize.X + (resizePoint.X - p.X);
            target.Width = w_ < 0?0: w_;
            target.Left = resizeWindowPoint.X - (resizePoint.X - p.X);
        }

        if (resizeUp)
        {
            target.Height = resizeSize.Y + (resizePoint.Y - p.Y);
            target.Top = resizeWindowPoint.Y - (resizePoint.Y - p.Y);
        }
    }

    private void updateMouseDown()
    {
        if (Mouse.LeftButton == MouseButtonState.Released)
        {
            resizeRight = false;
            resizeLeft = false;
            resizeUp = false;
            resizeDown = false;
        }
    }
    #endregion
    #endregion

    #region cursor updates
    private void element_MouseEnter(object sender, MouseEventArgs e)
    {
        bool resizeRight = false;
        bool resizeLeft = false;
        bool resizeUp = false;
        bool resizeDown = false;

        UIElement sourceSender = (UIElement)sender;
        if (leftElements.ContainsKey(sourceSender))
        {
            resizeLeft = true;
        }
        if (rightElements.ContainsKey(sourceSender))
        {
            resizeRight = true;
        }
        if (upElements.ContainsKey(sourceSender))
        {
            resizeUp = true;
        }
        if (downElements.ContainsKey(sourceSender))
        {
            resizeDown = true;
        }

        if ((resizeLeft && resizeDown) || (resizeRight && resizeUp))
        {
            setNESWCursor(sender, e);
        }
        else if ((resizeRight && resizeDown) || (resizeLeft && resizeUp))
        {
            setNWSECursor(sender, e);
        }
        else if (resizeLeft || resizeRight)
        {
            setWECursor(sender, e);
        }
        else if (resizeUp || resizeDown)
        {
            setNSCursor(sender, e);
        }
    }

    private void setWECursor(object sender, MouseEventArgs e)
    {
       target.Cursor = Cursors.SizeWE;
    }

    private void setNSCursor(object sender, MouseEventArgs e)
    {
        target.Cursor = Cursors.SizeNS;
    }

    private void setNESWCursor(object sender, MouseEventArgs e)
    {
        target.Cursor = Cursors.SizeNESW;
    }

    private void setNWSECursor(object sender, MouseEventArgs e)
    {
        target.Cursor = Cursors.SizeNWSE;
    }

    private void setArrowCursor(object sender, MouseEventArgs e)
    {
        if (!resizeDown && !resizeLeft && !resizeRight && !resizeUp)
        {
            target.Cursor = Cursors.Arrow;
        }
    }

    private void setArrowCursor()
    {
        //target.Cursor = Cursors.Arrow;
    }
    #endregion

    #region external call
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetCursorPos(out PointAPI lpPoint);

    private struct PointAPI
    {
        public int X;
        public int Y;
    }
    #endregion
}

