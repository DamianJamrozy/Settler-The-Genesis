using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiger : MonoBehaviour
{
    public static SpawnTiger Instance;
    public GameObject pref;


    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(float time)
    {

    }

    public IEnumerator spawnAnimal(float interval)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(pref, new Vector3(85.4f, 1.04f, 2030.25f), Quaternion.identity);
    }

}
