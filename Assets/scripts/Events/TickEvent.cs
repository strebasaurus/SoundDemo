using System;

public class TickEvent {

    public static event EventHandler<TickEventArgs> eventHandler;
    public static void Register( EventHandler<TickEventArgs> callback )
    {
        eventHandler += callback;
    }
    public static void Unregister( EventHandler<TickEventArgs> callback )
    {
        eventHandler -= callback;
    }

    public TickEvent( float tick, int cursub, int curbeat, int curbar )
    {
        TickEventArgs args = new TickEventArgs();
        args.tick = tick;
        args.cursub = cursub;
        args.curbeat = curbeat;
        args.curbar = curbar;

        EventHandler<TickEventArgs> handler = eventHandler;
        if( null != handler )
        {
            handler(this, args);
        }
    }

	
    public class TickEventArgs : EventArgs
    {
        public float tick;
        public int cursub;
        public int curbeat;
        public int curbar;
    }
}
