using UnityEngine;

public class Player : MonoBehaviour
{
    public static readonly string fileName = "Playermove";

    private readonly static string inputx = "Horizontal";
    private readonly static string inputz = "Vertical";

    public int speed = 5;
    public Rigidbody rb;
    public bool start = false;


    private void Update()
    {
        if(start)
        {
            var movex = Input.GetAxis(inputx);
            var movez = Input.GetAxis(inputz);

            var dir = new Vector3(movex, 0, movez);

            var velocity = rb.position + dir * speed * Time.deltaTime;

            rb.MovePosition(velocity);
        }

    }

    public void Startplay()
    {
        start = true;
    }
    public void Stopplay()
    {
        start = false;
    }

}
