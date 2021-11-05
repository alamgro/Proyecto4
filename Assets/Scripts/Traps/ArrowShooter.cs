using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowShooter : MonoBehaviour
{
    [SerializeField] private GameObject pfbArrow; //Arrow prefab
    [SerializeField] private float spawnTime;
    private List<GameObject> poolArrows;
    WaitForSecondsRealtime wait;

    void Start()
    {
        poolArrows = new List<GameObject>();

        wait = new WaitForSecondsRealtime(spawnTime); //Store WaitForSeconds to avoid generating garbage
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        //Infinite arrow spawner
        while (true)
        {
            yield return wait;
            GameObject go = GenerateArrow();
            go.GetComponent<Arrow>().Throw(transform.forward); //Set shot direction and shoot (same as the arrow shooter)
        }
    }

    private GameObject GenerateArrow()
    {
        for(int i = 0; i < poolArrows.Count; i++)
        {
            if (!poolArrows[i].activeSelf){
                poolArrows[i].SetActive(true);
                poolArrows[i].transform.position = transform.position; //Volver a la posición del lan
                poolArrows[i].transform.rotation = transform.rotation;
                return poolArrows[i];
            }
        }
        poolArrows.Add(Instantiate(pfbArrow, transform.position, transform.rotation));
        return poolArrows[poolArrows.Count - 1];
    }

    //Destroy arrows when this item is destroyed
    private void OnDestroy()
    {
        foreach (GameObject arrow in poolArrows)
        {
            Destroy(arrow);
        }
    }
}
