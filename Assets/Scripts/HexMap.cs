using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexMap : MonoBehaviour
{
    public Dropdown DropDownSizeMap, DropDownLands, DropDownBuilds;
    byte width = 8, height = 8, brush;
    public HexCell hex;
    public GameObject map;
    public HexCell[] hexs, builds;

    void Update()
    {
        if (Input.GetMouseButton(0))
            HandleInput();
    }

    public void ChangeValueMap()
    {
        switch (DropDownSizeMap.value)
        {
            case 0:
                height = width = 8;
                break;

            case 1:
                height = width = 16;
                break;

            case 2:
                height = width = 20;
                break;

            case 3:
                height = width = 24;
                break;

            case 4:
                height = width = 32;
                break;

            case 5:
                height = width = 64;
                break;
        }
    }

    public void CreateMap()
    {
        for (int z = 0; z < height; z++)
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z);
            }
    }

    void CreateCell(int x, int z)
    {
        Vector3 position;

        if (x % 2 == 0)
        {
            position.x = x * 17.32f;
            position.y = 0f;
            position.z = z * 20f;
        }
        else
        {
            position.x = x * 17.32f;
            position.y = 0f;
            position.z = z * 20f + 10f;
        }

        HexCell cell = Instantiate(hex);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }

    public void Clear()
    {
        foreach (var e in map.GetComponentsInChildren<HexCell>())
        {
            Destroy(e.gameObject);
        }
    }

    void HandleInput()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            switch (brush)
            {
                case 0:
                    HexCell build = Instantiate(builds[DropDownBuilds.value]);
                    build.transform.SetParent(transform, false);
                    build.transform.localPosition = hit.transform.position;
                    Destroy(hit.transform.parent.gameObject);
                    break;

                case 1:
                    break;

                case 2:
                    HexCell cell = Instantiate(hexs[DropDownLands.value]);
                    cell.transform.SetParent(transform, false);
                    cell.transform.localPosition = hit.transform.position;
                    Destroy(hit.transform.parent.gameObject);
                    break;               
            }
        }
    }

    public void BuildBrush()
    {
        brush = 0;
    }

    public void UnitsBrush()
    {
        brush = 1;
    }

    public void LandsBrush()
    {
        brush = 2;
    }
}

    
