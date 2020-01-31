using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexMap : MonoBehaviour
{
    public Dropdown DropDownSizeMap, DropDownLands, DropDownBuilds; //Списки размера карты, возможных поверхностей, возможных зданий
    byte width = 8, height = 8, brush = 3; //размеры карты и переменная для выбора возможной кисти
    public HexCell hex; //Префаб основного гекса
    public GameObject map; //Пустой объект внутри которого создаются все элементы карты
    public HexCell[] hexs, builds; //массивы возможных поверхностней, возможных зданий
    public Texture2D CursorTexture; //текстура курсора

    void Update()
    {
        if (Input.GetMouseButton(0))
            HandleInput();
    }

    public void ChangeValueMap() //Изменение размеров для создания новой карты
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

    public void CreateMap() //Создание начальной карты определённых размеров
    {
        for (int z = 0; z < height; z++)
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z);
            }
    }

    void CreateCell(int x, int z) //Создание начального гекса в определённых координатах
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

    public void Clear() //Удаление карты
    {
        foreach (var e in map.GetComponentsInChildren<HexCell>())
        {
            Destroy(e.gameObject);
        }
    }

    void HandleInput() //Рисование кисточкой на карте
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            switch (brush)
            {
                case 0: //Здания
                    HexCell build = Instantiate(builds[DropDownBuilds.value]);
                    build.transform.SetParent(transform, false);
                    build.transform.localPosition = hit.transform.position;
                    Destroy(hit.transform.parent.gameObject);
                    break;

                case 1: //Юниты
                    break;

                case 2: //Поверхность
                    HexCell land = Instantiate(hexs[DropDownLands.value]);
                    land.transform.SetParent(transform, false);
                    land.transform.localPosition = hit.transform.position;
                    Destroy(hit.transform.parent.gameObject);
                    break;
                
                case 3:
                    break;
            }
        }
    }

    /* Выбор кисти рисования */
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

    
