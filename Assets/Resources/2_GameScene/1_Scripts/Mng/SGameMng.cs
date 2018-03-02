using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum E_TIME
{
    E_COUNT = 0,
    E_LASER,
    E_MAX
}

public class SGameMng : MonoBehaviour
{
    private static SGameMng _Instance = null;

    public GameObject JoystickGams = null;
    public GameObject SkillBtnGams = null;
    public GameObject SkillCoolLabelGams = null;

    public GameObject EarthGams = null;

    public static SGameMng I
    {
        get
        {
            if (_Instance.Equals(null))
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    void Awake()
    {
        _Instance = this;

        if (!SSoundMng.I.bSoundOnOff)
            SSoundMng.I.Play("Game", false, true);

        if (SSoundMng.I.nJoyStickNum.Equals(0))                                                      //Left
        {
            JoystickGams.transform.localPosition = new Vector2(-140f, -380f);
            SkillBtnGams.transform.localPosition = new Vector2(135f, -375f);
            SkillCoolLabelGams.transform.localPosition = Vector2.zero;
        }
        else if (SSoundMng.I.nJoyStickNum.Equals(1))                                                 //Right
        {
            JoystickGams.transform.localPosition = new Vector2(160f, -380f);
            SkillBtnGams.transform.localPosition = new Vector2(-85f, -375f);
            SkillCoolLabelGams.transform.localPosition = new Vector2(-225f, 0f);
        }

    }

    void Update()
    {
        EarthGams.transform.Rotate(new Vector3(0f, 0f, -360f) * 0.2f * Time.deltaTime, Space.World);
    }

    public GameObject PlayerGame = null;
    public bool bPause;
    public bool bStartCheck;
    public bool bMoveAccess = false;
    public bool bPuaseBtn = false;

    public bool bLeftTouch = false;
    public bool bRightTouch = false;

    public int nTimeCount;
    public int nHightTimeCount;

    float[] gTime = new float[(int)E_TIME.E_MAX];

    public float fLazerTime = 5f;

    public bool TimeCtrl(int nindex, float DelTime)
    {
        if (gTime[nindex] + DelTime <= Time.time)
        {
            gTime[nindex] = Time.time;
            return true;
        }
        return false;
    }

    public IEnumerator LazerSpeedUp()
    {
        yield return new WaitForSeconds(10f);
        if (!bPuaseBtn)
        {
            if (fLazerTime >= 0.8f)
                fLazerTime -= 0.3f;
        }
        StartCoroutine(LazerSpeedUp());
    }

}