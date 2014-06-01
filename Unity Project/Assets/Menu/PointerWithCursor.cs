using UnityEngine;
using System.Collections;

public class PointerWithCursor : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(Input.mousePosition.x/(Screen.width/2)-2,Input.mousePosition.y/(Screen.height/2)-1,0);
        
	}
}
