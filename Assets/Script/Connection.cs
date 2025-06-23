using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ScoreSubmitter : MonoBehaviour
{
    private string submitURL = "http://localhost:8000/api/scores/";

    public void SubmitScore(string username, int score)
    {
        StartCoroutine(PostScore(username, score));
    }

    IEnumerator PostScore(string username, int score)
    {
        ScoreData data = new ScoreData { username = username, score = score };
        string json = JsonUtility.ToJson(data);

        using (UnityWebRequest www = UnityWebRequest.Post(submitURL, json, "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.LogError("점수 전송 오류: " + www.error);
            else
                Debug.Log("점수 전송 성공: " + json);
        }
    }
}

[System.Serializable] 
public class ScoreData {
    public string username;
    public int score;
}
