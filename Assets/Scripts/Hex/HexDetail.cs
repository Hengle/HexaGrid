using UnityEngine;
using System.Collections;

public class HexDetail : MonoBehaviour 
{
	void OnEnable() // Convert to Vertex Colours to enable batching again
	{
		MeshFilter mf = GetComponent<MeshFilter>();
		Mesh m = mf.mesh;
		float y = transform.position.y;

		Color randOffset = new Color(Random.value,Random.value,Random.value,1.0f) * 0.05f;

		Color[] cols = m.colors;
		if (cols.Length == 0)
			cols = new Color[m.vertices.Length];

		for(int i = 0; i < cols.Length; ++i)
		{
			if (y > 64.0f)
			{
				cols[i] = GameParameters.Instance.Colors[0] + randOffset;
			}
			else if (y > 32.0f)
			{
				cols[i] = GameParameters.Instance.Colors[1] + randOffset;
			}
			else if ( y > 4.0f)
			{
				cols[i] = GameParameters.Instance.Colors[2] + randOffset;
			}
			else if ( y > 3.0f)
			{
				cols[i] = GameParameters.Instance.Colors[3] + randOffset;
			}
			else if ( y > 0.5f)
			{
				cols[i] = GameParameters.Instance.Colors[3] + randOffset;
			}
		}

		m.colors = cols;
		mf.mesh = m;
	}
}
