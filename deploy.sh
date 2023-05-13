#!.bin/bash
docker stop butramApi
docker rm butramApi
docker build . -f Application/Dockerfile -t butram.api
docker run -p 1112:80 -d --name butramApplication butram.api
