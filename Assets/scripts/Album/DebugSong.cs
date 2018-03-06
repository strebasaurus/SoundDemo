using System.Collections.Generic;
using UnityEngine;

public class DebugSong : Song {

    #region Members
    protected float frequency = 0.0f;
    protected List<float> overticks = new List<float>();
    #endregion

    DebugSong() { }
    DebugSong( string songname )
    {
        LoadSongFromXML( songname );
    }
    

    #region Callback Methods
    public override void Tick( float tick, int cursub, int curbeat, int curbar )
    {
        base.Tick( tick, cursub, curbeat, curbar );

        // TODO: debug stuff
        overticks.Add( tick );

        new TickEvent( tick, cursub, curbeat, curbar );
    }

    public override void MeasureEnd( float timer )
    {
        base.MeasureEnd( timer );

        // TODO: debug stuff
        float average = 0.0f;
        foreach( float o in overticks )
        {
            average += o;
        }
        average /= overticks.Count;
        float marginOfError = (average / frequency)*100.0f;
        overticks.Clear();

        new MeasureEndEvent( average, marginOfError );
    }

    public override void LoadSongFromXML(string songname)
    {
        Debug.Log( "Song::LoadSongFromXML(" + songname + ")" );
        base.LoadSongFromXML(songname);
        frequency = (base.bpm / 60.0f) / base.perbeat;
        Debug.Log( "Frequency:  " + frequency );
        Debug.Log( "BPM:        " + base.bpm );
        Debug.Log( "Perbeat:    " + base.perbeat );
        Debug.Log( "Perbar:     " + base.perbar );
        Debug.Log( "PerMeasure: " + base.permeasure );
    }
    public static new DebugSong CreateSongFromXML(string songname)
    {
        DebugSong newsong = new DebugSong( songname );
        return newsong;
    }
    #endregion
}
