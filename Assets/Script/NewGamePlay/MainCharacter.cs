using UnityEngine;
using UnityEngine.AI;
public class MainCharacter : MonoBehaviour
{

    [SerializeField] private NavMeshAgent MeshAgent;
    [SerializeField] private Lean.Gui.LeanJoystick joyStick;
    [SerializeField] private Animator Animator;

    private bool IsEnableoyStick;
    private Vector2 joyStickVal;
    private float PositionChange;
    private int AnimSpeed;
    private int AnimPlant;

    // Start is called before the first frame update
    void Start()
    {
        PositionChange = 1;
        AnimSpeed = Animator.StringToHash("Speed");
        AnimPlant = Animator.StringToHash("Pull");
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementCharacter();
        HandleAnimation();
        MoveByJoyStick();
    }

    public void Pull()
    {
        Animator.SetTrigger(AnimPlant);
    }
    private void HandleMovementCharacter()
    {
        var newPos = new Vector3();
        if (Input.GetKey(KeyCode.A))
        {
            newPos = new Vector3(transform.position.x - PositionChange, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            newPos = new Vector3(transform.position.x + PositionChange, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.W))
        {
            newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + PositionChange);
        }

        if (Input.GetKey(KeyCode.S))
        {
            newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - PositionChange);
        }

        if (newPos != Vector3.zero) { MeshAgent.destination = newPos; }

    }

    private void HandleAnimation()
    {
        float speed = MeshAgent.velocity.magnitude;
        Animator.SetFloat(AnimSpeed, speed);
    }

    public void OnDown()
    {
        IsEnableoyStick = true;
    }
    public void OnUp()
    {
        IsEnableoyStick = false;
        joyStickVal = Vector2.zero;
    }
    public void OnSet(Vector2 val)
    {
        if (IsEnableoyStick)
        {
            joyStickVal = val;
        }
    }
    private void MoveByJoyStick()
    {
        if (IsEnableoyStick)
        {
            MeshAgent.destination = new Vector3(
                transform.position.x + joyStickVal.x,
                transform.position.y,
                transform.position.z + joyStickVal.y);
        }
    }
}