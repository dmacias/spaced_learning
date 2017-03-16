[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace SpacedLearning
{
    public class LambdaHandler{
        public string Handler(ILambdaContext context){
            return "blah";
        }
    }
}