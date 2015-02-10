using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Perlin
{
	public string name = "PairName";
	public float NoiseScale = 0.1f;
	public float HeightScale = 1;
	public float HeightOffset = 0;
	public AnimationCurve blendCurve;

	public float GetValue(float x, float z)
	{
		return HeightOffset + (Mathf.PerlinNoise((2048 + x) * NoiseScale,(2048 + z) * NoiseScale) * HeightScale);
	}
}

/// A place to store miscellaneous global parameters.
public class GameParameters : ScriptableObject 
{
    // Convenience method for accessing GameParameters asset
    public static GameParameters Instance
    {
        get
        {
            if (_instance == null)
                _instance = (GameParameters)Resources.Load("GameParameters", typeof(GameParameters));
            return _instance;
        }
    }
    static GameParameters _instance;

	// Global Game Params
	public string GameName;
	public int Version = 1;

	// World Game Params
	public GameObject Hexagon;

	public List<Color> Colors = new List<Color>();

	public List<Perlin> PerlinGroups = new List<Perlin>();
}
