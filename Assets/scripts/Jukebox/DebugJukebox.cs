using UnityEngine;

public class DebugJukebox : Jukebox {

    [SerializeField]
    float bpm, perbeat, perbar, permeasure;
    
	// Use this for initialization
	protected override void Start () {
        timer = gameObject.AddComponent(typeof(Metronome)) as Metronome;
        cursong = DebugSong.CreateSongFromXML( cursongname );
        StartSong( cursong );
	}

    private void Update()
    {
        bpm = base.cursong.bpm;
        perbeat = base.cursong.perbeat;
        perbar = base.cursong.perbar;
        permeasure = base.cursong.permeasure;
    }
}
