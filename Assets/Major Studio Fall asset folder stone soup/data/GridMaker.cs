using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{

    public GameObject tilePrefab;
    public GameObject gridContainer;
    public int width;
    public int height;

    public float yOffset;
    public float xOffset;

    [SerializeField]
    Color grassColor, mountainColor, sandColor, waterColor, forestColor;

    GameObject[,] tilesInGrid;
    
    int seed;

    // Start is called before the first frame update
    void Start()
    {
        seed = Random.Range(0, 100000);

        tilesInGrid = new GameObject[width, height];
        for(int i = 0; i < width; i++){
            for(int k = 0; k < height; k++){
                MakeTile(i, k);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeTile(int i, int k){
        GameObject newTile = Instantiate(tilePrefab, gridContainer.transform.position, gridContainer.transform.rotation);

        newTile.transform.SetParent(gridContainer.transform);

        float noise = Mathf.PerlinNoise((float)(seed + i)/10, (float)(k+seed)/10);
        if(noise < 0.3f){
            newTile.GetComponent<SpriteRenderer>().color = grassColor;
        } else if(noise >= 0.3f && noise < 0.5f){
            newTile.GetComponent<SpriteRenderer>().color = forestColor;
        } else if(noise >= 0.5f && noise < 0.7f){
            newTile.GetComponent<SpriteRenderer>().color = waterColor;
        } else if(noise >= 0.7f && noise < 0.8f){
            newTile.GetComponent<SpriteRenderer>().color = mountainColor;
        } else if(noise >= 0.8f){
            newTile.GetComponent<SpriteRenderer>().color = sandColor;
        }

       
        newTile.transform.position = new Vector3((i + k * 0.5f - k/2) * xOffset, (k * yOffset)/2);

        tilesInGrid[i,k] = newTile;
    }




}
