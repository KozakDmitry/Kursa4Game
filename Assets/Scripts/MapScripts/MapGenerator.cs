using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapGenerator : MonoBehaviour
{

    public Tilemap tilemap;

    public TileBase tile;
    public int width;
    public int height;

    public MapSettings mapSetting;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ClearMap();
            GenerateMap();
		}
    }

	[ExecuteInEditMode]
	public void GenerateMap()
	{
		ClearMap();
		int[,] map = new int[width, height];
		float seed;
		if (mapSetting.randomSeed)
		{
			seed = Time.time;
		}
		else
		{
			seed = mapSetting.seed;
		}

		//Generate the map depending omapSen the algorithm selected
		switch (mapSetting.algorithm)
		{
			case Algorithm.Perlin:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, true);
				//Next generate the perlin noise onto the array
				map = MapFunctions.PerlinNoise(map, seed);
				break;
			case Algorithm.PerlinSmoothed:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, true);
				//Next generate the perlin noise onto the array
				map = MapFunctions.PerlinNoiseSmooth(map, seed, mapSetting.interval);
				break;
			case Algorithm.PerlinCave:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, true);
				//Next generate the perlin noise onto the array
				map = MapFunctions.PerlinNoiseCave(map, mapSetting.modifier, mapSetting.edgesAreWalls);
				break;
			case Algorithm.RandomWalkTop:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, true);
				//Next generater the random top
				map = MapFunctions.RandomWalkTop(map, seed);
				break;
			case Algorithm.RandomWalkTopSmoothed:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, true);
				//Next generate the smoothed random top
				map = MapFunctions.RandomWalkTopSmoothed(map, seed, mapSetting.interval);
				break;
			case Algorithm.RandomWalkCave:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, false);
				//Next generate the random walk cave
				map = MapFunctions.RandomWalkCave(map, seed, mapSetting.clearAmount);
				break;
			case Algorithm.RandomWalkCaveCustom:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, false);
				//Next generate the custom random walk cave
				map = MapFunctions.RandomWalkCaveCustom(map, seed, mapSetting.clearAmount);
				break;
			case Algorithm.CellularAutomataVonNeuman:
				//First generate the cellular automata array
				map = MapFunctions.GenerateCellularAutomata(width, height, seed, mapSetting.fillAmount, mapSetting.edgesAreWalls);
				//Next smooth out the array using the von neumann rules
				map = MapFunctions.SmoothVNCellularAutomata(map, mapSetting.edgesAreWalls, mapSetting.smoothAmount);
				break;
			case Algorithm.CellularAutomataMoore:
				//First generate the cellular automata array
				map = MapFunctions.GenerateCellularAutomata(width, height, seed, mapSetting.fillAmount, mapSetting.edgesAreWalls);
				//Next smooth out the array using the Moore rules
				map = MapFunctions.SmoothMooreCellularAutomata(map, mapSetting.edgesAreWalls, mapSetting.smoothAmount);
				break;
			case Algorithm.DirectionalTunnel:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, false);
				//Next generate the tunnel through the array
				map = MapFunctions.DirectionalTunnel(map, mapSetting.minPathWidth, mapSetting.maxPathWidth, mapSetting.maxPathChange, mapSetting.roughness, mapSetting.windyness);
				break;
		}
		//Render the result
		MapFunctions.RenderMap(map, tilemap, tile);
	}

	public void ClearMap()
	{
		tilemap.ClearAllTiles();
	}
}
