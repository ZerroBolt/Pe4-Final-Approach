using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

public class MyGame : Game {
	public PlayerData playerData;
	public Player player;
	public LevelData levelData;

	Button button;
	Lever lever;

	public List<Player> playerList;
	public List<LineSegment> vertLines;
	public List<LineSegment> horLines;

	public MyGame() : base(1920, 1080, false, false)
	{
		playerData = new PlayerData();

		playerList = new List<Player>();
		vertLines = new List<LineSegment>();
		horLines = new List<LineSegment>();

		levelData = new LevelData();
		AddChild(levelData);
		levelData.LoadNextLevel();
    }

	void Update() 
	{
		
	}

	static void Main()
	{
		new MyGame().Start();
	}
}