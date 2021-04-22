$serviceName = "guidtokenapi"
# parse project.json and extract app version
$rootPath = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$projectPath = $rootPath + "\GuidTokenApi\appsettings.json"
$json = Get-Content -Raw -Path $projectPath | ConvertFrom-Json
echo $json
$version = $json.version.Split("-")[0]
echo $version
# tag docker image with app version
$imageName = "$serviceName-img:$version"

echo $imageName
echo $rootPath
echo "$rootPath\GuidTokenApi\dockerfile"
# build image
if(docker images -q $imageName){
   "Image $imageName exists!"
   return 
}else{
   docker build -t $imageName -f "$rootPath\GUIDTokenAPI\Dockerfile" $rootPath
}

# create service
docker service create --publish 5000:80 --name $serviceName --replicas 3 --update-delay 5s $imageName
