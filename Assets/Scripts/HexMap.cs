using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    public int width;
    public int height;
    public HexCell hex;

    HexCell[] cells;

    void Awake()
    {
        cells = new HexCell[height * width];

        for (int z = 0, i = 0; z < height; z++)
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }

        hex.gameObject.SetActive(false);
    }

    void CreateCell(int x, int z, int i)
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

        HexCell cell = cells[i] = Instantiate<HexCell>(hex);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }
}
