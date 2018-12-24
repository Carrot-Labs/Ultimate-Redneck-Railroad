using UnityEngine;
using System.Collections;

public class terrain_generation : MonoBehaviour {

    [System.Serializable]
    public class EnviromentObject
    {
        public GameObject prefab;
        public int spawnCount;
    }

    public EnviromentObject[] enviromentObjs;

	// Use this for initialization
	void Start () {
       
        //get terrain info
        Terrain myTerrain = GetComponent<Terrain>();
        Vector3 terrainPos = myTerrain.GetPosition();
        Vector3 terrainSize = myTerrain.terrainData.size;

        //randomly distribute the enviromental objects on the map
        foreach (EnviromentObject obj in enviromentObjs)
        {
            //iterate through all spawns of the object
            for(int i = 0; i < obj.spawnCount; ++i)
            {
                Vector3 spawnLocal = generateRandom(terrainPos, terrainPos + terrainSize);
                //ignore height and replace with actual
                spawnLocal.y = myTerrain.SampleHeight(spawnLocal);
                Quaternion spawnRot = Quaternion.Euler(generateRandom(new Vector3(0,0,0), new Vector3(0,360,0)));
                Instantiate(obj.prefab, spawnLocal, spawnRot, GetComponent<Transform>());
            }
        }
	}

    Vector3 generateRandom(Vector3 min, Vector3 max)
    {
        Vector3 retval = new Vector3(Random.Range(min.x,max.x),
                                     Random.Range(min.y,max.y),
                                     Random.Range(min.z,max.z));
        return retval;
    }
}
