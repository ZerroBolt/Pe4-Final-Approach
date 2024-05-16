using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    public class LevelData : GameObject
    {
        int levelNumber = 0;
        public LevelData() 
        {

        }

        public void LoadNextLevel()
        {
            levelNumber++;

            DestroyCurrentLevel();

            switch (levelNumber)
            {
                case 1:
                    LoadLevel1();
                    break;
                case 2:
                    LoadLevel2(); 
                    break;
                case 3:
                    LoadLevel3();
                    break;
                default:
                    levelNumber = 0;
                    LoadNextLevel();
                    break;
            }
        }

        void DestroyCurrentLevel()
        {
            List<GameObject> children = GetChildren();
            foreach (GameObject child in children)
            {
                child.LateDestroy();
            }
            //TODO: Reset all lists??
            ((MyGame)game).playerList.Clear();
            ((MyGame)game).vertLines.Clear();
            ((MyGame)game).horLines.Clear();
            ((MyGame)game).gravityZones.Clear();
        }

        #region Level Creation Functions
        void CreateOuterLines()
        {
            LineSegment outerLineTop = new LineSegment(new Vec2(0, 0), new Vec2(((MyGame)game).width + 1, 0));
            ((MyGame)game).horLines.Add(outerLineTop);
            AddChild(outerLineTop);
            
            LineSegment outerLineRight = new LineSegment(new Vec2(((MyGame)game).width + 1, 0), new Vec2(((MyGame)game).width + 1, ((MyGame)game).height + 1));
            ((MyGame)game).vertLines.Add(outerLineRight);
            AddChild(outerLineRight);
            
            LineSegment outerLineBottom = new LineSegment(new Vec2(0, ((MyGame)game).height + 1), new Vec2(((MyGame)game).width + 1, ((MyGame)game).height + 1));
            ((MyGame)game).horLines.Add(outerLineBottom);
            AddChild(outerLineBottom);
           
            LineSegment outerLineLeft = new LineSegment(new Vec2(0, 0), new Vec2(0, ((MyGame)game).height + 1));
            ((MyGame)game).vertLines.Add(outerLineLeft);
            AddChild(outerLineLeft);
        }

        void CreateLevelLoader(Vec2 pos)
        {
            LevelLoader levelLoader = new LevelLoader(pos);
            AddChild(levelLoader);
        }

        void CreatePlayer(Vec2 pos)
        {
            Player playerLeft = new Player(pos);
            ((MyGame)game).playerList.Add(playerLeft);
            AddChild(playerLeft);
        }

        void CreateBlock(Vec2 pos, int width, int height, bool _moving = false, float _moveSpeed = 0, float _moveTimer = 0)
        {
            if (height <= 6 && height >= -6) 
            {
                LineSegment horLine = new LineSegment(pos, new Vec2(pos.x + width, pos.y), _moving, _moveSpeed, _moveTimer);
                ((MyGame)game).horLines.Add(horLine);
                AddChild(horLine);
            }
            else if (width <= 6 && width >= -6)
            {
                LineSegment verLine = new LineSegment(new Vec2(pos.x, pos.y + 1), new Vec2(pos.x, pos.y + height), _moving, _moveSpeed, _moveTimer);
                ((MyGame)game).vertLines.Add(verLine);
                AddChild(verLine);
            }
            else
            {
                LineSegment horLine = new LineSegment(pos, new Vec2(pos.x + width, pos.y), _moving, _moveSpeed, _moveTimer);
                ((MyGame)game).horLines.Add(horLine);
                AddChild(horLine);
                
                LineSegment verLine = new LineSegment(new Vec2(pos.x, pos.y + 1), new Vec2(pos.x, pos.y + height), _moving, _moveSpeed, _moveTimer);
                ((MyGame)game).vertLines.Add(verLine);
                AddChild(verLine);

                LineSegment horLine2 = new LineSegment(new Vec2(pos.x, pos.y + height), new Vec2(pos.x + width, pos.y + height), _moving, _moveSpeed, _moveTimer);
                ((MyGame)game).horLines.Add(horLine2);
                AddChild(horLine2);
                
                LineSegment verLine2 = new LineSegment(new Vec2(pos.x + width, pos.y + 1), new Vec2(pos.x + width, pos.y + height), _moving, _moveSpeed, _moveTimer);
                ((MyGame)game).vertLines.Add(verLine2);
                AddChild(verLine2);
            }
        }

        void CreateGravityZone(Vec2 pos, int width, int height)
        {
            GravityZone gravityZone = new GravityZone(pos, width, height);
            ((MyGame)game).gravityZones.Add(gravityZone);
            AddChild(gravityZone);
        }

        void CreateAcidPuddle(Vec2 pos, bool dripping = false, bool gravityInverted = false)
        {
            AcidPuddle aPuddle = new AcidPuddle(pos, dripping, gravityInverted);
            AddChild(aPuddle);
        }
        #endregion

        #region Levels
        void LoadLevel1()
        {
            // LevelLoader object
            CreateLevelLoader(new Vec2(400, 250));

            // Outer lines
            CreateOuterLines();

            // Environment
            CreateBlock(new Vec2(0, 500), 500, 10);
            CreateBlock(new Vec2(300, 300), 200, 10);

            // Moving blocks
            CreateBlock(new Vec2(150, 400), 550, 50, true, .1f, 2000);

            // Gravity Zones
            CreateGravityZone(new Vec2(10, 10), 50, 200);

            // Interactables
            Button button = new Button(new Vec2(200, 200));
            AddChild(button);
            Lever lever = new Lever(new Vec2(600, 200));
            AddChild(lever);

            // Player
            CreatePlayer(new Vec2(100, 300));
        }

        void LoadLevel2()
        {
            // LevelLoader object
            CreateLevelLoader(new Vec2(400, 250));

            // Outer lines
            CreateOuterLines();

            // Environment
            CreateBlock(new Vec2(0, 500), 500, 10);
            CreateBlock(new Vec2(300, 300), 200, 10);

            // Moving blocks
            CreateBlock(new Vec2(150, 400), 550, 50, true, .1f, 2000);

            // Gravity Zones
            CreateGravityZone(new Vec2(10, 10), 50, 200);

            // Interactables
            Button button = new Button(new Vec2(200, 200));
            AddChild(button);
            Lever lever = new Lever(new Vec2(600, 200));
            AddChild(lever);

            CreateAcidPuddle(new Vec2(750, 100), true);
            CreateAcidPuddle(new Vec2(250, 500));

            // Player
            CreatePlayer(new Vec2(100, 300));
        }

        void LoadLevel3()
        {
            // LevelLoader object
            CreateLevelLoader(new Vec2(400, 250));

            // Outer lines
            CreateOuterLines();

            // Environment
            CreateBlock(new Vec2(300, 300), 200, 10);
            CreateBlock(new Vec2(0, 450), 200, 10);
            CreateBlock(new Vec2(800, 450), -200, 10);

            // Moving blocks


            // Gravity Zones


            // Interactables


            // Player
            CreatePlayer(new Vec2(400, 500));
        }
        #endregion
    }
}
