using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DCP_084
{
    class Program
    {
        const int mapWidth = 10;
        const int mapHeight = 10;

        public int islandCount = 0;
        public int landCount = 0;

        static void Main(string[] args)
        {
            int[,] map = returnMap2();
            PrintMap(map);
            int islandCount = Sail(map);
            Console.WriteLine("Number of Islands: " + islandCount);

        }

        static int Sail(int[,] map) {
            int islandCount = 0;
            List<int[]> discoveredLand = new List<int[]>();
            for (int y = 0; y < mapHeight; y++) {
                for (int x = 0; x < mapWidth; x++) {
                    //If Land.
                    if (map[x, y] == 1) {
                        int[] coords = { x, y };
                        //If the land is undiscovered
                        if (!ContainsCoordinate(coords, discoveredLand)) {
                            discoveredLand.Add(coords);
                            discoveredLand = Explore(coords, map, discoveredLand);
                            //Add 1 to Island Count
                            islandCount++;
                        }
                    }
                }
            }
            return islandCount;
        }

        static List<int[]> Explore(int[] coords, int[,] map, List<int[]> discoveryList) {
            /// 1) Check the 8 cardinal directions for land.
            ///     If there is a valid coordinate in that check position
            ///     AND
            ///     If that coordinate's value is 1
            ///     AND
            ///     That coordination is not in discoveryList.
            int north = coords[1] - 1;
            int south = coords[1] + 1;
            int east = coords[0] + 1;
            int west = coords[0] - 1;

            /// 2) If there is land, add those coordinates to discoverList,
            ///     then iterate Explore on those positions
            //NorthChecks
            if (CheckLocation(new int[] { west, north }, map, discoveryList)) {
                discoveryList.Add(new int[] { west, north });
                discoveryList = Explore(new int[] { west, north}, map, discoveryList);
            }
            if (CheckLocation(new int[] { coords[0], north }, map, discoveryList)){
                discoveryList.Add(new int[] { coords[0], north });
                discoveryList = Explore(new int[] { coords[0], north }, map, discoveryList);
            }
            if (CheckLocation(new int[] { east, north }, map, discoveryList)){
                discoveryList.Add(new int[] { east, north });
                discoveryList = Explore(new int[] { east, north }, map, discoveryList);
            }
            //EastCheck
            if (CheckLocation(new int[] { east, coords[1] }, map, discoveryList)){
                discoveryList.Add(new int[] { east, coords[1] });
                discoveryList = Explore(new int[] { east, coords[1] }, map, discoveryList);
            }
            //SouthChecks
            if (CheckLocation(new int[] { east, south }, map, discoveryList)) {
                discoveryList.Add(new int[] { east, south });
                discoveryList = Explore(new int[] { east, south }, map, discoveryList);
            }
            if (CheckLocation(new int[] { coords[0], south }, map, discoveryList)) {
                discoveryList.Add(new int[] { coords[0], south });
                discoveryList = Explore(new int[] { coords[0], south }, map, discoveryList);
            }
            if (CheckLocation(new int[] { west, south }, map, discoveryList)) {
                discoveryList.Add(new int[] { west, south });
                discoveryList = Explore(new int[] { west, south }, map, discoveryList);
            }
            //West Check
            if (CheckLocation(new int[] { west, coords[1] }, map, discoveryList)) {
                discoveryList.Add(new int[] { west, coords[1] });
                discoveryList = Explore(new int[] { west, coords[1] }, map, discoveryList);
            }

            /// 3) Return new discoveryList
            return discoveryList;
        }

        static bool CheckLocation(int[] coords, int[,] map, List<int[]> discoveredLocations) {
            bool locationCheck = false;
            bool validCoord = ValidateCoordinates(coords);
            if (!validCoord)
                return false;
            bool isLand = (map[coords[0], coords[1]] == 1) ? true : false;
            bool isDiscovered = ContainsCoordinate(coords, discoveredLocations);
            locationCheck = !isDiscovered && isLand;
            return locationCheck;
            
        }

        static bool ValidateCoordinates(int[] coords) {
            if (coords[0] < 0 || coords[1] < 0) {
                return false;
            }
            if (coords[0] > mapWidth - 1 || coords[1] > mapHeight - 1) {
                return false;
            }
            return true;
        }

        static bool ContainsCoordinate(int[] coords, List<int[]> discoveredLands){
            bool contains = discoveredLands.Any(a => a.SequenceEqual(coords));
            return contains;
        }
        static int[,] returnMap1() {
            if (mapHeight != 6 || mapWidth != 5)
                return null;
            int[,] map = new int[mapWidth, mapHeight];
            //Island 1
            map[0, 0] = 1;
            //Island 2
            map[2, 1] = 1;
            map[3, 1] = 1;
            map[1, 2] = 1;
            map[2, 2] = 1;
            //Island 3
            map[0, 4] = 1;
            map[1, 4] = 1;
            map[0, 5] = 1;
            map[1, 5] = 1;
            //Island 4
            map[4, 4] = 1;
            map[4, 5] = 1;
            return map;
        }

        static int[,] returnMap2() {
            if (mapWidth != 10 || mapHeight != 10)
                return null;
            int[,] map = new int[mapWidth, mapHeight];
            //Island 1
            map[2, 0] = 1;
            map[1, 1] = 1;
            map[2, 1] = 1;
            map[1, 2] = 1;
            map[2, 2] = 1;
            map[0, 3] = 1;
            //Island 2
            map[4, 2] = 1;
            //Island 3
            map[7, 0] = 1;
            map[6, 1] = 1;
            map[6, 2] = 1;
            map[6, 3] = 1;
            //Island 4
            map[8, 3] = 1;
            //Island 5
            map[4, 4] = 1;
            map[1, 5] = 1;
            map[2, 5] = 1;
            map[3, 5] = 1;
            map[1, 6] = 1;
            //Island 6
            map[3, 7] = 1;
            map[4, 7] = 1;
            map[5, 7] = 1;
            map[1, 8] = 1;
            map[2, 8] = 1;
            map[3, 8] = 1;
            map[4, 8] = 1;
            map[5, 8] = 1;
            map[0, 9] = 1;
            map[1, 9] = 1;
            map[2, 9] = 1;
            map[4, 9] = 1;
            map[5, 9] = 1;
            //Island 7
            map[7, 5] = 1;
            map[7, 6] = 1;
            map[7, 7] = 1;
            map[8, 7] = 1;
            map[7, 8] = 1;
            map[8, 8] = 1;
            map[7, 9] = 1;
            return map;
        }

        static void PrintMap(int[,] map) {
            for (int i = 0; i < mapHeight; i++) {
                for (int j = 0; j < mapWidth; j++) {
                    Console.Write(map[j, i] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
