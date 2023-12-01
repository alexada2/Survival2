using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public List<BuildingObject> AvaibleBuildings;
    private BuildingObject CurrentlySelected;
    [SerializeField] private Transform GetCamera;
    [SerializeField] private LayerMask GetLayer;
    public Vector3 Offset;
    private void Update()
    {
        if (Input.anyKey)
        {
            bool changeINDX = true;
            int toint;
            bool result = int.TryParse(Input.inputString, out toint);
           
            if (toint == 0 || toint > AvaibleBuildings.Count)
            {
                changeINDX = false;
            }
            if (changeINDX)
            {
                print(toint);
                if (CurrentlySelected)
                {
                    Destroy(CurrentlySelected.gameObject);
                }
                CurrentlySelected = Instantiate(AvaibleBuildings[toint-1]);
            }
            if (CurrentlySelected)
            {
                if (Input.inputString == "x" || Input.inputString == "y" || Input.inputString == "z")
                {
                    if (Input.inputString == "x")
                    {
                        CurrentlySelected.transform.Rotate(15, 0, 0);
                    }

                    if (Input.inputString == "y")
                    {
                        CurrentlySelected.transform.Rotate(0, 15, 0);
                    }

                    if (Input.inputString == "z")
                    {
                        CurrentlySelected.transform.Rotate(0, 0, 15);
                    }
                }
            }
        }
        if (CurrentlySelected)
        {
            
            Ray ray = new Ray(GetCamera.position, GetCamera.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 8, GetLayer))
            {
                Vector3 Pos = Vector3Int.CeilToInt(hit.point + Offset);
                CurrentlySelected.transform.position = new Vector3(Pos.x / 16, Pos.y / 16, Pos.z / 16);
            }
            if (Input.GetMouseButtonDown(0))
            {
                CurrentlySelected.gameObject.layer = 3;
                CurrentlySelected = null;
            }
        }
    }
}
