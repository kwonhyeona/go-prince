
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PrinceCtrl : MonoBehaviour
{
    public GameObject move1, move2, move3;

    //animator 설정

    private Animator animator = null;
    public int hp = 100;
    private int initHp;
    public Image imgHpbar;

    //눈덩이 던지기
    public GameObject snow;
    public Transform snowpos;
    public int rotSpeed = 150;
    private float h = 0.0f;
    private float v = 0.0f;

    private Transform princeTr;
    public float moveSpeed = 7.0f;
    private int hitCount = 0;  // 맞은 횟수
    
    public GameObject _uiResult; // 왕자가 죽으면 나타날 캔버스
    public UnityEngine.UI.Text _resultText; //캔버스 text

    // Use this for initialization
    void Start()
    {
        //왕자 transform컴포넌트 얻어오기
        princeTr = GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();
        initHp = hp;

    }

    // Update is called once per frame
    void Update()
    {
        float amtRot = rotSpeed * Time.deltaTime;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        inputButtonCtrl();

        if (h >= 0.1f || h <= -0.1f || v >= 0.1f || v <= -0.1f)
            animator.SetTrigger("Walk");

        princeTr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);
        princeTr.Rotate(Vector3.up * h * amtRot);
        princeTr.Translate(Vector3.right * moveSpeed * h * Time.deltaTime, Space.Self);

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BADGUY")
        {
            Debug.Log("나쁜놈이때렸다!");

            hp -= 10;
            imgHpbar.fillAmount = (float)hp / (float)initHp;    // 게이지바
            if (++hitCount >= 10) ChangeGauge();    // 10번 맞으면 주인공 죽는다
        }
        else if (coll.gameObject.tag == "PLANE")
        {
            GameObject[] array = { move1, move2, move3 };
            int r = UnityEngine.Random.Range(0, 3);
            this.transform.position = new Vector3(array[r].transform.position.x, array[r].transform.position.y, array[r].transform.position.z + 5.0f);
        }
    }

    void ChangeGauge()
    {
        // 주인공 죽었다는 ui 나오게 하기
        GameOver();

    }

    void inputButtonCtrl()
    {
        float amtRot = rotSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("점프");
            animator.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("부스터");
            Time.timeScale = 0.0f;
            moveSpeed += 5.0f;
            animator.SetTrigger("Run");
            Time.timeScale = 1.5f;
            moveSpeed -= 5.0f;

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("공격");
            animator.SetTrigger("Attack 02");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
            Fire();
    }

    void Fire()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        CreateSnow();
    }

    void CreateSnow()
    {
        Instantiate(snow, snowpos.position, snowpos.rotation);
    }

    public void GameOver()
    {
        _resultText.text = "FAIL";

        Time.timeScale = 0.0f;
        if (_uiResult != null) _uiResult.SetActive(true);

    }

    void Regame()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("MazeScene");
    }
}