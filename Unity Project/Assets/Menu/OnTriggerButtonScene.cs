using UnityEngine;
using System.Collections;

public class OnTriggerButtonScene : MonoBehaviour {

    public LoadSceneButton button;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        button.OnClick();
    }
}
