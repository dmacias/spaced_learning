using System;
using System.Collections.Generic;
using System.Linq;
using Math;

namespace OnlineOutdegreeProblem
{
    public class Graph {
        public IEnumerable<char> Vertices;
        public ISet<Tuple<char, char>> Edges;
    }

    internal enum Event{ VERTEX_ADD, VERTEX_DELETE, EDGE_MODIFY }

    internal struct EventRecord { public Event Event; public char Root; public Graph Subgraph; }

    internal static class OnlineOutdegreeProblem {
        public static List<Tuple<char,char>> GenerateReport(IEnumerable<EventRecord> eventRecords){ 
            var state = new List<Tuple<char,char>>();
            foreach (var eventRecord in eventRecords){
                state = OnEventRecordProcess(eventRecord, state);
            }
            return state;
        }

        private static List<Tuple<char,char>> OnEventRecordProcess(EventRecord record, List<Tuple<char,char>> report){
            switch(record.Event){
                case Event.VERTEX_ADD:
                break;
                case Event.VERTEX_DELETE:
                break;
                case Event.EDGE_MODIFY:
                break;
                default:
                    throw new Exception($"Non existent {nameof(Event)}: '{record.Event.ToString()}'");
            }

            // alter state here
            return report;
        }
    }

    public class ConsoleApp{
        public static void Main(string[] args){

            //CaptainPlanetProblem
            var state = OnlineOutdegreeProblem.GenerateReport(new List<EventRecord>{ 
                new EventRecord{ 
                    Event = Event.VERTEX_ADD, 
                    Root = 'a', 
                    Subgraph = new Graph { 
                        Vertices = new []{ 'a', 'b', 'c' }, 
                        Edges = new HashSet<Tuple<char,char>> { 
                            Tuple.Create('a', 'b'),
                            Tuple.Create('b', 'c') 
                } } },
            });
            state.ForEach(x => Console.Out.WriteLine($"{x.Item1} -> {x.Item2}"));

            //AlgebraicProperties
            var isInjective = AlgebraicProperties.IsInjective(new []{
                Tuple.Create('x', 'y'),
                Tuple.Create('x', 'y'),
                Tuple.Create('z', 'y'),
            });
            Console.Out.WriteLine($"Is Injective? {isInjective}");
        }
    }
}