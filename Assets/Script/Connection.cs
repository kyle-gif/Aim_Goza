using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class ScoreSubmitter : MonoBehaviour
{
    private string submitURL = "https://aimgoza.kr/api/scores/";

    // 1. SubmitScore 메서드에 int gameType 매개변수 추가
    public void SubmitScore(string username, int score, string gameType)
    {
        // 2. 코루틴을 호출할 때 gameType 전달
        StartCoroutine(PostScore(username, score, gameType));
    }

    // 3. PostScore 코루틴에도 int gameType 매개변수 추가
    IEnumerator PostScore(string username, int score, string gameType)
    {
        // 이제 gameType 변수를 정상적으로 사용할 수 있습니다.
        ScoreData data = new ScoreData { username = username, score = score, gameType = gameType.ToLower() };
        string json = JsonUtility.ToJson(data);

        using (UnityWebRequest www = new UnityWebRequest(submitURL, "POST"))
        {
            byte[] jsonToSend = new UTF8Encoding().GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();

            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("점수 전송 오류: " + www.error);
                Debug.LogError("서버 응답: " + www.downloadHandler.text);
            }
            else
            {
                Debug.Log("점수 전송 성공: " + www.downloadHandler.text);
            }
        }
    }
}

[System.Serializable]
public class ScoreData {
    public string username;
    public int score;
    public string gameType;
}