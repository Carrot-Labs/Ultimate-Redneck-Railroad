using UnityEngine;
using System.Collections;

public class terrain_createNext : MonoBehaviour {

    public float spawnPos = 0;
    public float offset = 0;

    private bool neverSpawned = true;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    //if past the position to spawn next terrain element then spawn
        if(transform.position.x < spawnPos && neverSpawned)
        {
            neverSpawned = false;
            //spawn new terrain
            Vector3 localShift = new Vector3();
            localShift.x = GetComponent<Terrain>().terrainData.size.x + offset;
            localShift.y = 0;
            localShift.z = 0;
            Quaternion rotation = Quaternion.identity;
            GameObject newTerrain = (GameObject)(Instantiate(this.gameObject, transform.position + localShift, 
                                                             this.transform.rotation * rotation,this.transform.parent));
        }
	}
}
