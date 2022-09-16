using DG.Tweening;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDig : MonoBehaviour
{
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;

    private PlayerState playerState;

    public float digRadius;
    Collider[] collisions;
    [SerializeField] LayerMask layer;

    //Animation
    public Animator Shovel;
    public float digDuration;
    public float camLerpDownDuration;
    private FirstPersonController firstPersonController;
    public Transform digLocation;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _input = GetComponent<StarterAssetsInputs>();
        playerState = GetComponent<PlayerState>();
        firstPersonController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.dig && firstPersonController.Grounded)
        {
            DigAnimation();
            collisions = Physics.OverlapSphere(transform.position, digRadius, layer);
            foreach (Collider collider in collisions)
            {
                Debug.Log(collider.gameObject.name);
                TreasureChest treasure = collider.GetComponent<TreasureChest>();
                if (treasure != null)
                {
                    Debug.Log("Surfacing");
                    treasure.surfaceChest(digLocation.position);
                }
            }
            _input.dig = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, digRadius);
    }

    private void DigAnimation()
    {
        if (firstPersonController != null)
        {
            firstPersonController.CameraLock = true;
            firstPersonController.MovementLock = true;
            LookDown();
            Invoke(nameof(UnlockCamera), digDuration);
        }

        // lerp camera to look down
        Shovel.SetTrigger("Dig");
    }

    private void UnlockCamera()
    {
        firstPersonController.CameraLock = false;
        firstPersonController.MovementLock = false;
    }

    public void LookDown()
    {
        firstPersonController._cinemachineTargetPitch = 90.0f;
        firstPersonController.CinemachineCameraTarget.transform.DOLocalRotateQuaternion(Quaternion.Euler(90.0f, 0.0f, 0.0f), camLerpDownDuration);
    }
}
