using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


public class Register : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confpassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string form;
    private bool EmailValid=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RegisterButton()
    { bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;
        
        if (Username != "") {
            if (System.IO.File.Exists(@"E:/Proiect_Joc_InfoFolder/" + Username + ".txt"))
            {
                UN = true;
            }
            else
            {
                Debug.LogWarning("Username Taken");
            } }
        else
        {
            Debug.LogWarning("Username field Empty");
        }
        if(Email != "")
        {
            if (EmailValid)
            {
                if (Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        EM = true;
                    }
                    else
                    {
                        Debug.LogWarning("Email is Incorrect");
                    }

                }
                else
                {
                    Debug.LogWarning("Email is Incorrect");
                }


            }
            else
            {
                Debug.LogWarning("Email is Incorrect");

            }

        }
        else
        {
            Debug.LogWarning("Email Field Empty");

        }
        if(Password != "")
        {
            if (Password.Length > 5)
            {
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password Must Be at least 6 Characters long");
            }
        }
        else
        {
            Debug.LogWarning("Password field Empty");
        }
        if (ConfPassword != "")
        {
            if(ConfPassword == Password)
            {
                CPW = true;

            }
            else {
                Debug.LogWarning("Passwords don't Match");
            }
        }
        else
        {
            Debug.LogWarning("Confirm Password Field Empty");
        }
        if(UN == true && EM==true&&PW==true && CPW == true)
        {
            bool Clear = true;
            int i = 1;
            foreach(char c in Password)
            {
                if (Clear)
                {
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                Password += Encrypted.ToString();
            }
            form = (Username + "\n" + Email + "\n" + Password);
            System.IO.File.WriteAllText(@"E:/Proiect_Joc_InfoFolder/" + Username + ".txt", form);
            username.GetComponent<InputField>().text="";
            email.GetComponent<InputField>().text="";
             password.GetComponent<InputField>().text="";
            confpassword.GetComponent<InputField>().text="";
            print("Registration Complete");
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();


            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confpassword.GetComponent<InputField>().Select();


            }
            if (username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();


            }

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Email !="" && Password != ""&&ConfPassword != "")
            {
                RegisterButton();
            }
        } 
        Username = username.GetComponent<InputField>().text;
        Email=email.GetComponent<InputField>().text;
        Password=password.GetComponent<InputField>().text;
        ConfPassword=confpassword.GetComponent<InputField>().text;

    }
}
