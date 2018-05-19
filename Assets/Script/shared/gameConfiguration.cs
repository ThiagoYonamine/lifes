
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
public class GameConfiguration{
	public Player player;
	public Supervisor supervisor;
}

[System.Serializable]
public class RootConfiguration{
	public GameConfiguration gameConfiguration;

}
