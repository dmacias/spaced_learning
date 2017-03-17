using System;
using Amazon.Lambda.Core;

[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace SpacedLearning {
    public class LambdaHandler {
        public string Handler(ILambdaContext context){
            var message = "Ana, te amo!";
            context.Logger.Log(message);
            return message;
        }
    }
}