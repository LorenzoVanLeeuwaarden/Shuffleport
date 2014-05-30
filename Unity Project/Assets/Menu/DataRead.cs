using System.Collections;
using System.Data;
using System.IO;
using UnityEngine;

public class DataRead {

    private DataTable shipData = new DataTable();
    private DataTable ContainerCount = new DataTable();
    private DataTable DistinctValues;


    public bool startDataRetrieval()
    {
        Initialize();
        ReadShipData();
        CountShips();
        SaveData(); //Save Data to MenuManager
        return true;
    }

    private void Initialize()
    {
        //Create DataTable ContainerCount
        ContainerCount.Columns.Add("Scheepsnaam", typeof(string));
        ContainerCount.Columns.Add("Aantal", typeof(int));
    }

    private void SaveData()
    {   //using Singleton for global variable save
        MenuDataManager.getInstance().ContainerCount = ContainerCount;
        MenuDataManager.getInstance().ShipData = shipData;
        MenuDataManager.getInstance().ShipNames = DistinctValues;
    }

    private void CountShips()
    {
        DistinctValues = shipData.DefaultView.ToTable(true,"Scheepsnaam"); //Select Distinct Scheepsnaam
        for (int i = 0; i < DistinctValues.Rows.Count; i++)
        {
            string currentShipName = DistinctValues.Rows[i][0].ToString();
            int counter = 0;
            foreach (DataRow row in shipData.Rows)
            {
                if (row["Scheepsnaam"].Equals(currentShipName))
                {
                    counter++;
                }
            }
            ContainerCount.Rows.Add(currentShipName, counter);
        }
    }

    private void ReadShipData()
    {
        //read CSV Data file and convert it to a DataTable
        string CSVFilePathName = "Assets/Menu/datasetschepen.csv";
        string[] Lines = File.ReadAllLines(CSVFilePathName);
        string[] Fields;
        Fields = Lines[0].Split(new char[] { ';' });
        int Cols = Fields.GetLength(0);
        //1st row of the file will become the collumn names. Collumn names are forced to lower case to prevent errors later on
        for (int i = 0; i < Cols; i++)
            shipData.Columns.Add(Fields[i].ToLower(), typeof(string));
        DataRow Row;
        for (int i = 1; i < Lines.GetLength(0); i++)
        {
            Fields = Lines[i].Split(new char[] { ';' });
            Row = shipData.NewRow();
            for (int f = 0; f < Cols; f++)
            {
                Row[f] = Fields[f];
            }
            shipData.Rows.Add(Row);
        }
    }
}
