using UnityEngine;
using System.Collections;
using System.Data;

public class Buttons : MonoBehaviour
{

    private string name;
    private int triggerCounter;

    private DataTable shipNames;
    private DataTable shipData;
    private bool animationStart;
    private int animationCounter = 0;
    private GameObject pointer;
    private bool animationComplete;

    void Start()
    {
        shipNames = MenuDataManager.getInstance().ShipNames;
        shipData = MenuDataManager.getInstance().ShipData;
        pointer = GameObject.FindGameObjectWithTag("pointer");
    }

    private DataTable SelectWhere(string column, string value)
    {
        DataView dv = new DataView(shipData);
        dv.RowFilter = "(" + column + " = '" + value + "')";
        DataTable newdt = dv.ToTable();
        return newdt;
    }

    private DataTable SelectWhere(string column, string[] value)
    {
        DataView dv = new DataView(shipData);
        string query = "(";
        for (int i = 0; i < value.Length; i++)
        {
            if (i >= value.Length - 1)
            {
                query += "[" + column + "]='" + value[i] + "'";
            }
            else
            {
                query += "[" + column + "]='" + value[i] + "' or ";
            }
        }
        query += ") and Scheepsnaam ='" + name + "'";
        dv.RowFilter = query;
        DataTable newdt = dv.ToTable();
        return newdt;
    }

    private DataTable SelectWhereNot(string column, string value)
    {
        DataView dv = new DataView(shipData);
        dv.RowFilter = "(NOT " + column + " = '" + value + "') and Scheepsnaam='" + name + "'";
        DataTable newdt = dv.ToTable();
        return newdt;
    }

    void Update()
    {
        if (animationStart)
        {
            if (animationCounter < 5)
            {
                Vector3 scale = this.transform.localScale;
                Vector3 newScale = new Vector3(scale.x + 0.025f, scale.y + 0.025f, scale.z);
                this.transform.localScale = newScale;
            }
            else
            {
                Vector3 scale = this.transform.localScale;
                Vector3 newScale = new Vector3(scale.x - 0.025f, scale.y - 0.025f, scale.z);
                this.transform.localScale = newScale;
            }
            if (animationCounter == 9)
            {
                animationCounter = 0;
                animationStart = false;
            }
            else
            {
                animationCounter++;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        animationComplete = false;
        triggerCounter = 1;
    }

    void OnTriggerStay(Collider other)
    {
        setPointerAnimation(triggerCounter);
        if (triggerCounter == 34)
        {

            ShowInformationBoxes();

            /* Start Button animation and sound */
            animationStart = true;
            this.audio.Play();

            /* Call Onclick method */
            this.OnClick();

            /* Reset Pointer Animations */
            setPointerAnimation(1);
            animationComplete = true;
        }
            triggerCounter++;
    }

    private void ShowInformationBoxes()
    {
        GameObject image = MenuDataManager.getInstance().ShipImage;
        if (!image.renderer.enabled)
        {
            image.renderer.enabled = true;
            MenuDataManager.getInstance().ShipText.renderer.enabled = true;
            MenuDataManager.getInstance().ShipTextBox.renderer.enabled = true;
            MenuDataManager.getInstance().SelectMessage.renderer.enabled = false;
        }
    }

    void OnTriggerExit()
    {
        setPointerAnimation(1);
    }

    private void setPointerAnimation(int count)
    {
        if (!animationComplete)
        {
            Texture2D img = Resources.Load("Cursor/pointer (" + count + ")") as Texture2D;
            pointer.renderer.material.SetTextureScale("_MainTex", new Vector2(1, 1));
            pointer.renderer.material.mainTexture = img;
        }
    }

   

    private void OnClick()
    {
        ConfirmShipName();

    }

    private void ConfirmShipName()
    {
        for (int a = 0; a < shipNames.Rows.Count; a++)
        {
            if (shipNames.Rows[a][0].ToString().Equals(name))
            {
                readShipData(name);
                break;
            }
        }
    }

    private void readShipData(string name)
    {
        int amountOfContainers = SelectWhere("scheepsnaam", name).Rows.Count;
        int amountOfDanger = SelectWhere("Packaging Group", new string[2] { "Medium danger", "Great danger" }).Rows.Count;
        int amountOfFlammable = SelectWhereNot("Flashpoint", "").Rows.Count;

        MenuDataManager.getInstance().ShipText.GetComponent<TextMesh>().text = "Schip: <i>" + name +
            "</i>\nAantal containers: <i>" + amountOfContainers + "</i>\nAantal gevaarlijke containers: <i>" + amountOfDanger + "</i>\nAantal brandbare containers: <i>" + amountOfFlammable + "</i>";

        GameObject tempObj = MenuDataManager.getInstance().ShipImage;

        tempObj.renderer.material = new Material(Shader.Find("Diffuse"));
        tempObj.renderer.material.SetTextureScale("_MainTex", new Vector2(1, 1));
        Texture2D image = Resources.Load(name) as Texture2D;
        if (image == null)
        {
            image = Resources.Load("geenfotogroot") as Texture2D;
        }
        tempObj.renderer.material.mainTexture = image;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
