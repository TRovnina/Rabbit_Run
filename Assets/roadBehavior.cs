using UnityEngine;
using System.Collections;

public class roadBehavior : MonoBehaviour
{

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

        int random = Random.Range(0, 2);
        if (random == 0)
        { // Установить префаб по оси X
            GameObject _platform = Instantiate(road) as GameObject;
            _platform.transform.position = lastpos + new Vector3(1f, 0f, 0f);
            lastpos = _platform.transform.position;
        }
        else
        { // Установить префаб по оси Z
            GameObject _platform = Instantiate(road) as GameObject;
            _platform.transform.position = lastpos + new Vector3(0f, 0f, 1f);
            lastpos = _platform.transform.position;
        }

    }

}