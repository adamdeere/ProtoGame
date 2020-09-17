using Shape_Data;
using UnityEngine;
using UnityEngine.AI;
using UtilityScripts;

public class Loco : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;
    private Vector2 _smoothDeltaPosition = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;
    private Shape zomb;

    private GameObject _john;
    
    public static event ReturnPlayerFunction GETPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _john = GETPlayer?.Invoke();
        _anim = GetComponent<Animator> ();
        _agent = GetComponent<NavMeshAgent> ();
        zomb = GetComponent<Shape>();
        // Don’t update position automatically
        _agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!zomb.dead)
        {
            _agent.destination = _john.transform.position;
            
            Vector3 worldDeltaPosition = _agent.nextPosition - transform.position;

            // Map 'worldDeltaPosition' to local space
            float dx = Vector3.Dot (transform.right, worldDeltaPosition);
            float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
            Vector2 deltaPosition = new Vector2 (dx, dy);

            // Low-pass filter the deltaMove
            float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
            _smoothDeltaPosition = Vector2.Lerp (_smoothDeltaPosition, deltaPosition, smooth);

            // Update velocity if time advances
            if (Time.deltaTime > 1e-5f)
                _velocity = _smoothDeltaPosition / Time.deltaTime;

            // Update animation parameters
            //anim.SetFloat ("TurningSpeed", velocity.x);
            _anim.SetFloat ("Speed", _velocity.y);
        }
    }
    void OnAnimatorMove()
    {
        transform.rotation = _anim.rootRotation;
        transform.position = _agent.nextPosition;
    }
}
