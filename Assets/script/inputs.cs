using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inputs : MonoBehaviour
{
    private int num1, num2, answer, correct1 = 0, incorrect1 = 0, round01 = 1,useranswer;
    private float timer1;
    public Text equation, correct, incorrect, round, time1, averageTimeText;
    public InputField Input;
    public GameObject panel;
    bool isrunning = true;
    private List<float> questionTimes = new List<float>();
    private float questionEndTime, questionStartTime;
    public Button button;

    public void Start()
    {
        multipy();
       

        Input.onValueChanged.AddListener(OnInputChanged);
        button.onClick.AddListener(OnSubmit);
        CheckInput();

    }

    void OnInputChanged(string input)
    {
        CheckInput();
    }
    void CheckInput()
    {
        button.interactable = !string.IsNullOrEmpty(Input.text);
    }
    void OnSubmit()
    {
        string userInput = Input.text;
    }
    public void multipy()
    {
        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);
        answer = num1 * num2;
        equation.text = num1 + " x " + num2;

    }
    public void check()
    {
        questionEndTime = Time.time;
        float timeTaken = (questionEndTime - questionStartTime);
        questionTimes.Add(timeTaken);

       
        if (int.TryParse(Input.text, out useranswer))
        {
            if (useranswer == answer)
            {
                correct1++;
                correct.text = "" + correct1;

            }
            else
            {
                incorrect1++;
                incorrect.text = "" + incorrect1;
            }
            Input.text = "";
            multipy();

            round01++;
            round.text = round01 + "/5";
            if (round01 == 6)
            {
                panel.SetActive(true);
                isrunning = false;
            }
            else
            {
                panel.SetActive(false);
                isrunning = true;
            }
        }
    }
    public void Update()
    {

        if (isrunning)
            timer1 += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer1 / 60);
        int second = Mathf.FloorToInt(timer1 % 60);
        time1.text = string.Format("{0:00}:{1:00}", minutes, second);


        ShowResults();

    }

    public void ShowResults()
    {
        averageTimeText.text = "";
        for (int i = 0; i < questionTimes.Count; i++)
        {
            float roundedTime = Mathf.Round(questionTimes[i] * 10f) / 10f;
            averageTimeText.text += "Time taken in question " + (i + 1) + "." + " is " + roundedTime.ToString("F1") + ","+"\n";
        }

    }
   
    
}
