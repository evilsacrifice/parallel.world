using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float metan;
    private Vector2 input;
    private float maxSpeed = 2.2f;
    void Start()
    {
    }
    void FixedUpdate()
    {
        if (EventStates.Instance.GetState(CustomEventTypes.Movement))
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            var rigidbody = GetComponent<Rigidbody2D>();
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce(input * metan);
            }
            var direction = input.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }
}
