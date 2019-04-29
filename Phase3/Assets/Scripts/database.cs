using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class database : MonoBehaviour
{
    public static string user = "", name ="";
    private string password = "", rePass = "", message="";
    private long width = Screen.width / 2, height = Screen.height/2;
    private int BoxW = 400, BoxH = 800;
    Texture tex;

 



    private bool registerFunc = false;

    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.label);
        myStyle.fontSize = 35;

        GUIStyle myStyle2 = new GUIStyle(GUI.skin.label);
        myStyle2.fontSize = 72;

        GUI.skin.textField.fontSize = 30;

        GUI.skin.button.fontSize = 30;

        GUI.skin.box.fontSize = 30;


        myStyle.normal.textColor = Color.black;

        myStyle2.normal.textColor = Color.black;

        myStyle2.alignment = TextAnchor.UpperCenter;

        GUIStyle myBox = new GUIStyle(GUI.skin.box);
        myBox.alignment = TextAnchor.UpperCenter;


        if (message != "")
        {
            GUILayout.BeginArea(new Rect(width - (BoxW / 2), 950, BoxW, BoxH));
            GUILayout.Box(message, myBox);
            GUILayout.EndArea();
        }

        if (registerFunc)
        {
            GUILayout.BeginArea(new Rect(width - (BoxW / 2), height - (BoxH / 2), BoxW, BoxH));
            GUILayout.Label("");
            GUILayout.Label("");
            GUILayout.Label("Registration",myStyle2);
            GUILayout.Label("");
            GUILayout.Label("Username", myStyle);
            user = GUILayout.TextField(user);
            GUILayout.Label("Name", myStyle);
            name = GUILayout.TextField(name);
            GUILayout.Label("Password", myStyle);
            password = GUILayout.PasswordField(password, "*"[0]);
            GUILayout.Label("Re-enter Password", myStyle);
            rePass = GUILayout.PasswordField(rePass, "*"[0]);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Back"))
            {
            registerFunc = false;
            message = "";
            }

            if (GUILayout.Button("Register"))
            {
                message = "";
                if (user == "" || name == "" || password == "")
                    message += "Please enter all the fields \n";
                else if (password == rePass)
                {
                    WWWForm form = new WWWForm();
                    form.AddField("user", user);
                    form.AddField("name", name);
                    form.AddField("password", password);
                    WWW w = new WWW("http://stressful.atwebpages.com/register.php", form);
                    StartCoroutine(register(w));

                }
                else
                    message += "Your Passwords do not match \n";
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        else
        {
            GUILayout.BeginArea(new Rect(width - (BoxW / 2), height - (BoxH / 2), BoxW, BoxH));
            GUILayout.Label("");
            GUILayout.Label("");
            GUILayout.Label("Login", myStyle2);
            GUILayout.Label("User:", myStyle);
            user = GUILayout.TextField(user);
            GUILayout.Label("Password:", myStyle);
            password = GUILayout.PasswordField(password, "*"[0]);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Login"))
            {
                message = "";
                if (user == "" || password == "")
                {
                    message += "Please enter all the fields \n";

                }
                else
                {
                    WWWForm form = new WWWForm();
                    form.AddField("user", user);
                    form.AddField("password", password);
                    WWW w = new WWW("http://stressful.atwebpages.com/login.php", form);
                    StartCoroutine(login(w));

                }

            }
        
            if (GUILayout.Button("Register"))
            {
                registerFunc = true;
            }


            GUILayout.EndHorizontal();
            GUILayout.EndArea();


            
        }
    }

    IEnumerator login(WWW w)
    {
        yield return w;
        if (w.error == null)
        {
            if (w.text == "login-SUCCESS")
            {
                SceneManager.LoadScene(1); //changes 7 to 1
            }
            else
            {
                message += w.text;
            }
            
        }
        else
        {
            message += "ERROR: " + w.error + "\n";
        }
    }

    IEnumerator register(WWW w)
    {
        yield return w;
        if(w.error == null)
        {
            message += w.text;
			SceneManager.LoadScene(1); //changes 7 to 1
        }
        else
        {
            message += "ERROR: " + w.error + "\n";
        }
    }

   

}


