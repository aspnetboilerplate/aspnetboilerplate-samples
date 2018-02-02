docker rm $(docker ps -aq)
docker-compose up -d abp_redis
sleep 3
docker-compose up -d abp_host
docker-compose up -d abp_ng
sleep 2
docker-compose scale abp_host=2
sleep 2
docker-compose up -d load_balancer