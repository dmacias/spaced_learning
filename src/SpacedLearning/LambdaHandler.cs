using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Amazon.Lambda.Core;
using Google.Apis.Auth;
using System.IO;

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
            var path = "/Users/danielm/test.ics";

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
        public string CreateCalendarEvents(IEnumerable<CalendarEventBE> events){
            var er = events.Single();
            var startEnd = er.Date.ToString("yyyyMMddTHHmmssZ");
            var ics = 
$@"BEGIN:VCALENDAR
VERSION:2.0
CALSCALE:GREGORIAN
BEGIN:VEVENT
SUMMARY:Spaced Learning for {startEnd}
DTSTART;TZID=America/Los_Angeles:{startEnd}
DTEND;TZID=America/Los_Angeles:{startEnd}
LOCATION:My Mind
DESCRIPTION:{er.Description}
STATUS:CONFIRMED
SEQUENCE:3
BEGIN:VALARM
TRIGGER:-PT10M
DESCRIPTION:Pickup Reminder
ACTION:DISPLAY
END:VALARM
END:VEVENT
END:VCALENDAR";
            return ics;
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