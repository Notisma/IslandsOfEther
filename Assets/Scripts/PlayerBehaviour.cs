using System.Collections;
using Data;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour P;

    public PlayerData data;
    public bool isEnabled = true;

    public bool canWalk = true;
    public float walkSpeed = 7;
    Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        if (P == null) P = this;

        DontDestroyOnLoad(gameObject);

        data = new PlayerData("Pr. M.Padraig");
        data.AddCard(CardsManager.cards["ange"]);
    }

    private void Update()
    {
        //handles normal walking
        if (!isEnabled || !canWalk) return;

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        if (direction.x == 0) //pour empêcher les diagonales
            direction.y = Input.GetAxisRaw("Vertical");

        if (direction != Vector3.zero && Time.timeScale > 0)
        {
//            Rotate(direction);
            if (!ColliderAhead())
                StartCoroutine(Walk(direction));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetInteger("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetInteger("Speed", 1);
        }
    }

    public bool ColliderAhead()
    {
        //checks if there is a non-trigger collider ahead
        foreach (Collider2D coll in GetObjectsInFront())
            if (!coll.isTrigger)
                return true;
        return false;
    }

    public Collider2D[] GetObjectsInFront()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, 1);
        Collider2D[] colliders = new Collider2D[hits.Length];
        for (int i = 0; i < hits.Length; i++)
            colliders[i] = hits[i].collider;
        return colliders;
    }

    public void Rotate(Vector3 direction)
    {
        int rotaZion = ((int)direction.y == -1) ? (180) : (270 * (int)direction.x); //formule pour calc la rotation en z

        transform.rotation = Quaternion.Euler(0, 0, rotaZion);

        transform.GetChild(0).rotation = Quaternion.identity; //reset la rotation de la cam
    }

    public IEnumerator Walk(Vector3 direction)
    {
        canWalk = false;

        //normal + cutscene walking
        float distWalked = 0f;
        Vector3 ogPos = transform.position;

        while (distWalked < 1)
        {
            distWalked += walkSpeed * Time.deltaTime;
            transform.position += direction * (walkSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        transform.position = ogPos + direction;

        canWalk = true;
    }
}