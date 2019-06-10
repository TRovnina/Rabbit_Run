using UnityEngine;

public class sphereBehavior : MonoBehaviour
{
    public static sphereBehavior Obj;
    private Rigidbody _rb; // Объявление новой переменной Rigidbody
    private bool _isMovingRight = true; // переменная, отражающая условное направление объекта
    private float speed = 5f; // Скорость движения объекта
    private float rotate = -90f;
    private Animator _animator;

    private bool _overOnce;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>(); // Получение доступа к Rigidbody
        _overOnce = false;
    }

    public Animator getAnimation()
    {
        return _animator;
    }

    void ChangeDirection()
    {
        _isMovingRight = !_isMovingRight;
        _rb.transform.Rotate(0f, rotate, 0f);
        rotate = -rotate;
    }

    void Update()
    {
        if (Manager.Obj.GameOver && !_overOnce) // && LifeManager.Obj.GetLives() == 0
        {
            Manager.Obj.Finish();
            _overOnce = true;
            return;
        }
           

        if (Input.GetKeyDown(KeyCode.Space) && !Manager.Obj.GameOver)
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

        if (other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            LifeManager.Obj.UpdateLives(1);
        }
    }

}