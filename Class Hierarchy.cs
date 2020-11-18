
//Homework
//Propose a class hierarchy for the representation of Obstacles in a generic game environment with at least 5 different types of obstacles.


public class Puddle : MonoBehaviour
{
    public float slowPlayerAmount;
    public float slowForTimeAmountOfTime;
    private float slowPlayerAfterTimer;
    private float slowPlayerAfterTimerMax;
    public bool canSlow;
    Material m_Pubble;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObject("Player").GetComponent<Player>();
        canSlow = true;
    }

    void Update()
    {
        SlowPlayerAfter();
    }

    void SlowPlayerAfter()
    {
        if (slowPlayerAfterTimer >= 0 && canSlow == false)
        {
                slowPlayerAfterTimer -= Time.deltaTime;
                if(slowPlayerAfterTimer <= 0) canSlow = true;
        }
        else
        {
                slowPlayerAfterTimer = slowPlayerAfterTimerMax;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canSlow == true)
        {
            player.PlayerIsSlowed();
            canSlow = false;
        }
    }
}
