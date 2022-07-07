using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class LoginManager : MonoBehaviour
{

    [SerializeField]
    private Canvas loginCanvas, successCanvas, failCanvas;
    // Start is called before the first frame update
    [SerializeField]
    private InputField usernameBox, passwordBox;

    private bool success = false;
    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetRequest("http://gljf.learnictnow.com/login_check.php"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    if(webRequest.downloadHandler.text == "SUCCESS") {
                        success = true;
                    } else {
                        success = false;
                    }
                    break;
            }

            if(success) {
                loginCanvas.gameObject.SetActive(false);
                successCanvas.gameObject.SetActive(true);
            } else {
                failCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void HandleLogin() {

        string url = "http://gljf.learnictnow.com/login_check.php";
        url = url + "?u=" + usernameBox.text;
        url = url + "&p=" + passwordBox.text;

        StartCoroutine(GetRequest(url));

        
    }
}
