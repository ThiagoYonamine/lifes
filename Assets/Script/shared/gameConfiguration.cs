
using UnityEngine;

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
