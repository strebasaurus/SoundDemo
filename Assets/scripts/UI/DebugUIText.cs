using UnityEngine;
using UnityEngine.UI;

public class DebugUIText : MonoBehaviour {

    [SerializeField]
    Text uitick;
    [SerializeField]
    Text uimeasure;

    private void Start()
    {
        TickEvent.Register( OnTickEvent );
        MeasureEndEvent.Register( OnMeasureEndEvent );
    }

    public void OnTickEvent( object sender, TickEvent.TickEventArgs e )
    {
        if( null != uitick )
        {
            uitick.text = "Cur tick: " + e.cursub + "-" + e.curbeat + "-" + e.curbar + "\nOvertick: " + e.tick;
        }
    }

    public void OnMeasureEndEvent( object sender, MeasureEndEvent.MeasureEndEventArgs e )
    {
        if( null != uimeasure )
        {
            uimeasure.text = "Average: " + e.average + "\nM of E : " + e.moe;
        }
    }
}
