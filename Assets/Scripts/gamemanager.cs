using System;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public problem[] problems;      
    public int curProblem;          
    public static gamemanager instance;
    public Color redcolor;
    public Color greencolor;

    void LoadProblems()
    {
        var commandText = "GetMathProblems";



        var command = new SqlCommand
        {
            CommandText = commandText,
            CommandType = CommandType.StoredProcedure
        };

        var dataTable = ExecuteCommand(command);

        var list = new problem[dataTable.Rows.Count];
        for (int index = 0; index < dataTable.Rows.Count; index++)
        {
            DataRow dataRow = dataTable.Rows[index];
            var problem = new problem

            {
                firstNumber = Convert.ToInt32(dataRow["firstNumber"]),
                secondNumber = Convert.ToInt32(dataRow["secondNumber"]),
                operation = (MathsOperation)Convert.ToInt32(dataRow["operation"]),

            };
            list[index] = (problem);
        }
        this.problems = list;
    }

    public string _connectionString = "";
    private DataTable ExecuteCommand(SqlCommand command, String tableName = "DataTable")
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            command.Connection = connection;
            using (var dataAdapter = new SqlDataAdapter(command))
            {
                var dataTable = new DataTable(tableName);
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }


    void Awake()
    {
        // set instance to this script.
        instance = this;
    }

    void Start()
    {
        // set the initial problem
        SetProblem(0);
    }

    void Update()
    {
        // remainingTime -= Time.deltaTime;

        // has the remaining time ran out?
        // if (remainingTime <= 0.0f)
        // {
        //     Lose();
        // }
    }

    
    public void OnAppleCollision(int cube)
    {
        
        if (cube == problems[curProblem].correctcube)
        {


            CorrectAnswer();
            scoreMultiply.scoreAmount += 10;

        }
        else
        {


            IncorrectAnswer();
            scoreMultiply.scoreAmount -= 10;
        }
    }

  
    void CorrectAnswer()
    {
        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("stick"))
            {
                Debug.Log("It's ALIVE and red");
                transform.GetComponent<Renderer>().material.color = redcolor;
            }
        }
        // is this the last problem?
        if (problems.Length - 1 == curProblem)
            Win();

        else
            SetProblem(curProblem + 1);
    }

   
    void IncorrectAnswer()
    {
       
    }

    
    void SetProblem(int problem)
    {
        curProblem = problem;
        UI.instance.SetProblemText(problems[curProblem]);
       
    }

   
    void Win()
    {
        
        UI.instance.SetEndText(true);
    }

   
    void Lose()
    {
       
        UI.instance.SetEndText(false);
    }
}