using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquationGenerator : MonoBehaviour
{
    [Header("UI Элементы")]
    public Toggle toggleAdd;
    public Toggle toggleSub;
    public Toggle toggleMul;
    public Toggle toggleDiv;
    public TMP_Text textDisplay;

    public void GenerateEquation()
    {
        string operation = "";

        int count = 0;
        if (toggleAdd.isOn)
        {
            operation = "+";
            count++;
        }
        if (toggleSub.isOn) 
        {
            operation = "-";
            count++;
        }
        if (toggleMul.isOn)
        {
            operation = "*";
            count++;
        }
        if (toggleDiv.isOn) 
        { 
            operation = "/";
            count++;
        }
        if (count > 1)
        {
            textDisplay.text = "Выберите действие!";
            return; 
        } 
        

        int num1 = Random.Range(1, 20);
        int num2 = Random.Range(1, 20);
        int result = 0;

        if (operation == "/")
        {
            result = num1; 
            num1 = result * num2; 
        }
        else
        {
            result = CalculateResult(num1, num2, operation);
        }

        
        int unknownIndex = Random.Range(0, 3);
        textDisplay.text = FormatEquation(num1, num2, result, operation, unknownIndex);
    }

    private int CalculateResult(int n1, int n2, string op)
    {
        return op switch
        {
            "+" => n1 + n2,
            "-" => n1 - n2,
            "*" => n1 * n2,
            _ => 0
        };
    }

    private string FormatEquation(int n1, int n2, int res, string op, int unknownIndex)
    {
        string s1 = (unknownIndex == 0) ? "X" : n1.ToString();
        string s2 = (unknownIndex == 1) ? "X" : n2.ToString();
        string s3 = (unknownIndex == 2) ? "X" : res.ToString();

        return $"{s1} {op} {s2} = {s3}";
    }
}

