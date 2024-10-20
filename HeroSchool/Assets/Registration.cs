using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

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

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("User creation failed. Error: " + www.error);
            }
            else
            {
                if (www.downloadHandler.text == "0")
                {
                    Debug.Log("User created successfully.");
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
                }
                else
                {
                    Debug.Log("User creation failed. Error: " + www.downloadHandler.text);
                }
            }
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 5 && passswordField.text.Length >= 8);
    }
}
