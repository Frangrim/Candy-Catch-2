using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    float MaxX; // Max value of x positon of Candy

    public GameObject[] Candies; // Array of Candy objects
    public GameObject[] Veggies; // Array of Veggie objects

    public int spawnInterval = 2;

    int spawnGenerator;

    // Creating this instance allows easy access to the spawner
    // elsewhere in the code.
    public static ObjectSpawner instance;

    // This method says that if there is no reference of
    // this instance, then this is the instance. I think. 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawningObjects();
    }

    // Update is called once per frame
    void Update()
    {
        // Generate a random number to determine what object is spawned
        spawnGenerator = Random.Range(0, 11);
    }

    void SpawnCandy()
    {
        int randomCandy = Random.Range(0, Candies.Length); // Selects randomly from Candy array

        float randX = Random.Range(-MaxX, MaxX); // Random value for the candy spawner,
                                                 // between the max X value and its inverse. 

        // Generating a position with a randomized x value.
        Vector3 randomPos = new Vector3(randX, transform.position.y, transform.position.z);

        // Create an object (Which, where, rotation).
        //           Candy Array,  Random X,        Unchanged
        Instantiate(Candies[randomCandy], randomPos, transform.rotation);
    }

    void SpawnVeggie()
    {
        int randomVeggie = Random.Range(0, Veggies.Length); // Selects randomly from Veggie array

        float randX = Random.Range(-MaxX, MaxX); // Random value for the veggie spawner,
                                                 // between the max X value and its inverse. 

        // Generating a position with a randomized x value.
        Vector3 randomPos = new Vector3(randX, transform.position.y, transform.position.z);

        // Create an object (Which, where, rotation).
        //           Veggie Array,  Random X,        Unchanged
        Instantiate(Veggies[randomVeggie], randomPos, transform.rotation);
    }

    IEnumerator SpawnObjects()
    {
        // This coroutine begins by waiting for
        // 2 seconds before it does anything.

        yield return new WaitForSeconds(2f);

        // This while loop will spawn a new object
        // every (spawnInterval) seconds
        while (true)
        {
            // Spawns either candy, veggie, or both depending on the random number
            if (spawnGenerator > 0 && spawnGenerator <= 5)
            {
                SpawnCandy();
                print("Candy");
            }
            else if (spawnGenerator >= 6 && spawnGenerator <= 9)
            {
                SpawnVeggie();
                print("Veggie");
            }
            else if (spawnGenerator == 10)
            {
                SpawnCandy();
                SpawnVeggie();
                print("Both!");
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // These two methods are just to start and stop the
    // couroutine that spawns the candy. 


    public void StartSpawningObjects()
    {
        StartCoroutine("SpawnObjects");
    }

    public void StopSpawningObjects()
    {
        StopCoroutine("SpawnObjects"); // I don't know why, but the name as a string seems to work better than as a function.
    }
}
