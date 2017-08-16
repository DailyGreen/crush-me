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

    public GameObject JoystickGams;
    public GameObject SkillBtnGams;
    public GameObject SkillCoolLabelGams;

    public GameObject EarthGams;

    public static SGameMng I
    {
        get
        {
            if (_Instance == null)
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

        if (SSoundMng.I.nJoyStickNum == 0)                                                      //Left
        {
            JoystickGams.transform.localPosition = new Vector2(-140f, -380f);
            SkillBtnGams.transform.localPosition = new Vector2(135f, -375f);
            SkillCoolLabelGams.transform.localPosition = Vector2.zero;
        }
        else if (SSoundMng.I.nJoyStickNum == 1)                                                 //Right
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

    public bool bPause;
    public bool bStartCheck;
    public GameObject PlayerGame = null;
    public bool bMoveAccess = false;

    public int nTimeCount;
    public int nHightTimeCount;

    float[] gTime = new float[(int)E_TIME.E_MAX];

    public bool TimeCtrl(int nindex, float DelTime)
    {
        if (gTime[nindex] + DelTime <= Time.time)
        {
            gTime[nindex] = Time.time;
            return true;
        }
        return false;
    }
}

