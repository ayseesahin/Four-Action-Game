using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourAction : MonoBehaviour
{
    public Text firstNumber, secondNumber, operations, answer, result, scoreText;
    public InputField answerInput;
    public int correctScore = 0, wrongScore = 0, blankScore = 0;
    int number1, number2, transactionSign;
    int transactionResult;
    bool questionGenerated = false;
    bool questionAnswered = true;
    bool isInputValid = true;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        answerInput.contentType = InputField.ContentType.IntegerNumber;

        questionGenerated = false;
        NewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnswerCheck()
    {
        questionAnswered = true;

        if (int.TryParse(answer.text, out int userAnswer))
        {
            if (userAnswer == transactionResult)
            {
                result.text = "TRUE";
                correctScore++;
            }
            else
            {
                result.text = "FALSE";
                wrongScore++;
            }
        }
        else
        {
            // Handle the case where the input is not a valid integer
            result.text = "INVALID INPUT";
            isInputValid = false;
        }

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"SCORE:  Correct: {correctScore}   Wrong: {wrongScore}   Blank: {blankScore}";
    }


    public void NewQuestion()
    {
        result.text = "";
        answerInput.text = "";

        if (questionGenerated && !questionAnswered || !isInputValid)
        {
       
            blankScore++;
            UpdateScoreText();
        
        }

        isInputValid = true;

        transactionSign = Random.Range(1, 6);
        switch (transactionSign)
        {
            case 1:
                operations.text = "+";
                number1 = Random.Range(0, 1000);
                number2 = Random.Range(0, 1000);
                transactionResult = number1 + number2;
                break;
            case 2:
                operations.text = "-";
                number2 = Random.Range(1, 1000);
                number1 = Random.Range(0, 1000);
                if (number1 < number2)
                {
                    number1 = number2 + Random.Range(0, 100);
                }
                transactionResult = number1 - number2;
                break;
            case 3:
                operations.text = "*";
                number1 = Random.Range(1, 100);
                number2 = Random.Range(0, 100);
                transactionResult = number1 * number2;
                break;
            case 4:
                operations.text = "*";
                number1 = Random.Range(1, 1000);
                number2 = Random.Range(0, 10);
                transactionResult = number1 * number2;
                break;
            case 5:
                operations.text = "/";
                number2 = Random.Range(1, 100);
                number1 = number2 * Random.Range(1, 10);
                transactionResult = number1 / number2;
                break;
          
        }
        firstNumber.text = number1 + "";
        secondNumber.text = number2 + "";
        questionGenerated = true;
        questionAnswered = false;
    }
}
