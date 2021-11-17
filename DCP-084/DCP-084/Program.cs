using System;
using System.Collections.Generic;

namespace DCP_084
{
    class Program
    {
        const int mapWidth = 5;
        const int mapHeight = 6;

        public int islandCount = 0;
        public int landCount = 0;

        static void Main(string[] args)
        {
            int[,] map = returnMap1();
            PrintMap(map);
            int islandCount = Sail(map);
            Console.WriteLine(islandCount);
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
                        if (!discoveredLand.Contains(coords)) {
                            discoveredLand.Add(coords);
                            discoveredLand = Explore(coords, map, discoveredLand);
                        }
                        //Add 1 to Island Count
                        islandCount++;
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
            }
            if (CheckLocation(new int[] { coords[0], north }, map, discoveryList)){
                discoveryList.Add(new int[] { coords[0], north });
            }
            if (CheckLocation(new int[] { east, north }, map, discoveryList)){
                discoveryList.Add(new int[] { east, north });
            }
            //EastCheck
            if (CheckLocation(new int[] { east, coords[1] }, map, discoveryList)){
                discoveryList.Add(new int[] { east, coords[1] });
            }
            //SouthChecks
            if (CheckLocation(new int[] { east, south }, map, discoveryList)) {
                discoveryList.Add(new int[] { west, south });
            }
            if (CheckLocation(new int[] { coords[0], south }, map, discoveryList)) {
                discoveryList.Add(new int[] { west, coords[1] });
            }
            if (CheckLocation(new int[] { west, south }, map, discoveryList)) {
                discoveryList.Add(new int[] { west, south });
            }
            //West Check
            if (CheckLocation(new int[] { west, coords[1] }, map, discoveryList)) {
                discoveryList.Add(new int[] { west, north });
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
            bool isDiscovered = discoveredLocations.Contains(coords);
            locationCheck = !isDiscovered && isLand;
            return locationCheck;
            
        }

        static bool ValidateCoordinates(int[] coords) {
            if (coords[0] < 0 || coords[1] < 0) {
                return false;
            }
            if (coords[0] > 4 || coords[1] > 5) {
                return false;
            }
            return true;
        }

        static int[,] returnMap1() {
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
