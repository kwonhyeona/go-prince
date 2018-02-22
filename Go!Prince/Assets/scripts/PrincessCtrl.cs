using UnityEngine;
using System.Collections;

public class PrincessCtrl : MonoBehaviour {
    public Transform PrincessTr;
    public Transform PrinceTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private Animator animator;

    public enum PrincessState { idle, run, jump};
    public PrincessState princessState = PrincessState.idle;

    public float traceDist = 10.0f;
    public float jumpDist = 3.0f;
    private bool isDie = false;

    public GameObject _uiResult; // 왕자를 만나면 나타날 캔버스
    public UnityEngine.UI.Text _resultText; //캔버스 text



    // Use this for initialization
    void Start () {
        PrincessTr = this.gameObject.GetComponent<Transform>();
        PrinceTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        animator = this.gameObject.GetComponent<Animator>();
        nvAgent.destination = PrinceTr.position;
        StartCoroutine(this.CheckPrincessState());
        StartCoroutine(this.PrincessAction());
    }
	
	// Update is called once per frame
	void Update () {
       
      }

    IEnumerator CheckPrincessState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(PrinceTr.position, PrincessTr.position);
            if (dist <= jumpDist)
            {
                princessState = PrincessState.jump;
                Debug.Log("왕자를 만났어");
                GameOver();
            }
            else if (dist <= traceDist)
            {
                princessState = PrincessState.run;
            }
            else
            {
                princessState = PrincessState.idle;
            }
        }
    }

    IEnumerator PrincessAction()
    {
        while (!isDie)
        {
            switch (princessState)
            {
                case PrincessState.idle:
                    nvAgent.Stop();
                    animator.SetBool("IsRun", false);
                    break;
                case PrincessState.run:
                   // nvAgent.destination = PrinceTr.position;
                    nvAgent.Resume();
                    animator.SetBool("IsJump", false);
                    animator.SetBool("IsRun", true);
                    break;
                case PrincessState.jump:
                    nvAgent.Stop();
                    animator.SetBool("IsJump", true);
                    break;
            }
            yield return null;
        }
    }

    public void GameOver()
    {
        _resultText.text = "WIN";

        Time.timeScale = 0.0f;
        if (_uiResult != null) _uiResult.SetActive(true);

    }
}
