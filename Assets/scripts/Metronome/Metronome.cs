using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour {
#region Members
    // used to calculate the tempo of the music
    [SerializeField]
    float bpm        = 0.0f;
    [SerializeField]
    float perbeat    = 0.0f;
    [SerializeField]
    float perbar     = 0.0f;
    [SerializeField]
    float permeasure = 0.0f;

    // the calculated tempo and duration of a measure
    float frequency = 0.0f;
    float beatlen   = 0.0f;
    float barlen    = 0.0f;
    float measlen   = 0.0f;

    // starts and stops the metronome
    bool isPlaying = false;

    // used to time out the song
    float timer  = 0.0f;
    float ticker = 0.0f;

    // keeps track of where we are in the song
    int cursub  = 1;
    int curbeat = 1;
    int curbar  = 1;

    // callbacks
    public delegate void SendTick( float _timer, int _cursub, int _curbeat, int _curbar );
    public delegate void SendMeasureEnd( float _timer );
    SendTick Tick = null;
    SendMeasureEnd MeasureEnd = null;

#endregion

#region Private Methods
    void CalculateTempo()
    {
        beatlen = bpm / 60.0f;
        barlen = beatlen * perbar;
        measlen = barlen * permeasure;
        frequency = beatlen / perbeat;
    }

    // Update is called once per frame
    void Update() {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            // send's a tick at each subdivision
            ticker += Time.deltaTime;
            if (frequency < ticker)
            {
                ticker -= frequency;
                ++cursub;
                if (perbeat < cursub)
                {
                    cursub = 1;
                    ++curbeat;
                    if (perbar < curbeat)
                    {
                        curbeat = 1;
                        ++curbar;
                        if (permeasure < curbar)
                            curbar = 1;
                    }
                }
                // send callbacks
                Tick( ticker, cursub, curbeat, curbar );
            }

            // reset measure counter if we've finished a measure
            if (measlen < timer)
            {
                timer -= measlen;
                // send callbacks
                MeasureEnd( timer );
            }
        }
	}
    #endregion

#region Public Methods
    public void LoadSong( ISong newSong )
    {
        // gather new tempo
        bpm = newSong.bpm;
        perbeat = newSong.perbeat;
        perbar = newSong.perbar;
        permeasure = newSong.permeasure;
        CalculateTempo();

        // set up callbacks
        Tick += newSong.Tick;
        MeasureEnd += newSong.MeasureEnd;
    }

    public float GetCurTick(out int _cursub, out int _curbeat, out int _curbar)
    {
        _cursub  = cursub;
        _curbar  = curbar;
        _curbeat = curbeat;
        return timer;
    }
    public float GetCurTick()
    {
        return timer;
    }

    public void Play()       { isPlaying = true; }
    public void Pause()      { isPlaying = false; }
    public void TogglePlay() { isPlaying = !isPlaying; }
}
#endregion