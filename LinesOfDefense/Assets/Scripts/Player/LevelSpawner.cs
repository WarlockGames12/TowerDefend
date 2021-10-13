using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    public int[,] tileMaps = new int[,] {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3},
        { 0, 1, 4, 4, 4, 1, 1, 1, 1, 1, 1, 4, 4, 4, 1, 1, 3, 3},
        { 0, 1, 1, 1, 4, 1, 1, 1, 4, 4, 4, 4, 1, 4, 4, 1, 3, 3},
        { 0, 1, 4, 4, 4, 4, 4, 1, 4, 1, 1, 4, 1, 1, 4, 1, 3, 3},
        { 0, 1, 4, 1, 1, 1, 4, 1, 4, 4, 1, 4, 4, 1, 4, 4, 4, 5},
        { 0, 1, 4, 1, 1, 1, 4, 1, 1, 4, 1, 1, 4, 1, 4, 1, 3, 3},
        { 0, 1, 4, 1, 1, 1, 4, 1, 4, 4, 1, 1, 4, 4, 4, 1, 3, 3},
        { 0, 1, 4, 4, 4, 4, 4, 1, 4, 1, 1, 1, 1, 1, 1, 1, 3, 3},
        { 0, 1, 1, 1, 1, 1, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 3, 3}
    };
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
