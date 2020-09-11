using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Vector3 initialPos;
    private Animator thisAnim;
    public CinemachineFreeLook _freeLookComponent;
    private CinemachineCameraOffset offsetCamera;
    private readonly Vector3 originalOffset = new Vector3(-0.71f,-0.21f,0.33f);
    public SpawnableObjects cube;
    private Quaternion newDirection;
    private Camera mainCamera;
    private Vector2 vec2;
    private Rigidbody rb;
    public Image aImage;
    public float turnSpeed = 15f;
    [Range(0f, 10f)] public float LookSpeed = 0.5f;
    public bool InvertY = false;
    private Vector3 velocity, desiredVelocity;
    int groundContactCount;
    bool OnGround => groundContactCount > 0;
    private int jumpPhase;
    float minGroundDotProduct;
    Vector3 contactNormal;
    int stepsSinceLastGrounded, stepsSinceLastJump;
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f, maxAirAcceleration = 1f;
    private bool desiredJump;
    [SerializeField, Range(0f, 10f)]
    float jumpHeight = 2f;
    [SerializeField, Range(0, 5)]
    int maxAirJumps = 0;
    [SerializeField, Range(0f, 90f)]
    float maxGroundAngle = 25f;
    [SerializeField, Range(0f, 100f)]
    float maxSnapSpeed = 100f;
    [SerializeField, Min(0f)]
    float probeDistance = 1f;


    private void Awake()
    {
        mainCamera = Camera.main;
        thisAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        offsetCamera = _freeLookComponent.GetComponent<CinemachineCameraOffset>();
        initialPos = rb.position;
        OnValidate();
    }
    

    void Update ()
    {
        Vector2 playerInput;
        playerInput.x = vec2.x;
        playerInput.y = vec2.y;
        desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
    }

    private void FixedUpdate()
    {
        float camFloat = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,camFloat,0), turnSpeed * Time.fixedDeltaTime);
        UpdateState();
        AdjustVelocity();
        if (desiredJump)
        {
            desiredJump = false;
            JumpPhysics();
        }
        rb.velocity = velocity;
        thisAnim.SetFloat("velocityY",rb.velocity.y);
        thisAnim.SetBool("isGrounded", OnGround);
        thisAnim.SetFloat ("Speed", vec2.y);
        thisAnim.SetFloat ("TurningSpeed", vec2.x);
        thisAnim.SetFloat("CombineSTS",vec2.x * vec2.y);
        ClearState();
    }
    
    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name == "Resetter")
        {
            rb.position = initialPos;
        }
        EvaluateCollision(collision);
    }
    void OnCollisionStay (Collision collision) {
        EvaluateCollision(collision);
    }

    void OnValidate () {
        minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
    }

    public void JumpPhysics()
    {
        if (OnGround|| jumpPhase < maxAirJumps) 
        {
            stepsSinceLastJump = 0;
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            float alignedSpeed = Vector3.Dot(velocity, contactNormal);
            if (alignedSpeed > 0f) 
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity += contactNormal * jumpSpeed;
        }
    }

    void EvaluateCollision (Collision collision) {
        for (int i = 0; i < collision.contactCount; i++) 
        {
            Vector3 normal = collision.GetContact(i).normal;
            if (normal.y >= minGroundDotProduct)
            {
                groundContactCount += 1;
                contactNormal += normal;
            }
        }
    }
    
    void UpdateState () {
        stepsSinceLastGrounded += 1;
        stepsSinceLastJump += 1;
        velocity = rb.velocity;
        if (OnGround || SnapToGround()) {
            stepsSinceLastGrounded = 0;
            jumpPhase = 0;
            if (groundContactCount > 1)
            {
                contactNormal.Normalize();
            }
        }
        else {
            contactNormal = Vector3.up;
        }
    }
    
    Vector3 ProjectOnContactPlane (Vector3 vector) 
    {
        return vector - contactNormal * Vector3.Dot(vector, contactNormal);
    }
    
    void AdjustVelocity () {
        Vector3 xAxis = ProjectOnContactPlane(transform.right).normalized;
        Vector3 zAxis = ProjectOnContactPlane(transform.forward).normalized;
        
        float currentX = Vector3.Dot(velocity, xAxis);
        float currentZ = Vector3.Dot(velocity, zAxis);
        
        float acceleration = OnGround ? maxAcceleration : maxAirAcceleration;
        float maxSpeedChange = acceleration * Time.deltaTime;

        float newX =
            Mathf.MoveTowards(currentX, desiredVelocity.x, maxSpeedChange);
        float newZ =
            Mathf.MoveTowards(currentZ, desiredVelocity.z, maxSpeedChange);
        velocity += xAxis * (newX - currentX) + zAxis * (newZ - currentZ);
    }
    
    void ClearState ()
    {
        groundContactCount = 0;
        contactNormal = Vector3.zero;
    }
    
    bool SnapToGround () {
        if (stepsSinceLastGrounded > 1 || stepsSinceLastJump <= 2) {
            return false;
        }
        float speed = velocity.magnitude;
        if (speed > maxSnapSpeed) {
            return false;
        }
        if (!Physics.Raycast(rb.position, Vector3.down, out RaycastHit hit, probeDistance))
        {
            return false;
        }
        if (hit.normal.y < minGroundDotProduct) {
            return false;
        }
        groundContactCount = 1;
        contactNormal = hit.normal;
        float dot = Vector3.Dot(velocity, hit.normal);
        if (dot > 0f)
        {
            velocity = (velocity - hit.normal * dot).normalized * speed;
        }
        return true;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        vec2 = context.ReadValue<Vector2>();
        //Debug.Log(vec2);
    }

    public void Aiming(InputAction.CallbackContext context)
    {
        if (thisAnim.GetBool("Hostility"))
        {
            if (thisAnim.GetBool("isAiming"))
            {
                thisAnim.SetBool("isAiming",false);
            }
            else
            {
                thisAnim.SetBool("isAiming",true);
            }
        }
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        desiredJump = true;
    }

    public void HostilitySwitcher(InputAction.CallbackContext context)
    {
        if (thisAnim.GetBool("Hostility"))
        {
            thisAnim.SetBool("Hostility",false);
            offsetCamera.m_Offset = Vector3.zero;
            aImage.enabled = false;
        }
        else
        {
            thisAnim.SetBool("Hostility",true);
            offsetCamera.m_Offset = originalOffset;
            aImage.enabled = true;
        }
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookMovement = context.ReadValue<Vector2>().normalized;
        lookMovement.y = InvertY ? -lookMovement.y : lookMovement.y;
        thisAnim.SetFloat("AnalogueX", lookMovement.x);
        lookMovement.x *= 180f;
        _freeLookComponent.m_XAxis.Value += lookMovement.x * LookSpeed * Time.deltaTime;
        _freeLookComponent.m_YAxis.Value += lookMovement.y * LookSpeed * Time.deltaTime;
    }

    public void SpawnCube(InputAction.CallbackContext context)
    {
        cube.SpawnOne(transform.position + transform.up * -1f);
    }
}
