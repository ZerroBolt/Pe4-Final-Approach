using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

public class MyGame : Game {
	public PlayerData playerData;
	Player playerTop;
	Player playerBottom;

	Button button;
	Lever lever;

	public List<Player> playerList;
	public List<LineSegment> vertLines;
	public List<LineSegment> horLines;

	public MyGame() : base(800, 600, false)
	{
		playerData = new PlayerData();

		playerList = new List<Player>();
		vertLines = new List<LineSegment>();
		horLines = new List<LineSegment>();

		playerTop = new Player(new Vec2(100, 300));
		playerBottom = new Player(new Vec2(700, 300), true);
		playerList.Add(playerTop);
		AddChild(playerTop);
		playerList.Add(playerBottom);
		AddChild(playerBottom);

		LineSegment line = new LineSegment(new Vec2(400, 0), new Vec2(400, 600));
		vertLines.Add(line);
		AddChild(line);

		LineSegment line2 = new LineSegment(new Vec2(0, 500), new Vec2(800, 500));
		horLines.Add(line2);
		AddChild(line2);
		LineSegment line3 = new LineSegment(new Vec2(300, 300), new Vec2(500, 300));
		horLines.Add(line3);
		AddChild(line3);

		button = new Button();
		AddChild(button);
		lever = new Lever();
		AddChild(lever);
	}

	void Update() 
	{
		
	}

	static void Main()
	{
		new MyGame().Start();
	}
}