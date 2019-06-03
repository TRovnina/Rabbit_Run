using UnityEngine;
using System.Collections;

public class roadBehavior : MonoBehaviour
{
    public GameObject diamond;
    public GameObject road; // Префаб участка пути
    private Vector3 lastpos = new Vector3(0f, 0f, 0f); // Координаты установленного префаба

    void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject _platform = Instantiate(road) as GameObject;
            _platform.transform.position = lastpos + new Vector3(1f, 0f, 0f);
            lastpos = _platform.transform.position;
        }

        InvokeRepeating("SpawnPlatform", 1f, 0.2f);

    }

    void SpawnPlatform()
    {
        if (GameObject.FindGameObjectWithTag("Falling") != null)
            return;

        int random = Random.Range(0, 2);
        GameObject _platform = Instantiate(road) as GameObject;

        if (random == 0)
        { // Установить префаб по оси X
            _platform.transform.position = lastpos + new Vector3(1f, 0f, 0f);
            lastpos = _platform.transform.position;
        }
        else
        { // Установить префаб по оси Z
            _platform.transform.position = lastpos + new Vector3(0f, 0f, 1f);
            lastpos = _platform.transform.position;
        }

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            GameObject _diamond = Instantiate(diamond) as GameObject;
            _diamond.transform.position = _platform.transform.position + new Vector3(0f, 1f, 0f);
        }
    }

}