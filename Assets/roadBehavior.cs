using UnityEngine;

/**
 * Creates parts of road, diamonds and hearts
 */
public class RoadBehavior : MonoBehaviour
{
    public GameObject Heart;
    public GameObject Diamond;
    public GameObject Road;
    //coordinates of last prefab
    private Vector3 _lastpos = new Vector3(6f, 0f, 0f);

    void Start()
    {
        // create first 10 parts of road
        for (int i = 0; i < 10; i++)
        {
            GameObject platform = Instantiate(Road) as GameObject;
            platform.transform.position = _lastpos + new Vector3(3f, 0f, 0f);
            _lastpos = platform.transform.position;
        }

        InvokeRepeating("SpawnPlatform", 1f, 0.2f);

    }

    // creates parts of roads, diamond and hearts
    void SpawnPlatform()
    {
        if (Manager.Obj.GameOver)
            return;

        // make road
        int random = Random.Range(0, 2);
        GameObject platform = Instantiate(Road) as GameObject;

        if (random == 0)
        { // create prefab on X axis
            platform.transform.position = _lastpos + new Vector3(3f, 0f, 0f);
            _lastpos = platform.transform.position;
        }
        else
        { // create prefab on Z axis
            platform.transform.position = _lastpos + new Vector3(0f, 0f, 3f);
            _lastpos = platform.transform.position;
        }


        int rand = Random.Range(0, 4);
        // create diamonds
        if (rand < 1)
        {
            GameObject diamond = Instantiate(Diamond) as GameObject;
            diamond.transform.position = platform.transform.position + new Vector3(0f, 3.5f, 0f);
            return;
        }

        // create hearts
        if (rand == 2 && ScoreManager.Obj.GetScore() != 0 && ScoreManager.Obj.GetScore() % 5 == 0)
        {
            GameObject heart = Instantiate(Heart) as GameObject;
            heart.transform.position = platform.transform.position + new Vector3(0f, 3.5f, 0f);
        }
    }

}