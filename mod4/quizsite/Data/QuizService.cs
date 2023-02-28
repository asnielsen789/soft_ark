using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace quizsite.Data;

public class QuizService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public event Action RefreshRequired;

    public QuizService(HttpClient http, IConfiguration configuration) {
        this.http = http;
        this.configuration = configuration;
        this.baseAPI = configuration["base_api"];
    }

    public void CallRequestRefresh()
    {
         RefreshRequired?.Invoke();
    }

    public async Task<QuestionData[]> GetQuestionData()
    {
        string url = $"{baseAPI}quiz/";
        return await http.GetFromJsonAsync<QuestionData[]>(url);
    }

    public async Task<bool> CheckAnswer(int id, int input)
    {
        string url = $"{baseAPI}quiz/{id}/{input}";
        return await http.GetFromJsonAsync<bool>(url);
    }
/*
    public async void PutTaskData(TaskData data)
    {
        TaskDataAPI newData = new TaskDataAPI(data.Text, data.Done);
        string url = $"{baseAPI}tasks/{data.Id}";
        var res = await http.PutAsJsonAsync(url, newData);
        CallRequestRefresh();
    }

    public async void PostTask(TaskData data)
    {
        TaskDataAPI newData = new TaskDataAPI(data.Text, data.Done);
        string url = $"{baseAPI}tasks/";
        var res = await http.PostAsJsonAsync(url, newData);
        CallRequestRefresh();
    }
*/
    record Question(int id, string question, string[] answers, int correct);
    
}
