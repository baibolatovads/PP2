using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculatortop
{
    public delegate void MyDelegate(string msg);
    public enum CurrentState
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithDecimal,
        ComputeSingleOp,
        ComputePending,
        Compute,
        ShowResult,
        ShowError
    }

    public class Brain
    {
        public string firstNumber = "0";
        public string secondNumber = "0";
        public string currentNumber = "0";
        public string result = "0";
        public string op = "";

        public double memoryNum = 0;
        public MyDelegate invoker;
        public CurrentState currentState;
        string[] all_digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] non_zero_digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] zero_digits = { "0" };
        string[] singleop = { "sqrt", "1/x", "+-", "x^2" };
        string[] deletebtn = { "CE", "C", "⌫" };
        string[] operations = { "+", "-", "*", "/"};
        string[] equals = { "=" };
        string[] separators = { "," };

        string[] memory = { "MC", "MR", "M+", "M-", "MS" };
        public Brain()
        {
            currentState = CurrentState.Zero;
        }

        public void Process(string operation)
        {
            if (memory.Contains(operation))
            {
                MemoryProcess(operation);
            }
            if (deletebtn.Contains(operation))
            {
                deleteit(operation);
            }
            switch (currentState)
            {
                case CurrentState.Zero:
                    Zero(false, operation);
                    break;
                case CurrentState.AccumulateDigits:
                    AccumulateDigits(false, operation);
                    break;
                case CurrentState.AccumulateDigitsWithDecimal:
                    AccumulateDigitsWithDecimal(false, operation);
                    break;
                case CurrentState.ComputeSingleOp:
                    ComputeSingleOp(false, operation);
                    break;
                case CurrentState.ComputePending:
                    ComputePending(false, operation);
                    break;
                case CurrentState.Compute:
                    Compute(false, operation);
                    break;
                /*case CurrentState.ShowResult:
                    ShowResult(false, operation);
                    break;*/
                case CurrentState.ShowError:
                    break;
                default:
                    break;
            }
        }

        public void MemoryProcess(string info)
        {
            switch (info)
            {
                case "MC":
                    memoryNum = 0;
                    break;
                case "MR":
                    currentNumber = "0";
                    Process(memoryNum.ToString());
                    break;
                case "MS":
                    memoryNum = double.Parse(currentNumber);
                    currentNumber = "0";
                    break;
                case "M+":
                    memoryNum += double.Parse(currentNumber);
                    currentNumber = "0";
                    break;
                case "M-":
                    memoryNum -= double.Parse(currentNumber);
                    currentNumber = "0";
                    break;
            }
            invoker.Invoke(currentNumber);

        }

        public void deleteit(string info)
        {
            switch (info)
            {
                case "CE":
                    //firstNumber = currentNumber;
                    currentNumber = "0";
                    //secondNumber = "0";
                    /*invoker.Invoke(currentNumber);
                    invoker.Invoke(firstNumber);*/
                    invoker.Invoke(currentNumber);
                    break;
                case "C":
                    firstNumber = "0";
                    secondNumber = "0";
                    currentNumber = "0";
                    invoker.Invoke(currentNumber);
                    invoker.Invoke(firstNumber);
                    invoker.Invoke(secondNumber);
                    break;
                case "⌫":
                    currentNumber = currentNumber.Remove(currentNumber.Length - 1, 1);
                    if (currentNumber.Length == 0)
                    {
                        currentNumber = "0";
                    }
                    invoker.Invoke(currentNumber);
                    break;
                default:
                    break;
            }
           /* invoker.Invoke(currentNumber);
            invoker.Invoke(firstNumber);
            invoker.Invoke(secondNumber);
           */
        }
        public void Zero(bool isInput, string info)
        {
            if (isInput)
            {
                firstNumber = "0";
                secondNumber = "0";
                currentNumber = "0";
                op = "";

                invoker.Invoke("0");
                currentState = CurrentState.Zero;
            }
            else
            {
                if (non_zero_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }
                else if (zero_digits.Contains(info))
                {
                    Zero(true, info);
                }
                else if (separators.Contains(info))
                {
                    AccumulateDigitsWithDecimal(true, info);
                }
            }
        }
       
        public void AccumulateDigits(bool isInput, string info)
        {
            if (isInput)
            {
                if (currentNumber.Length >= 1 && currentNumber != "0")
                {
                    currentNumber = currentNumber + info;
                }
                else if (currentNumber.Length == 1 && currentNumber == "0")
                {
                    currentNumber = info;
                }
                invoker.Invoke(currentNumber);
                currentState = CurrentState.AccumulateDigits;
            }
            else
            {
                if (all_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }
                else if (operations.Contains(info))
                {
                    ComputePending(true, info);
                }
                else if (equals.Contains(info))
                {
                    Compute(true, info);
                }
                else if (separators.Contains(info))
                {
                    AccumulateDigitsWithDecimal(true, info);
                }
                else if (singleop.Contains(info))
                {
                    ComputeSingleOp(true, info);
                }
            }

        }
        public void AccumulateDigitsWithDecimal(bool isInput, string info)
         {
             if (isInput)
             {
                if(info == ",")
                {
                    if (!currentNumber.Contains(info))
                    {
                        currentNumber += info;
                    }
                }
                else
                {
                    currentNumber += info;
                }
                
                 invoker.Invoke(currentNumber);
                 currentState = CurrentState.AccumulateDigitsWithDecimal;
             }
             else
             {
                 if (all_digits.Contains(info))
                 {
                     AccumulateDigitsWithDecimal(true, info);
                 }
                 else if (operations.Contains(info))
                 {
                     ComputePending(true, info);
                 }
                 else if (equals.Contains(info))
                {
                    Compute(true, info);
                }
                 else if (singleop.Contains(info))
                {
                    ComputeSingleOp(true, info);
                }
                 else if (separators.Contains(info))
                {
                    AccumulateDigitsWithDecimal(true, info);
                }
             }
         }

        public void ComputeSingleOp(bool isInput, string info)
        {
            if (isInput)
            {
                
                double r = double.Parse(currentNumber);
                if (info == "sqrt")
                {
                    r = Math.Sqrt(r);
                }
                else if (info == "1/x")
                {
                    r = 1 / r;
                }
                else if (info == "x^2")
                {
                    r = r * r;
                }
                else if (info == "+-")
                {
                    r = -r;
                }
                else if (info == "%")
                {
                    r = r / 100;
                }
                result = r.ToString();
                currentNumber = result;
                if (result == "NaN" || result == "inf")
                {
                    firstNumber = "0";
                    secondNumber = "0";
                    currentNumber = "0";
                    op = "";
                    invoker.Invoke("Error!");
                    currentState = CurrentState.Zero;
                }
                else
                {
                    invoker.Invoke(result);
                    currentState = CurrentState.ComputeSingleOp;
                }
            }
            else
            {
                if (operations.Contains(info))
                {
                    ComputePending(true, info);
                }
                else if (all_digits.Contains(info))
                {
                    firstNumber = "0";
                    secondNumber = "0";
                    currentNumber = "0";
                    result = "0";
                    op = "";

                    if (non_zero_digits.Contains(info))
                    {
                        AccumulateDigits(true, info);
                    }
                    else if (zero_digits.Contains(info))
                    {
                        Zero(true, info);
                    }
                }
                else if (singleop.Contains(info))
                {
                    ComputeSingleOp(true, info);
                }
                else if (separators.Contains(info))
                {
                    Zero(true, info);
                }
            }
        }
         /*
        public void AccumulateDigitsWithDecimal(bool isInput, string info)
        {
            if (isInput)
            {
                if (info == "." && !result.Contains('.'))
                {
                    result += '.';
                }
                else
                {
                    result += info;
                }
                invoker.Invoke(result);
            }
            else
            {
                if (all_digits.Contains(info))
                {
                    AccumulateDigitsWithDecimal(true, info);
                }
                else if (operations.Contains(info))
                {
                    ComputePending(true, info);
                }
            }
        }
        */
        public void ComputePending(bool isInput, string info)
        {
            if (isInput)
            {
                op = info;
                firstNumber = currentNumber;
                currentNumber = "0";
                currentState = CurrentState.ComputePending;
                invoker.Invoke(currentNumber);
            }
            else
            {
                if (operations.Contains(info))
                {
                    op = info;
                }
                else if (all_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }
                else if (singleop.Contains(info))
                {
                    ComputeSingleOp(true, info);
                }
                else if (separators.Contains(info))
                {
                    AccumulateDigitsWithDecimal(true, info);
                }
            }
        }

        public void Compute(bool isInput, string info)
        {
            if (isInput)
            {
                secondNumber = currentNumber;
                currentNumber = "0";
                double a1 = double.Parse(firstNumber);
                double a2 = double.Parse(secondNumber);
                double r = 0;
                if (op == "+")
                {
                    r = a1 + a2;
                }
                else if (op == "-")
                {
                    r = a1 - a2;
                }
                else if (op == "/")
                {
                    r = a1 / a2;
                }
                else if (op == "*")
                {
                    r = a1 * a2;
                }
                result = r.ToString();
                firstNumber = result;
                currentState = CurrentState.Compute;
                if (result == "NaN" || result == "inf")
                {
                    firstNumber = "0";
                    secondNumber = "0";
                    currentNumber = "0";
                    op = "";
                    invoker.Invoke("Error!");
                    currentState = CurrentState.Zero;
                }
                else
                {
                    invoker.Invoke(result);
                }
            }
            else
            {
                if (all_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }
                else if (operations.Contains(info))
                {
                    op = info;
                }
                else if(singleop.Contains(info))
                {
                    currentNumber = result;
                    ComputeSingleOp(true, info);
                }
            }
        }

       

                /*  public void ShowResult(bool isInput, string info)
                  {
                      if (isInput)
                      {
                          switch (info)
                          {
                              case "+":
                                  result = (int.Parse(firstNumber) + int.Parse(currentNumber)).ToString();
                                  break;
                              case "-":
                                  result = (int.Parse(firstNumber) - int.Parse(currentNumber)).ToString();

                                  break;
                              case "*":
                                  result = (int.Parse(firstNumber) * int.Parse(currentNumber)).ToString();
                                 // firstNumber = "";

                                  break;
                              case "/":
                                  result = (int.Parse(firstNumber) / int.Parse(currentNumber)).ToString();
                                 // firstNumber = "";

                                  break;
                              case "x^2":
                                  result = (int.Parse(firstNumber) * int.Parse(firstNumber)).ToString();
                                  //firstNumber = "";

                                  break;
                              default:
                                  break;
                          }
                          //result = (int.Parse(firstNumber) + int.Parse(currentNumber)).ToString();
                          firstNumber = "";
                          currentNumber = result;
                          invoker.Invoke(result);
                          currentState = CurrentState.ShowResult;
                      }
                      else
                      {
                          if (zero_digits.Contains(info))
                          {
                              Zero(true, info);
                          }
                          else if (operations.Contains(info))
                          {
                              Compute(true, info);
                          }
                      }
                  }
                  */


            }
}

