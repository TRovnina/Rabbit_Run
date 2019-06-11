using UnityEngine;

/**
 * Controls behavior of the Player. Change directions and check for collisions
 */
public class PlayerBehavior : MonoBehaviour
{
    // class object to avoid static methods
    public static PlayerBehavior Obj;
    // Player
    private Rigidbody _rb;
    // variable reflecting the conditional direction of the object
    private bool _isMovingRight = true;
    // variable reflecting the rotation of the object
    private float _rotate = -90f;
    // Player animation
    private Animator _animator;
    // variable for ending game
    private bool _overOnce;
    // Player sounds
    private AudioSource _musicSource;

    void Start()
    {
        //initialize variables
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _overOnce = false;
        _musicSource = GetComponent<AudioSource>();
    }

    //change Player direction and rotation
    void ChangeDirection()
    {
        _isMovingRight = !_isMovingRight;
        _rb.transform.Rotate(0f, _rotate, 0f);
        _rotate = -_rotate;
    }

    void Update()
    {
        //stop Player if game is over
        if (Manager.Obj.GameOver && !_overOnce)
        {
            LifeManager.Obj.UpdateLives(-1);
            _overOnce = true;

            //if Player has no lives end game
            if(LifeManager.Obj.GetLives() == 0)
                Manager.Obj.Finish();
           
            return;
        }
           
        //control direction of Player
        if (Input.GetKeyDown(KeyCode.Space) && !Manager.Obj.GameOver)
        {
            ChangeDirection();
            ScoreManager.Obj.IncrementScore(1);
        }
    }

    // check collisions with diamonds and hearts
    private void OnCollisionEnter(Collision other)
    {
        // collision with diamond
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            if (AudioHelper.SoundsOn)
                _musicSource.Play();
            ScoreManager.Obj.IncrementScore(2);
        }
        // collision with heart
        else if (other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            if (AudioHelper.SoundsOn)
                _musicSource.Play();
            LifeManager.Obj.UpdateLives(1);
        }
    }

}