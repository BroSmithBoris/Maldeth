using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexMap : MonoBehaviour
{
    public Dropdown DropDownSizeMap, DropDownLands, DropDownBuilds; //Списки размера карты, возможных поверхностей, возможных зданий
    byte width = 8, height = 8, brush = 2; //размеры карты и переменная для выбора возможной кисти
    public HexCell startHex; //Префаб начального гекса
    public GameObject map; //Пустой объект внутри которого создаются все элементы карты
    public HexCell[] lands, builds; //массивы возможных поверхностней, возможных зданий
    public GameObject LoadMap; //префаб карты для загрузки
    [HideInInspector]public HexCell[] AllHexs; //массив, содержащий всю карту

    private GameObject loadMap; //объект "загруженная карта"

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
        AllHexs = new HexCell[width * height];
        for (int z = 0, i = 0; z < height; z++)
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
    }

    void CreateCell(int x, int z, int i) //Создание начального гекса в определённых координатах
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

        HexCell cell = Instantiate(startHex);
        cell.x = position.x;
        cell.z = position.z;
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        AllHexs[i] = cell;
    }

    public void Clear() //Удаление карты
    {
        foreach (var e in map.GetComponentsInChildren<HexCell>())
        {
            Destroy(e.gameObject);
        }

        Destroy(loadMap);
    }

    void HandleInput() //Рисование кисточкой на карте
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            switch (brush)
            {
                case 0: //Здания
                    HexCell build = Instantiate(builds[DropDownBuilds.value]);
                    build.x = hit.transform.position.x;
                    build.z = hit.transform.position.z;
                    build.transform.SetParent(transform, false);
                    build.transform.localPosition = hit.transform.position;
                    ReplaceHex(build, hit.transform.position);
                    Destroy(hit.transform.parent.gameObject);
                    break;

                case 1: //Поверхность
                    HexCell land = Instantiate(lands[DropDownLands.value]);
                    land.x = hit.transform.position.x;
                    land.z = hit.transform.position.z;
                    land.transform.SetParent(transform, false);
                    land.transform.localPosition = hit.transform.position;
                    ReplaceHex(land, hit.transform.position);
                    Destroy(hit.transform.parent.gameObject);
                    break;
                
                case 2: //Дефолтная пустая кисть
                    break;
            }
        }
    }

    /* Выбор кисти рисования */
    public void BuildBrush()
    {
        brush = 0;
    }

    public void LandsBrush()
    {
        brush = 1;
    }

    public void MapLoading() //Загрузка карты
    {
        loadMap = Instantiate(LoadMap);
        loadMap.transform.position = Vector3.zero;
        var loadDropDownBuilds = GameObject.FindGameObjectWithTag("DropDownBuilds");
        var loadDropDownLands = GameObject.FindGameObjectWithTag("DropDownLands");
        DropDownBuilds = loadDropDownBuilds.GetComponentInChildren<Dropdown>();
        DropDownLands = loadDropDownLands.GetComponentInChildren<Dropdown>();
    }

    public void ReplaceHex(HexCell hex, Vector3 vector) //Замещает гекс в массиве при рисовании нового кистью
    {
        for (int i = 0; i < AllHexs.Length; i++)
        {
            if (AllHexs[i].x == vector.x && AllHexs[i].z == vector.z)
            {
                AllHexs[i] = hex;
                return;
            }
        }
    }
}

    
