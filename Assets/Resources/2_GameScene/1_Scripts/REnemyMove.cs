using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REnemyMove : MonoBehaviour
{

    public enum E_MONSTERTYPE
    {
        E_NORMAL = 0,
        E_FOLLOW,
        E_MAX
    }

    public E_MONSTERTYPE nMonsterType;        // Monster Type, 유도인지 일반인지 레이저인지 걸러주기 위함.

    public Transform tfPlayer;               // Player Transfrom 
    public SpriteRenderer Sr;

    public float fRotateSpeed = 0.0f;   // 몬스터 회전 속도
    public float fMoveSpeed = 0.0f;     // 몬스터 움직이는 속도

    public bool bBulletColAccess = false;               //총알 충돌 허용
    public bool bBulletCol = false;                     //총알 충돌 판단

    [SerializeField] Vector3 dir;
    [SerializeField] float rotatetime;

    public Vector3 BulletRezenVec3;

    public static List<REnemyMove> v_bullet = new List<REnemyMove>();           // Bullet 오브젝트를 이곳에 모두 저장함
    public bool isColliding = false;                                            // true : 충돌중

    // Use this for initialization
    void Awake()
    {
        Sr = GetComponent<SpriteRenderer>();
        v_bullet.Add(this);                                             //v_bullet에 이 오브젝트를 추가함
    }
    void Start()
    {
        BulletRezenVec3 = transform.localPosition;

        fMoveSpeed = Random.Range(0.5f, 1.9f);


        if (nMonsterType.Equals(E_MONSTERTYPE.E_FOLLOW))
        {
            StartCoroutine(ChangeRotation());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!SGameMng.I.bPause && !SGameMng.I.bMoveAccess)
        {
            if (SGameMng.I.bStartCheck)
            {
                BulletRezen();
                Move();
            }
        }
    }

    void Move()
    {
        dir = tfPlayer.position - transform.position;
        rotatetime += Time.deltaTime;
        if (nMonsterType.Equals(E_MONSTERTYPE.E_FOLLOW) && rotatetime <= 5)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        transform.Translate(Vector3.up * Time.deltaTime * fMoveSpeed);
    }

    IEnumerator ChangeRotation()
    {
        yield return new WaitForSeconds(5.0f);

    }

    void BulletRezen()
    {
        if (bBulletCol)
        {
            transform.localPosition = BulletRezenVec3;
            bBulletCol = false;
            transform.localScale = Vector3.one;
            Sr.color = new Color(255f, 255f, 255f, 255f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hero"))
        {
            Sr.color = new Color(255f, 255f, 255f, 0f);
        }
        if (col.CompareTag("Shield"))
        {
            bBulletCol = true;
        }
        if (col.CompareTag("BackGround"))
        {
            isColliding = true;
        }

        if (col.CompareTag(" TransparencyWall"))                                //총알이 화면밖에 투명벽에 부딪혔을때 총알 재사용을 위한 곳
        {
            bBulletCol = true;
            rotatetime = 0f;

            if (fMoveSpeed <= 7f)
                fMoveSpeed += 0.01f;                                                 //총알 속도 증가
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("BackGround"))
        {
            isColliding = false;
        }
    }
}