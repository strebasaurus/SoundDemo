using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneUI : MonoBehaviour {

    [SerializeField]
    string uiScene;

	// Use this for initialization
	void Start () {
		if( "" != uiScene )
        {
            SceneManager.LoadSceneAsync( uiScene, LoadSceneMode.Additive );
        }
	}
}
