using UnityEngine;

/**
 * Check for Player falling from the road
 */
public class PlayerFalls : MonoBehaviour
{
    // class object to avoid static methods
    public static PlayerFalls Obj;
    //Player
    private Rigidbody _rb;
    private Animator _animator;
    private const float Speed = 15f;

    void Start()
    {
        // init variables 
        if (Obj == null)
            Obj = this;

        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private bool _resurect = true;

    void Update()
    {
        // check for the ground
        RaycastHit hit;
        if (!(Physics.Raycast(_rb.transform.position, Vector3.down, out hit, 1f) && hit.transform.gameObject.tag == "Ground"))
        {
            _rb.useGravity = true;
            _rb.velocity = _rb.transform.eulerAngles.y == 0 ? new Vector3(0f, -10f, Speed)
                : new Vector3(Speed, -10f, 0f);
            Manager.Obj.GameOver = true;
            _animator.enabled = false;

            // save Player
            if (LifeManager.Obj.GetLives() > 1 && _resurect)
            {
                UIManager.Obj.ResurrectPanel();
                _resurect = false;
            }
                
        }
    }

}