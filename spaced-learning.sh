chomeTab "https://github.com/aws/aws-lambda-dotnet" \
         "https://github.com/dotnet/core"

dotnet lambda deploy-function -fn lamda-sharp-spaced-learning

dotnet new -n spaced-learning
dotnet clean
#restore any references to dependencies of the project
dotnet restore
#which compiles the application and packages the source code and any dependencies into a folder.

#setup
alias aws="aws --profile danielmacias13"
projDir=/Users/danielm/Projects/spaced-learning
outputDir=$projDir/src/SpacedLearning/bin/Debug/netcoreapp1.0
packageName=lambda-spaced-learning.zip

p $outputDir

dotnet publish
7z a -r -tzip $packageName $outputDir

aws s3 cp "$outputDir/$packageName" "s3://spaced-learning" 
aws lambda update-function-code --function-name spaced-learning --s3-bucket spaced-learning --s3-key lambda-spaced-learning.zip


