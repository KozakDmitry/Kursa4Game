using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapGenerator : MonoBehaviour
{

    public Tilemap tilemap;

    public TileBase tile;
	public TileBase tileRiver;
	public TileBase tileRoad;
    public int width;
    public int height;

    public MapSettings mapSettingFirst;
	public MapSettings RiverSetting;
	public MapSettings MapSettingSecond;

	private void Start()
	{
		Generate();
	}
	// Start is called before the first frame update
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ClearMap();
            Generate();
		}
    }

	private bool CoreyanRandom()
	{
		return Random.Range(0,2)>0?true:false;
	}


	public void Generate()
	{
		ClearMap();
		int[,] map = new int[width, height];
		float seed;
		if (mapSettingFirst.randomSeed)
		{
			seed = Time.time;
		}
		else
		{
			seed = mapSettingFirst.seed;
		}
		bool river = CoreyanRandom();
		map = MapFunctions.GenerateCellularAutomata(width, height, seed, mapSettingFirst.fillAmount, mapSettingFirst.edgesAreWalls);
		map = MapFunctions.SmoothVNCellularAutomata(map, mapSettingFirst.edgesAreWalls, mapSettingFirst.smoothAmount);
		if (river)
			map = MapFunctions.DirectionalTunnel(map, RiverSetting.minPathWidth, RiverSetting.maxPathWidth, RiverSetting.maxPathChange, RiverSetting.roughness, RiverSetting.windyness);
		map = MapFunctions.RandomRoad(map);
		MapFunctions.RenderMap(map, tilemap, tile, tileRiver, tileRoad) ;
		
	}
	[ExecuteInEditMode]
	public void GenerateMap()
	{
		ClearMap();
		int[,] map = new int[width, height];
		float seed;
		if (mapSettingFirst.randomSeed)
		{
			seed = Time.time;
		}
		else
		{
			seed = mapSettingFirst.seed;
		}

		//Generate the map depending omapSen the algorithm selected
		switch (mapSettingFirst.algorithm)
		{
			//case Algorithm.PerlinSmoothed:
			//	//First generate our array
			//	map = MapFunctions.GenerateArray(width, height, true);
			//	//Next generate the perlin noise onto the array
			//	map = MapFunctions.PerlinNoiseSmooth(map, seed, mapSettingFirst.interval);
			//	break;
			//case Algorithm.PerlinCave:
			//	//First generate our array
			//	map = MapFunctions.GenerateArray(width, height, true);
			//	//Next generate the perlin noise onto the array
			//	map = MapFunctions.PerlinNoiseCave(map, mapSettingFirst.modifier, mapSettingFirst.edgesAreWalls);
			//	break;
			//case Algorithm.RandomWalkTop:
			//	//First generate our array
			//	map = MapFunctions.GenerateArray(width, height, true);
			//	//Next generater the random top
			//	map = MapFunctions.RandomWalkTop(map, seed);
			//	break;
			//case Algorithm.RandomWalkTopSmoothed:
			//	//First generate our array
			//	map = MapFunctions.GenerateArray(width, height, true);
			//	//Next generate the smoothed random top
			//	map = MapFunctions.RandomWalkTopSmoothed(map, seed, mapSettingFirst.interval);
			//	break;
			//case Algorithm.RandomWalkCave:
			//	//First generate our array
			//	map = MapFunctions.GenerateArray(width, height, false);
			//	//Next generate the random walk cave
			//	map = MapFunctions.RandomWalkCave(map, seed, mapSettingFirst.clearAmount);
			//	break;
			//case Algorithm.RandomWalkCaveCustom:
			//	//First generate our array
			//	map = MapFunctions.GenerateArray(width, height, false);
			//	//Next generate the custom random walk cave
			//	map = MapFunctions.RandomWalkCaveCustom(map, seed, mapSettingFirst.clearAmount);
			//	break;
			case Algorithm.CellularAutomataVonNeuman:
				//First generate the cellular automata array
				map = MapFunctions.GenerateCellularAutomata(width, height, seed, mapSettingFirst.fillAmount, mapSettingFirst.edgesAreWalls);
				//Next smooth out the array using the von neumann rules
				map = MapFunctions.SmoothVNCellularAutomata(map, mapSettingFirst.edgesAreWalls, mapSettingFirst.smoothAmount);
				break;
			case Algorithm.CellularAutomataMoore:
				//First generate the cellular automata array
				map = MapFunctions.GenerateCellularAutomata(width, height, seed, mapSettingFirst.fillAmount, mapSettingFirst.edgesAreWalls);
				//Next smooth out the array using the Moore rules
				map = MapFunctions.SmoothMooreCellularAutomata(map, mapSettingFirst.edgesAreWalls, mapSettingFirst.smoothAmount);
				break;
			case Algorithm.DirectionalTunnel:
				//First generate our array
				map = MapFunctions.GenerateArray(width, height, false);
				//Next generate the tunnel through the array
				map = MapFunctions.DirectionalTunnel(map, mapSettingFirst.minPathWidth, mapSettingFirst.maxPathWidth, mapSettingFirst.maxPathChange, mapSettingFirst.roughness, mapSettingFirst.windyness);
				break;
		}
		//Render the result
		//MapFunctions.RenderMap(map, tilemap, tile,tileRiver);
	}

	public void ClearMap()
	{
		tilemap.ClearAllTiles();
	}
}
