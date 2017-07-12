using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Serialize {
    public static void SaveScore(UpdateScore curScore)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/score.swag", FileMode.Create);

        ScoreData scoreData = new ScoreData(curScore);

        bf.Serialize(stream, scoreData);
        stream.Close();

    }

    public static int LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/score.swag"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/score.swag", FileMode.Open);

            ScoreData scoreData = bf.Deserialize(stream) as ScoreData;
            stream.Close();
            return scoreData.score;
        }
        else
        {
            Debug.Log("Error, no file exists");
            return 0;
        }
    }	
}

[Serializable]
public class ScoreData
{
    public int score;

    public ScoreData(UpdateScore curScore)
    {
        score = curScore.score;
    }
}
