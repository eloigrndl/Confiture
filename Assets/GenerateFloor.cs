using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{

    public GameObject building;
    public GameObject AICar;
    public GameObject player;
    public int densityBuildings;
    public int amountCars;

    int MAX_WIDTH = 500;
    int MAX_HEIGHT = 500;

    public GameObject[] buildings;

    public GameObject[] AICars;

    // Start is called before the first frame update
    void Start()
    {
        buildings = new GameObject[densityBuildings];

        AICars = new GameObject[amountCars];

        for (int i=0;i<densityBuildings;i++) {
            float x=0;
            float z=0;
            do {
                x = Random.Range(-MAX_WIDTH/2,MAX_WIDTH/2);
                z = Random.Range(-MAX_HEIGHT/2,MAX_HEIGHT/2);
            } while(Vector3.Distance(new Vector3(x,0,z),player.transform.position) < 10f);
            
            buildings[i] = (GameObject)Instantiate(building, new Vector3(x,gameObject.transform.position.y+building.transform.localScale.y/2,z), Quaternion.identity);
        }

        for (int i=0;i<amountCars;i++) {
            float x=0;
            float z=0;
            bool occupied = false;
            do {
                x = Random.Range(-MAX_WIDTH/2,MAX_WIDTH/2);
                z = Random.Range(-MAX_HEIGHT/2,MAX_HEIGHT/2);

                occupied = false;
                for (int j=0;j<densityBuildings;j++) {
                    if (Vector3.Distance(new Vector3(x,0,z),buildings[j].transform.position) < 10f) {
                        occupied = true;
                        break;
                    }
                }

            } while(!occupied && Vector3.Distance(new Vector3(x,0,z),player.transform.position) < 10f);

            AICars[i] = (GameObject)Instantiate(AICar, new Vector3(x,gameObject.transform.position.y+1f,z), Quaternion.identity);
        }
    }

    int interval = 1;
    float nextTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime) {
              for (int i=0;i<amountCars;i++) {
                if (AICars[i]==null) {
                    float x=0;
                    float z=0;
                    bool occupied = false;
                    do {
                        x = Random.Range(-MAX_WIDTH/2,MAX_WIDTH/2);
                        z = Random.Range(-MAX_HEIGHT/2,MAX_HEIGHT/2);

                        occupied = false;
                        for (int j=0;j<densityBuildings;j++) {
                            if (Vector3.Distance(new Vector3(x,0,z),buildings[j].transform.position) < 10f) {
                                occupied = true;
                                break;
                            }
                        }

                    } while(!occupied && Vector3.Distance(new Vector3(x,0,z),player.transform.position) < 10f);
                    AICars[i] = (GameObject)Instantiate(AICar, new Vector3(x,gameObject.transform.position.y+1f,z), Quaternion.identity);
                }
              }
 
              nextTime += interval; 
         }
    }
}   