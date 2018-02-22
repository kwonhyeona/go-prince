using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BadGuyCtrl : MonoBehaviour {

    private Transform BadGuyTr;
    public Transform PlayerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private Animator animator;

    public enum BadGuyState { idle, run, attack, die};
    public BadGuyState badguyState = BadGuyState.idle;

    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    private bool isDie = false;

    public int hp = 100;
    private int initHp;
    public Image imgHpbar;
    private int hitCount = 0;  // 맞은 횟수
    public Texture[] textures;   // 악당들 랜덤 텍스쳐

    // Use this for initialization
    void Start () {
    
        BadGuyTr = this.gameObject.GetComponent<Transform>();
        //PlayerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        initHp = hp;

        int idx = Random.Range(0, textures.Length);
        GetComponentInChildren<MeshRenderer>().material.mainTexture = textures[idx];
        animator = this.gameObject.GetComponent<Animator>();
        nvAgent.destination = PlayerTr.position;
        StartCoroutine(this.CheckBadGuyState());
        StartCoroutine(this.BadGuyAction());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision coll)
    {
         if(coll.collider.tag == "SNOW")
        {
            Debug.Log("눈 맞았오!");
            Destroy(coll.gameObject); // 층돌한 눈덩이 제거
            if (++hitCount >= 3) ChangeGauge();
        }
    }

    void ChangeGauge()  // 공격받으면 게이지 감소
    { 
        hp /= 3;
        imgHpbar.fillAmount = (float)hp / (float)initHp;
        badguyState = BadGuyState.die;
        Destroy(gameObject, 1.0f);  // 5초 후에 악당 사라짐
    }


    IEnumerator CheckBadGuyState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(PlayerTr.position, BadGuyTr.position);
            if(dist <= attackDist)
            {
                badguyState = BadGuyState.attack;
            }
            else if(dist <=traceDist)
            {
                badguyState = BadGuyState.run;
            }
            else
            {
                badguyState = BadGuyState.idle;
            }
        }
    }

    IEnumerator BadGuyAction()
    {
        while (!isDie)
        {
            switch (badguyState)
            {
                case BadGuyState.idle:
                    nvAgent.Stop();
                    animator.SetBool("IsRun", false);
                    break;
                case BadGuyState.run:
                    nvAgent.destination = PlayerTr.position;
                    nvAgent.Resume();
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsRun", true);
                    break;
                case BadGuyState.attack:
                    nvAgent.Stop();
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }

}
