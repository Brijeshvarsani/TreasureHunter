using StarterAssets;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private StarterAssetsInputs _input;

    public bool canInteract;


    public float interactRadius;
    Collider[] collisions;
    [SerializeField] LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        collisions = Physics.OverlapSphere(transform.position, interactRadius, layer);
        canInteract = collisions.Length > 0;
        if (_input.interact)
        {
            foreach (Collider collider in collisions)
            {
                NPC npc = collider.GetComponent<NPC>();
                if (npc != null)
                {
                    npc.Interact();
                }
            }
            _input.interact = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, interactRadius);
    }
}
