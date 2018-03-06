using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour {

    [SerializeField]
    protected string cursongname = "WordTest.xml";
    protected Song cursong = null;
    protected Metronome timer;

	// Use this for initialization
	protected virtual void Start () {
        timer = gameObject.AddComponent(typeof(Metronome)) as Metronome;
        cursong = Song.CreateSongFromXML( cursongname );
        StartSong( cursong );
	}

    protected void StartSong( Song nextsong )
    {
        // TODO: clean up current song.

        // TODO: play next song.
        timer.LoadSong( nextsong );
        timer.Play();
    }
}
