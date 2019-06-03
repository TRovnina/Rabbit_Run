﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.XR.WSA.Sharing;

public class sphereBehavior : MonoBehaviour
{

    private Rigidbody rb; // Объявление новой переменной Rigidbody
    private bool isMovingRight = true; // переменная, отражающая условное направление объекта
    private float speed = 5f; // Скорость движения объекта

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получение доступа к Rigidbody
    }

    void ChangeDirection()
    {
        isMovingRight = !isMovingRight;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))//MouseButtonDown(0))
        {
            ChangeDirection();
            scoreManager.incrementScore(1);
        }

        if (isMovingRight)
        {
            rb.velocity = new Vector3(speed, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, speed);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Console.WriteLine("diamond");
            Destroy(other.gameObject);
            scoreManager.incrementScore(2);
        }
    }

}