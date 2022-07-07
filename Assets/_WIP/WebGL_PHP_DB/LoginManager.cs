using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private Canvas loginCanvas, successCanvas, failCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleLogin() {
        bool success = false;

        if(success) {
            loginCanvas.gameObject.SetActive(false);
            successCanvas.gameObject.SetActive(true);
        } else {
            failCanvas.gameObject.SetActive(true);
        }
    }

    private string formNick = ""; //this is the field where the player will put the name to login
    private string formPassword = ""; //this is his password
    string formText = ""; //this field is where the messages sent by PHP script will be in
    
    string URL = "http://mywebsite/check_scores.php"; //change for your URL
    string hash = "hashcode"; //change your secret code, and remember to change into the PHP file too
    
    private Rect textrect = new Rect (10, 150, 500, 500); //just make a GUI object rectangle

 
    void Login() {
        var form = new WWWForm(); //here you create a new form connection
        form.AddField( "myform_hash", hash ); //add your hash code to the field myform_hash, check that this variable name is the same as in PHP file
        form.AddField( "myform_nick", formNick );
        form.AddField( "myform_pass", formPassword );
        var w = WWW(URL, form); //here we create a var called 'w' and we sync with our URL and the form
        yield w; //we wait for the form to check the PHP file, so our game dont just hang
        if (w.error != null) {
            print(w.error); //if there is an error, tell us
        } else {
            print("Test ok");
            formText = w.data; //here we return the data our PHP told us
            w.Dispose(); //clear our form in game
        }
    
        formNick = ""; //just clean our variables
        formPassword = "";
}
 
}
