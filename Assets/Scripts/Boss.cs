using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public List<GameObject> fires { get; set; } = new List<GameObject>();
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fires.Count == 4)
        {
            foreach(var fire in fires)
            {
                Destroy(fire);
            }
            body.SetActive(true);
        }
    }
}
