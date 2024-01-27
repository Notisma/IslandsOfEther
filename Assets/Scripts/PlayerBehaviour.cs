using System.Collections;
using Combat;
using Combat.Layout;
using Data;
using Manager;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour I;
    
    public WielderData data;
    
    [Header("Related Objects")]
    public PlayerSprite childSprite;
    public CardsContainer cardsContainer;
    
    [Header("Fields")]
    public bool canWalk = true;
    public float walkSpeed = 7;
    public Vector3 lookingTowards;
    
    private Animator animator;

    private void Start()
    {
        if (I == null) I = this;
        DontDestroyOnLoad(gameObject);
        
        animator = GetComponent<Animator>();
        cardsContainer = BigManager.I.alliedCardsContainer;
        
        data = new WielderData("Pr. M.Padraig");
        GetNewCard("ange");
        GetNewCard("kitsune");
    }

    public void HandleWalking()
    {
        //handles normal walking
        if (!canWalk) return;

        lookingTowards = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        if (lookingTowards.x == 0) //pour empêcher les diagonales
            lookingTowards.y = Input.GetAxisRaw("Vertical");

        if (lookingTowards != Vector3.zero && Time.timeScale > 0)
        {
            if (!ColliderAhead())
                StartCoroutine(Walk());
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
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, lookingTowards, 1);
        Collider2D[] colliders = new Collider2D[hits.Length];
        for (int i = 0; i < hits.Length; i++)
            colliders[i] = hits[i].collider;
        return colliders;
    }

    public IEnumerator Walk()
    {
        canWalk = false;

        //normal + cutscene walking
        float distWalked = 0f;
        Vector3 ogPos = transform.position;

        while (distWalked < 1)
        {
            distWalked += walkSpeed * Time.deltaTime;
            transform.position += lookingTowards * (walkSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        transform.position = ogPos + lookingTowards;

        canWalk = true;
    }
    
    public void CesseTotalementDExister()
    {
        transform.GetChild(0).gameObject.transform.position = new Vector3(-1.78f, -0.05f, -10); // camera
        childSprite.gameObject.SetActive(false);
    }

    public void GetNewCard(string codename)
    {
        CardData c = CardsManager.cards[codename];
        data.AddCard(c);
    }
}
