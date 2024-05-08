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

	public MyGame() : base(800, 600, false)
	{
		playerData = new PlayerData();

		playerTop = new Player(new Vec2(100, 100));
		playerBottom = new Player(new Vec2(700, 100), true);
		AddChild(playerTop);
		AddChild(playerBottom);

		LineSegment line = new LineSegment(new Vec2(400, 0), new Vec2(400, 600));
		AddChild(line);

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