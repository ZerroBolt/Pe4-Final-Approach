using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game {
	public PlayerData playerData;

	public MyGame() : base(800, 600, false)
	{
		playerData = new PlayerData();

	}

	void Update() 
	{
		
	}

	static void Main()
	{
		new MyGame().Start();
	}
}