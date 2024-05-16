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

            Sprite sprite = new Sprite("space_background.png");
            AddChild(sprite);

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
            //((MyGame)game).gravityZones.Clear();
        }

        #region Level Creation Functions
        void CreateOuterLines()
        {
            LineSegment outerLineTop = new LineSegment(new Vec2(0, 50), new Vec2(((MyGame)game).width + 1, 50));
            ((MyGame)game).horLines.Add(outerLineTop);
            AddChild(outerLineTop);
            
            LineSegment outerLineRight = new LineSegment(new Vec2(((MyGame)game).width - 50, 0), new Vec2(((MyGame)game).width - 50, ((MyGame)game).height + 1));
            ((MyGame)game).vertLines.Add(outerLineRight);
            AddChild(outerLineRight);
            
            LineSegment outerLineBottom = new LineSegment(new Vec2(0, ((MyGame)game).height - 50), new Vec2(((MyGame)game).width + 1, ((MyGame)game).height - 50));
            ((MyGame)game).horLines.Add(outerLineBottom);
            AddChild(outerLineBottom);
           
            LineSegment outerLineLeft = new LineSegment(new Vec2(50, 0), new Vec2(50, ((MyGame)game).height + 1));
            ((MyGame)game).vertLines.Add(outerLineLeft);
            AddChild(outerLineLeft);
        }

        void CreateLevelLoader(Vec2 pos, int collisionTimeMs = 0)
        {
            LevelLoader levelLoader = new LevelLoader(pos, collisionTimeMs);
            AddChild(levelLoader);
        }

        void CreatePlayer(Vec2 pos)
        {
            Player playerLeft = new Player(pos);
            ((MyGame)game).playerList.Add(playerLeft);
            AddChild(playerLeft);
        }

        void CreateBlock(Vec2 pos, int width, int height, bool _moving = false, float _moveSpeed = 0, float _moveTimer = 0, Interactable interactable = null)
        {
            if (height <= 6 && height >= -6) 
            {
                LineSegment horLine = new LineSegment(pos, new Vec2(pos.x + width, pos.y), _moving, _moveSpeed, _moveTimer, interactable);
                ((MyGame)game).horLines.Add(horLine);
                AddChild(horLine);
            }
            else if (width <= 6 && width >= -6)
            {
                LineSegment verLine = new LineSegment(new Vec2(pos.x, pos.y + 1), new Vec2(pos.x, pos.y + height), _moving, _moveSpeed, _moveTimer, interactable);
                ((MyGame)game).vertLines.Add(verLine);
                AddChild(verLine);
            }
            else
            {
                LineSegment horLine = new LineSegment(pos, new Vec2(pos.x + width, pos.y), _moving, _moveSpeed, _moveTimer, interactable);
                ((MyGame)game).horLines.Add(horLine);
                AddChild(horLine);
                
                LineSegment verLine = new LineSegment(new Vec2(pos.x, pos.y + 1), new Vec2(pos.x, pos.y + height-1), _moving, _moveSpeed, _moveTimer, interactable);
                ((MyGame)game).vertLines.Add(verLine);
                AddChild(verLine);

                LineSegment horLine2 = new LineSegment(new Vec2(pos.x, pos.y + height), new Vec2(pos.x + width, pos.y + height), _moving, _moveSpeed, _moveTimer, interactable);
                ((MyGame)game).horLines.Add(horLine2);
                AddChild(horLine2);
                
                LineSegment verLine2 = new LineSegment(new Vec2(pos.x + width, pos.y + 1), new Vec2(pos.x + width, pos.y + height-1), _moving, _moveSpeed, _moveTimer, interactable);
                ((MyGame)game).vertLines.Add(verLine2);
                AddChild(verLine2);
            }
        }

        void CreateGravityZone(Vec2 pos, int width, int height, Interactable interactable = null)
        {
            GravityZone gravityZone = new GravityZone(pos, width, height, interactable);
            //((MyGame)game).gravityZones.Add(gravityZone);
            AddChild(gravityZone);
        }

        void CreateAcidPuddle(Vec2 pos, bool dripping = false, bool gravityInverted = false)
        {
            AcidPuddle aPuddle = new AcidPuddle(pos, dripping, gravityInverted);
            AddChild(aPuddle);
        }

        void CreateCrate(Vec2 pos)
        {
            Crate crate = new Crate(pos);
            AddChild(crate);
        }
        #endregion

        #region Levels
        void LoadLevel1()
        {
            TilesData tiles = new TilesData(levelNumber-1);
            AddChild(tiles);

            // LevelLoader object
            CreateLevelLoader(new Vec2(1800, 180), 500);

            // Outer lines
            CreateOuterLines();

            // Environment
            CreateBlock(new Vec2(0, 840), 540, 40);
            CreateBlock(new Vec2(500, 850), 40, 180);
            CreateBlock(new Vec2(500, 960), 90, 40);
            CreateBlock(new Vec2(560, 960), 40, 90);

            CreateBlock(new Vec2(500, 1020), 400, 40);
            CreateBlock(new Vec2(840, 840), 40, 180);
            CreateBlock(new Vec2(840, 840), 1660, 40);

            CreateBlock(new Vec2(0, 540), 300, 40);
            CreateBlock(new Vec2(900, 540), 300, 40);
            CreateBlock(new Vec2(1380, 540), 300, 40);

            CreateBlock(new Vec2(180, 240), 300, 40);
            CreateBlock(new Vec2(900, 240), 300, 40);
            CreateBlock(new Vec2(1680, 240), 240, 40);

            // Interactables
            Lever lever = new Lever(new Vec2(1300, 810));
            AddChild(lever);
            Button button = new Button(new Vec2(1550, 510));
            AddChild(button);
            Lever lever1 = new Lever(new Vec2(1050, 510));
            AddChild(lever1);
            Lever lever2 = new Lever(new Vec2(1050, 210));
            AddChild(lever2);

            // Moving blocks
            CreateBlock(new Vec2(400, 540), 120, 40, true, .3f, 2000, lever1);
            Tile tile = new Tile("Tiles/FloorEndPiece.png", 400, 540, true, .3f, 2000, lever1);
            tile.Mirror(true, false);
            AddChild(tile);
            Tile tile2 = new Tile("Tiles/FloorEndPiece.png", 460, 540, true, .3f, 2000, lever1);
            AddChild(tile2);

            CreateBlock(new Vec2(1500, 240), 120, 40, true, -.3f, 3000, lever2);
            Tile tile3 = new Tile("Tiles/FloorEndPiece.png", 1500, 240, true, -.3f, 3000, lever2);
            tile3.Mirror(true, false);
            AddChild(tile3);
            Tile tile4 = new Tile("Tiles/FloorEndPiece.png", 1560, 240, true, -.3f, 3000, lever2);
            AddChild(tile4);

            // Gravity Zones
            CreateGravityZone(new Vec2(1680, 300), 180, 540, lever);
            CreateGravityZone(new Vec2(60, 60), 120, 480, button);

            CreateGravityZone(new Vec2(480, 180), 420, 120);

            // Acid Puddles
            CreateAcidPuddle(new Vec2(560, -100), true);
            CreateAcidPuddle(new Vec2(675, -100), true);
            CreateAcidPuddle(new Vec2(790, -100), true);

            //Crates
            CreateCrate(new Vec2(1000, 800));

            // Player
            CreatePlayer(new Vec2(150, 750));
        }

        void LoadLevel2()
        {
            // LevelLoader object
            CreateLevelLoader(new Vec2(400, 250), 500);

            // Outer lines
            CreateOuterLines();

            // Environment
            CreateBlock(new Vec2(0, 500), 500, 10);
            CreateBlock(new Vec2(300, 300), 200, 10);
            CreateBlock(new Vec2(300, 300), 10, -200);
            CreateBlock(new Vec2(500, 300), -10, -200);

            // Interactables
            Button button = new Button(new Vec2(200, 200));
            AddChild(button);
            Lever lever = new Lever(new Vec2(600, 200), 5000);
            AddChild(lever);

            // Moving blocks
            CreateBlock(new Vec2(150, 400), 550, 50, true, .1f, 2000);

            // Gravity Zones
            CreateGravityZone(new Vec2(10, 10), 50, 600, lever);
            CreateGravityZone(new Vec2(10, 10), 800, 50, lever);

            // Acid Puddles
            CreateAcidPuddle(new Vec2(750, 100), true);
            CreateAcidPuddle(new Vec2(250, 500));

            // Player
            CreatePlayer(new Vec2(100, 300));
        }

        void LoadLevel3()
        {
            // LevelLoader object
            CreateLevelLoader(new Vec2(400, 250), 1000);

            // Outer lines
            CreateOuterLines();

            // Environment
            CreateBlock(new Vec2(0, 450), 200, 10);
            CreateBlock(new Vec2(800, 450), -200, 10);

            // Interactables


            // Moving blocks
            CreateBlock(new Vec2(300, 300), 200, 10, true, .4f, 3000);

            // Gravity Zones


            // Acid Puddles


            // Player
            CreatePlayer(new Vec2(400, 500));
        }
        #endregion
    }
}
