
using System.Data;
using UnityEngine;
public class MenuManager : MonoBehaviour
{

    private DataRead dataRead = new DataRead();


    public GameObject button;
    public GameObject buttonText;
    public GameObject shipImage;
    public GameObject menuText;
    public GameObject menuBackgroundText;

    private int currentButtonNumber;
    private bool allButtonsSet = false;
    private float dX;
    private float dY;

    private Vector3 stageDimensions;

    void Start()
    {
        initialize();
        dataRead.startDataRetrieval();
    }

    private void initialize()
    {
        stageDimensions = this.camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update() { }

    void OnGUI()
    {
        if (!allButtonsSet)
        {
            InstantiateShipImage();
            InstantiateTextBox();
            InstantiateMenuButtons();

        }
    }

    

    private void InstantiateMenuButtons()
    {
        for (currentButtonNumber = 0; currentButtonNumber < MenuDataManager.getInstance().ShipNames.Rows.Count; currentButtonNumber++)
        {
            string currentButtonName = MenuDataManager.getInstance().ShipNames.Rows[currentButtonNumber][0].ToString();
            /* Create Button */
            GameObject obj = (GameObject)Instantiate(button, new Vector3(-stageDimensions.x + (stageDimensions.x / 4.5f) + (0.7141597f * currentButtonNumber * 1.3f), -stageDimensions.y + (stageDimensions.y / 4.2f), 0), Quaternion.identity);

            obj.GetComponent<Buttons>().Name = currentButtonName;

            /* Create Button Text */
            buttonText.GetComponent<TextMesh>().text = currentButtonName;
            Instantiate(buttonText, new Vector3(-stageDimensions.x + (stageDimensions.x / 4.5f) + (0.7141597f * currentButtonNumber * 1.3f), -stageDimensions.y + (stageDimensions.y / 4.4f), 0), Quaternion.identity);

            /* Stop when all buttons a created */
            if (currentButtonNumber < MenuDataManager.getInstance().ShipNames.Rows.Count - 1)
            {
                allButtonsSet = true;
            }
        }
    }

    private void InstantiateShipImage()
    {
        /* Instantiate ship Image */
        GameObject image = (GameObject)Instantiate(shipImage, new Vector3(-stageDimensions.x + (stageDimensions.x / 2.4f), stageDimensions.y / 3f, 0), Quaternion.identity);
        image.transform.eulerAngles = new Vector3(90, -180, 0);

        /* Set Image to first ship in list*/
        image.renderer.material = new Material(Shader.Find("Diffuse"));
        image.renderer.material.SetTextureScale("_MainTex", new Vector2(1, 1));
        image.renderer.material.mainTexture = Resources.Load(MenuDataManager.getInstance().ShipNames.Rows[0][0].ToString()) as Texture2D;

        /* Save ShipImage Global */
        MenuDataManager.getInstance().ShipImage = image;
    }

    private void InstantiateTextBox()
    {
        GameObject backgroundBox = (GameObject)Instantiate(menuBackgroundText, new Vector3(stageDimensions.x - (stageDimensions.x / 1.8f), stageDimensions.y / 4.75f, 0), Quaternion.identity);
        backgroundBox.transform.eulerAngles = new Vector3(0, 0, -180);

        GameObject backgroundBoxText = (GameObject)Instantiate(menuText, new Vector3(stageDimensions.x - (stageDimensions.x), stageDimensions.y / 1.2f, 0), Quaternion.identity);
        MenuDataManager.getInstance().ShipText = backgroundBoxText;
    }
}
