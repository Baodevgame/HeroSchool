using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField nameField;
    public InputField passswordField;
    public Button submitButton;
    public Text errorText;

    void Start()
    {
        nameField.onValueChanged.AddListener(delegate { VerifyInputs(); });
        passswordField.onValueChanged.AddListener(delegate { VerifyInputs(); });
        errorText.text = "";
    }
    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passswordField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Login failed. Error: " + www.error);
                errorText.text = "loi ket noi den server";
            }
            else
            {
                if (www.downloadHandler.text == "0")
                {
                    Debug.Log("Login successful.");
                    errorText.text = "";
                    UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                }
                else
                {
                    Debug.Log("Login failed. Error: " + www.downloadHandler.text);
                    errorText.text = "sai tai khoan hoac mat khau";
                }
            }
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 5 && passswordField.text.Length >= 8);
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
