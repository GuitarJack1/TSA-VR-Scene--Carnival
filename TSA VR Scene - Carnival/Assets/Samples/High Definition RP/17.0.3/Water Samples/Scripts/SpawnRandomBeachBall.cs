using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SpawnRandomBeachBall : MonoBehaviour
{
    public static float TimeBtwnEachBall = 0.1f;
    public float rangeAmplitude = 10;
    public float verticalSpeedMultiplier = 5;
    
    private float lastBeachBallSpawnedTime = 0f;
    

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if ((Time.realtimeSinceStartup - lastBeachBallSpawnedTime) >= TimeBtwnEachBall)
            {       
        
                if(PoolManager.Instances[PoolManager.InstanceType.Ball] != null)
                {
                    GameObject beachBall = PoolManager.Instances[PoolManager.InstanceType.Ball].getNextAvailable();
                    if(beachBall != null)
                    {
                        lastBeachBallSpawnedTime = Time.realtimeSinceStartup;
                        beachBall.transform.position = new Vector3(-2.5f, 4f, -2f);
                        
                        beachBall.GetComponent<Buoyancy>().targetSurface = this.GetComponent<WaterSurface>();
                        Vector3 randomForce = new Vector3(Random.Range(-rangeAmplitude, rangeAmplitude), -Random.Range(0, verticalSpeedMultiplier * rangeAmplitude), Random.Range(-rangeAmplitude, rangeAmplitude));
                        beachBall.SetActive(true);
                        beachBall.GetComponent<Rigidbody>().AddForce(randomForce, ForceMode.Impulse);
                    }
                }
                
            }
        }
        
            
        
    }
}
