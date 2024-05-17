using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    public class TilesData : GameObject
    {
        int currentLevel;

        int[,,] levels = {
            // level 1
            {
                {7,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,45,43,43,43,43,44,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,42,0,0,0,0,41,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,40,38,38,38,38,39,1,1,1,1,18},
                {35,1,1,47,46,46,46,15,1,1,1,1,1,1,1,47,46,46,46,15,1,1,1,1,1,1,1,1,47,46,46,27},
                {35,1,45,43,44,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,45,43,44,18},
                {35,1,42,0,41,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,42,0,41,18},
                {35,1,42,0,41,1,1,1,1,45,43,43,43,44,1,1,1,1,1,1,1,1,1,1,1,1,1,1,42,0,41,18},
                {35,1,40,38,39,1,1,1,1,42,0,0,0,41,1,1,1,1,1,1,1,1,1,1,1,1,1,1,40,38,39,18},
                {28,46,46,46,15,1,1,1,1,42,0,0,0,41,1,47,46,46,46,15,1,1,1,47,46,46,46,15,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,42,0,0,0,41,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,40,38,38,38,39,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {14,12,12,12,12,12,12,12,31,1,1,1,1,1,30,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,13},
                {0,0,0,0,0,0,0,0,35,1,1,1,1,1,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,14,31,1,1,1,1,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,14,12,12,12,12,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            },
            // level 2
            {
                {7,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,45,44,1,18},
                {35,1,1,1,1,1,45,43,43,43,43,43,44,1,1,47,46,46,46,46,46,46,46,46,46,46,15,1,42,41,1,18},
                {28,46,46,46,15,1,42,0,0,0,0,0,41,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,40,39,1,18},
                {35,1,1,1,1,1,42,0,0,0,0,0,41,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,1,40,38,38,38,38,38,39,1,1,1,1,1,22,46,46,46,20,46,46,46,46,46,46,46,46,27},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,47,50,1,1,1,19,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,47,46,46,46,46,46,46,46,15,1,1,1,1,48,1,1,47,49,46,46,46,46,46,46,46,46,27},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {28,46,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,45,43,43,43,43,44,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,40,38,38,38,38,39,1,1,1,1,18},
                {28,46,46,46,46,46,46,46,15,1,1,1,1,1,1,1,1,47,46,46,46,46,46,46,46,46,15,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {35,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,18},
                {14,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,31 ,1 ,1 ,1 ,1 ,30,12,12,12,12,12,12,12,12,12,13},
                {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,14,12,12,12,12,13,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            },
        };
        public TilesData(int levelIndex) 
        {
            currentLevel = levelIndex;

            int tileSize = 60;

            for (int row = 0; row < levels.GetLength(1); row++)
            {
                for (int col = 0; col < levels.GetLength(2); col++)
                {
                    int tileType = levels[levelIndex, row, col];
                    switch (tileType)
                    {
                        case 0:
                            break;
                        case 1:
                            Tile tile = new Tile("Tiles/BackgroundWall.png");
                            tile.x = col * tileSize;
                            tile.y = row * tileSize;
                            AddChild(tile);
                            break;
                        case 2:
                            Tile tile2 = new Tile("Tiles/BackgroundWallLower.png");
                            tile2.x = col * tileSize;
                            tile2.y = row * tileSize;
                            AddChild(tile2);
                            break;
                        case 3:
                            Tile tile3 = new Tile("Tiles/BackgroundWallLowerVariant2.png");
                            tile3.x = col * tileSize;
                            tile3.y = row * tileSize;
                            AddChild(tile3);
                            break;
                        case 4:
                            Tile tile4 = new Tile("Tiles/BackgroundWallTop.png");
                            tile4.x = col * tileSize;
                            tile4.y = row * tileSize;
                            AddChild(tile4);
                            break;
                        case 5:
                            Tile tile5 = new Tile("Tiles/Ceiling.png");
                            tile5.x = col * tileSize;
                            tile5.y = row * tileSize;
                            AddChild(tile5);
                            break;
                        case 6:
                            Tile tile6 = new Tile("Tiles/CeilingCorner.png");
                            tile6.x = col * tileSize;
                            tile6.y = row * tileSize;
                            AddChild(tile6);
                            break;
                        case 7:
                            Tile tile7 = new Tile("Tiles/CeilingCornerMirrored.png");
                            tile7.x = col * tileSize;
                            tile7.y = row * tileSize;
                            AddChild(tile7);
                            break;
                        case 8:
                            Tile tile8 = new Tile("Tiles/CeilingVariant2.png");
                            tile8.x = col * tileSize;
                            tile8.y = row * tileSize;
                            AddChild(tile8);
                            break;
                        case 9:
                            Tile tile9 = new Tile("Tiles/CeilingWallConnector.png");
                            tile9.x = col * tileSize;
                            tile9.y = row * tileSize;
                            AddChild(tile9);
                            break;
                        case 10:
                            Tile tile10 = new Tile("Tiles/CeilingWallConnectorMirrored.png");
                            tile10.x = col * tileSize;
                            tile10.y = row * tileSize;
                            AddChild(tile10);
                            break;
                        case 11:
                            Tile tile11 = new Tile("Tiles/CeilingWallTop.png");
                            tile11.x = col * tileSize;
                            tile11.y = row * tileSize;
                            AddChild(tile11);
                            break;
                        case 12:
                            Tile tile12 = new Tile("Tiles/Floor.png");
                            tile12.x = col * tileSize;
                            tile12.y = row * tileSize;
                            AddChild(tile12);
                            break;
                        case 13:
                            Tile tile13 = new Tile("Tiles/FloorCorner.png");
                            tile13.x = col * tileSize;
                            tile13.y = row * tileSize;
                            AddChild(tile13);
                            break;
                        case 14:
                            Tile tile14 = new Tile("Tiles/FloorCornerMirrored.png");
                            tile14.x = col * tileSize;
                            tile14.y = row * tileSize;
                            AddChild(tile14);
                            break;
                        case 15:
                            Tile tile15_2 = new Tile("Tiles/BackgroundWall.png");
                            Tile tile15 = new Tile("Tiles/FloorEndPiece.png");
                            tile15.x = col * tileSize;
                            tile15.y = row * tileSize;
                            tile15_2.x = col * tileSize;
                            tile15_2.y = row * tileSize;
                            AddChild(tile15_2);
                            AddChild(tile15);
                            break;
                        case 16:
                            Tile tile16 = new Tile("Tiles/FloorVariant2.png");
                            tile16.x = col * tileSize;
                            tile16.y = row * tileSize;
                            AddChild(tile16);
                            break;
                        case 17:
                            Tile tile17 = new Tile("Tiles/FloorWallConnection.png");
                            tile17.x = col * tileSize;
                            tile17.y = row * tileSize;
                            AddChild(tile17);
                            break;
                        case 18:
                            Tile tile18 = new Tile("Tiles/Wall.png");
                            tile18.x = col * tileSize;
                            tile18.y = row * tileSize;
                            AddChild(tile18);
                            break;
                        case 19:
                            Tile tile19 = new Tile("Tiles/WallDouble.png");
                            tile19.x = col * tileSize;
                            tile19.y = row * tileSize;
                            AddChild(tile19);
                            break;
                        case 20:
                            Tile tile20 = new Tile("Tiles/WallDoubleFloor.png");
                            tile20.x = col * tileSize;
                            tile20.y = row * tileSize;
                            AddChild(tile20);
                            break;
                        case 21:
                            Tile tile21 = new Tile("Tiles/WallDoubleFloorConnector.png");
                            tile21.x = col * tileSize;
                            tile21.y = row * tileSize;
                            AddChild(tile21);
                            break;
                        case 22:
                            Tile tile22 = new Tile("Tiles/WallDoubleFloorTop.png");
                            tile22.x = col * tileSize;
                            tile22.y = row * tileSize;
                            AddChild(tile22);
                            break;
                        case 23:
                            Tile tile23 = new Tile("Tiles/WallDoubleFloorTopDouble.png");
                            tile23.x = col * tileSize;
                            tile23.y = row * tileSize;
                            AddChild(tile23);
                            break;
                        case 24:
                            Tile tile24 = new Tile("Tiles/WallDoubleFloorTopMirrored.png");
                            tile24.x = col * tileSize;
                            tile24.y = row * tileSize;
                            AddChild(tile24);
                            break;
                        case 25:
                            Tile tile25 = new Tile("Tiles/WallDoubleVariant2.png");
                            tile25.x = col * tileSize;
                            tile25.y = row * tileSize;
                            AddChild(tile25);
                            break;
                        case 26:
                            Tile tile26 = new Tile("Tiles/WallFloor.png");
                            tile26.x = col * tileSize;
                            tile26.y = row * tileSize;
                            AddChild(tile26);
                            break;
                        case 27:
                            Tile tile27 = new Tile("Tiles/WallFloorConnector.png");
                            tile27.x = col * tileSize;
                            tile27.y = row * tileSize;
                            AddChild(tile27);
                            break;
                        case 28:
                            Tile tile28 = new Tile("Tiles/WallFloorConnectorMirrored.png");
                            tile28.x = col * tileSize;
                            tile28.y = row * tileSize;
                            AddChild(tile28);
                            break;
                        case 29:
                            Tile tile29 = new Tile("Tiles/WallFloorMirrored.png");
                            tile29.x = col * tileSize;
                            tile29.y = row * tileSize;
                            AddChild(tile29);
                            break;
                        case 30:
                            Tile tile30 = new Tile("Tiles/WallFloorTop.png");
                            tile30.x = col * tileSize;
                            tile30.y = row * tileSize;
                            AddChild(tile30);
                            break;
                        case 31:
                            Tile tile31 = new Tile("Tiles/WallFloorTopMirrored.png");
                            tile31.x = col * tileSize;
                            tile31.y = row * tileSize;
                            AddChild(tile31);
                            break;
                        case 32:
                            Tile tile32 = new Tile("Tiles/WallLower.png");
                            tile32.x = col * tileSize;
                            tile32.y = row * tileSize;
                            AddChild(tile32);
                            break;
                        case 33:
                            Tile tile33 = new Tile("Tiles/WallLowerDouble.png");
                            tile33.x = col * tileSize;
                            tile33.y = row * tileSize;
                            AddChild(tile33);
                            break;
                        case 34:
                            Tile tile34 = new Tile("Tiles/WallLowerMirrored.png");
                            tile34.x = col * tileSize;
                            tile34.y = row * tileSize;
                            AddChild(tile34);
                            break;
                        case 35:
                            Tile tile35 = new Tile("Tiles/WallMirrored.png");
                            tile35.x = col * tileSize;
                            tile35.y = row * tileSize;
                            AddChild(tile35);
                            break;
                        case 36:
                            Tile tile36 = new Tile("Tiles/WallVariant2.png");
                            tile36.x = col * tileSize;
                            tile36.y = row * tileSize;
                            AddChild(tile36);
                            break;
                        case 37:
                            Tile tile37 = new Tile("Tiles/WallVariant2Mirrored.png");
                            tile37.x = col * tileSize;
                            tile37.y = row * tileSize;
                            AddChild(tile37);
                            break;
                        case 38:
                            Tile tile38 = new Tile("Tiles/WindowLower.png");
                            tile38.x = col * tileSize;
                            tile38.y = row * tileSize;
                            AddChild(tile38);
                            break;
                        case 39:
                            Tile tile39 = new Tile("Tiles/WindowLowerCorner.png");
                            tile39.x = col * tileSize;
                            tile39.y = row * tileSize;
                            AddChild(tile39);
                            break;
                        case 40:
                            Tile tile40 = new Tile("Tiles/WindowLowerCornerMirrored.png");
                            tile40.x = col * tileSize;
                            tile40.y = row * tileSize;
                            AddChild(tile40);
                            break;
                        case 41:
                            Tile tile41 = new Tile("Tiles/WindowSide.png");
                            tile41.x = col * tileSize;
                            tile41.y = row * tileSize;
                            AddChild(tile41);
                            break;
                        case 42:
                            Tile tile42 = new Tile("Tiles/WindowSideMirrored.png");
                            tile42.x = col * tileSize;
                            tile42.y = row * tileSize;
                            AddChild(tile42);
                            break;
                        case 43:
                            Tile tile43 = new Tile("Tiles/WindowTop.png");
                            tile43.x = col * tileSize;
                            tile43.y = row * tileSize;
                            AddChild(tile43);
                            break;
                        case 44:
                            Tile tile44 = new Tile("Tiles/WindowTopCorner.png");
                            tile44.x = col * tileSize;
                            tile44.y = row * tileSize;
                            AddChild(tile44);
                            break;
                        case 45:
                            Tile tile45 = new Tile("Tiles/WindowTopCornerMirrored.png");
                            tile45.x = col * tileSize;
                            tile45.y = row * tileSize;
                            AddChild(tile45);
                            break;
                        case 46:
                            Tile tile46 = new Tile("Tiles/BackgroundWall.png");
                            Tile tile46_2 = new Tile("Tiles/Floor.png");
                            tile46.x = col * tileSize;
                            tile46.y = row * tileSize;
                            tile46_2.x = col * tileSize;
                            tile46_2.y = row * tileSize;
                            AddChild(tile46);
                            AddChild(tile46_2);
                            break;
                        case 47:
                            Tile tile47 = new Tile("Tiles/BackgroundWall.png");
                            Tile tile47_2 = new Tile("Tiles/FloorEndPiece.png");
                            tile47_2.Mirror(true, false);
                            tile47.x = col * tileSize;
                            tile47.y = row * tileSize;
                            tile47_2.x = col * tileSize;
                            tile47_2.y = row * tileSize;
                            AddChild(tile47);
                            AddChild(tile47_2);
                            break;
                        case 48:
                            Tile tile48 = new Tile("Tiles/BackgroundWall.png");
                            Tile tile48_2 = new Tile("Tiles/WallDoubleFloorTopDouble.png");
                            tile48_2.Mirror(false, true);
                            tile48.x = col * tileSize;
                            tile48.y = row * tileSize;
                            tile48_2.x = col * tileSize;
                            tile48_2.y = row * tileSize;
                            AddChild(tile48);
                            AddChild(tile48_2);
                            break;
                        case 49:
                            Tile tile49 = new Tile("Tiles/BackgroundWall.png");
                            Tile tile49_2 = new Tile("Tiles/FloorWallConnection.png");
                            tile49.x = col * tileSize;
                            tile49.y = row * tileSize;
                            tile49_2.x = col * tileSize;
                            tile49_2.y = row * tileSize;
                            AddChild(tile49);
                            AddChild(tile49_2);
                            break;
                        case 50:
                            Tile tile50 = new Tile("Tiles/WallDouble.png");
                            Tile tile50_2 = new Tile("Tiles/WallFloorConnector.png");
                            tile50.x = col * tileSize;
                            tile50.y = row * tileSize;
                            tile50_2.x = col * tileSize;
                            tile50_2.y = row * tileSize;
                            AddChild(tile50);
                            AddChild(tile50_2);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
