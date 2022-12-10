using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

// Global enum
public enum Faction {
    Player,
    Enemy,
    Neutral
};

public class DriftController : MonoBehaviour
{
    private bool vibration = true;
    public UIS UIS;
    public bool canPause;

    #region Parameters
    public float Accel = 15.0f;
    public bool Nitro;
    Controls Controles;
    float restart;
    private float startb;
    private bool paused;


    //public float Boost = 4f/3;          // In ratio
    public float TopSpeed = 30.0f;      // In meters/second
    //public float Jump = 3.0f;           // In meters/second2
    public float GripX = 12.0f;
    public float GripY = 12.0f;          // In meters/second2
    public float GripZ = 3.0f;          // In meters/second2
    public float Rotate = 190;       // In degree/second
    public float RotVel = 0.8f;         // Ratio of forward velocity transfered on rotation

    // Center of mass, fraction of collider boundaries (= half of size)
    // 0 = center, and +/-1 = edge in the pos/neg direction.
    public Vector3 CoM = new Vector3(0f, .5f, 0f);


    public Faction carFaction = Faction.Player;  // Drop-down to select faction of this object
    public Transform Target;            // Target for the AI to act upon

    // Ground & air angular drag
    // reduce stumbling time on ground but maintain on-air one
    float AngDragG = 5.0f;
    float AngDragA = 0.05f;

    // Rotational
    float MinRotSpd = 1f;           // Velocity to start rotating
    float MaxRotSpd = 4f;           // Velocity to reach max rotation
    public AnimationCurve SlipL;    // Slip hysteresis static to full (x, input = speed)
    public AnimationCurve SlipU;    // Slip hysteresis full to static (y, output = slip ratio)
    public float SlipMod = 20f;     // Basically widens the slip curve
                                    // (determine the min speed to reach max slip)
    float a;
    // AI-specific parameters
    [Header("AI Behaviors")]
    public float turnTh = 20f;      // Delta threshold to goal before start turning
    #endregion

    #region Intermediate
    Rigidbody rigidBody;
    Bounds groupCollider;
    public float distToGround;

    // The actual value to be used (modification of parameters)
    float rotate;
    float accel;
    float gripX;
    float gripY;
    float gripZ;
    float rotVel;
    float slip;     // The value used based on Slip curves

    // For determining drag direction
    float isRight = 1.0f;
    float isForward = 1.0f;
    float move;
    float breake;


    bool isRotating = false;
    bool isGrounded = true;
    bool isStumbling = false;

    // Control signals
    float inThrottle = 0f;
    [HideInInspector] public float inTurn = 0f;
    bool inReset = false;
    bool isStuck = false;
    bool autoReset = false;
    public Animator anim;
    //bool inBoost = false;
    public bool inSlip = false;

    Vector3 spawnP;
    Quaternion spawnR;

    Vector3 vel = new Vector3(0f, 0f, 0f);
    Vector3 pvel = new Vector3(0f, 0f, 0f);
    #endregion

    float timedr;

    private void Awake()
    {
        Controles = new Controls();
        Controles.P1.Enable();

    }
    // Use this for initialization
    void Start()
    {

        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
        rigidBody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        OnEnable();
        // Store start location & rotation
        spawnP = transform.position;
        spawnR = transform.rotation;

        groupCollider = GetBounds(gameObject);     // Get the full collider boundary of group
        distToGround = groupCollider.extents.y;    // Pivot to the outermost collider

        // Move the CoM to a fraction of colliders boundaries
        rigidBody.centerOfMass = Vector3.Scale(groupCollider.extents, CoM);

        //distToGround = transform.position.y + 1f;
        a = Accel;
    }

    // Called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, rigidBody.velocity / 2, Color.green);

      

        if (Gamepad.current != null && breake != 0 && !Nitro &&  vibration)
        {
            Gamepad.current.SetMotorSpeeds(Mathf.Abs(breake / 10), Mathf.Abs(breake / 10));
        }
        else if(Gamepad.current != null && breake == 0 && Nitro&& vibration){
            Gamepad.current.SetMotorSpeeds(1, 1);
        }
        else if(Gamepad.current != null && breake == 0 && !Nitro&& vibration)
        {
            Gamepad.current.SetMotorSpeeds(0, 0);
        }
        if (breake > 0 && !Nitro)
        {
            Accel = a - 30 * breake;
        }
        else if (breake <= 0 && Nitro)
        {
            Accel = a + 30;
        }
        else
        {
            Accel = a;
        }
        timedr += Time.deltaTime;

        if (timedr >= 7)
        {
            a = a + 2;
            timedr = 0;
        }









        if (transform.InverseTransformDirection(rigidBody.velocity).x > 1f)
        {
            anim.SetFloat("Blend", Mathf.Lerp(anim.GetFloat("Blend"), 0, Time.deltaTime * 10));
           
        }
        else if (transform.InverseTransformDirection(rigidBody.velocity).x < -1f)
        {
            anim.SetFloat("Blend", Mathf.Lerp(anim.GetFloat("Blend"), 1, Time.deltaTime * 10));
    
        }
        else
        {
            anim.SetFloat("Blend", Mathf.Lerp(anim.GetFloat("Blend"), 0.5f, Time.deltaTime));
        }
    }
    private void OnEnable()
    {
        Controles.P1.Enable();
    }
    private void OnDisable()
    {
        Controles.P1.Disable();
    }
    // Called once multiple times per frame 
    // (according to physics setting)
    void FixedUpdate()
    {
        Debug.Log(isRotating);
        move = Controles.P1.Sideways.ReadValue<float>();
 
        breake = Controles.P1.Break.ReadValue<float>();



        #region Situational Checks
        accel = Accel;
        rotate = Rotate;
        gripX = GripX;
        gripY = GripY;
        gripZ = GripZ;
        rotVel = RotVel;
        rigidBody.angularDrag = AngDragG;

        // Adjustment in slope
        accel = accel * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad);
        accel = accel > 0f ? accel : 0f;
        gripZ = gripZ * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad);
        gripZ = gripZ > 0f ? gripZ : 0f;
        gripY = gripY * Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad);
        gripY = gripY > 0f ? gripY : 0f;
        gripX = gripX * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        gripX = gripX > 0f ? gripX : 0f;

        // A short raycast to check below
        /*isGrounded = Physics.Raycast(transform.position, -transform.up, distToGround + 0.1f);
        if (!isGrounded)
        {
            rotate = 0f;
            accel = 0f;
            gripX = 0f;
            gripY = 0f;
            gripZ = 0f;
            rigidBody.angularDrag = AngDragA;
        }
       

        // Prevent the rotational input intervenes with physics angular velocity 
        isStumbling = rigidBody.angularVelocity.magnitude > 0.1f * Rotate * Time.deltaTime;
        if (isStumbling)
        {
            //rotate = 0f;
        }*/

        // Start turning only if there's velocity
        if (pvel.magnitude < MinRotSpd)
        {
            rotate = 0f;
        }
        else
        {

            rotate = pvel.magnitude / MaxRotSpd * rotate;
        }


        if (rotate > Rotate) rotate = Rotate;
        
        // Calculate grip based on sideway velocity in hysteresis curve
        if (!inSlip)
        {
            // Normal => slip
            slip = this.SlipL.Evaluate(Mathf.Abs(pvel.x) / SlipMod);
           
            if (slip == 1f) inSlip = true;
        }
        else
        {
            // Slip => Normal
            
            slip = this.SlipU.Evaluate(Mathf.Abs(pvel.x) / SlipMod);
            if (slip == 0f) inSlip = false;
        }
        if (slip != 0)
        {

            if (Gamepad.current != null && vibration && !Nitro)
            {
                
                if (pvel.x > 0)
                {
                    Gamepad.current.SetMotorSpeeds(Mathf.Abs(slip * 5)*10, 0);
                }
                else if (pvel.x < 0)
                {
                    Gamepad.current.SetMotorSpeeds(0, Mathf.Abs(slip * 5 )*10);
                }
            }

        }
        
        DebugPlayer(slip);

        //rotate *= (1f + 0.5f * slip);   // Overall rotation, (body + vector)
        rotate *= (1f - 0.3f * slip);   // Overall rotation, (body + vector)
        rotVel *= (1f - slip);          // The vector modifier (just vector)

        /* Should be:
         * 1. Moving fast       : local forward, world forward.
         * 2. Swerve left       : instantly rotate left, local sideways, world forward.
         * 3. Wheels turn a little : small adjustments to the drifting arc.
         * 3. Wheels turn right : everything the same, traction still gone.
         * 4. Slowing down      : instantly rotate right, local forward, world left.
         * 
         * Update, solution: Hysteresis, gradual loss but snappy return.
         */

        #endregion

        #region Logics
        // Get command from keyboard or simple AI (conditional rulesets)
        switch (carFaction)
        {
            case Faction.Player:
                InputKeyboard();
                break;
            
            default:
                // Do nothing
                break;
        }

        // Execute the commands
        Controller();   // pvel assigment in here
        #endregion

        #region Passives
        // Get the local-axis velocity after rotation
        vel = transform.InverseTransformDirection(rigidBody.velocity);

        // Rotate the velocity vector
        //vel = pvel; => Transfer all (full grip)
        if (isRotating)
        {
            vel = vel * (1 - rotVel) + pvel * rotVel; // Partial transfer
            //vel = vel.normalized * speed;
        }

        // Sideway grip
        isRight = vel.x > 0f ? 1f : -1f;
        vel.x -= isRight * gripX * Time.deltaTime;  // Accelerate in opposing direction
        if (vel.x * isRight < 0f) vel.x = 0f;       // Check if changed polarity

        // Straight grip
        isForward = vel.z > 0f ? 1f : -1f;
        vel.z -= isForward * gripZ * Time.deltaTime;
        if (vel.z * isForward < 0f) vel.z = 0f;

        // Top speed
        if (vel.z > TopSpeed) vel.z = TopSpeed;
        else if (vel.z < -TopSpeed) vel.z = -TopSpeed;

        rigidBody.velocity = transform.TransformDirection(vel);
        #endregion

    }



    #region Controllers
    // Get input values from keyboard
    void InputKeyboard()
    {
        //inBoost = Input.GetAxisRaw("Boost") > 0f;
        inTurn = move;
        inThrottle = 1;

        if (restart > 0 || inReset)
        {
            inReset = true;
        }


    }

   

    // Executing the queued inputs
    void Controller()
    {

        //if (inBoost) accel *= Boost; // Higher acceleration

        if (inThrottle > 0.5f || inThrottle < -0.5f)
        {
            rigidBody.velocity += transform.forward * inThrottle * accel * Time.deltaTime;
            gripZ = 0f;     // Remove straight grip if wheel is rotating
        }

        if (autoReset)
        {
            // If stuck, check next frame too then reset
            if (pvel.magnitude <= 0.01f)
            {
                inReset = isStuck;  // So, true on next frame
                isStuck = true;
            }
            else
            {
                isStuck = false;
            }
        }

        if (inReset)
        {  // Reset
            UIS.GameO();
        }

        isRotating = false;

        // Get the local-axis velocity before new input (+x, +y, and +z = right, up, and forward)
        pvel = transform.InverseTransformDirection(rigidBody.velocity);

        // Turn statically

            float dir = (pvel.z < 0) ? -1 : 1;    // To fix direction on reverse
            RotateGradConst(inTurn * dir);
        
    }
    #endregion



    #region Rotation Methods
    /* Advised to not read eulerAngles, only write: https://answers.unity.com/questions/462073/
     * As it turns out, the problem isn't there. */

    /* As is: Conflict with physical Y-axis rotation, must be disabled.
     * Current methods:
     * 1. Prevent rotational input when there's angular velocity.
     * 2. Significantly increase angular drag while grounded.
     * 3. Result: rotation responding to environment, responsive input, & natural stumbling.
     */

    Vector3 drot = new Vector3(0f, 0f, 0f);


    void RotateGradConst(float isCW)
    {
        // Delta = right(taget) - left(current)
        drot.y = isCW * rotate * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(drot.y, transform.up);
        isRotating = true;
    }


    #endregion



    #region Utilities
    void DebugPlayer(object message)
    {
        //if (carFaction == Faction.Player) Debug.Log(message);
    }

    

    // Get bound of a large 
    public static Bounds GetBounds(GameObject obj)
    {

        // Switch every collider to renderer for more accurate result
        Bounds bounds = new Bounds();
        Collider[] colliders = obj.GetComponentsInChildren<Collider>();

        if (colliders.Length > 0)
        {

            //Find first enabled renderer to start encapsulate from it
            foreach (Collider collider in colliders)
            {

                if (collider.enabled)
                {
                    bounds = collider.bounds;
                    break;
                }
            }

            //Encapsulate (grow bounds to include another) for all collider
            foreach (Collider collider in colliders)
            {
                if (collider.enabled)
                {
                    bounds.Encapsulate(collider.bounds);
                }
            }
        }
        return bounds;
    }
    #endregion

   
    IEnumerator pausa()
    {
        yield return new WaitForSeconds(1);
     

    }
}