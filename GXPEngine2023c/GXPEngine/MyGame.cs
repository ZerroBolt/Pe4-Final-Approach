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

	SoundChannel soundTrack;

	public MyGame() : base(1920, 1080, false, false)
	{
		targetFps = 90;
		playerData = new PlayerData();

		playerList = new List<Player>();
		vertLines = new List<LineSegment>();
		horLines = new List<LineSegment>();

        soundTrack = new SoundChannel(1);
        soundTrack = new Sound("Cosmic_Conundrum.mp3", true).Play();

		levelData = new LevelData();
		AddChild(levelData);
		levelData.LoadNextLevel();
    }

	void Update() 
	{
		if (Input.GetKeyDown(Key.UP) && soundTrack.Volume < 1) soundTrack.Volume += 0.1f;
		else if (Input.GetKeyDown(Key.DOWN) && soundTrack.Volume > 0) soundTrack.Volume -= 0.1f;
    }

	static void Main()
	{
		new MyGame().Start();
	}
}