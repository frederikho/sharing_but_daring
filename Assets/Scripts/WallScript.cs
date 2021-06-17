using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public float speed = -1.0f;
    private Rigidbody2D rb;
    private bool canSummonNewElement = true; //löschen? wird nicht gebraucht.
    public List<GameObject> wallPrefabs;

    public float spawnDistance = 15;
    public float destructionPoint = -15;
    public float triggerPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0.0f, speed);
        if (canSummonNewElement && transform.position.y <= triggerPoint)
        {
            summonNewElement();
        }

        if (transform.position.y <= destructionPoint)
        {
            Destroy(gameObject);
        }
    }

    void summonNewElement()
    {
        int wallIndex = UnityEngine.Random.Range(0, wallPrefabs.Count - 1);
        Instantiate(wallPrefabs[wallIndex], new Vector2(transform.position.x, transform.position.y + spawnDistance), Quaternion.identity);
        canSummonNewElement = false; 
    }
}
