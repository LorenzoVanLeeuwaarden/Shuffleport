using UnityEngine;
using System.Collections;

public class Button2Test : MonoBehaviour
{

    private GameObject panel1;
    private GameObject panel2;
    private GameObject panel3;
    private GameObject panel4;
    private GameObject panel5;

    // Use this for initialization
    void Start()
    {
        panel1 = GameObject.Find("PanelBoot1");
        panel2 = GameObject.Find("PanelBoot2");
        panel3 = GameObject.Find("PanelBoot3");
        panel4 = GameObject.Find("PanelBoot4");
        panel5 = GameObject.Find("PanelBoot5");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnClick()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(false);

    }
}
