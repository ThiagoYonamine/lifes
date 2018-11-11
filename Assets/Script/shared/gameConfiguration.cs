
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
/* 
[System.Serializable]
public class Resource{
	public string url;
	public string name;
	public string license;
	public string type;
}
*/
/*
[System.Serializable]
public class Component{
	public string id;
	public string purpose;
	public int score;
	public Resource[] resources;
}
*/
[System.Serializable]
public class Mechanic{
	public string description;
	public string knowledge;
	public Component[] components;
}
/*
[System.Serializable]
public class Game{
	public string name;
	public Mechanic mechanic;	
	public Feedback[] feedbacks;
}
*/

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
public class SessionResponse{
	public GameConfiguration gameConfiguration;
}

[System.Serializable]
public class GamePerformance{
	public Player player;
	public Supervisor supervisor;
	public String game;
	public DateTime date;
	public Performance performance;
}

[System.Serializable]
public class Performance{
	public float time;
	public int hits;
    public int fails;
	public int score;
	public int feelingRate;
}

[System.Serializable]
public class StopSessionRequest{
	public GamePerformance gamePerformance;
}

/* new json */

[System.Serializable]
public class LoginRequest{
	public string username;
	public string password;
}

[System.Serializable]
public class User{
	public long id;
	public string first_name;
	public string last_name;
	public string username;
}

[System.Serializable]
public class LoginWrapper{
	public string token;
	public User user;
}

[System.Serializable]
public class ResourceType{
	public long id;
	public string name;
}

[System.Serializable]
public class Resource{
	public long id;
	public string content;
	public string rights;
	public bool status;
	public long author;
	public ResourceType resourceType;
	public string institution;
	public string related;
    public string role;
	public int score;
}
/*
[System.Serializable]
public class Component{
	public long id;
	public string name;
	public int score;
	public string purpose;
	public string tag;
	public ResourceType[] resourceTypes;
}
*/
[System.Serializable]
public class GameComponent{
	public long id;
	public Resource[] resources;
	public Component component;
}
/*
[System.Serializable]
public class Configuration{
	public long id;
	public long game;
	public GameComponent[] gameComponents;
}
*/

[System.Serializable]
public class Response{
	public Configuration[] configurations;
}

[System.Serializable]
public class GameResult{
	public int hits;
    public int fails;
	public int score;
	public int feelingRate;
	public long game;
	public long player;
}

///////////////////// NEW JSON 10/11 //////////////////////
[System.Serializable]
public class Component{
	public long id;
	public string name;
	public int score;
	public string purpose;
	public string tag;
	public ResourceType[] resourceTypes;
	public Resource[] resources;
}

[System.Serializable]
public class Game{
	public long id;
	public string name;
	public Component[] components;
}

[System.Serializable]
public class Configuration{
	public long id;
	public Game game;
}