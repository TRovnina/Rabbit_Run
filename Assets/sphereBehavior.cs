using System;
using UnityEngine;
using System.Collections;
using UnityEngine.XR.WSA.Sharing;

public class sphereBehavior : MonoBehaviour
{

    private Rigidbody _rb; // Объявление новой переменной Rigidbody
    private bool _isMovingRight = true; // переменная, отражающая условное направление объекта
    private float speed = 5f; // Скорость движения объекта
    private float rotate = -90f;

    private bool _overOnce;

    void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Получение доступа к Rigidbody
        _overOnce = false;
    }

    void ChangeDirection()
    {
        _isMovingRight = !_isMovingRight;
        _rb.transform.Rotate(0f, rotate, 0f);
        rotate = -rotate;
    }

    void Update()
    {
        if (Manager.Obj.GameOver && !_overOnce)
        {
            Manager.Obj.Finish();
            _overOnce = true;
            return;
        }
           

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
            scoreManager.Obj.IncrementScore(1);
        }

        //_rb.velocity = _isMovingRight ? new Vector3(speed, 0f, 0f) 
        //    : new Vector3(0f, 0f, speed);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            scoreManager.Obj.IncrementScore(2);
        }
    }

}