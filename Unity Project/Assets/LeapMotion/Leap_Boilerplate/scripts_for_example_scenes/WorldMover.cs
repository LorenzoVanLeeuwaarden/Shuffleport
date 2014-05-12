using UnityEngine;
using System.Collections;

public class WorldMover : MonoBehaviour {
	private LeapManager _leapManager;
	// Use this for initialization
	void Start () {
		_leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
	}
	
	// Update is called once per frame
	void Update () {
		if(_leapManager != null) { 
			if(_leapManager.pointerAvailible)
			{
                Vector3 yolo = new Vector3(_leapManager.pointerPositionWorld.x, _leapManager.pointerPositionWorld.y, 0);
                this.transform.position = yolo;
            if(!renderer.enabled) { renderer.enabled = true; }
			}
			else
			{
				renderer.enabled = false;
			}
		}
	}
}
