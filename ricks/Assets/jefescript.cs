using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefescript : MonoBehaviour
{
    public GameObject money; // Prefab for the money
    public float moneyOffsetY = 1.0f;

    void Start()
    {
        if (money == null)
        {
            Debug.LogError("Money prefab has not been assigned in the inspector.");
            return;
        }

        StartCoroutine(SpawnJefeWithMoney());
    }


    private IEnumerator SpawnJefeWithMoney()
    {
        while (true) // This will continuously spawn money for the jefe.
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f)); // Wait for a random time before spawning the next money.

            // Find the jefe GameObject in the scene
            GameObject jefe = GameObject.FindGameObjectWithTag("Jefe");
            if (jefe == null)
            {
                Debug.LogError("Jefe GameObject not found in the scene.");
                yield break;
            }

            // Instantiate the money above the jefe
            GameObject spawnedMoney = Instantiate(money, jefe.transform.position + new Vector3(0, moneyOffsetY, 0), Quaternion.identity);
            spawnedMoney.transform.localScale = new Vector3(0.4f, 0.4f, 0.2f);
            spawnedMoney.transform.SetParent(jefe.transform, false);
        }
    }
}
