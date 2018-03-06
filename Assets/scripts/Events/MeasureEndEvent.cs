using System;

public class MeasureEndEvent {

    public static event EventHandler<MeasureEndEventArgs> eventHandler;
    public static void Register( EventHandler<MeasureEndEventArgs> callback )
    {
        eventHandler += callback;
    }
    public static void Unregister( EventHandler<MeasureEndEventArgs> callback )
    {
        eventHandler -= callback;
    }

    public MeasureEndEvent( float average, float moe )
    {
        MeasureEndEventArgs args = new MeasureEndEventArgs();
        args.average = average;
        args.moe = moe;
        EventHandler<MeasureEndEventArgs> handler = eventHandler;
        if( null != handler )
        {
            handler(this, args);
        }
    }


    public class MeasureEndEventArgs : EventArgs
    {
        public float average;
        public float moe;
    }
}
