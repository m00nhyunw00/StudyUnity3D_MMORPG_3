using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;  // static을 통한 매니저 유일성 보장	
    public static Managers Instance { get { Init(); return s_instance; } }   // 유일성이 보장된 매니저 객체 반환

    // 다른 스크립트에서 Manager.Input.X로 매니저 접근 가능
    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        // 키 입력이 있는지 없는지 프레임마다 체크하며 키 입력 발생 시 Action 실행
        _input.OnUpdate();
    }

    // 게임 실행 시 초기 게임 환경 구성
    static void Init()
    {
        if (s_instance == null)
        {
            // 혹시 매니저가 이미 게임 상에 존재하는지 체크
            GameObject go = GameObject.Find("@Manager");

            // 게임 실행 시 매니저 생성
            if (go == null)
            {
                go = new GameObject { name = "@Manager" };
                go.AddComponent<Managers>();
            }

            // 매니저 파괴 방지
            DontDestroyOnLoad(go);

            // 동적으로 생성한 매니저 객체에 Manager 컴포넌트 부여
            s_instance = go.GetComponent<Managers>();
        }
    }
}

