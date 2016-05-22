using UnityEngine;
using System.Collections;
using System;

public class ModeMenager : MonoBehaviour
{
    private static ModeMenager _instance;

    public static ModeMenager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ModeMenager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public static Camera MainCam;
    public static GameObject blinder;
    public static GameObject confuse;
    public static bool resetMachine;
    Rotate r;
    GhostMove b; 
    GhostMove p;
    GhostMove i; 
    GhostMove c;

    public static bool reverseMode=false;

    public float modeTime;
    public enum ModeState { Norm, Rotate, Blind, Reverse,  Close, Speedo }
    public static ModeState modeState;

    void Awake() {
        b = GameObject.Find("blinky").GetComponent<GhostMove>();
        p = GameObject.Find("pinky").GetComponent<GhostMove>();
        i = GameObject.Find("inky").GetComponent<GhostMove>();
        c = GameObject.Find("clyde").GetComponent<GhostMove>();
        
        resetMachine = false;
        blinder = GameObject.Find("blackout");
        confuse = GameObject.Find("confuse");
        MainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        r = MainCam.GetComponent<Rotate>();
        modeState = ModeState.Norm;
     if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
    }
        else
        {
            if(this != _instance)   
                Destroy(this.gameObject);
    }
}

void Start () {
        //StartCoroutine(ReturnToNormalState());
        StartMode();
    }


    // Update is called once per frame
    void Update()
    {
        if (resetMachine)
        {
            resetMachine = false;
            StopAllCoroutines();
            modeState = ModeState.Norm;
            StartMode();
        }
    }
    

    void StartMode()
    {
        switch (modeState)
        {  
        
            case ModeState.Norm:
                {
                    StartCoroutine(Normal());
                    ModeTexts.ChangeText();
                    break;
                }
            case ModeState.Close:
                {
                    //StopCoroutine(ReturnToNormalState());
                    StartCoroutine(Close());
                    ModeTexts.ChangeText();
                    break;
                }
            case ModeState.Blind:
                {
                    StartCoroutine(Blind());
                    ModeTexts.ChangeText();
                    break;
                }
            case ModeState.Reverse:
                {
                    StartCoroutine(Reverse());
                    ModeTexts.ChangeText();
                    break;
                }
            case ModeState.Rotate:
                {
                    StartCoroutine(Rotate());
                    ModeTexts.ChangeText();
                    break;
                }
            case ModeState.Speedo:
                {
                    StartCoroutine(Speedo());
                    ModeTexts.ChangeText();
                    break;
                }
            default:
                StartCoroutine(Normal());
                ModeTexts.ChangeText();
                break;

        }
    }

    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue( UnityEngine.Random.Range(1, v.Length));
    }


    IEnumerator Normal()
    {
        yield return ReturnToNormalState();
        yield return new WaitForSeconds(5f);
        modeState = RandomEnumValue<ModeState>();
            Debug.Log(modeState);
        StartMode();
        yield break;
        
    }

    IEnumerator Blind()
    {
        blinder.SetActive(true);
        yield return new WaitForSeconds(modeTime);
        modeState = ModeState.Norm;
        StartMode();
        yield break;
    }
    IEnumerator Speedo()
    {
        
        b.speed = 0.16f;
        p.speed = 0.16f;
        i.speed = 0.16f;
        c.speed = 0.16f;
        yield return new WaitForSeconds(modeTime);
        modeState = ModeState.Norm;
        StartMode();
        yield break;
    }

    IEnumerator Rotate()
    {
        
        r.rotate = true; 
        yield return new WaitForSeconds(modeTime);
        modeState = ModeState.Norm;
        StartMode();
        yield break;
    }

    IEnumerator Reverse()
    {
        confuse.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        reverseMode = true;
        yield return new WaitForSeconds(modeTime);
        modeState = ModeState.Norm;
        StartMode();
        yield break;
    }

    IEnumerator Close()
    {
        while (MainCam.orthographicSize > 6)
        {
            MainCam.orthographicSize -= 4f * Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSeconds(modeTime);
        modeState = ModeState.Norm;
        StartMode();
        yield break;
    }

    IEnumerator ReturnToNormalState()
    {
        b.speed = 0.12f;
        p.speed = 0.12f;
        i.speed = 0.12f;
        c.speed = 0.12f;
        reverseMode = false;
        blinder.SetActive(false);
        confuse.SetActive(false);
        r.rotate = false;
        /*  if (MainCam.transform.rotation.z < 0)
          {
              while (MainCam.transform.rotation.z < 0)
              {
                  MainCam.transform.Rotate(new Vector3(0f, 0f, -150f * Time.deltaTime));
                  yield return null;
              }
          }
          else
          {
              while (MainCam.transform.rotation.z > 0)
              {
                  MainCam.transform.Rotate(new Vector3(0f, 0f, 10f));
                  yield return null;
              }
          }*/
        while (MainCam.orthographicSize < 13)
        {
            MainCam.orthographicSize += 5f * Time.deltaTime;
            
            yield return null;
        }
        yield return null;
        if (MainCam.transform.rotation.z != 0)
            MainCam.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

        yield break; 
    }


}
