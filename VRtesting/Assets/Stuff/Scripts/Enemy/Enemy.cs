using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Definiendo un tipo enumerado para los estados del enemigo
enum EnemyStates
{
    idle,
    turn,
    walkingToPlayer,
    attack,
    gettingDamage,
    die
}

public class Enemy : Character
{
    [SerializeField]
    float damage;
    [SerializeField]
    float turnSpeed;
    [SerializeField]
    float turnDelay;
    float turndelayAux = 0;
    [SerializeField]
    float attakDelay;
    float attakDelayAux = 0;
    [SerializeField]
    Animator animator;
    int direccionRotacion = Random.Range(0,2);

    EnemyStates enemyStates = EnemyStates.idle;
    GameObject player;
    RaycastHit hit;
    Ray ray;
    [SerializeField]
    Collider attackHitBox;

    float distance;

    [SerializeField]
    float rangoDeteccion;

    public Enemy(float health, float speed)
    {
        Healt = health;
        Speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        SearchingPlayer();
        MovementManager();
        Idle();
        Turn();
        MoveToPlayer();
        Attack();
    }

    //Buscando al jugador por distancia y raycast
    void  SearchingPlayer()
    {
        //generando rayo hacia adelante 
        ray = new Ray(this.transform.position, Vector3.forward * rangoDeteccion);
        //Calculando la distancia con el jugados
        distance = Fisics.Distance(this.transform.position, player.transform.position);

        if(Physics.Raycast(ray, out hit))//Si el rayo colisiona
            if(hit.transform.gameObject.name == "Player" )//Con el player
                if(distance < 2)
                {
                    enemyStates = EnemyStates.attack; //Si esta cerca ataca
                    attakDelayAux = 0;
                }
                else enemyStates = EnemyStates.walkingToPlayer; //Si esta lejos camina hacia el        
    }

    //Fisics
    void Rotate(Vector3 ejeRotacion)
    {
        Vector4 q = Fisics.Quaternion(ejeRotacion, turnSpeed * Time.fixedDeltaTime);
        Quaternion quater = new Quaternion(q.x, q.y, q.z, q.w);
        this.transform.rotation = Fisics.SumaQuaternion(this.transform.rotation, quater);
    }
    void Translate() 
    {
        //Sacando el vector de distancia entre el ebemigo y el player
        Vector3 direccion = Fisics.DistanceVector(this.transform.position, player.transform.position);
        //Sacando el vector unitario
        direccion = Fisics.VectorUnitario(direccion);
        //Trasladando el enemigo en la direccion del vector unitario
        transform.position = Fisics.Translate(direccion.x, direccion.y, direccion.z, this.transform.position) * Time.fixedDeltaTime;
    }

    //Parado
    void Idle()
    {
        if (enemyStates == EnemyStates.idle)
            animator.SetTrigger("Idle");
    }

    //Girando
    void Turn()
    {
        if (enemyStates == EnemyStates.turn && turndelayAux < turnDelay)
        {
            //animacion
            animator.SetTrigger("Idle");
            //audio idle
            turndelayAux += Time.fixedDeltaTime;
            direccionRotacion = Random.Range(0, 2);
        }
        else if(enemyStates == EnemyStates.turn && turndelayAux < turnDelay * 5)
        {
            animator.SetTrigger("Turn");
            turndelayAux += Time.fixedDeltaTime;

            if(direccionRotacion == 0)
            {
                Rotate(Vector3.up );
            }
            else
            {
                Rotate(Vector3.down);
            }
        }
        else if(enemyStates == EnemyStates.turn )
        {
            animator.SetTrigger("Idle");
            turndelayAux = 0;
        }
    }

    //Ataque del enemigo
    void Attack()
    {

        if (enemyStates == EnemyStates.attack)
        {
            animator.SetTrigger("Attack");
            attackHitBox.enabled = true;
        }
            //activar audio
    }

    //Moviendose hacia el jugador
    void MoveToPlayer()
    {        
        if(enemyStates == EnemyStates.walkingToPlayer)
        {
            //CAMINAR
            Translate();

            //ROTAR
            //Angulo entre vectores de posicion de enemigo y el player
            float angulo = Fisics.AnguloVectores(this.transform.position, player.transform.position);
            //Calculanto el quaternion de rotacion
            Vector4 rotation = Fisics.Quaternion(Vector3.up, angulo);
            //Asignando la nueva rotacion
            this.transform.rotation = new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
        }
    }

    //Recibe daño y es llamada por las partes que se pueden dañar del enemigo
    public void GetDamage(float damage)
    {
        Healt -= damage;
    }

    //Controla el movimiento segun el estado en que se encuentra
    void MovementManager()
    {
        switch (enemyStates)
        {
            case EnemyStates.idle:
                if (turndelayAux < turnDelay)
                {
                    Idle();
                    turndelayAux += Time.fixedDeltaTime;
                }
                else if(turndelayAux < turnDelay * 2)
                {
                    enemyStates = EnemyStates.turn;
                    Turn();
                }
                break;
            case EnemyStates.turn:
                if(turndelayAux < turnDelay * 2)
                {
                    Turn();
                    turndelayAux += Time.fixedDeltaTime;
                }
                else
                {
                    enemyStates = EnemyStates.idle;
                    turndelayAux = 0;
                }
                break;
            case EnemyStates.attack:
                if(attakDelayAux < attakDelay)
                {
                    Attack();
                    attakDelayAux += Time.fixedDeltaTime;
                }
                else if(attakDelayAux < attakDelay * 2)
                {
                    attackHitBox.enabled = false;
                    attakDelayAux += Time.fixedDeltaTime;
                }
                else
                {
                    attakDelayAux = 0;
                    enemyStates = EnemyStates.idle;
                }

                break;
            case EnemyStates.die:
                animator.SetTrigger("Die");
                Destroy(this.gameObject, 2f);
                break;
            case EnemyStates.walkingToPlayer:
                animator.SetTrigger("Walking");
                MoveToPlayer();
                break;
        }
    }   
    
}
