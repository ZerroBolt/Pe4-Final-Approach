using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game {
	public PlayerData playerData;
	Player playerTop;
	Player playerBottom;

	public MyGame() : base(800, 600, false)
	{
		playerData = new PlayerData();

		playerTop = new Player();
		playerBottom = new Player(true);
		AddChild(playerTop);
		AddChild(playerBottom);
	}

	void Update() 
	{
		
	}

	static void Main()
	{
		new MyGame().Start();
	}
}