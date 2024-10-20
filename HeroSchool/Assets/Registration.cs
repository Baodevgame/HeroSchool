using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passswordField;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passswordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php");
        yield return www;
        if(www.text=="0")
        {
            Debug.Log("User create successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation false. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 5 && passswordField.text.Length >= 8);
    }
}
