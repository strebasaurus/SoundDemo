using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Song : ISong {
	
    #region Members
    protected float _bpm        = 0.0f;
    protected float _perbeat    = 0.0f;
    protected float _perbar     = 0.0f;
    protected float _permeasure = 0.0f;
    public float bpm { get { return _bpm; } } 
    public float perbeat { get { return _perbeat; } }
    public float perbar { get { return _perbar; } }
    public float permeasure { get { return _permeasure; } }
    #endregion

    protected Song() { }
    protected Song( string songname )
    {
        LoadSongFromXML(songname);
    }

    #region Callback Methods
    public virtual void Tick( float timer, int cursub, int curbeat, int curbar )
    {
        
    }

    public virtual void MeasureEnd( float timer )
    {

    }

    public virtual void LoadSongFromXML( string songname )
    {
        // early out for no song
        if( "" == songname ) return;

        // get the song.
        XmlDocument songxml = new XmlDocument();
        songxml.Load( songname );
        
        XmlNodeList bpm   = songxml.GetElementsByTagName("bpm");
        XmlNodeList subs  = songxml.GetElementsByTagName("subs");
        XmlNodeList beats = songxml.GetElementsByTagName("beats");
        XmlNodeList bars  = songxml.GetElementsByTagName("bars");

        _bpm        = float.Parse(bpm  [0].InnerText);
        _perbeat    = float.Parse(subs [0].InnerText);
        _perbar     = float.Parse(beats[0].InnerText);
        _permeasure = float.Parse(bars [0].InnerText);
    }
    public static Song CreateSongFromXML( string songname )
    {
        Song newsong = new Song( songname );
        return newsong;
    }
    #endregion
}
