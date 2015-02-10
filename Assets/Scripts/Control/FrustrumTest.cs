using UnityEngine;
using System.Collections;

public class FrustrumTest : MonoBehaviour 
{
	Plane[] planes;
	public GameObject FrustrumParent;

	void FixedUpdate()
	{
		planes = GeometryUtility.CalculateFrustumPlanes(camera);
		for(int i = 0; i < FrustrumParent.transform.childCount; ++i)
		{
			GameObject go = FrustrumParent.transform.GetChild(i).gameObject;
			if(GeometryUtility.TestPlanesAABB(planes, go.collider.bounds))
				go.SetActive(true);
			else if ((go.transform.position - camera.transform.position).sqrMagnitude > 128.0f)
				go.SetActive(false);
		}
	}
}
