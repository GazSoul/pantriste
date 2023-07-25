using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Server : MonoBehaviour
{

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://127.0.0.1/sqlconnect/login.php", form);
        yield return www;
        /* if(www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            //DBManager.score = int.Parse(www.text.Split('\t')[1]);
        }
        else
        {
            Debug.Log("El login ha fallado. Error: " + www.text);
        } */
        

        if (www.error != null) {
			//errorMessages.text = "404 not found!";
			//Debug.Log("<color=red>"+www.text+"</color>");//error
            Debug.Log("aaaaaaaaaaaaaaaa>");
		} else {
			if (www.isDone) {
				if (www.text.Contains("error")) {
					//errorMessages.text = "invalid username or password!";
					Debug.Log("bbbbbbbbbbbbbb");//error
				} else {
					//open welcom panel
					//SceneManager.LoadScene("Main Menu");
					//welcomePanel.SetActive(true);
					//user.text = username.text;
					Debug.Log("ccccccccccccccc");//user exist
                    DBManager.username = nameField.text;
				}
			}
		}


    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 1 && passwordField.text.Length >= 1);
    }


}
