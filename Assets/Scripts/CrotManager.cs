using UnityEngine;
using System.Collections;
using System;

public class CrotManager : MonoBehaviour
{
    public Cell cell;
    public Crot crot;
    public Cell[,] cells = new Cell[3, 3];
    public float timer = 0, spawnTime = 1;
    public Vector2 hotSpot = Vector2.zero;
    
    void Start()
    {
        CreateCells();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            CreateCrot();
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0){// Пауза
                Time.timeScale = 1;
            }
            else{// Продолжить
                Time.timeScale = 0;
            }
        }
    }

    void CreateCells()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        cells[0, 0] = (Cell)Instantiate(cell, pos, Quaternion.identity);
        pos = new Vector3(1, -1, 0);//
        cells[1, 0] = (Cell)Instantiate(cell, pos, Quaternion.identity);
        pos = new Vector3(2, 0, 0);//
        cells[1, 1] = (Cell)Instantiate(cell, pos, Quaternion.identity);
        pos = new Vector3(3, -1, 0);//
        cells[2, 1] = (Cell)Instantiate(cell, pos, Quaternion.identity);
        pos = new Vector3(4, 0, 0);//
        cells[2, 2] = (Cell)Instantiate(cell, pos, Quaternion.identity);
    }

    void CreateCrot()
    {
        try{
            int x = UnityEngine.Random.Range(0, cells.GetLength(0)), y = UnityEngine.Random.Range(0, cells.GetLength(0));
            if (!cells[x, y].GetComponentInChildren<Crot>()){
                Crot c = (Crot)Instantiate(crot, cells[x, y].GetComponentInChildren<SpawnPosition>().transform.position, Quaternion.identity);
                c.transform.SetParent(cells[x, y].transform);
            }
        }
        catch (NullReferenceException){
            
        }
    }
}
