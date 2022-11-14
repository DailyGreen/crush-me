using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSoundMng : MonoBehaviour
{
    public AudioSource MainAudio = null;
    [SerializeField]
    AudioSource EffectAudio = null;
    [SerializeField]
    AudioSource EffectAudio2 = null;
    [SerializeField]
    AudioClip[] SoundClip = null;

    private static SSoundMng _Instance = null;

    public int nJoyStickNum;
    public int nCharNum;
    private int nCredit;

    public int nAC
    {
        get
        {
            return nCredit;
        }
        set
        {
            nCredit = value;
        }
    }

    public bool[] bCharLock;

    public bool bBackGroundSound;       // true 배경음악 나옴 false 안나옴
    public bool bEffectSound;           // true 효과음 나옴 false 안나옴

    public bool bJoyPos;

    public static SSoundMng I
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
        string[] charUnLock;
        Screen.SetResolution(540, 960, false);
        _Instance = this;
        StartCoroutine("SoundCtrl");
        DontDestroyOnLoad(transform.gameObject);
        nAC = PlayerPrefs.GetInt("Credit");
        charUnLock = PlayerPrefs.GetString("Char").Split(',');
        for (int i = 0; i < bCharLock.Length; i++)
        {
            int temp = System.Convert.ToInt32(charUnLock[i]);
            bCharLock[i] = System.Convert.ToBoolean(temp);
        }
        nCharNum = PlayerPrefs.GetInt("EquipChar");
    }

    public void Play(string sSoundName, bool bEffectAudio, bool bAutoPlay)
    {
        if (bAutoPlay.Equals(true))
        {
            MainAudio.playOnAwake = true;
            MainAudio.loop = true;
        }
        else
        {
            MainAudio.playOnAwake = false;
            MainAudio.loop = false;
        }

        for (int i = 0; i < SoundClip.Length; i++)
        {
            if (!bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                MainAudio.clip = SoundClip[i];
                MainAudio.Play();
            }
            else if (!EffectAudio.isPlaying && bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                EffectAudio.clip = SoundClip[i];
                EffectAudio.Play();
            }
            else if (EffectAudio.isPlaying && bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                EffectAudio2.clip = SoundClip[i];
                EffectAudio2.Play();
            }
        }
    }

    void SoundOff()
    {
        if (bBackGroundSound)
        {
            if (!MainAudio.playOnAwake || !MainAudio.loop)
            {
                MainAudio.playOnAwake = true;
                MainAudio.loop = true;
            }
            MainAudio.enabled = true;
        }
        else
        {
            MainAudio.enabled = false;
        }

        if (bEffectSound)
        {
            EffectAudio.enabled = true;
            EffectAudio2.enabled = true;
        }
        else
        {
            EffectAudio.enabled = false;
            EffectAudio2.enabled = false;
        }
    }

    IEnumerator SoundCtrl()
    {
        yield return null;
        SoundOff();

        StartCoroutine("SoundCtrl");
    }

	private void OnApplicationQuit()
	{
        string charUnlock = "";
        PlayerPrefs.SetInt("Credit", nAC);
        for(int i = 0; i < bCharLock.Length; i++)
        {
            charUnlock = charUnlock + System.Convert.ToInt32(bCharLock[i]).ToString();
            if(i < bCharLock.Length - 1)
            {
                charUnlock = charUnlock + ",";
            }
        }
        PlayerPrefs.SetString("Char", charUnlock);
        //PlayerPrefs.SetString("Char", "0,0,0,0,0,0,0,0");         // 캐릭터 잠김 초기화
        PlayerPrefs.SetInt("EquipChar", nCharNum);
    }
}