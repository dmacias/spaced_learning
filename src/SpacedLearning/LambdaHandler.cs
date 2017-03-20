using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Lambda.Core;

[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace SpacedLearning {
    public class LambdaHandler {
        public string Handler(ILambdaContext context){
            var message = "It finally works!";
            context.Logger.Log(message);
            //DeserializeMessage()
            return message;
        }
    }

    public class ConsoleApp{
        public static void Main(string[] args){
            var test = new CalendarEventBE(new DateTime(2016, 03, 18), @"
* a multigraph is a graph which is permitted to have multiple edges (also called parallel edges[1]), that is, edges that have the same end nodes.
* identity element: for all of x in S, f(x, e) AND f(e, x) = x. e in S. 
* left identity if f(e, x) and right identity if f(x, e)
* inverse element: x * y = y * x = e
* multiplicative (*) inverse is y^-1.  additive (+) inverse is -y
* f^-1(f(x)) = x --- f(x) = y IFF f^-1(y) = x
* IFF - 1001 (9), opposite of XOR

Español: catálogo 
            ");
            //TODO: Move to IoC
            var io = new SpacedLearningIO();
            SpacedLearning.FibonocciDateGenerator(test.Date)
                .Take(10)
                .ToList()
                .ForEach(x => 
                    //io.CreateCalendarEvents(new CalendarEventBE(x, test.Description))
                    Console.Out.WriteLine($"{x}")
                );
        }
    }

    public class SpacedLearningIO{
        public void CreateCalendarEvents(IEnumerable<CalendarEventBE> events){
            //TODO: Async all calendar POSTs
            throw new NotImplementedException();
        }
    }

    public class CalendarEventBE
    {
        public readonly DateTime Date;
        public readonly string Description;
        public CalendarEventBE(DateTime date, string description){
            this.Date = date;
            this.Description = description;
        }
    }

    public class SpacedLearning {
        internal static IEnumerable<DateTime> FibonocciDateGenerator(DateTime startDate) {
            var curr = startDate;
            var iter = FibonocciGenerator().Skip(2).GetEnumerator();
            while(iter.MoveNext()){
                curr = curr.AddDays(iter.Current);
                yield return curr;
            }
        }
        //TODO: Go in Math namespace and eventually its own assembly
        internal static IEnumerable<int> FibonocciGenerator() {
            var last = 0;
            var curr = 1;
            int res;
            yield return last; //F(0)
            yield return curr; //F(1)
            while(true){
                res = curr + last;
                yield return res; //F(2...n)
                last = curr;
                curr = res;
            }
        }
    }
}