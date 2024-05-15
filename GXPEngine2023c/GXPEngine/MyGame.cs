using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

public class MyGame : Game {
	public PlayerData playerData;
	Player playerLeft;
	Player playerRight;

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


		GravityZone gravityZone = new GravityZone(new Vec2(10, 10), 50, 200);
		AddChild(gravityZone);

		LineSegment outerLineTop = new LineSegment(new Vec2(0, 0), new Vec2(801, 0));
		horLines.Add(outerLineTop);
		AddChild(outerLineTop);
		LineSegment outerLineRight = new LineSegment(new Vec2(801, 0), new Vec2(801, 601));
		vertLines.Add(outerLineRight);
		AddChild(outerLineRight);
		LineSegment outerLineBottom = new LineSegment(new Vec2(0, 601), new Vec2(801, 601));
		horLines.Add(outerLineBottom);
		AddChild(outerLineBottom);
		LineSegment outerLineLeft = new LineSegment(new Vec2(0, 0), new Vec2(0, 601));
		vertLines.Add(outerLineLeft);
		AddChild(outerLineLeft);

		LineSegment line2 = new LineSegment(new Vec2(0, 500), new Vec2(800, 500));
		horLines.Add(line2);
		AddChild(line2);
		LineSegment line3 = new LineSegment(new Vec2(300, 300), new Vec2(500, 300));
		horLines.Add(line3);
		AddChild(line3);

		LineSegment movingLine = new LineSegment(new Vec2(150, 400), new Vec2(700, 400), true, .1f, 2000);
		horLines.Add(movingLine);
		AddChild(movingLine);
		LineSegment movingLine2 = new LineSegment(new Vec2(150, 401), new Vec2(150, 450), true, .1f, 2000);
		vertLines.Add(movingLine2);
		AddChild(movingLine2);

		button = new Button(new Vec2(200, 200));
		AddChild(button);
		lever = new Lever(new Vec2(600, 200));
		AddChild(lever);

  //      AcidPuddle aPuddle = new AcidPuddle(new Vec2(250, 500), true);
		//AddChild(aPuddle);
  //      AcidPuddle aPuddle2 = new AcidPuddle(new Vec2(750, 100), false);
  //      AddChild(aPuddle2);


        playerLeft = new Player(new Vec2(100, 300));
        playerList.Add(playerLeft);
        AddChild(playerLeft);
    }

	void Update() 
	{
		
	}

	static void Main()
	{
		new MyGame().Start();
	}
}