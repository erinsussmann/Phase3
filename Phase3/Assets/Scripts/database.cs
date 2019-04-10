using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class database : MonoBehaviour
{
    public static string user = "", name ="";
    private string password = "", rePass = "", message="";
    private long width = Screen.width / 2, height = Screen.height/2;
    private int BoxW = 200, BoxH = 300;
    Texture tex;
    


    private bool registerFunc = false;

    private void OnGUI()
    {
        if (message != "")
        {
            GUILayout.BeginArea(new Rect(width - (BoxW / 2), height + (BoxH / 2), BoxW, BoxH));
            GUILayout.Box(message);
            GUILayout.EndArea();
        }

        if (registerFunc)
        {
            GUILayout.BeginArea(new Rect(width - (BoxW / 2), height - (BoxH / 2), BoxW, BoxH));
            GUILayout.Label("Username");
            user = GUILayout.TextField(user);
            GUILayout.Label("Name");
            name = GUILayout.TextField(name);
            GUILayout.Label("Password");
            password = GUILayout.PasswordField(password, "*"[0]);
            GUILayout.Label("Re-enter Password");
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
            GUILayout.Label("User:");
            user = GUILayout.TextField(user);
            GUILayout.Label("Password:");
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
                SceneManager.LoadScene(7);
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
        }
        else
        {
            message += "ERROR: " + w.error + "\n";
        }
    }

   

}


