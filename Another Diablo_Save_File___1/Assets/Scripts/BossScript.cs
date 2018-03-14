using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public Animator anim;
    public AttackSpot[] attackSpots;
    public float attack1Time = 0f;
    //public int[] potentialAttacks;
    //public List<int> potentialAttacks;
    public Dictionary<int, int> potentiaAttacks;
    public int potAttCounter = 0;
    public bool hurt;
    public GameObject laser_hitbox;
    public EnemyController enem;
    public bool dead;
    public GameObject drop_stuff;
    public AudioSource basic_attack_sound;
    public AudioSource laser_sound;

    // Use this for initialization
    void Start()
    {
        //potentialAttacks = new int[attackSpots.Length];
        //potentialAttacks = new List<int>;
        potentiaAttacks = new Dictionary<int, int>();
        anim = GetComponent<Animator>();
        enem = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hurt)
        {
            StartCoroutine(Hurt());
        }

        else if (attack1Time <= Time.time) // if cooldown is 0
        {
            int range = Random.Range(0, 10);
            attack1Time = Time.time + 3f;
            if (range > 3)
            {
                StartCoroutine(BasicAttack());
            }
            else
            {
                StartCoroutine(Laser());
            }
        }
        else if (enem.currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
    }
    public IEnumerator Death()
    {
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(1.5f);
        GetComponent<BossScript>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    void checkForPlayers()
    {
        //Debug.Log("Checking for players yup I am it seems");
        for (int i = 0; i < attackSpots.Length; i++)
        {
            AttackSpot temp = attackSpots[i];
            if (temp.containsPlayer)
            {
                //Debug.Log("Oh it looks the counter is  : " + potAttCounter+" and the position is : "+i);
                //potentialAttacks[potAttCounter] = i;
                //Debug.Log("Before it is " + potAttCounter);
                potentiaAttacks.Add(potAttCounter++, i);

                //Debug.Log("We just mapped : "+potAttCounter+" to "+i);
            }
        }
    }

    private IEnumerator Hurt()
    {
        anim.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Hurt", false);
        hurt = false;
    }


    private IEnumerator Laser()
    {
        anim.SetBool("Laser", true);
        yield return new WaitForSeconds(0.5f);
        laser_sound.Play();
        yield return new WaitForSeconds(1.2f);
        laser_hitbox.SetActive(true);
        yield return new WaitForSeconds(1f);
        laser_hitbox.SetActive(false);
        anim.SetBool("Laser", false);
    }
    private IEnumerator BasicAttack()
    {

        checkForPlayers();
        if (potAttCounter <= 0)
        {
            Debug.Log("No players, no need to bother attacking");
        }
        else
        {
            anim.SetBool("Smash", true);
            basic_attack_sound.Play();
            int randomNum = Random.Range(0, potAttCounter);

            int positionKey = potentiaAttacks[randomNum];

            AttackSpot selectedSpot = attackSpots[positionKey];
            //selectedSpot.Warning();
            selectedSpot.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.4f);
            GameObject drop = Instantiate(drop_stuff, selectedSpot.transform);
            yield return new WaitForSeconds(0.6f);
            selectedSpot.Attack(Random.Range(10, 20));
            anim.SetBool("Smash", false);
            selectedSpot.GetComponent<SpriteRenderer>().enabled = false;
        }
        potAttCounter = 0;
        //Debug.Log("Now the thing is " + potAttCounter);
        potentiaAttacks = new Dictionary<int, int>();

        yield return new WaitForSeconds(1f); // animation time

    }



}
