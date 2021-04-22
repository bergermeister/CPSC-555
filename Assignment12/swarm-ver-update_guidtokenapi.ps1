$serviceName = "guidtokenapi"
# parse project.json and extract app version
$rootPath = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$projectPath = $rootPath + "\GuidTokenApi\appsettings.json"
$json = Get-Content -Raw -Path $projectPath | ConvertFrom-Json
$version = $json.version.Split("-")[0]
# tag docker image with app version
$imageName = "$serviceName-img:$version"
echo $imageName
# build image
if(docker images -q $imageName){
 "Image $imageName exists!"
 return 
}else{
 docker build -t $imageName -f "$rootPath\GuidTokenAPI\Dockerfile" $rootPath
}
# apply update
docker service update --image $imageName $serviceName
