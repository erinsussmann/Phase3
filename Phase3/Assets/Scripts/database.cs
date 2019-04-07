using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class database : MonoBehaviour
{
    public static string user = "", name ="";
    private string password = "", rePass = "", message="";

    private void OnGUI()
    {
        if (message != "")
            GUILayout.Box(message);
    
        GUILayout.Label("Username");
        user = GUILayout.TextField(user);
        GUILayout.Label("Name");
        name = GUILayout.TextField(name);
        GUILayout.Label("Password");
        password = GUILayout.PasswordField(password, "*"[0]);
        GUILayout.Label("Re-enter Password");
        rePass = GUILayout.PasswordField(rePass, "*"[0]);
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


