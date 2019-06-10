using UnityEngine;
using System.Collections;

public class playerFalls : MonoBehaviour
{

    public static playerFalls Obj;
    private Rigidbody _rb;
    private Animator _animator;
    private float _speed = 15f;

    void Start()
    {
        if (Obj == null)
            Obj = this;
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        RaycastHit hit;
        //print(Physics.Raycast(transform.position, Vector3.down, out hit, 1f));
        if (!(Physics.Raycast(_rb.transform.position, Vector3.down, out hit, 1f) && hit.transform.gameObject.tag == "Ground"))
        {
            _rb.useGravity = true;
            _rb.velocity = _rb.transform.eulerAngles.y == 0 ? new Vector3(0f, -10f, _speed)
                : new Vector3(_speed, -10f, 0f);
            Manager.Obj.GameOver = true;
            _animator.enabled = false;
        }

    }

}