using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISong {
    #region Members
    float bpm { get; }
    float perbeat { get; }
    float perbar { get; }
    float permeasure { get; }
    #endregion

    #region Callback Methods
    void Tick(float timer, int cursub, int curbeat, int curbar);
    void MeasureEnd(float timer);
    void LoadSongFromXML(string songname);
    #endregion
}
