using Unity.VisualScripting;
using UnityEngine;

public class groundDetection : MonoBehaviour
{
    public Player player;
    RaycastHit2D hit;
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down);
        if(hit.distance <= 0 && hit.collider != null)
        {
            player.isGrounded = true;
        }
        else
        {
            player.isGrounded = false;
        }
    }
}
