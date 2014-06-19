using UnityEngine;
using System.Collections;
using System.Data;

public class Container : MonoBehaviour
{

    private int[] coords; // 0 = tier, 1 = row, 2 = bay
    private DataRow containerData;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public DataRow ContainerData
    {
        get { return containerData; }
        set { containerData = value; }
    }

    public int[] Coords
    {
        get { return coords; }
        set { coords = value; }
    }
}
