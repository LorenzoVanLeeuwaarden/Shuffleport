using UnityEngine;
using System.Collections;
using System.Data;

public class Manager : MonoBehaviour
{

    public GameObject container;
    public Texture[] textures = new Texture[6];

    private Vector3 rightRear;
    private Vector3 rightFront;
    private Vector3 leftRear;
    private Vector3 leftFront;

    private float containerWidth;
    private float containerHeight;
    private float containerLength;

    private StowagePosition sp;
    private ArrayList containers = new ArrayList();

    void Start()
    {
        Initialize();
        GenerateContainers();
    }


    void Update()
    {

    }

    private void Initialize()
    {
        DataRead dr = new DataRead();
        sp = new StowagePosition();
        dr.startDataRetrieval();

        leftRear = new Vector3(-246.1768f, 15.42147f, 119.26f);
        rightRear = new Vector3(-246.1768f, 15.42147f, 51.2159f);
        rightFront = new Vector3(-165.4609f, 15.42147f, 51.2159f);
        leftFront = new Vector3(-165.4609f, 15.42147f, 119.26f);

        containerWidth = container.transform.localScale.z;
        containerHeight = container.transform.localScale.y;
        containerLength = container.transform.localScale.x;


    }

    // containerwidth * 1.3f
    private void GenerateContainers()
    {
        foreach (DataRow row in MenuDataManager.getInstance().ShipData.Rows)
        {
            //Debug.Log(row["Stowage position"]);
            int[] coords = sp.CalculatePosition(row["Stowage position"].ToString()); // tier, row, bay

            float dX = leftRear.x + (containerLength * (coords[1] + 5)) * 1f;
            float dY = leftRear.y + (containerHeight * (coords[0])) * 1f;
            float dZ = leftRear.z - (containerWidth * coords[2] * 1.3f);

            //Set data for individual container
            container.GetComponent<Container>().Coords = coords;
            container.GetComponent<Container>().ContainerData = row;

            Vector3 newLocation = new Vector3(dX, dY, dZ);

            //Create new container and set texture
            GameObject tempObj = Instantiate(container, newLocation, Quaternion.identity) as GameObject;
            tempObj.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("Textures/" + row[8].ToString()) as Texture2D;

            //add container to arraylist
            containers.Add(tempObj);
        }
    }
}
