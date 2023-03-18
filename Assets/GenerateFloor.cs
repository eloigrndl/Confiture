using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{

    public GameObject building;
    public GameObject player;
    public int densityBuildings;

    int MAX_WIDTH = 500;
    int MAX_HEIGHT = 500;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<densityBuildings;i++) {
            int x = Random.Range(-MAX_WIDTH/2,MAX_WIDTH/2);
            int z = Random.Range(-MAX_HEIGHT/2,MAX_HEIGHT/2);
            if (Vector3.Distance(new Vector3(x,0,z),player.transform.position) > 10f) {
                Instantiate(building, new Vector3(x,gameObject.transform.position.y+building.transform.localScale.y/2,z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
