
using UnityEngine;
using System;

[System.Serializable]
public class Player{
	public string name;
}

[System.Serializable]
public class Supervisor{
	public string name;
}
[System.Serializable]
public class Resource{
	public string url;
	public string name;
	public string license;
	public string type;
}

[System.Serializable]
public class Component{
	public string id;
	public string purpose;
	public int score;
	public Resource[] resources;
}
[System.Serializable]
public class Mechanic{
	public string description;
	public string knowledge;
	public Component[] components;
}

[System.Serializable]
public class Game{
	public string name;
	public Mechanic mechanic;	
	public Feedback[] feedbacks;
}

[System.Serializable]
public class Feedback{
	public string id;
	public string message;
}

[System.Serializable]
public class GameConfiguration{
	public Player player;
	public Supervisor supervisor;
    public Game[] games;
	
}

[System.Serializable]
public  class SessionResponse{
	public GameConfiguration gameConfiguration;
}

[System.Serializable]
public class GamePerformance{
	Player player;
	Supervisor supervisor;
	String game;
	DateTime date;
	Performance performance;
}

[System.Serializable]
public class Performance{
	float time;
	int hits;
    int fails;
	int score;
	int feelingRate;

    public float Time { 
		get { return time; }  
		set { time = value; }
	}

    public int Hits { 
		get { return hits; }  
		set { hits = value; }
	}

    public int Fails { 
		get { return fails; }  
		set { fails = value; }
	}

    public int Score { 
		get { return score; }  
		set { score = value; }
	}

    public int FeelingRate { 
		get { return feelingRate; }  
		set { feelingRate = value; }
	}
}

[System.Serializable]
public  class StopSessionRequest{
	GamePerformance gamePerformance;
}