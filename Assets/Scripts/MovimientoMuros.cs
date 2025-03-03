using UnityEngine;

public class MomimientoMuro : MonoBehaviour
{

    [SerializeField] private float velocidadMuro = 10f;
    [SerializeField] private float ladoMuro = 5;
    [SerializeField] private float alturaMuro = 1.5f;
    [SerializeField] private GameObject[] spheres;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * velocidadMuro;
        velocidadMuro += 0.05f * Time.deltaTime;


        if (transform.position.z < -55)
        {
            transform.position = new Vector3(Random.Range(-ladoMuro, ladoMuro), Random.Range(0, alturaMuro), 55);
            
            for (int i = 0; i < spheres.Length; i++)
            {
                spheres[i].SetActive(true);
            }
            
        }



    }
}