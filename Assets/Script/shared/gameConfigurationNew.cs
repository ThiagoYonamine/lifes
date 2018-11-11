[System.Serializable]
public class nComponent{
	public long id;
	public string name;
	public int score;
	public string purpose;
	public string tag;
	public ResourceType[] resourceTypes;
	public Resource[] resources;
}

[System.Serializable]
public class nGame{
	public long id;
	public string name;
}

[System.Serializable]
public class nConfiguration{
	public long id;
	public Game game;
}

[System.Serializable]
public class nResponse{
	public Configuration[] configurations;
}