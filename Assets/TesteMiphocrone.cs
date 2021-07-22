using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextSpeech;
using UnityEngine.Android;

public class TesteMiphocrone : MonoBehaviour
{
    private void Awake()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            Debug.Log("oi");

        }
    }
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            Debug.Log("oi");
            
        }
#endif
        image_button = bt_Gravar.GetComponent<Image>();
        Debug.Log("pegou");
        SpeechToText.instance.Setting("pt-BR");
        SpeechToText.instance.onResultCallback = OnResult;
        SpeechToText.instance.isShowPopupAndroid = false;
        Debug.Log("passou");
        bt_Gravar.onClick.AddListener(() =>
        {
            if (isRecord)
            {
                Debug.Log("Gravando");
                SpeechToText.instance.StartRecording();
                Debug.Log("Gravando 1.5");
                image_button.color = Color.red;
                isRecord = false;
                txt_Speek.text = "";
                Debug.Log("Gravando 2");
            }
            else
            {
                SpeechToText.instance.StopRecording();
                image_button.color = Color.white;
                isRecord = true;
            }
        });
    }

    private void OnResult(string result)
    {
        txt_Speek.text = result;
    }

    [SerializeField] private Button bt_Gravar;
    [SerializeField] private TextMeshProUGUI txt_Speek;

    private Image image_button;
    private bool isRecord;
}
