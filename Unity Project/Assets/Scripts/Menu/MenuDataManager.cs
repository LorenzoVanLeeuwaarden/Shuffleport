using UnityEngine;
using System.Collections;
using System.Data;

public class MenuDataManager
{

    private DataTable shipData = new DataTable();
    private DataTable containerCount = new DataTable();
    private DataTable shipNames = new DataTable();

    private GameObject shipImage;
    private GameObject shipText;
    private GameObject shipTextBox;
    private GameObject selectMessage;

      
    private static MenuDataManager instance;

    private MenuDataManager(){ }

    public static MenuDataManager getInstance()
    {
        if (instance == null)
        {
            instance = new MenuDataManager();
        }
        return instance;
    }

    public DataTable ShipData
    {
        get { return shipData; }
        set { shipData = value; }
    }

    public DataTable ContainerCount
    {
        get { return containerCount; }
        set { containerCount = value; }
    }

    public DataTable ShipNames
    {
        get { return shipNames; }
        set { shipNames = value; }
    }

    public GameObject ShipImage
    {
        get { return shipImage; }
        set { shipImage = value; }
    }

    public GameObject ShipText
    {
        get { return shipText; }
        set { shipText = value; }
    }

    public GameObject ShipTextBox
    {
        get { return shipTextBox; }
        set { shipTextBox = value; }
    }

    public GameObject SelectMessage
    {
        get { return selectMessage; }
        set { selectMessage = value; }
    }

    
}
