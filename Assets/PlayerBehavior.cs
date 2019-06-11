using UnityEngine;

/**
 * Controls behavior of the player. Change directions and check for collisions
 */
public class PlayerBehavior : MonoBehaviour
{
    // class object to avoid static methods
    public static PlayerBehavior Obj;
    // player
    private Rigidbody _rb;
    // variable reflecting the conditional direction of the object
    private bool _isMovingRight = true;
    // variable reflecting the rotation of the object
    private float _rotate = -90f;
    // player animation
    private Animator _animator;
    // variable for ending game
    private bool _overOnce;
    // player sounds
    private AudioSource _musicSource;

    void Start()
    {
        //initialize variables
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _overOnce = false;
        _musicSource = GetComponent<AudioSource>();
    }

    //change player direction and rotation
    void ChangeDirection()
    {
        _isMovingRight = !_isMovingRight;
        _rb.transform.Rotate(0f, _rotate, 0f);
        _rotate = -_rotate;
    }

    void Update()
    {
        //stop player if game is over
        if (Manager.Obj.GameOver && !_overOnce)
        {
            LifeManager.Obj.UpdateLives(-1);
            _overOnce = true;

            //if player has no lives end game
            if(LifeManager.Obj.GetLives() == 0)
                Manager.Obj.Finish();
           
            return;
        }
           
        //control direction of player
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