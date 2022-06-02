using System;
using System.Collections.Generic;

	class Life
	{
        private static int cycles = 10;
        private static HashSet<Tuple<long,long>> aliveLocations = new HashSet<Tuple<long,long>>();
        private static HashSet<Tuple<long,long>> dead;
        
		public static void Main(string[] args)
		{
            GetInput();
            for(int i = 0; i < cycles; i++){
                Iterate();
            }
            Console.WriteLine("#Life 1.06");
            foreach(Tuple<long, long> loc in aliveLocations){
                Console.WriteLine(loc.Item1 + " " + loc.Item2);
            }
		}
        private static void GetInput(){
            Console.WriteLine("Please enter courdinates in the format: (x, y)");
            while(true){
                string temp = Console.ReadLine();
                if(temp != "") {
                string[] cordStr = temp.Split(' ');
                long[] cords = new long[2];
               cords[0] = long.Parse(cordStr[0].Substring(1,cordStr[0].Length-2));
               cords[1] = long.Parse(cordStr[1].Substring(0,cordStr[1].Length-1));
                aliveLocations.Add(new Tuple<long,long>(cords[0], cords[1]));
                }
                else {
                    break;
                }
            }
        }
        private static void Iterate(){
            HashSet<Tuple<long,long>> newAlive = new HashSet<Tuple<long,long>>();
            dead = new HashSet<Tuple<long,long>>();
            
            foreach(Tuple<long,long> i in aliveLocations){
                HashSet<Tuple<long,long>> neighbors = GetNeighbors(i);
                int count = 0;
                foreach(Tuple<long,long> n in neighbors){
                    if(aliveLocations.Contains(n)){
                        count++;
                    }
                    else if(!dead.Contains(n)){
                        dead.Add(n);
                    }
                }
                if(count == 3 || count == 2) newAlive.Add(i);
            }
            foreach(Tuple<long,long> cell in dead){
                HashSet<Tuple<long,long>> neighbors = GetNeighbors(cell);
                int count = 0;
                foreach(Tuple<long,long> n in neighbors){
                    if(aliveLocations.Contains(n)){
                        count++;
                    }
                }
                if(count == 3) newAlive.Add(cell);
            }
            aliveLocations = newAlive;
        }
        
        private static HashSet<Tuple<long,long>> GetNeighbors(Tuple<long,long> i){
            HashSet<Tuple<long,long>> neighbors = new HashSet<Tuple<long,long>>();
            if(i.Item1 > Int64.MinValue){
                neighbors.Add(new Tuple<long,long>( i.Item1-1, i.Item2));
            }
            if(i.Item1 > Int64.MinValue && i.Item2 > Int64.MinValue){
                neighbors.Add(new Tuple<long,long> ( i.Item1-1, i.Item2-1));
            }
            if(i.Item1 > Int64.MinValue && i.Item2 < Int64.MaxValue){
                neighbors.Add(new Tuple<long,long> ( i.Item1-1, i.Item2+1));
            }
            if(i.Item1 < Int64.MaxValue && i.Item2 > Int64.MinValue){
                neighbors.Add(new Tuple<long,long> ( i.Item1+1, i.Item2 - 1));
            }
            if(i.Item1 < Int64.MaxValue && i.Item2 < Int64.MaxValue){
                neighbors.Add(new Tuple<long,long> ( i.Item1+1, i.Item2 + 1));
            }
            if(i.Item1 < Int64.MaxValue){
                neighbors.Add(new Tuple<long,long> ( i.Item1+1, i.Item2));
            }
            if(i.Item2 > Int64.MinValue){
                neighbors.Add(new Tuple<long,long> ( i.Item1, i.Item2-1));
            }
            if(i.Item2 < Int64.MaxValue){
                neighbors.Add(new Tuple<long,long>(i.Item1, i.Item2+1));
            }
            return neighbors;
        }
	}