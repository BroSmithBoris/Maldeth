﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexMap : MonoBehaviour
{
    public Dropdown dropdown;
    int width;
    int height;
    public HexCell hex;
    public GameObject map;

    public void ChangeValueMap()
    {
        switch (dropdown.value)
        {
            case 0:
                break;

            case 1:
                height = 8;
                width = 8;
                break;

            case 2:
                height = 16;
                width = 16;
                break;

            case 3:
                height = 20;
                width = 20;
                break;

            case 4:
                height = 24;
                width = 24;
                break;

            case 5:
                height = 32;
                width = 32;
                break;

            case 6:
                height = 64;
                width = 64;
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
}
