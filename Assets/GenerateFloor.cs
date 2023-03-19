using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{
    public GameObject AICar;
    public GameObject player;
    public int amountCars;

    int MAX_WIDTH = 500;
    int MAX_HEIGHT = 500;

    public GameObject[] AICars;

    // Start is called before the first frame update
    void Start()
    {
        AICars = new GameObject[amountCars];

        for (int i=0;i<amountCars;i++) {
            float x=0;
            float z=0;
            do {
                x = Random.Range(-MAX_WIDTH/2,MAX_WIDTH/2);
                z = Random.Range(-MAX_HEIGHT/2,MAX_HEIGHT/2);
            } while(Vector3.Distance(new Vector3(x,0,z),player.transform.position) < 10f);

            AICars[i] = (GameObject)Instantiate(AICar, new Vector3(x,gameObject.transform.position.y+1f,z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}   