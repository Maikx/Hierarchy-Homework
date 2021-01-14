
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

public class Spikebush : MonoBehaviour
{
    public float damagePlayerAmount;
    Material m_Spikebush;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObject("Player").GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            player.health - damagePlayerAmount;
        }
    }
}

public class Poisonbush : MonoBehaviour
{
    public float poisonDuration;
    public float poisonDamagePlayerAmount;
    public float addPoisonDuration;
    Material m_Poisonbush;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObject("Player").GetComponent<Player>();
    }

    void Update()
    {
        Poison();
        PoisonDamage();
    }

    void Poison()
    {
        if(player.poisoned == true)
        {
            poisonDuration -= Time.DeltaTime;
            if (poisonDuration <= 0)
                player.poisoned == false;
        }
    }

    void PoisonDamage()
    {
        if (player.poisoned == true)
            player.health -= poisonDamagePlayerAmount * time.DeltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            poisonDuration += addPoisonDuration;
        }
    }
}

public class Pebble : MonoBehaviour
{
    Material m_Pebble;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObject("Player").GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            player.isFalling;
        }
    }
}

public class Fire : MonoBehaviour
{
    public float fireDamagePlayerAmount;
    Material m_Poisonbush;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObject("Player").GetComponent<Player>();
        weather = GameObject.FindGameObject("WheatherManager").GetComponent<WheatherManager>();
    }

    void Update()
    {
        FireDamage();
    }

    void PoisonDamage()
    {
        if (player.burning == true && player.wet == false && weather.isRaining == false)
            player.health -= fireDamagePlayerAmount * time.DeltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            player.burning == true;
        }
    }
}