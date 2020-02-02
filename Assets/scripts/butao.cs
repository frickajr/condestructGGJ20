using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class butao : MonoBehaviour
{   
    public Button buton;
    public string level;

    // Start is called before the first frame update
    void Start()
    {
        buton = GetComponent<Button>();
        buton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(buton.onClick){
         SceneManager.LoadScene("testepersonagem", LoadSceneMode.Additive);
         }*/
    }
    
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(level);
    }




}




