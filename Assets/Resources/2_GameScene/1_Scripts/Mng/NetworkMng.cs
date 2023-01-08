using System.Collections;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Networking;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkMng : MonoBehaviourPunCallbacks
{
    public string nickname = "";        // <! 닉네임

    const int MAX_PLAYER = 2;
    private static NetworkMng _Instance;

    public static NetworkMng I
    {
        get
        {
            if (_Instance.Equals(null))
            {
                Debug.Log("Instance is null");
            }
            return _Instance;
        }
    }

    private void Awake()
    {
        _Instance = this;
        DontDestroyOnLoad(this);
        ConnectToServer();
    }

    public void ConnectToServer()
    {
        Debug.Log("Connect To Main Server");
        PhotonNetwork.GameVersion = "1.0";      // 게임 버전
        PhotonNetwork.ConnectUsingSettings();   // 서버 연결
    }

    private void Update()    // <! 디버그용
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            PhotonNetwork.JoinRandomRoom();      // 렌덤 room 들어가는곳
            // PhotonNetwork.JoinRandomRoom();
        }
    }
    /**
     * @brief 웹통신으로 로그인
     */
    public void Login()
    {
        // try
        // {
        //     // 로그인
        // }
        // catch
        // {
        //     // 로그인 실패 UI 만들어주세요
        // }
        if (Application.internetReachability.Equals(NetworkReachability.NotReachable))
        {
            // 인터넷이 연결 안되어 있을
            Debug.LogError("network disconnected");
        }
        else
        {
            // TODO 서버 상태보고 로그인 구현
        }
    }

    /**
     * @brief Master권한으로 서버 연결 callback 함수
     */
    public override void OnConnectedToMaster()
    {
        //Debug.Log("Joined Lobby");
    }

    public override void OnJoinRandomFailed(short retrunCode, string message)
    {
        //Debug.Log("no room");
        // PhotonNetwork.CreateRoom("myroom");
        JoinRandomOrCreateRoom();
    }

    public void JoinRandomOrCreateRoom()
    {
        Debug.Log($"{nickname} 랜덤 매칭 시작.");
        PhotonNetwork.LocalPlayer.NickName = nickname; // 현재 플레이어 닉네임 설정하기.

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = MAX_PLAYER; // 인원 지정.

        // 방 참가를 시도하고, 실패하면 생성해서 참가함.
        PhotonNetwork.JoinRandomOrCreateRoom(
            expectedMaxPlayers: MAX_PLAYER, // 참가할 때의 기준.
            roomOptions: roomOptions // 생성할 때의 기준.
        );
    }

    /**
     * @brief 방 들어간거 성공 했을때 callback 함수
     */
    public override void OnJoinedRoom()
    {
        // SceneManager.LoadScene("New Scene");
        StartCoroutine(this.CreatePlayer());
        //Debug.Log("Joined room");
    }
    /**
     * @brief player 생성
     */
    IEnumerator CreatePlayer()
    {
        PhotonNetwork.Instantiate("2_GameScene/4_Prefab/MultyPlayer", Vector3.zero, Quaternion.identity);
        yield return null;
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
}