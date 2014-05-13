using UnityEngine;
using System.Collections;

public class OnTriggerButtonScene : MonoBehaviour {

    int i = 0;
    public LoadSceneButton button;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        i = 0;
    }

    void OnTriggerStay(Collider other)
    {

        i++;
        if (i > 30)
        {

            button.OnClick();
        }
    }
}
