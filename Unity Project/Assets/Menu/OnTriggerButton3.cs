using UnityEngine;
using System.Collections;

public class OnTriggerButton3 : MonoBehaviour
{

    public Button3Test button;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        button.OnClick();
    }

}
