docker service scale guidtokenapi=0
docker service rm guidtokenapi
docker image rm guidtokenapi-img:1.0.1